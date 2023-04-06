using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface IProducto_ModoAdm
    {
        OOB.Resultado.Lista<OOB.Producto_ModoAdm.Lista.Ficha> 
            Producto_ModoAdm_GetLista(OOB.Producto.Lista.Filtro filtro);
        OOB.Resultado.FichaEntidad<bool>
            Producto_ModoAdm_VerificaPrecioVtaProducto(string autoPrd, string tipoPrecio, string tipoEmpaque);
        OOB.Resultado.FichaEntidad<OOB.Producto_ModoAdm.Precio.Ficha>
            Producto_ModoAdm_GetPrecio_By(OOB.Producto_ModoAdm.Precio.Filtro filtro);
        OOB.Resultado.FichaEntidad<OOB.Producto_ModoAdm.Entidad.Ficha>
            Producto_ModoAdm_GetFicha_By(string autoPrd);
    }
}