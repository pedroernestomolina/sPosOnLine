using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IProducto
    {

        OOB.Resultado.Lista<OOB.Producto.Lista.Ficha> Producto_GetLista(OOB.Producto.Lista.Filtro filtro);
        OOB.Resultado.FichaEntidad<OOB.Producto.Entidad.Ficha> Producto_GetFichaById (string id);
        OOB.Resultado.FichaAuto Producto_BusquedaByCodigo(string buscar);
        OOB.Resultado.FichaAuto Producto_BusquedaByPlu(string buscar);
        OOB.Resultado.FichaAuto Producto_BusquedaByCodigoBarra(string buscar);
        OOB.Resultado.FichaEntidad<OOB.Producto.Existencia.Entidad.Ficha> Producto_Existencia_GetByPrdDeposito(OOB.Producto.Existencia.Buscar.Ficha ficha);

    }

}