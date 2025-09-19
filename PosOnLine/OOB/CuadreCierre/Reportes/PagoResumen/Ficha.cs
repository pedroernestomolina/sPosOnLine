using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.CuadreCierre.Reportes.PagoResumen
{
    public class Ficha
    {
        public decimal montoVueltoMonLocal { get; set; }
        public decimal montoCreditoMonLocal { get; set; }
        public decimal montoCreditoMonReferencia { get; set; }
        public int cntMovCredito { get; set; }
        public List<Metodo> metodosUsado { get; set; }
    }
}