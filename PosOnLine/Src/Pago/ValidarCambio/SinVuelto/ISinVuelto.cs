using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.ValidarCambio.SinVuelto
{
    
    public interface ISinVuelto: IValidarCambio
    {

        void setMontoCapturado(decimal monto);

        bool PagoMovilIsOk { get; }
        void PagoMovil();

    }

}