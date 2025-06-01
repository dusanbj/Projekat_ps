using Common.Domain;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
namespace Domen
{
    public class StavkaReversa : IEntity
    {
        public long Rb { get; set; }
        public Revers Revers { get; set; }
        public string Naziv { get; set; }
        public int Kolicina { get; set; }
        public Roba Roba { get; set; }

        public string TableName => "stavkaReversa";

        public string Values => $"{Revers.Id}, {Rb}, '{Naziv}', {Kolicina}, {Roba.Id}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> stavke = new List<IEntity>();
            while (reader.Read())
            {
                stavke.Add(new StavkaReversa
                {
                    Revers = new Revers { Id = (long)reader["idRevers"] },
                    Rb = (int)reader["rb"],
                    Naziv = (string)reader["naziv"],
                    Kolicina = (int)reader["kolicina"],
                    Roba = new Roba { Id = (long)reader["idRoba"] }
                });
            }
            return stavke;
        }


    }
}