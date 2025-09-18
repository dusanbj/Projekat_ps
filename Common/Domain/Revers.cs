using Common.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Domen
{
    public class Revers : IEntity
    {
        public long Id { get; set; }
        public DateTime Datum { get; set; }
        public Zaposleni Zaposleni { get; set; }
        public Klijent Klijent { get; set; }
        public List<StavkaReversa> Stavke { get; set; }
        public decimal UkupnaCena { get; set; }

        [JsonIgnore] public string TableName => "revers";

        [JsonIgnore] public string PrimaryKeyName => "id";
        [JsonIgnore] public string PrimaryKeyValue => Id.ToString(CultureInfo.InvariantCulture);

        [JsonIgnore] public string InsertColumns => "datum, idZaposleni, idKlijent, ukupnaCena";

        [JsonIgnore]
        public string Values
        {
            get
            {
                // ako nema zaposlenog/klijenta -> NULL (umesto 0)
                var idZap = (Zaposleni != null && Zaposleni.Id > 0)
                    ? Zaposleni.Id.ToString(CultureInfo.InvariantCulture)
                    : "NULL";

                var idKli = (Klijent != null && Klijent.Id > 0)
                    ? Klijent.Id.ToString(CultureInfo.InvariantCulture)
                    : "NULL";

                return $"'{Datum:yyyy-MM-dd HH:mm:ss}', {idZap}, {idKli}, {UkupnaCena.ToString(CultureInfo.InvariantCulture)}";
            }
        }

        [JsonIgnore]
        public string UpdateValues
        {
            get
            {
                var idZap = (Zaposleni != null && Zaposleni.Id > 0)
                    ? Zaposleni.Id.ToString(CultureInfo.InvariantCulture)
                    : "NULL";

                var idKli = (Klijent != null && Klijent.Id > 0)
                    ? Klijent.Id.ToString(CultureInfo.InvariantCulture)
                    : "NULL";

                return $"datum='{Datum:yyyy-MM-dd HH:mm:ss}', idZaposleni={idZap}, idKlijent={idKli}, ukupnaCena={UkupnaCena.ToString(CultureInfo.InvariantCulture)}";
            }
        }

        [JsonIgnore]
        public string ZaposleniPrikaz
    => Zaposleni == null ? "" :
       $"{(Zaposleni.Ime ?? "").Trim()} {(Zaposleni.Prezime ?? "").Trim()}".Trim();

        [JsonIgnore]
        public string KlijentPrikaz
            => Klijent == null ? "" :
               $"{(Klijent.Ime ?? "").Trim()} {(Klijent.Prezime ?? "").Trim()}".Trim();

        [JsonIgnore]
        public long KlijentIdPrikaz => Klijent?.Id ?? 0;

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var reversi = new List<IEntity>();

            // Uzmemo ordinale jednom (brže i jasnije)
            int ordId = reader.GetOrdinal("id");
            int ordDatum = reader.GetOrdinal("datum");
            int ordZap = reader.GetOrdinal("idZaposleni");
            int ordKli = reader.GetOrdinal("idKlijent");
            int ordTotal = reader.GetOrdinal("ukupnaCena");

            while (reader.Read())
            {
                // id moze biti INT ili BIGINT => Convert.ToInt64 je najbezbednije
                long id = Convert.ToInt64(reader.GetValue(ordId));

                // datum moze biti NULL u teoriji => fallback na 2000-01-01 (ili stavi DateTime.Today po želji)
                DateTime datum = reader.IsDBNull(ordDatum) ? new DateTime(2000, 1, 1) : reader.GetDateTime(ordDatum);

                // FK-ovi: ako su NULL => nema Zaposleni/Klijent objekta
                long? zapId = reader.IsDBNull(ordZap) ? (long?)null : Convert.ToInt64(reader.GetValue(ordZap));
                long? kliId = reader.IsDBNull(ordKli) ? (long?)null : Convert.ToInt64(reader.GetValue(ordKli));

                decimal ukupno = reader.IsDBNull(ordTotal) ? 0m : reader.GetDecimal(ordTotal);

                reversi.Add(new Revers
                {
                    Id = id,
                    Datum = datum,
                    Zaposleni = zapId.HasValue ? new Zaposleni { Id = zapId.Value } : null,
                    Klijent = kliId.HasValue ? new Klijent { Id = kliId.Value } : null,
                    UkupnaCena = ukupno
                });
            }

            return reversi;
        }

    }
}
