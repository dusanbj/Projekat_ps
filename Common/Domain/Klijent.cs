using Common;
using Common.Domain;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
namespace Domen
{
    public class Klijent : IEntity
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrTelefona { get; set; }
        public Mesto Mesto { get; set; }

        public string TableName => "klijent";

        public override string ToString()
        {
            return $"{Id} - {Prezime}, {Ime}";
        }

        public string Values => $"'{Ime}', '{Prezime}', '{BrTelefona}', {Mesto.Ptt}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> klijenti = new List<IEntity>();
            while (reader.Read())
            {
                Klijent k = new Klijent
                {
                    Id = (long)reader["id"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    BrTelefona = (string)reader["brTelefona"],
                    Mesto = new Mesto
                    {
                        Ptt = (long)reader["ptt"],
                        //Naziv = (string)reader["naziv"] 
                    }
                };
                klijenti.Add(k);
            }
            return klijenti;
        }
    }
}