using Common.Domain;
using Microsoft.Data.SqlClient;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Zaposleni : IEntity
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrTelefona { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public string TableName => "zaposleni";
        public string Values => $"'{Ime}', '{Prezime}', '{BrTelefona}', '{Username}', '{Password}'";
        public override string ToString() => $"{Id} - {Prezime}, {Ime}";

        public string PrimaryKeyName => "id";

        public string PrimaryKeyValue => Id.ToString();

        public string UpdateValues => $"ime='{Ime}', prezime='{Prezime}', brTelefona='{BrTelefona}', username='{Username}', password='{Password}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> zaposleni = new List<IEntity>();
            while (reader.Read())
            {
                zaposleni.Add(new Zaposleni
                {
                    Id = (long)reader["id"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    BrTelefona = (string)reader["brTelefona"],
                    Username = (string)reader["username"],
                    Password = (string)reader["password"]
                });
            }
            return zaposleni;
        }

        
    }
}
