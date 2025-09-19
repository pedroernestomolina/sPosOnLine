using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain
{
    static class converter
    {
        static public FormaPago.Domain.Models.MedioPago MedioPago(_Domain.Models.MedioPago mp) 
        {
            return new FormaPago.Domain.Models.MedioPago()
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
        static public FormaPago.Domain.Models.Moneda Moneda(_Domain.Models.Moneda m)
        {
            return new FormaPago.Domain.Models.Moneda()
            {
                codigo = m.codigo,
                id = m.id,
                nombre = m.nombre,
                simbolo = m.simbolo,
                tasaRespectoMonReferencia = m.tasaRespectoMonReferencia,
            };
        }
    }
}