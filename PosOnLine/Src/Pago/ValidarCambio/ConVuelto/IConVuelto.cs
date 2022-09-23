using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.ValidarCambio.ConVuelto
{
    
    public interface IConVuelto: IValidarCambio
    {

        decimal GetMontoValidar { get; }
        decimal GetTotal { get; }


        decimal GetMontoEfectivoEnt { get; }
        void setMontoEfectivo(decimal monto);
        void PagoPorEfectivo(decimal monto);


        int GetCntDivisaEnt { get; }
        decimal GetMontoDivisa { get; }
        void setCntDivisa(int cnt);
        void PagoPorDivisa(int cnt);


        bool PagoMovilIsOk { get; }
        void PagoPorPagoMovil(decimal monto);
        decimal GetMontoPagoMovilEnt { get; }
        void setMontoPagoMovil(decimal monto);


        string GetVueltoDesc { get; }
        decimal GetVueltoMonto { get;  }

    }

}