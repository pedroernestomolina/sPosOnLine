using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.ZUFU
{
    public class ImpPago: Pago, IPagoZufu
    {
        public ImpPago()
            :base()
        {
        }
        //
        public bool GetModoBonoPorPagoDivisa { get { return _activarBonoPorPagoDivisa; } }
        public void ActualizaDivisa()
        {
            var it = Detalle.FirstOrDefault(f => f.Modo == Src.Pago.Procesar.Enumerados.ModoPago.Divisa);
            if (it != null)
            {
                AddDivisa(it.MontoRecibido);
            }
        }
    }
}
