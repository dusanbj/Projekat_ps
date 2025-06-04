using Common.Domain;
using Domen;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Server.SystemOperation
{
    public class GetAllKlijentFullSO : SystemOperationBase
    {

        //moze foreach da prodje kroz klijente i nadje naziv mesta za taj dati ptt
        //malo manje efikasno ali funckionise


        //public List<Klijent> Result { get; private set; }

        //protected override void ExecuteConcreteOperation()
        //{
        //    SqlCommand cmd = broker.CreateCommand();
        //    cmd.CommandText = @"
        //        SELECT k.id, k.ime, k.prezime, k.brTelefona, k.ptt, m.naziv 
        //        FROM klijent k 
        //        JOIN mesto m ON k.ptt = m.ptt";

        //    SqlDataReader reader = cmd.ExecuteReader();
        //    Result = new List<Klijent>();

        //    while (reader.Read())
        //    {
        //        var klijent = new Klijent
        //        {
        //            Id = (long)reader["id"],
        //            Ime = (string)reader["ime"],
        //            Prezime = (string)reader["prezime"],
        //            BrTelefona = (string)reader["brTelefona"],
        //            Mesto = new Mesto
        //            {
        //                Ptt = (long)reader["ptt"],
        //                Naziv = (string)reader["naziv"]
        //            }
        //        };

        //        Result.Add(klijent);
        //    }

        //    reader.Close();
        //    cmd.Dispose();
        //}
        protected override void ExecuteConcreteOperation()
        {
            throw new NotImplementedException();
        }
    }
}
