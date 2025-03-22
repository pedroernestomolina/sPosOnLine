using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Buscar
{
    public interface IBuscarModo
    {
        void ActivarBusqueda(string buscar, bool activarBusquedaPorDescripcion = true);
        string AutoDeposito { get; }
        string AutoProducto { get; }
        bool BusquedaIsOk { get; }
        bool EstatusModoBusquedaPorCodigoBarra { get; }
        bool SeguirMismaLista { get; }
        //
        void setDepositoAsignado(PosOnLine.OOB.Deposito.Entidad.Ficha _depositoAsignado);
        void setGestionLista(PosOnLine.Src.Producto.Lista.IListaModo ctr);
        void setTarifaPrecio(string tarifa);
    }
}
