using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.ZUFU
{
    public interface IPagoZufu: IPago
    {
        bool GetModoBonoPorPagoDivisa { get; }
        void ActualizaDivisa();
    }
}
