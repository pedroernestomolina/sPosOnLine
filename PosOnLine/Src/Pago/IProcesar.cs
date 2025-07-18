using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago
{
    public interface IProcesar
    {
        void AddDivisa(decimal monto);
        void AddEfectivo(decimal monto);
        void AddElectronico(decimal monto, int p);
        bool AplicarIGTF { get; }
        decimal BaseAplicaIGTFMonAct { get; }
        decimal BaseAplicaIGTFMonDiv { get; }
        void Calculadora();
        string ClienteData { get; }
        void DarCredito();
        void DarDescuento();
        dataRecolectar DataPagoRecolectar { get; }
        decimal DescuentoPorct { get; }
        decimal GetCntDivisaRecomendar { get; }
        decimal GetPagoOtro { get; }
        bool LimpiarPagosIsOk { get; }
        decimal MontoCambioDar { get; }
        decimal MontoCambioDar_Divisa { get; }
        decimal MontoCambioDar_Divisa_Tasa_POS { get; }
        decimal MontoCambioDar_MonedaNacional { get; }
        decimal MontoDivisa { get; }
        decimal MontoPagar { get; }
        decimal MontoPagarDivisa { get; }
        decimal MontoPorIGTF { get; }
        decimal MontoRecibido { get; }
        decimal MontoResta_Divisa { get; }
        decimal MontoResta_MonedaNacional { get; }
        System.Collections.Generic.List<PagoDetalle> PagoDetalles { get; }
        string PagoElectronico_LOTE_1 { get; }
        string PagoElectronico_LOTE_2 { get; }
        string PagoElectronico_LOTE_3 { get; }
        string PagoElectronico_LOTE_4 { get; }
        string PagoElectronico_REF_1 { get; }
        string PagoElectronico_REF_2 { get; }
        string PagoElectronico_REF_3 { get; }
        string PagoElectronico_REF_4 { get; }
        bool PagoIsOk { get; }
        PosOnLine.Src.PagoMovil.data PagoMovilData { get; }
        bool PagoMovilIsOk { get; }
        bool IsCreditoOk { get; }
        decimal SubTotalMontoPagar { get; }
        decimal TasaCambio { get; }
        decimal TasaIGTF { get; }
        bool TipoDocumento_IsNotaCredito { get; }
        //
        void Inicializar();
        void setAplicarIGTF(bool aplicar);
        void setCliente(string data);
        void setDataCliente(PosOnLine.OOB.Cliente.Entidad.Ficha ent);
        void setDescuento(decimal dsctoFinal);
        void setImporte(decimal monto);
        void setNotaCredito(bool estatus);
        void setTasaCambio(decimal tasa);
        void setTasaIGTF(decimal tasa);
        void Inicia();
        void Limpiar();
        void LimpiarPagos();
        void Procesar();
        void setPorctBonoAplicar(decimal porct);
    }
}