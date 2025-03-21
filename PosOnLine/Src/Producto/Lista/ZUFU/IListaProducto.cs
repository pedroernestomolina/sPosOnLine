using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista.ZUFU
{
    public interface IListaProducto: IGestion
    {
        object ItemSeleccionado { get; }
        bool ItemSeleccionadoIsOk { get; }
        bool SalirListaIsOk { get; }
        //
        object GetSource { get; }
        string GetTituloPrecioBono { get; }
        string GetDetalleProducto { get; }
        //
        bool GetIsOkEmp1 { get; }
        string GetEmp1 { get; }
        string GetPrecio1 { get; }
        string GetPrecio1ConBono { get; }
        //
        bool GetIsOkEmp2 { get; }
        string GetEmp2 { get; }
        string GetPrecio2 { get; }
        string GetPrecio2ConBono { get; }
        //
        bool GetIsOkEmp3 { get; }
        string GetEmp3 { get; }
        string GetPrecio3 { get; }
        string GetPrecio3ConBono { get; }
        //
        decimal GetInvEmpCompra { get; }
        string GetDescEmpCompra { get; }
        decimal GetInvEmpInv { get; }
        string GetDescEmpInv { get; }
        decimal GetInvEmpUnd { get; }
        string GetDescEmpUnd { get; }
        //
        object GetPrdImagen { get; }
        //
        void SeleccionarItem();
        void FlechaArriba();
        void FlechaAbajo();
        void setData(IEnumerable<object> lst, decimal factorCambio, decimal porctBonoDivisa, bool habilitarBonoDivisa);
        void SalirLista();
    }
}