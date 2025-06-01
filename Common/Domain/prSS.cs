using Common.Domain;
using Microsoft.Data.SqlClient;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class prSS : IEntity
    {
        public Zaposleni Zaposleni { get; set; }
        public StrSprema StrSprema { get; set; }
        public string Opis { get; set; }

        public string TableName => "prSS";
        public string Values => $"{Zaposleni.Id}, {StrSprema.Id}, '{Opis}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> prSSLista = new List<IEntity>();
            while (reader.Read())
            {
                prSSLista.Add(new prSS
                {
                    Zaposleni = new Zaposleni { Id = (long)reader["idZaposleni"] },
                    StrSprema = new StrSprema { Id = (long)reader["idStrucnaSprema"] },
                    Opis = (string)reader["opis"]
                });
            }
            return prSSLista;
        }
    }
}
