using Domen;
using System.Linq;

namespace Server.SystemOperation
{
    public class UpdateReversSO : SystemOperationBase
    {
        private readonly Revers input;
        public Revers Result { get; private set; }

        public UpdateReversSO(Revers revers)
        {
            input = revers;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (input == null) throw new System.Exception("Revers nije prosleđen.");
            if (input.Id <= 0) throw new System.Exception("Nevalidan Revers.Id.");
            if (input.Klijent == null || input.Klijent.Id <= 0) throw new System.Exception("Klijent je obavezan.");
            if (input.Zaposleni == null || input.Zaposleni.Id <= 0) throw new System.Exception("Zaposleni je obavezan.");
            if (input.Stavke == null || input.Stavke.Count == 0) throw new System.Exception("Revers mora sadržati bar jednu stavku.");

            var header = new Revers
            {
                Id = input.Id,
                Datum = input.Datum,
                Klijent = input.Klijent,
                Zaposleni = input.Zaposleni,
                UkupnaCena = 0m
            };
            broker.Update(header);

            var postojece = broker.GetByCondition(new StavkaReversa(), $"idRevers = {input.Id}")
                                  .Cast<StavkaReversa>()
                                  .ToList();
            foreach (var old in postojece)
                broker.Delete(old);

            decimal total = 0m;
            long rb = 1;

            foreach (var s in input.Stavke)
            {
                var cena = s.Roba?.Cena ?? 0m;
                var iznos = System.Math.Round(cena * s.Kolicina, 2);

                var row = new StavkaReversa
                {
                    IdRevers = header.Id,
                    Revers = header,
                    Rb = rb++,
                    Roba = s.Roba,
                    Kolicina = s.Kolicina,
                    IznosStavke = iznos
                };
                broker.Add(row);
                total += iznos;
            }

            header.UkupnaCena = total;
            broker.Update(header);

            Result = header;
        }
    }
}
