
using Common.Domain;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Domen
{
    public class Roba : IEntity
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public string TableName => "roba";
        public string Values => $"'{Naziv}', '{Opis}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> roba = new List<IEntity>();
            while (reader.Read())
            {
                roba.Add(new Roba
                {
                    Id = (long)reader["id"],
                    Naziv = (string)reader["naziv"],
                    Opis = (string)reader["opis"]
                });
            }
            return roba;
        }
    }
}
