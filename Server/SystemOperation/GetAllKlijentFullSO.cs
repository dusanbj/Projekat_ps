using Common.Domain;
using Domen;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class GetAllKlijentFullSO : SystemOperationBase
    {

        //moze foreach da prodje kroz klijente i nadje naziv mesta za taj dati ptt
        //malo manje efikasno ali funckionise


        public List<Klijent> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            List<Mesto> mesta = broker.GetAll(new Mesto()).Cast<Mesto>().ToList();
            Result = broker.GetAll(new Klijent()).Cast<Klijent>().ToList();
            foreach (var klijent in Result)
            {
                foreach (var mesto in mesta)
                {
                    if (klijent.Mesto.Ptt == mesto.Ptt)
                    {
                        klijent.Mesto.Naziv = mesto.Naziv;
                    }
                }
            }
        }
    }
}
