using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PosBuscarProducto.Domain.UseCase
{
    public class UseCaseImpl : IUseCase
    {
        public string
            BuscarPor_CodigoBarra_Plu_CodigoAdm(string cadena)
        {
            try
            {
                //POR CODIGO/BARRA
                var r01 = Sistema.MyData.Producto_BusquedaByCodigoBarra(cadena);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Auto.Trim() != "")
                {
                    return r01.Auto;
                }
                //POR PLU
                var r02 = Sistema.MyData.Producto_BusquedaByPlu(cadena);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
                if (r02.Auto.Trim() != "")
                {
                    return r02.Auto;
                }
                //POR CODIGO/ADMINISTRATIVO
                var r03 = Sistema.MyData.Producto_BusquedaByCodigo(cadena);
                if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r03.Mensaje);
                }
                if (r03.Auto.Trim() != "")
                {
                    return r03.Auto;
                }
                return "";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Pos.Domain.Models.PosProducto>
            BuscarPor_Descripcion(Pos.Domain.Models.PosPrdFiltrarLista filtrarPor)
        {
            try
            {
                var filtro = new OOB.Producto.Lista.Filtro()
                {
                    autoDeposito = filtrarPor.PorIdDeposito,
                    cadena = filtrarPor.CadenaBuscar,
                    idPrecioManejar = filtrarPor.PorIdPrecioManejar,
                    isPorPlu = filtrarPor.IsPorPlu,
                };
                var rt = Sistema.MyData.Producto_GetLista(filtro);
                if (rt.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rt.Mensaje);
                }
                return Pos.Domain.Models.Mappers.ToListaProducto(rt.ListaD);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}