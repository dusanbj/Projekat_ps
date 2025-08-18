using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public enum Operation
    {
        //logovanje
        Login,
        Logout,
        //klijenti
        CreateKlijent,
        UpdateKlijent,
        DeleteKlijent,
        GetAllKlijent,
        GetKlijent,
        //zaposleni
        CreateZaposleni,
        UpdateZaposleni,
        DeleteZaposleni,
        GetZaposleni,
        //reversi
        CreateRevers,
        UpdateRevers,
        DeleteRevers,
        GetRevers,
        GetAllRevers,
        //Roba
        CreateRoba,
        UpdateRoba,
        DeleteRoba,
        GetRoba,
        //Mesto
        CreateMesto,
        UpdateMesto,
        DeleteMesto,
        GetMesto,
        GetAllMesto,
        //strucna sprema
        AddStrSprema,
        UpdateStrSprema,
        DeleteStrSprema,
        GetStrSprema
    }
}
