using Domen;
using System.Linq;

namespace Server.SystemOperation
{
    public class UpdateKlijentSO : SystemOperationBase
    {
        private readonly Klijent p;

        public UpdateKlijentSO(Klijent p)
        {
            this.p = p;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (p == null) throw new System.Exception("Klijent nije prosleđen.");
            if (p.Id <= 0) throw new System.Exception("Nevalidan Klijent.Id.");

            // Validacija minimalna
            var ime = (p.Ime ?? string.Empty).Trim();
            var prezime = (p.Prezime ?? string.Empty).Trim();
            var tel = (p.BrTelefona ?? string.Empty).Trim();

            if (ime.Length == 0) throw new System.Exception("Ime ne sme biti prazno.");
            if (prezime.Length == 0) throw new System.Exception("Prezime ne sme biti prazno.");
            if (tel.Length == 0) throw new System.Exception("Broj telefona ne sme biti prazan.");
            if (p.Mesto == null || p.Mesto.Ptt <= 0) throw new System.Exception("Mesto je obavezno.");

            // SQL safe stringovi
            var sIme = ime.Replace("'", "''");
            var sPrezime = prezime.Replace("'", "''");
            var sTel = tel.Replace("'", "''");

            // Duplikat: isto ime + prezime (case-insensitive) + isti telefon (normalizovan),
            // ali isključujemo TEKUĆI zapis (id <> p.Id)
            var uslov =
                $"LOWER(ime) = LOWER('{sIme}') AND " +
                $"LOWER(prezime) = LOWER('{sPrezime}') AND " +
                $"REPLACE(REPLACE(brTelefona,' ',''),'-','') = REPLACE(REPLACE('{sTel}',' ',''),'-','') AND " +
                $"id <> {p.Id}";

            var postoji = broker.GetByCondition(new Klijent(), uslov)
                                .Cast<Klijent>()
                                .Any();

            if (postoji)
                throw new System.Exception("Klijent sa istim imenom, prezimenom i brojem telefona već postoji.");

            broker.Update(p);
        }
    }
}
