using Client.UserControls;
using Common.Communication;
using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class ReversGuiController
    {
        private UCDodajRevers dodajRevers;
        private UCDodajStavke dodajStavke;
        private Form forma;
        private Revers revers;

        internal Control CreateDodajRevers()
        {
            dodajRevers = new UCDodajRevers();

            // 1) Kontroler preuzima učitavanje (binduje podatke u view)
            dodajRevers.ViewLoaded += OnViewLoaded;

            // 2) Flow kreiranja reversta
            dodajRevers.btnDodaj.Click += AddRevers;

            return dodajRevers;
        }

        private void OnViewLoaded(object sender, EventArgs e)
        {
            try
            {
                var lista = (List<Klijent>)Communication.Instance.GetAllKlijent();
                var binding = new BindingList<Klijent>(lista ?? new List<Klijent>());

                // “Ubrizgaj” podatke u view
                dodajRevers.BindKlijenti(binding);
                dodajRevers.SetDatum(DateTime.Today);
                dodajRevers.SetZaposleni(LoginGuiController.Instance.Z);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju klijenata: " + ex.Message);
            }
        }

        private void AddRevers(object sender, EventArgs e)
        {
            var izabrani = dodajRevers.cmbKlijent.SelectedItem as Klijent;
            if (izabrani == null)
            {
                MessageBox.Show("Morate izabrati klijenta!");
                return;
            }

            revers = new Revers
            {
                Datum = dodajRevers.danas,
                Zaposleni = LoginGuiController.Instance.Z,
                Klijent = izabrani,
                Stavke = null
            };

            Response response = Communication.Instance.CreateRevers(revers);
            if (response.ExceptionMessage == null)
            {
                // preuzmi kreirani revers sa ID-em iz response-a (prilagodi po tvojoj Response klasi)
                if (response.Result is Revers r) revers = r;

                MessageBox.Show("Uspešno kreiran revers! Dodajte stavke.");

                // otvori FrmStavke i zadrži reference
                var frmStavke = new FrmStavke();
                forma = frmStavke;
                dodajStavke = frmStavke.uc;

                // upiši broj reversa (Id) u UC
                dodajStavke.SetBrojReversa(revers.Id);

                // napuni cmbRoba iz servisa kroz UC API
                var robe = Communication.Instance.GetRoba(null); // null => sve
                dodajStavke.BindRobe(new BindingList<Roba>(robe ?? new List<Roba>()));

                // handleri za dodavanje i čuvanje (pazi da se ne dupliraju ako ponovo otvaraš)
                dodajStavke.btnDodaj.Click -= AddStavke;
                dodajStavke.btnSacuvaj.Click -= SacuvajStavke;
                dodajStavke.btnDodaj.Click += AddStavke;
                dodajStavke.btnSacuvaj.Click += SacuvajStavke;

                frmStavke.ShowDialog();
            }
            else
            {
                Debug.WriteLine(response.ExceptionMessage);
                MessageBox.Show("Greška: " + response.ExceptionMessage);
            }
        }

        private void AddStavke(object sender, EventArgs e)
        {
            if (dodajStavke.cmbRoba.SelectedItem == null ||
                !decimal.TryParse(dodajStavke.tbKolicina.Text, out decimal kolicina) || kolicina <= 0)
            {
                MessageBox.Show("Unesite validnu robu i količinu!");
                return;
            }

            var roba = (Roba)dodajStavke.cmbRoba.SelectedItem;

            var stavka = new StavkaReversa
            {
                // Rb možeš da postaviš i ovde ako želiš prikaz rednog broja:
                // Rb = (dodajStavke.Stavke?.Count ?? 0) + 1,
                Roba = roba,
                Kolicina = kolicina,
                IznosStavke = kolicina * (roba?.Cena ?? 0m)
                // NE postavljamo Revers — [JsonIgnore] će ionako preseći ciklus,
                // ali nam na klijentu back-ref nije potreban.
            };

            // UC već ima BindingList i dgvStavke je vezan — dodavanje auto-osvežava grid
            dodajStavke.Stavke.Add(stavka);

            // UX sitnica
            dodajStavke.tbKolicina.Clear();
            dodajStavke.cmbRoba.Focus();
        }

        //FrmClosing event da proverim da li su stavke null ili count=0 i da obrisem revers

        private void SacuvajStavke(object sender, EventArgs e)
        {
            if (dodajStavke.Stavke == null || dodajStavke.Stavke.Count == 0)
            {
                MessageBox.Show("Revers mora sadržati barem jednu stavku!");
                // Opcioni rollback header-a:
                try { Communication.Instance.DeleteRevers(revers); }
                catch (Exception ex) { MessageBox.Show("Rollback greška: " + ex.Message); }
                return;
            }

            // Ako ipak negde ostane back-ref, [JsonIgnore] ga neće serijalizovati.
            // Dovoljno je samo spakovati listu.
            revers.Stavke = dodajStavke.Stavke.ToList();

            Response response = Communication.Instance.UpdateRevers(revers);
            if (response.ExceptionMessage == null)
            {
                MessageBox.Show("Revers i stavke su uspešno sačuvani!");
                forma?.Close();
                forma?.Dispose();
            }
            else
            {
                MessageBox.Show("Greška prilikom čuvanja: " + response.ExceptionMessage);
            }
        }
    }
}
