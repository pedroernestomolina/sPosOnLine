using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cierre.NoFiscal
{
    public interface INoFiscal: IGestion
    {
        int cntDoc { get; }
        int cntFactura { get; }
        int cntNCredito { get; }
        int cntNEntrega { get; }
        decimal montoFactura { get; }
        decimal montoNCredito { get; }
        decimal montoNEntrega { get; }
        decimal montoVenta { get; }
        int cntDocContado { get; }
        int cntDocCredito { get; }
        decimal montoDocContado { get; }
        decimal montoDocCredito { get; }
        //
        int cntEfecitvo { get; }
        int cntDivisa { get; }
        int cntElectronico { get; }
        int cntOtros { get; }
        //
        decimal montoEfectivo { get; }
        decimal montoDivisa { get; }
        decimal montoElectronico { get; }
        decimal montoOtros { get; }
        //
        decimal montoDesgloze { get; }
        decimal montoEntrada { get; }
        decimal montoEntradaDivisa { get; }
        decimal Diferencia { get; }
        //
        int cntFacturaAnulada { get; }
        decimal montoFacturaAnulada { get; }
        int cntNCreditoAnulada { get; }
        decimal montoNCreditoAnulada { get; }
        int cntNEntregaAnulada { get; }
        decimal montoNEntregaAnulada { get; }
        //
        string Estacion { get; }
        string Usuario { get; }
        string FechaHoraApertura { get; }
        //
        bool CierreIsOk { get; }
        //
        bool AbandonarIsOk { get; }
        decimal GetVueltoPorPagoMovil { get; }
        decimal tasaPromedioDivisa { get; }
        decimal DesglozeDinero { get; }
        //
        int cntCambio { get; }
        decimal montoCambio { get; }
        //
        void setCntDivisa(int cntDivisa);
        void setEfectivo(decimal mEfectivo);
        void setTarjeta(decimal mTarjeta);
        void setOtro(decimal mOtro);
        void PagoResumen();
        void ReporteDetalle();
        void NCreditoDetalle();
        void PagoMovil();
        void VueltosEntregados();
        void MovCaja();
        void VentCredito();
        void Procesar();
        void Salir();
    }
}