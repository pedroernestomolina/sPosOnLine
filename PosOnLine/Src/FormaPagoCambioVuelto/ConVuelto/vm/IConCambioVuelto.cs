using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPagoCambioVuelto.ConVuelto.vm
{
    public interface IConCambioVuelto: ICambioVuelto
    {
        decimal Get_MontoValidar { get; }
        decimal Get_MontoPorEfectivo { get; }
        int Get_CntPorDivisa { get; }
        decimal Get_MontoPorDivisa { get; }
        decimal Get_MontoPorPagoMovil { get; }
        decimal Get_SaldoTotal { get; }
        string Get_EstadoFaltaSobraOk { get; }
        //
        void setMontoPorEfectivo(decimal monto);
        void setCntPorDivisa(int cnt);
        void setMontoPorPagoMovil(decimal monto);
    }
}