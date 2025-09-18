using Domen;
using System;
using System.Linq;
using System.Collections.Generic;

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

        // 1) kreiranje BLANKO reversa (datum = 01.01.2000; FK-ovi NULL preko Revers.Values)
        // 2) popunjavanje klijent, zaposleni, datum i UPDATE headera
        // 3) ako ima stavki -> pozvati UpdateReversSO da ih upiše i preračuna total

        protected override void ExecuteConcreteOperation()
        {
            // (1) BLANKO insert: obavezno staviti validan datum, ne default(DateTime)
            var blanko = new Revers
            {
                Datum = new DateTime(2000, 1, 1),
                Zaposleni = null,     // očekujem da Revers.Values upiše NULL, ne 0
                Klijent = null,     // isto i ovde
                UkupnaCena = 0m
            };
            broker.Add(blanko);

            // (2) Dohvati poslednje ubacen header (koristimo ORDER BY da izbegnemo full-scan preko LINQ)
            var kandidat = broker.GetByCondition(new Revers(), "1=1 ORDER BY id DESC")
                                 .Cast<Revers>()
                                 .FirstOrDefault()
                           ?? new Revers { Stavke = new List<StavkaReversa>() };

            // Ako iz nekog razloga nisam našao, nema smisla nastavljati dalje
            if (kandidat.Id <= 0)
            {
                Result = kandidat;
                return;
            }

            // Validacije za header (kao što si zahtevao)
            if (input == null) throw new System.Exception("Revers nije prosleđen.");
            if (input.Klijent == null || input.Klijent.Id <= 0) throw new System.Exception("Klijent je obavezan.");
            if (input.Zaposleni == null || input.Zaposleni.Id <= 0) throw new System.Exception("Zaposleni je obavezan.");
            if (input.Datum == default) throw new System.Exception("Datum je obavezan.");

            // (3) Popuni header i upiši
            kandidat.Datum = input.Datum;
            kandidat.Klijent = input.Klijent;
            kandidat.Zaposleni = input.Zaposleni;
            kandidat.UkupnaCena = 0m;
            broker.Update(kandidat);

            // (4) Ako ima stavki, guramo ih preko UpdateReversSO; inače vraćamo samo header
            if (input.Stavke != null && input.Stavke.Count > 0)
            {
                var soUpdate = new UpdateReversSO(new Revers
                {
                    Id = kandidat.Id,
                    Datum = kandidat.Datum,
                    Klijent = kandidat.Klijent,
                    Zaposleni = kandidat.Zaposleni,
                    Stavke = input.Stavke
                });
                soUpdate.ExecuteTemplate();
                Result = soUpdate.Result;
                return;
            }

            // Nema stavki – vrati header kako je upisan
            Result = kandidat;
        }
    }
}
