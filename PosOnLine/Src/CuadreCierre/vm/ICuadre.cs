using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.vm
{
    public interface ICuadre: IGestion
    {
        object Get_ResumenSource { get; }
        object Get_TipoDocSource { get; }
        object Get_MetodosPagoSource { get; }
        decimal Get_ImporteRecibido { get; }
        string Get_EstadoPendSobrante { get; }
        decimal Get_MontoPendSobrante { get; }
        string Get_DescMPPorPagoBonoDivisa { get; }
        decimal Get_MontoMPPorPagoBonoDivisa { get; }
        decimal Get_VueltoMontoPorEfectivo { get; }
        int Get_VueltoCntPorDivisa { get; }
        object Get_MediosPagoLocalSource { get; }
        string Get_IdMedioPagoLocal { get; }
        object Get_MediosPagoReferenciaSource { get; }
        string Get_IdMedioPagoReferencia { get; }
        //
        void setVueltoMedPagoLocal(string id);
        void setVueltoMedPagoReferencia(string id);
        //
        void ActualizarImporteMetodoPago();
        void MsgAlerta(string msg);
        void LimpiarVueltoMonLocal();
        void LimpiarVueltoMonReferencia();
        void LimpiarIngresoMetodosPagoUsado();
        //
        void reportePagoDetalle();
        void reportePagoResumen();
        void reporteVentaCredito();
        void reporteCambiosVuelto();
        void reportePagoMovil();
        //
        bool ProcesarCierreIsOk { get; }
        bool AbandonarFichaIsOk { get; }
        void ProcesarCierre();
        void AbandonarFicha();
        //
        void Invoke();
    }
}