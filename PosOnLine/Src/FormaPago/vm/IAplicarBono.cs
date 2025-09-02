using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.vm
{
    public class dataAplicar
    {
        public decimal porctBono { get; set; }
        public decimal montoTotalDivisa { get; set; }
        public decimal montoAplicarBono { get; set; }
    }
    public class dataCalcularMaxMontoPagarDivisa
    {
        public decimal porctBono { get; set; }
        public decimal montoTotalDivisa { get; set; }
    }
    public interface IAplicarBono
    {
        decimal aplicar(dataAplicar data);
        decimal calcularMaxMontoPagarDivisa(dataCalcularMaxMontoPagarDivisa data);
    }
}
