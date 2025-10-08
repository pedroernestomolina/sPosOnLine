using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosItemCambiarPrecio.vm
{
    public interface ICambiarPrecio
    {
        string Get_ProductoInfo { get; }
        decimal Get_PrecioPagoBs { get; }
        decimal Get_PrecioPagoPrdNoDivisa { get; }
        decimal Get_PrecioPagoDivisa { get; }
        decimal Get_PorctAumentoProductosNoDivisa { get; }
        bool Get_IsProductoAdmPorDivisa { get; }
        decimal Get_Utilidad { get; }
        decimal Get_CostoEmpaqueVenta { get; }
        decimal Get_TasaSistema { get; }
        decimal PrecioNetoMonActualActualizado { get; }
        decimal PrecioFullMonDivisaActualizado { get; }
        bool DarPorcentajeAumento { get; }
        bool AbandonarFichaIsOK { get; }
        bool ProcesarCambioIsOK { get; }
        //
        void Invoke(int idItem);
        void setPagoMontoBs(decimal monto);
        void setPagoDivisa(decimal monto);
        void setPagoProductoNoDivisa(decimal monto);
        void setSwitchPorcentajeAumento(bool sw);
        void AbandonarFicha();
        void ProcesarCambio();
    }
}