using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPagoCambioVuelto.Domain.Models
{
    public class DataRetornar
    {
        public decimal MontoPorPagoMovil { get; set; }
        public decimal MontoPorVueltoEnEfectivo { get; set; }
        public decimal MontoPorVueltoEnDivisa { get; set; }
        public int CantDivisaPorVueltoEnDivisa { get; set; }
        //
        public decimal MontoPorVueltoEnPagoMovil { get { return MontoPorPagoMovil; } }
    }
}