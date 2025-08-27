using Domen;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class GetKlijentSO : SystemOperationBase
    {
        private readonly string _filter;
        public List<Klijent> Result { get; private set; }

        public GetKlijentSO(string filter)
        {
            _filter = filter;
        }

        protected override void ExecuteConcreteOperation()
        {
            // Ako nema filtera -> vrati sve
            if (string.IsNullOrWhiteSpace(_filter))
            {
                Result = broker.GetByCondition(new Klijent(), null)
                               .Cast<Klijent>()
                               .ToList();
                return;
            }

            // Normalizacija i escape za navodnike
            var f = _filter.Trim().Replace("'", "''");

            // Sastavi WHERE: ime/prezime/telefon preko LIKE (case-insensitive)
            var conditions = new List<string>
            {
                $"LOWER(ime) LIKE LOWER('%{f}%')",
                $"LOWER(prezime) LIKE LOWER('%{f}%')",
                $"LOWER(brTelefona) LIKE LOWER('%{f}%')"
            };

            // Ako je ceo broj, dodaj i tačno poređenje po ID-u
            if (long.TryParse(_filter.Trim(), out long idVal))
            {
                conditions.Add($"id = {idVal}");
            }

            var where = string.Join(" OR ", conditions);

            Result = broker.GetByCondition(new Klijent(), where)
                           .Cast<Klijent>()
                           .ToList();
        }
    }
}

