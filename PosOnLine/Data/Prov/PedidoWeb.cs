using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Data.Prov
{
    public partial class DataPrv : IData
    {
        public OOB.Resultado.Lista<OOB.PedidoWeb.Entidad> 
            PedidoWeb_ObtenerListaPedidos(OOB.PedidoWeb.FiltrarLista ficha)
        {
            var r = new OOB.Resultado.Lista<OOB.PedidoWeb.Entidad>();
            //
            try
            {
                var _estatus = (DtoLibPos.PedidoWeb.EstatusProceso) ficha.FiltrarPorEstatusActual;
                var filtroDTO = new DtoLibPos.PedidoWeb.FiltroPedidoWebListaRequest()
                {
                    FiltrarPorEstatusProceso = _estatus,
                    FiltrarSoloActivo = ficha.FiltrarSoloActivo,
                };
                var rt = MyData.PedidoWeb_ObtenerListaPedidos(filtroDTO);
                if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                r.ListaD = rt.Lista.Select(s =>
                {
                    var nr = new OOB.PedidoWeb.Entidad()
                    {
                        Id = s.Id,
                        FechaRegistro = s.FechaRegistro,
                        NombreEntidad = s.NombreEntidad,
                        CiRifEntidad = s.CiRifEntidad,
                        ImporteMonRef = s.ImporteMonRef,
                        ImporteMonLocal = s.ImporteMonLocal,
                        CntArticulos = s.CntArticulos,
                        CntItems = s.CntItems,
                        PedidoNro = s.PedidoNro,
                    };
                    return nr;
                }).ToList();
                //
                return r;
            }
            catch (Exception e)
            {
                r.Mensaje = e.Message;
                r.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return r;
            }
        }
    }
}
