using Domen;
using System;
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
            // 1) Pripremi WHERE uslov za pretragu reversa na osnovu filtera
            string where = BuildWhereForRevers(_filter);

            // 2) Izvuci sve revers(e) po uslovu
            var reversi = broker.GetByCondition(new Revers(), where)
                                .Cast<Revers>()
                                .ToList();

            if (reversi.Count == 0)
            {
                // Nema pogodaka -> vrati praznu listu
                Result = new List<Revers>();
                return;
            }

            // 3) Skupljam sve id-jeve reversa da bi jednim upitom povukao sve stavke
            var ids = reversi.Select(r => r.Id).Distinct().ToList();

            // Guard: ako nema validnih id-jeva, vrati revers(e) ali sa praznim stavkama
            ids = ids.Where(id => id > 0).ToList();
            if (ids.Count == 0)
            {
                foreach (var r in reversi) r.Stavke = new List<StavkaReversa>();
                Result = reversi;
                return;
            }

            // 4) Dohvatam sve stavke za te revers(e) (IN klauzula umesto N+1 upita)
            var inClause = string.Join(",", ids);
            var stavkeWhere = $"idRevers IN ({inClause})";

            var sveStavke = broker.GetByCondition(new StavkaReversa(), stavkeWhere)
                                  .Cast<StavkaReversa>()
                                  .ToList();

            // 5) Grupisanje stavki po idRevers i uparivanje sa svojim reversom
            var map = sveStavke.GroupBy(s => s.IdRevers)
                               .ToDictionary(g => g.Key, g => g.ToList());

            foreach (var r in reversi)
            {
                if (!map.TryGetValue(r.Id, out var list))
                    list = new List<StavkaReversa>();

                r.Stavke = list;
            }

            // 6) Rezultat je lista reversa, gde svaki već ima svoje stavke
            Result = reversi;
        }

        /// <summary>
        /// Pomoćna metoda koja sklapa WHERE klauzulu za pretragu reversa.
        /// </summary>
        private static string BuildWhereForRevers(string filter)
        {
            // Ako filter nije prosleđen -> nema WHERE (vrati sve)
            if (string.IsNullOrWhiteSpace(filter)) return null;

            var f = filter.Trim();
            var fEsc = f.Replace("'", "''"); // escape apostrofa

            var conditions = new List<string>();

            // Ako je filter broj -> proveri id reversa, id klijenta i id zaposlenog
            if (long.TryParse(f, out long idVal))
            {
                conditions.Add($"id = {idVal}");
                conditions.Add($"idKlijent = {idVal}");
                conditions.Add($"idZaposleni = {idVal}");
            }

            // Pretraga zaposlenog po imenu, prezimenu ili "ime prezime"
            conditions.Add(
                "idZaposleni IN (" +
                "  SELECT id FROM zaposleni " +
                $" WHERE LOWER(ime) LIKE LOWER('%{fEsc}%')" +
                $"    OR LOWER(prezime) LIKE LOWER('%{fEsc}%')" +
                $"    OR LOWER((COALESCE(ime,'') + ' ' + COALESCE(prezime,''))) LIKE LOWER('%{fEsc}%')" +
                ")"
            );

            // Pretraga klijenta po imenu, prezimenu ili "ime prezime"
            conditions.Add(
                "idKlijent IN (" +
                "  SELECT id FROM klijent " +
                $" WHERE LOWER(ime) LIKE LOWER('%{fEsc}%')" +
                $"    OR LOWER(prezime) LIKE LOWER('%{fEsc}%')" +
                $"    OR LOWER((COALESCE(ime,'') + ' ' + COALESCE(prezime,''))) LIKE LOWER('%{fEsc}%')" +
                ")"
            );

            return string.Join(" OR ", conditions);
        }
    }
}
