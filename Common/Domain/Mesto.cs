using Common.Domain;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
namespace Domen
{
    public class Mesto : IEntity
    {
        public long Ptt { get; set; }
        public string Naziv { get; set; } 

        public string TableName => "mesto";

        public string Values => $"'{Ptt}', '{Naziv}'";

        public string PrimaryKeyName => "ptt";

        public string PrimaryKeyValue => Ptt.ToString();

        public string UpdateValues => $"naziv='{Naziv}'";

        public override string? ToString()
        {
            return Naziv;
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> mesta = new List<IEntity>();
            while (reader.Read())
            {
                Mesto m = new Mesto
                {
                    Ptt = (long)reader["ptt"],
                    Naziv = (string)reader["naziv"]
                };
                mesta.Add(m);
            }
            return mesta;
        }

        
    }
}