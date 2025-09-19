using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.CuadreCierre.Reportes.PagoResumen
{
    public class Metodo
    {
        public string codigoMP { get; set; }
        public string descMP { get; set; }
        public string codigoMoneda { get; set; }
        public string simboloMoneda { get; set; }
        public decimal tasaRespectoMonReferencia { get; set; }
        public decimal recibido { get; set; }
        public decimal montoRecibidoMonLocal { get; set; }
        public int cntMov { get; set; }
        public decimal tasaReferencia { get; set; }
    }
}