using Domen;
using System.Linq;

namespace Server.SystemOperation
{
    public class CreateReversSO : SystemOperationBase
    {
        private readonly Revers input;
        public Revers Result { get; private set; }

        public CreateReversSO(Revers revers)
        {
            this.input = revers;
        }

        protected override void ExecuteConcreteOperation()
        {
            // Validacija
            if (input == null)
                throw new System.Exception("Revers nije prosleđen.");
            if (input.Klijent == null || input.Klijent.Id <= 0)
                throw new System.Exception("Klijent je obavezan.");
            if (input.Zaposleni == null || input.Zaposleni.Id <= 0)
                throw new System.Exception("Zaposleni je obavezan.");
            if (input.Datum == default)
                throw new System.Exception("Datum je obavezan.");

            // 1) Upis header-a (bez stavki, bez ukupne cene)
            var header = new Revers
            {
                Datum = input.Datum,
                Klijent = input.Klijent,
                Zaposleni = input.Zaposleni,
                UkupnaCena = 0m
            };
            broker.Add(header);

            // 2) Preuzmi kreirani red da dođeš do ID-a
            //    (WHERE + ORDER BY ID DESC — uzmemo prvi)
            var cond = $"idZaposleni = {input.Zaposleni.Id} AND idKlijent = {input.Klijent.Id} AND datum = '{input.Datum:yyyyMMdd HH:mm}' ORDER BY id DESC";
            var kandidat = broker.GetByCondition(new Revers(), cond)
                                 .Cast<Revers>()
                                 .FirstOrDefault();
            if (kandidat == null)
            {
                kandidat = broker.GetAll(new Revers()).Cast<Revers>()
                                 .OrderByDescending(r => r.Id)
                                 .FirstOrDefault()
                           ?? throw new System.Exception("Kreirani revers nije pronađen.");
            }

            // 3) Ako stižu stavke odmah — upiši i izračunaj total
            decimal total = 0m;
            long rb = 1;
            if (input.Stavke != null && input.Stavke.Count > 0)
            {
                foreach (var s in input.Stavke)
                {
                    var cena = s.Roba?.Cena ?? 0m;
                    var iznos = System.Math.Round(cena * s.Kolicina, 2);

                    var row = new StavkaReversa
                    {
                        Revers = kandidat,
                        Rb = rb++,
                        Roba = s.Roba,
                        Kolicina = s.Kolicina,
                        IznosStavke = iznos
                    };
                    broker.Add(row);
                    total += iznos;
                }

                kandidat.UkupnaCena = total;
                broker.Update(kandidat);
            }

            Result = kandidat;
        }
    }
}
