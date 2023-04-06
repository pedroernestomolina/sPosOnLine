using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Item
{
    public interface IModo
    {
        event EventHandler Hnd_Item_Cambio;


        int CantItem { get; }
        decimal TotalPeso { get;  }
        int CantRenglones { get; }
        decimal Importe { get; }
        decimal ImporteDivisa { get; }
        string Producto { get; }
        string PrdTasaIva { get; }
        decimal PrdPrecioNeto { get; }
        decimal PrdContenido { get; }
        decimal PrdIva { get; }
        BindingSource ItemSource { get; }
        data Item { get; }
        BindingList<data> Items { get; }
        data DataItemActual { get; }


        void setGestionMultiplicar(Multiplicar.Gestion _gestionMultiplicar);
        void setGestionPendiente(Pendiente.Gestion _gestionPendiente);
        void setDepositoAsignado(OOB.Deposito.Entidad.Ficha _depositoAsignado);
        void setTarifaPrecio(string _precioManejar);
        void setValidarExistencia(bool p);
        void setHabilitarPrecio5VentaMayor(bool p);
        void setData(List<OOB.Venta.Item.Entidad.Ficha> list, decimal _tasaCambioActual);
        void setData(List<OOB.Documento.Entidad.FichaItem> list, decimal _tasaCambioActual);
        void SetCantIncrementar(data it, int p);
        void setDescuentoFinal(decimal dsctoFinal);
        void setItemActualInicializar();


        void Inicializar();
        void RegistraItem(string autoPrd, string tipoPrecio);
        bool AnularVentaIsOk { get; }
        void AnularVenta(bool p);
        void DevolucionItem(bool p);
        void Decrementar();
        bool DejarCtaPendienteIsOk { get; }
        void DejarCtaPendiente(OOB.Cliente.Entidad.Ficha ficha, string _idSucursal, string _idDeposito, string _idVendedor);
        void Limpiar();
    }
}