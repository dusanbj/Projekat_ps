using Common.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Domen
{
    public class StavkaReversa : IEntity
    {
        public long Rb { get; set; }

        private Revers _revers;

        [JsonIgnore]
        public Revers Revers
        {
            get => _revers;
            set
            {
                _revers = value;
                if (value != null && value.Id > 0) IdRevers = value.Id;
            }
        }

        public long IdRevers { get; set; }
        public decimal Kolicina { get; set; }
        public Roba Roba { get; set; }
        public decimal IznosStavke { get; set; }

        // NOVO: za prikaz u gridu (nije za bazu/JSON)
        [JsonIgnore]
        public string RobaPrikaz => Roba == null ? "" : Roba.Naziv;

        [JsonIgnore] public string TableName => "stavkaReversa";
        [JsonIgnore] public string InsertColumns => "idRevers, rb, kolicina, idRoba, iznosStavke";

        [JsonIgnore]
        public string Values =>
            $"{IdRevers}, {Rb}, {Kolicina.ToString(CultureInfo.InvariantCulture)}, {(Roba?.Id ?? 0)}, {IznosStavke.ToString(CultureInfo.InvariantCulture)}";

        [JsonIgnore] public string PrimaryKeyName => "idRevers, rb";
        [JsonIgnore] public string PrimaryKeyValue => $"{IdRevers}, {Rb}";

        [JsonIgnore]
        public string UpdateValues =>
            $"kolicina={Kolicina.ToString(CultureInfo.InvariantCulture)}, idRoba={(Roba?.Id ?? 0)}, iznosStavke={IznosStavke.ToString(CultureInfo.InvariantCulture)}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var stavke = new List<IEntity>();
            while (reader.Read())
            {
                var idRevers = Convert.ToInt64(reader["idRevers"]);
                var rb = Convert.ToInt64(reader["rb"]);
                var kolicina = Convert.ToDecimal(reader["kolicina"], CultureInfo.InvariantCulture);
                var idRoba = Convert.ToInt64(reader["idRoba"]);
                var iznos = Convert.ToDecimal(reader["iznosStavke"], CultureInfo.InvariantCulture);

                stavke.Add(new StavkaReversa
                {
                    IdRevers = idRevers,
                    Revers = new Revers { Id = idRevers },
                    Rb = rb,
                    Kolicina = kolicina,
                    Roba = new Roba { Id = idRoba },
                    IznosStavke = iznos
                });
            }
            return stavke;
        }
    }
}