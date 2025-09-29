using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosImprimirTicket.vm
{
    public interface IPosImprimir
    {
        void ImprimirFactura(string idDoc);
        void ImprimirNotaCredito(string idDoc);
        void ImprimirNotaEntrega(string idDoc);
        void ImprimirCopiaDocumento(string idDoc);
    }
}