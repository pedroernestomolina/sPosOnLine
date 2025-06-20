using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista.ZUFU
{
    public interface ILista
    {
        object ItemSeleccionado { get; }
        bool ItemSeleccionadoIsOk { get; }
        object ItemActual { get; }
        object GetSource { get; }
        string GetDetalleProducto { get; }
        //PRECIOS
        string GetEmp1 { get; }
        string GetEmp2 { get; }
        string GetEmp3 { get; }
        string GetPrecio1 { get; }
        string GetPrecio2 { get; }
        string GetPrecio3 { get; }
        string GetPrecio1ConBono { get; }
        string GetPrecio2ConBono { get; }
        string GetPrecio3ConBono { get; }
        string GetTituloPrecioBono { get; }
        //INVENTARIO
        decimal GetInvEmpCompra { get; }
        decimal GetInvEmpInv { get; }
        decimal GetInvEmpUnd { get; }
        string GetDescEmpCompra { get; }
        string GetDescEmpInv { get; }
        string GetDescEmpUnd { get; }
        //
        bool GetIsOkEmp1 { get; }
        bool GetIsOkEmp2 { get; }
        bool GetIsOkEmp3 { get; }
        object GetPrdImagen { get; }
        //
        void Inicializa();
        void FlechaArriba();
        void FlechaAbajo();
        void SeleccionarItem();
        void setData(IEnumerable<object> lst, decimal factorCambio, decimal porctBonoDivisa, bool habilitarBonoDivisa, string descBonoDivisa);
    }
}
