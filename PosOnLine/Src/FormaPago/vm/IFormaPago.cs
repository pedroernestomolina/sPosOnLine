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
        decimal Get_PorctBono { get; }
        decimal Get_TasaFactorCambio { get; }
        string Get_ClienteData { get; }
        decimal Get_TotalPagarMonLocal { get; }
        decimal Get_TotalPagarMonDivisa { get; }
        decimal Get_PorctDesctoDado { get; }
        decimal Get_MontoDscto { get; }
        bool Get_DsctActivo { get; }
        decimal Get_PorctIGTFAplicar { get; }
        decimal Get_BaseAplicarIGTF { get; }
        decimal GetMontoIGTF { get; }
        bool Get_IGTFActivo { get; }
        bool ProcesoPagoIsOk { get; }
        bool EstatusCuentaIsCredito { get; }
        bool abandonarFichaIsOk { get; }
        FormaPago.Domain.Models.DataRetornar Get_DataRetornar { get; }
        //
        void setMedioPago(string id);
        void setMontoIngresar(decimal monto);
        void setFactorCambio(decimal factorCambio);
        void setMontoPorPagarMonLocal(decimal monto);
        void setMontoPorPagarMonDivisa(decimal monto);
        void setPorctBono(decimal porctBono);
        void setActivarBonoPorPagoDivsa(bool modo);
        void setActivarModoSoloFormasPagoConMonedaLocal(bool modo);
        void setDesctoDado(decimal porct);
        void setClienteEntidad(Domain.Models.Cliente data);
        void setModoDocumento(Domain.Models.Enumerados.TipoDocumento tipo);
        void setActivarFicha(bool activar);
        //
        void agregarMedioPago();
        void eliminarFormaPago();
        void limpiezaGeneral();
        void refrescarMontos();
        void apagarEncenderBonoPorPagoDivsa();
        void dsctoDar();
        void ctaCredito();
        void abandonarFicha();
        void procesarFicha();
        void limpiarItemsFormaPago();
    }
}