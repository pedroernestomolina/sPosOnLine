using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src._Domain.Models
{
    public class Enumerados
    {
        public enum enumTipoDoc { SinDefinir = -1, Factura = 1, NotaDebito, NotaCredito, NotaEntrega };
        static public enumTipoDoc TipoDocumento(string codigoDoc)
        {
            switch (codigoDoc.Trim().ToUpper())
            {
                case "01":
                    return Enumerados.enumTipoDoc.Factura;
                case "02":
                    return Enumerados.enumTipoDoc.NotaDebito;
                case "03":
                    return Enumerados.enumTipoDoc.NotaCredito;
                case "04": 
                    return Enumerados.enumTipoDoc.NotaEntrega;
                default:
                    return Enumerados.enumTipoDoc.SinDefinir;
            }
        }
    }
}