using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.Domain.Models
{
    public class MetodoPagoUso
    {
        public string idMP { get; set; }
        public string codigoMP { get; set; }
        public string descripcionMP { get; set; }
        public string simboloMon { get; set; }
        public string codigoMon { get; set; }
        public decimal totalMontoRecibido { get; set; }
        public decimal totalMontoRecibidoMonLocal { get; set; }
        public decimal tasaFactorPonderado { get; set; }
        //
        public string CabDescripcion { get { return descripcionMP.Trim() + " " + simboloMon.Trim(); } }
        public string CabMontoSist { get { return totalMontoRecibido.ToString("n2"); } }
        public string CabFactor { get { return tasaFactorPonderado.ToString("n4"); } }
        public decimal CabMontoUsu { get; set; }
    }
}