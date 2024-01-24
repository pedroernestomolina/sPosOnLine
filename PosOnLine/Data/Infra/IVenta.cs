using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface IVenta
    {
        OOB.Resultado.FichaId 
            Venta_Item_Registrar(OOB.Venta.Item.Registrar.Ficha ficha);
        OOB.Resultado.FichaEntidad<OOB.Venta.Item.Entidad.Ficha> 
            Venta_Item_GetById(int id);
        OOB.Resultado.Lista<OOB.Venta.Item.Entidad.Ficha> 
            Venta_Item_GetLista(OOB.Venta.Item.Lista.Filtro filtro);
        OOB.Resultado.Ficha 
            Venta_Anular(OOB.Venta.Anular.Ficha ficha);
        OOB.Resultado.Ficha 
            Venta_Item_Eliminar(OOB.Venta.Item.Eliminar.Ficha ficha);
        OOB.Resultado.Ficha 
            Venta_Item_ActualizarCantidad_Disminuir(OOB.Venta.Item.ActualizarCantidad.Disminuir.Ficha ficha);
        OOB.Resultado.Ficha 
            Venta_Item_ActualizarCantidad_Aumentar(OOB.Venta.Item.ActualizarCantidad.Aumentar.Ficha ficha);
        OOB.Resultado.Ficha
            Venta_Item_ActualizarPrecio(OOB.Venta.Item.ActualizarPrecio.Ficha ficha);
    }
}