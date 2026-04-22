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
                var _estatus = (DtoLibPos.PedidoWeb.EstatusProceso)ficha.FiltrarPorEstatusActual;
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

        public OOB.Resultado.FichaEntidad<OOB.PedidoWeb.Entidad>
            PedidoWeb_ObtenerUnPedido(int idPedido)
        {
            var r = new OOB.Resultado.FichaEntidad<OOB.PedidoWeb.Entidad>();
            //
            try
            {
                var rt = MyData.PedidoWeb_ObtenerPedidoWeb(idPedido);
                if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                if (rt.Entidad == null)
                {
                    throw new Exception("Entidad No Fue Cargada Correctamente");
                }
                if (rt.Entidad.Encabezado == null)
                {
                    throw new Exception("Encabezado Entidad No Fue Cargada Correctamente");
                }
                //
                if (rt.Entidad != null && rt.Entidad.Encabezado != null)
                {
                    var enc = rt.Entidad.Encabezado;
                    var entidad = new OOB.PedidoWeb.Entidad
                    {
                        Id = enc.Id,
                        FechaRegistro = enc.FechaRegistro,
                        NombreEntidad = enc.NombreEntidad,
                        CiRifEntidad = enc.CiRifEntidad,
                        DirEntidad = enc.DirEntidad,
                        TelefonoEntidad = enc.TelefonoEntidad,
                        IdSucursal = enc.IdSucursal,
                        IdDeposito = enc.IdDeposito,
                        ImporteMonRef = enc.ImporteMonRef,
                        ImporteMonLocal = enc.ImporteMonLocal,
                        TasaCambio = enc.TasaCambio,
                        TasaSistema = enc.TasaSistema,
                        CntArticulos = enc.CntArticulos,
                        CntItems = enc.CntItems,
                        PedidoNro = enc.PedidoNro,
                        IsAnulado = (enc.EstatusAnulado ?? "").ToUpper() == "1",
                        EstatusActual = (enc.EstatusProcesado ?? "").ToUpper() == "1"
                            ? OOB.PedidoWeb.EnumEstatusActual.Procesado
                            : OOB.PedidoWeb.EnumEstatusActual.SinProcesar,
                        DescSucursal = enc.DescSucursal,
                        DescDeposito = enc.DescDeposito,
                        IdWebCliente = enc.IdWebCliente,
                        Detalles = new List<OOB.PedidoWeb.Detalle>()
                    };

                    if (rt.Entidad.Detalles != null && rt.Entidad.Detalles.Count > 0)
                    {
                        entidad.Detalles = rt.Entidad.Detalles.Select(d => new OOB.PedidoWeb.Detalle
                        {
                            Id = d.Id,
                            IdProducto = d.IdProducto,
                            DescProducto = d.DescProducto,
                            DescWebProducto = d.DescWebProducto,
                            CntSolicitada = d.CntSolicitada,
                            IdEmpq = d.IdEmpq,
                            DescEmpq = d.DescEmpq,
                            ContEmpq = d.ContEmpq,
                            EstatusPrdHot = d.EstatusPrdHot,
                            EstatusPrdDivisa = d.EstatusPrdDivisa,
                            PrecioNetoMonLocal = d.PrecioNetoMonLocal,
                            PrecioFullMonRef = d.PrecioFullMonRef,
                            ImporteNetoMonLocal = d.ImporteNetoMonLocal,
                            ImporteMonRef = d.ImporteMonRef
                        }).ToList();
                    }

                    r.Entidad = entidad;
                }
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