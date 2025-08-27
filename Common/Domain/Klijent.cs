using Common;
using Common.Domain;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domen
{
    public class Klijent : IEntity
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrTelefona { get; set; }
        public Mesto Mesto { get; set; }

        [JsonIgnore]
        public string TableName => "klijent";

        public override string ToString() => $"{Id} - {Prezime}, {Ime}";

        [JsonIgnore]
        public string Values => $"'{Ime}', '{Prezime}', '{BrTelefona}', {(Mesto?.Ptt ?? 0)}";

        [JsonIgnore]
        public string PrimaryKeyName => "id";

        [JsonIgnore]
        public string PrimaryKeyValue => Id.ToString();

        [JsonIgnore]
        public string UpdateValues => $"ime='{Ime}', prezime='{Prezime}', brTelefona='{BrTelefona}', ptt={(Mesto?.Ptt ?? 0)}";

        [JsonIgnore]
        public string MestoPrikaz =>
    Mesto == null
        ? ""
        : (string.IsNullOrWhiteSpace(Mesto.Naziv)
            ? Mesto.Ptt.ToString()
            : $"{Mesto.Naziv} ({Mesto.Ptt})");

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            var klijenti = new List<IEntity>();
            while (reader.Read())
            {
                var k = new Klijent
                {
                    Id = (long)reader["id"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    BrTelefona = reader["brTelefona"] as string,
                    Mesto = new Mesto
                    {
                        Ptt = (long)reader["ptt"],
                    }
                };
                klijenti.Add(k);
            }
            return klijenti;
        }
    }
}
