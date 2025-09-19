using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.Domain
{
    static class converter
    {
        static public CuadreCierre.Domain.Models.MedioPago 
            MedioPago(_Domain.Models.MedioPago mp) 
        {
            return new CuadreCierre.Domain.Models.MedioPago()
            {
                aplicaBonoPagoDivisa = mp.aplicaBonoPagoDivisa,
                aplicaIGTF = mp.aplicaIGTF,
                aplicaLoteRef = mp.aplicaLoteRef,
                codigoCurrencies = mp.codigoCurrencies,
                codigoMp = mp.codigoMp,
                idCurrencies = mp.idCurrencies,
                idMp = mp.idMp,
                nombreCurrencies = mp.nombreCurrencies,
                nombreMp = mp.nombreMp,
                simboloCurrencies = mp.simboloCurrencies,
            };
        }
    }
}