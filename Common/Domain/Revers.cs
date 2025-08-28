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
        public string Values =>
            $"'{Datum:yyyy-MM-dd HH:mm:ss}', {(Zaposleni?.Id ?? 0)}, {(Klijent?.Id ?? 0)}, {UkupnaCena.ToString(CultureInfo.InvariantCulture)}";

        [JsonIgnore]
        public string UpdateValues =>
            $"datum='{Datum:yyyy-MM-dd HH:mm:ss}', idZaposleni={(Zaposleni?.Id ?? 0)}, idKlijent={(Klijent?.Id ?? 0)}, ukupnaCena={UkupnaCena.ToString(CultureInfo.InvariantCulture)}";

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
            while (reader.Read())
            {
                reversi.Add(new Revers
                {
                    Id = (long)reader["id"],
                    Datum = (DateTime)reader["datum"],
                    Zaposleni = new Zaposleni { Id = (long)reader["idZaposleni"] },
                    Klijent = new Klijent { Id = (long)reader["idKlijent"] },
                    UkupnaCena = (decimal)reader["ukupnaCena"]
                });
            }
            return reversi;
        }
    }
}
