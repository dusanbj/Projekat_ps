using Domen;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class GetReversSO : SystemOperationBase
    {
        private readonly string _filter;
        public List<Revers> Result { get; private set; }

        public GetReversSO(string filter)
        {
            _filter = filter;
        }

        protected override void ExecuteConcreteOperation()
        {
            // Bez filtera -> vrati sve
            if (string.IsNullOrWhiteSpace(_filter))
            {
                Result = broker.GetByCondition(new Revers(), null)
                               .Cast<Revers>()
                               .ToList();
                return;
            }

            // Normalizuj i escape-uj
            var f = _filter.Trim().Replace("'", "''");

            var conditions = new List<string>();

            // Ako je broj -> traži po id-jevima: reversa, klijenta i ZAPOSLENOG
            if (long.TryParse(_filter.Trim(), out long idVal))
            {
                conditions.Add($"id = {idVal}");            // id reversa
                conditions.Add($"idKlijent = {idVal}");     // id klijenta
                conditions.Add($"idZaposleni = {idVal}");   // id zaposlenog
            }

            // Zaposleni: ime / prezime / "ime prezime"
            conditions.Add(
                "idZaposleni IN (" +
                "  SELECT id FROM zaposleni " +
                $" WHERE LOWER(ime) LIKE LOWER('%{f}%')" +
                $"    OR LOWER(prezime) LIKE LOWER('%{f}%')" +
                $"    OR LOWER((COALESCE(ime,'') + ' ' + COALESCE(prezime,''))) LIKE LOWER('%{f}%')" +
                ")"
            );

            // Klijent: ime / prezime / "ime prezime"
            conditions.Add(
                "idKlijent IN (" +
                "  SELECT id FROM klijent " +
                $" WHERE LOWER(ime) LIKE LOWER('%{f}%')" +
                $"    OR LOWER(prezime) LIKE LOWER('%{f}%')" +
                $"    OR LOWER((COALESCE(ime,'') + ' ' + COALESCE(prezime,''))) LIKE LOWER('%{f}%')" +
                ")"
            );

            var where = string.Join(" OR ", conditions);

            Result = broker.GetByCondition(new Revers(), where)
                           .Cast<Revers>()
                           .ToList();
        }
    }
}
