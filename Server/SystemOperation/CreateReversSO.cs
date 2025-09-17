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
            input = revers;
        }

        //1. kreiranje blanko reversa
        //2. popunjavanje klijent, zaposleni, datum i uradim update
        //3. u UpdateReversSO dodati stavke reversa

        protected override void ExecuteConcreteOperation()
        {
            if (input == null) throw new System.Exception("Revers nije prosleđen.");
            if (input.Klijent == null || input.Klijent.Id <= 0) throw new System.Exception("Klijent je obavezan.");
            if (input.Zaposleni == null || input.Zaposleni.Id <= 0) throw new System.Exception("Zaposleni je obavezan.");
            if (input.Datum == default) throw new System.Exception("Datum je obavezan.");

            var header = new Revers
            {
                Datum = input.Datum,
                Klijent = input.Klijent,
                Zaposleni = input.Zaposleni,
                UkupnaCena = 0m
            };
            broker.Add(header);

            // najrobustnije sa postojećim brokerom: uzmi poslednji ID
            var kandidat = broker.GetAll(new Revers())
                                 .Cast<Revers>()
                                 .OrderByDescending(r => r.Id)
                                 .FirstOrDefault()
                           ?? throw new System.Exception("Kreirani revers nije pronađen.");

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
                        IdRevers = kandidat.Id,
                        Revers = kandidat,   // ok je, [JsonIgnore] je na navigaciji
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
