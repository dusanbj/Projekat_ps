using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCDodajStavke : UserControl
    {
        public BindingList<StavkaReversa> Stavke { get; set; }

        private bool _gridConfigured = false;

        public UCDodajStavke()
        {
            InitializeComponent();

            //UC se otvori cim se kreira revers (edituje revers)
            //na UC pise broj reversa koji je upravo kreiran
            //informacije o stavki se upisu u UC
            //na dugme "Sacuvaj" - pokupi se i validira se
            //zapise se u objekat tipa StavkaReversa
            //strpa se u binding listu "Stavke" koja je DataSource za dgvStavke
            //na dugme "Sacuvaj" se za celu listu zove SO Dodavanje stavki 
            //u toj SO foreach i dodaje se jedna po jedna stavka za taj revers
            //commit ako je sve ok, rollback ako nije :) 

            Stavke = new BindingList<StavkaReversa>();
            dgvStavke.AutoGenerateColumns = false;   // bitno
            dgvStavke.DataSource = Stavke;

            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            if (_gridConfigured) return;

            var dgv = dgvStavke;
            dgv.Columns.Clear();

            // Kolicina
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colKolicina",
                HeaderText = "Količina",
                DataPropertyName = "Kolicina",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N2"
                }
            });

            // RobaPrikaz (naziv robe)
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRoba",
                HeaderText = "Roba",
                DataPropertyName = "RobaPrikaz",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            // IznosStavke
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIznos",
                HeaderText = "Iznos",
                DataPropertyName = "IznosStavke",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N2"
                }
            });

            // UX
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true; // izmene idu preko dugmadi, ne direktno u grid

            _gridConfigured = true;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            // Prazno – ReversGuiController već hendluje dodavanje preko event handlera.
        }

        public void BindRobe(BindingList<Roba> robe)
        {
            cmbRoba.DataSource = robe ?? new BindingList<Roba>();
            // Ako u Domen.Roba uradiš override ToString(), može i bez DisplayMember-a
            cmbRoba.DisplayMember = "Naziv";
            cmbRoba.ValueMember = "Id";
        }

        public void SetBrojReversa(long id)
        {
            tbBrojReversa.Text = id.ToString();
            tbBrojReversa.ReadOnly = true;
        }
    }
}
