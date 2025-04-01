using System;
namespace PosOnLine.Src.Pago
{
    public interface IPago
    {
        void AddDivisa(decimal monto);
        void AddEfectivo(decimal monto);
        void AddElectronico(decimal monto, int id, string nroLote = "", string nroReferencia = "", bool activar = true);
        void AplicarMontoCargoPorIgtf(decimal monto);
        void DarCredito();
        void DarDescuento();
        dataRecolectar DataPagoRecolectar { get; }
        decimal Descuento { get; }
        decimal DescuentoPorct { get; }
        System.Collections.Generic.List<PagoDetalle> Detalle { get; }
        decimal GetCntDivisaRecomendar { get; }
        decimal GetPagoOtro { get; }
        bool IsCredito { get; }
        void Limpiar();
        void LimpiarFicha();
        decimal MontoCambioDar { get; }
        decimal MontoCambioDar_Divisa { get; }
        decimal MontoCambioDar_MonedaNacional { get; }
        decimal MontoDivisa { get; }
        decimal MontoPagar { get; }
        decimal MontoPagarDivisa { get; }
        decimal MontoRecibido { get; }
        decimal MontoResta_Divisa { get; }
        decimal MontoResta_MonedaNacional { get; }
        string PagoElectronico_LOTE(int id);
        string PagoElectronico_REF(int id);
        PosOnLine.Src.PagoMovil.data PagoMovilData { get; }
        bool PagoMovilIsOk { get; }
        bool Procesar();
        void setActivarBonoPorPagoDivisa(bool activar);
        void setDataCliente(PosOnLine.OOB.Cliente.Entidad.Ficha ent);
        void setDescuento(decimal porct);
        bool setDocumentoCredito();
        void setGestionDescuento(PosOnLine.Src.Pago.Descuento.Gestion gestion);
        void setGestionLoteRef(PosOnLine.Src.Pago.LoteReferencia.Gestion gestion);
        void setMontoPagar(decimal monto);
        void setNotaCredito(bool estatus);
        void setPorctBonoPorPagoDivisa(decimal porct);
        void setTasaCambio(decimal tasa);
        decimal SubTotalMontoPagar { get; }
        decimal TasaCambio { get; }
    }
}
