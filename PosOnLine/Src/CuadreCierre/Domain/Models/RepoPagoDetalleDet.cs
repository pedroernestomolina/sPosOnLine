using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.Domain.Models
{
    public class RepoPagoDetalleDet
    {
        public decimal montoRecibido { get; set; }
        public string codigoMP{ get; set; }
        public string descMP { get; set; }
        public string loteNro { get; set; }
        public string referenciaNro { get; set; }
        public string codigoMoneda { get; set; }
        public string simboloMoneda { get; set; }
        public decimal tasaMoneda { get; set; }
        public decimal montoRecibioMonLocal { get; set; }
        public decimal montoRecibidoMonReferencia { get; set; }
    }
}