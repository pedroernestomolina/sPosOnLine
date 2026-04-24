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
                throw new Exception(e.Message);
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
                throw new Exception(e.Message);
            }
        }

        public OOB.Resultado.FichaEntidad<OOB.PedidoWeb.CapturarTrasladoPisoVentaOoB>
            PedidoWeb_CapturarTrasladoPisoventa(int idPedido)
        {
            var r = new OOB.Resultado.FichaEntidad<OOB.PedidoWeb.CapturarTrasladoPisoVentaOoB>();
            //
            try
            {
                var rt = MyData.PedidoWeb_CapturarTrasladoPisoVenta(idPedido);
                if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }

                // Validar que los datos del encabezado no sean nulos
                if (rt.Entidad == null || rt.Entidad.Datos == null)
                {
                    throw new Exception("No se obtuvo información del encabezado del pedido");
                }

                // Mapear el encabezado del DTO al OOB
                var encabezado = new OOB.PedidoWeb.CapturarEncTrasladarPisoVentaOoB
                {
                    Id = rt.Entidad.Datos.Id,
                    FechaRegistro = rt.Entidad.Datos.FechaRegistro,
                    NombreEntidad = rt.Entidad.Datos.NombreEntidad,
                    CiRifEntidad = rt.Entidad.Datos.CiRifEntidad,
                    DirEntidad = rt.Entidad.Datos.DirEntidad,
                    TelefonoEntidad = rt.Entidad.Datos.TelefonoEntidad,
                    IdSucursal = rt.Entidad.Datos.IdSucursal,
                    IdDeposito = rt.Entidad.Datos.IdDeposito,
                    DescSucursal = rt.Entidad.Datos.DescSucursal,
                    DescDeposito = rt.Entidad.Datos.DescDeposito,
                    IdWebCliente = rt.Entidad.Datos.IdWebCliente,
                    ImporteMonRef = rt.Entidad.Datos.ImporteMonRef,
                    ImporteMonLocal = rt.Entidad.Datos.ImporteMonLocal,
                    TasaCambio = rt.Entidad.Datos.TasaCambio,
                    TasaSistema = rt.Entidad.Datos.TasaSistema,
                    CntArticulos = rt.Entidad.Datos.CntArticulos,
                    CntItems = rt.Entidad.Datos.CntItems,
                    PedidoNro = rt.Entidad.Datos.PedidoNro,
                    EstatusAnulado = rt.Entidad.Datos.EstatusAnulado,
                    EstatusProcesado = rt.Entidad.Datos.EstatusProcesado
                };

                if (rt.Entidad == null || rt.Entidad.Items == null || rt.Entidad.Items.Count == 0)
                {
                    throw new Exception("No se obtuvo información del pedido o está vacío");
                }

                var entidad = new OOB.PedidoWeb.CapturarTrasladoPisoVentaOoB
                {
                    Items = rt.Entidad.Items.Select(item => new OOB.PedidoWeb.CatpurarItemTrasladarPisoVentaOoB
                    {
                        idProducto = item.idProducto,
                        idDepartamento = item.idDepartamento,
                        idGrupo = item.idGrupo,
                        idSubGrupo = item.idSubGrupo,
                        idTasaFiscal = item.idTasaFiscal,
                        codigoPrd = item.codigoPrd,
                        nombrePrd = item.nombrePrd,
                        cntSolicitada = item.cntSolicitada,
                        pNeto = item.pNeto,
                        pDivisaFull = item.pDivisaFull,
                        tasaFiscal = item.tasaFiscal,
                        categoriaPrd = item.categoriaPrd,
                        decimalesPrd = item.decimalesPrd,
                        descEmpq = item.descEmpq,
                        contEmpq = item.contEmpq,
                        estatusPesado = item.estatusPesado,
                        costoUnd = item.costoUnd,
                        costoPromUnd = item.costoPromUnd,
                        costoCompra = item.costoCompra,
                        costoProm = item.costoProm,
                        pesoPrd = item.pesoPrd,
                        volumenPrd = item.volumenPrd,
                        estatusDivisa = item.estatusDivisa,
                        exDisponible = item.exDisponible,
                        costoDivisa= item.costoDivisa,
                        contEmpqCompra=item.contEmpqCompra,
                    }).ToList(),
                };
                entidad.Encabezado = encabezado;

                r.Entidad = entidad;
                return r;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public OOB.Resultado.FichaEntidad<bool>
            PedidoWeb_AplicarTrasladoPisoventa(OOB.PedidoWeb.AplicarTrasladoPisoVenta aplicarTraslado)
        {
            var r = new OOB.Resultado.FichaEntidad<bool>();
            //
            try
            {
                var dto = new DtoLibPos.PedidoWeb.AplicarTrasladoPisoVentaRequest()
                {
                    IdPedidoWeb=aplicarTraslado.IdPedidoWeb,
                    NroPedidoWeb = aplicarTraslado.NroPedidoWeb,
                    CiRifEntidad = aplicarTraslado.CiRifEntidad,
                    CntRenglones = aplicarTraslado.CntRenglones,
                    IdCliente = aplicarTraslado.IdCliente,
                    IdSucursal = aplicarTraslado.IdSucursal,
                    IdVendedor = aplicarTraslado.IdVendedor,
                    ImporteFullMonRef = aplicarTraslado.ImporteFullMonRef,
                    ImporteNetoMonLocal = aplicarTraslado.ImporteNetoMonLocal,
                    NombreEntidad = aplicarTraslado.NombreEntidad,
                    TasaCambioPos = aplicarTraslado.TasaCambioPos,
                    IdDeposito = aplicarTraslado.IdDeposito,
                    IdOperador = aplicarTraslado.IdOperador,
                    ItemBloqEx = aplicarTraslado.PrdBloquearEx.Select(it =>
                    {
                        var ex = new DtoLibPos.PedidoWeb.ItemsDepositoBloquearExRequest()
                        {
                            cntBloquear = it.CntBloquear,
                            idDeposito = aplicarTraslado.IdDeposito,
                            idProducto = it.IdProducto,
                        };
                        return ex;
                    }).ToList(),
                    ItemsPisoVta = aplicarTraslado.ItemsPisoVta.Select(it =>
                    {
                        var pv = new DtoLibPos.PedidoWeb.ItemsPisoVentaRequest()
                        {
                            categoriaPrd = it.categoriaPrd,
                            cntSolicitada = it.cntSolicitada,
                            codigoPrd = it.codigoPrd,
                            contEmpq = it.contEmpq,
                            costoCompra = it.costoCompra,
                            costoProm = it.costoProm,
                            costoPromUnd = it.costoPromUnd,
                            costoUnd = it.costoUnd,
                            decimalesPrd = it.decimalesPrd,
                            descEmpq = it.descEmpq,
                            estatusDivisa = it.estatusDivisa,
                            estatusPesado = it.estatusPesado,
                            idDepartamento = it.idDepartamento,
                            idGrupo = it.idGrupo,
                            idProducto = it.idProducto,
                            idSubGrupo = it.idSubGrupo,
                            idTasaFiscal = it.idTasaFiscal,
                            nombrePrd = it.nombrePrd,
                            pDivisaFull = it.pDivisaFull,
                            pesoPrd = it.pesoPrd,
                            pNeto = it.pNeto,
                            tasaFiscal = it.tasaFiscal,
                            volumenPrd = it.volumenPrd,
                        };
                        return pv;
                    }).ToList(),
                };
                var rt = MyData.PedidoWeb_TrasladarPisoVenta(dto);
                if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                r.Entidad = true;
                return r;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}