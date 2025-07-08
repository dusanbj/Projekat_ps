using Common.Domain;
using Microsoft.Data.SqlClient;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class StrSprema : IEntity
    {
        public long Id { get; set; }
        public string Naziv { get; set; }

        public string TableName => "strSprema";
        public string Values => $"'{Naziv}'";
        public string PrimaryKeyName => "id";
        public string PrimaryKeyValue => Id.ToString();
        public string UpdateValues => $"naziv='{Naziv}'";


        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> spreme = new List<IEntity>();
            while (reader.Read())
            {
                spreme.Add(new StrSprema
                {
                    Id = (long)reader["id"],
                    Naziv = (string)reader["naziv"]
                });
            }
            return spreme;
        }
    }
}
