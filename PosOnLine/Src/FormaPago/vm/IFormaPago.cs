using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.vm
{
    public interface IFormaPago: IVista
    {
        object Get_MedioPagoSource { get; }
        String Get_MedioPagoId { get; }
        string Get_SimboloMonedaFormaPago { get; }
        object Get_FormasPagoSource { get; }
        bool agregarMedioPagoIsOk { get; }
        decimal Get_MontoBonoMonedaLocal { get; }
        decimal Get_MonoBonoMonedaReferencia { get; }
        string Get_SimboloMonedaLocal { get; }
        string Get_SimboloMonedaReferencia { get; }
        decimal Get_MontoRestaCambioMonLocal { get; }
        decimal Get_MontoRestaCambioMonReferencia { get; }
        bool IsCuentaPendiente { get; }
        bool EstatusBonoPagoPorDivisa { get; }
        decimal MontoMaxIngresarPagoDivisa { get; }
        //
        void setMedioPago(string id);
        void setMontoIngresar(decimal monto);
        void setFactorCambio(decimal factorCambio);
        void setMontoPorPagarMonLocal(decimal monto);
        void setMontoPorPagarMonDivisa(decimal monto);
        void setPorctBono(decimal porctBono);
        void setActivarBonoPorPagoDivsa(bool modo);
        //
        void agregarMedioPago();
        void eliminarFormaPago();
        void limpiezaGeneral();
        void refrescarMontos();
        void ApagarEncenderBonoPorPagoDivsa();
    }
}