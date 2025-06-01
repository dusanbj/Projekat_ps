using Common.Domain;
using Microsoft.Data.SqlClient;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Revers : IEntity
    {
        public long Id { get; set; }
        public DateTime Datum { get; set; }
        public Zaposleni Zaposleni { get; set; }
        public Klijent Klijent { get; set; }
        public List<StavkaReversa> Stavke { get; set; }

        public string TableName => "revers";
        public string Values => $"'{Datum.ToString("yyyyMMdd HH:mm")}', {Zaposleni.Id}, {Klijent.Id}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> reversi = new List<IEntity>();
            while (reader.Read())
            {
                reversi.Add(new Revers
                {
                    Id = (long)reader["id"],
                    Datum = (DateTime)reader["datum"],
                    Zaposleni = new Zaposleni { Id = (long)reader["idZaposleni"] },
                    Klijent = new Klijent { Id = (long)reader["idKlijent"] }
                });
            }
            return reversi;
        }

    }
}
