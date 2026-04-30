using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.Domain.UseCase
{
    public class UseCaseImpl : IUseCase
    {
        public IEnumerable<Models.PedidoWeb>
            ObtenerListaDePedidosWebActivosSinProcesar()
        {
            var rt = new List<Models.PedidoWeb>();
            //
            try
            {
                var filtro = new OOB.PedidoWeb.FiltrarLista()
                {
                    FiltrarPorEstatusActual = OOB.PedidoWeb.EnumEstatusActual.SinProcesar,
                    FiltrarSoloActivo = true,
                };
                var r01 = Sistema.MyData.PedidoWeb_ObtenerListaPedidos(filtro);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                //
                rt = r01.ListaD.Select(s =>
                {
                    var nr = new Models.PedidoWeb()
                    {
                        Id = s.Id,
                        FechaRegistro = s.FechaRegistro,
                        NombreEntidad = s.NombreEntidad,
                        CiRifEntidad = s.CiRifEntidad,
                        DirEntidad = s.DirEntidad,
                        TelefonoEntidad = s.TelefonoEntidad,
                        IdSucursal = s.IdSucursal,
                        IdDeposito = s.IdDeposito,
                        ImporteMonRef = s.ImporteMonRef,
                        ImporteMonLocal = s.ImporteMonLocal,
                        TasaCambio = s.TasaCambio,
                        TasaSistema = s.TasaSistema,
                        CntArticulos = s.CntArticulos,
                        CntItems = s.CntItems,
                        PedidoNro = s.PedidoNro,
                        IsAnulado = false,
                        EstatusActual = Models.EnumEstatusActual.SinProcesar,
                        DescSucursal = s.DescSucursal,
                        DescDeposito = s.DescDeposito,
                        IdWebCliente = s.IdWebCliente
                    };
                    return nr;
                }).ToList();
                //
                return rt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Models.PedidoWeb
            CargarPedidoWebById(int idPedidoCargar)
        {
            var rt = new Models.PedidoWeb();
            //
            try
            {
                var r01 = Sistema.MyData.PedidoWeb_ObtenerUnPedido(idPedidoCargar);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }

                if (r01.Entidad == null)
                {
                    throw new Exception("Pedido no encontrado");
                }

                rt = new Models.PedidoWeb()
                {
                    Id = r01.Entidad.Id,
                    FechaRegistro = r01.Entidad.FechaRegistro,
                    NombreEntidad = r01.Entidad.NombreEntidad,
                    CiRifEntidad = r01.Entidad.CiRifEntidad,
                    DirEntidad = r01.Entidad.DirEntidad,
                    TelefonoEntidad = r01.Entidad.TelefonoEntidad,
                    IdSucursal = r01.Entidad.IdSucursal,
                    IdDeposito = r01.Entidad.IdDeposito,
                    ImporteMonRef = r01.Entidad.ImporteMonRef,
                    ImporteMonLocal = r01.Entidad.ImporteMonLocal,
                    TasaCambio = r01.Entidad.TasaCambio,
                    TasaSistema = r01.Entidad.TasaSistema,
                    CntArticulos = r01.Entidad.CntArticulos,
                    CntItems = r01.Entidad.CntItems,
                    PedidoNro = r01.Entidad.PedidoNro,
                    IsAnulado = r01.Entidad.IsAnulado,
                    EstatusActual = (Models.EnumEstatusActual)r01.Entidad.EstatusActual,
                    DescSucursal = r01.Entidad.DescSucursal,
                    DescDeposito = r01.Entidad.DescDeposito,
                    IdWebCliente = r01.Entidad.IdWebCliente,
                    Detalles = r01.Entidad.Detalles != null
                        ? r01.Entidad.Detalles.Select(d => new Models.PedidoWebDetalle()
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
                        }).ToList()
                        : new List<Models.PedidoWebDetalle>()
                };
                //
                return rt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Models.CapturarTrasladoModel
            CapturarTrasladoPisoVenta(int idPedido)
        {
            var rt = new Models.CapturarTrasladoModel();
            //
            try
            {
                var r01 = Sistema.MyData.PedidoWeb_CapturarTrasladoPisoventa(idPedido);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }

                // Validar que los datos del encabezado no sean nulos
                if (r01.Entidad == null || r01.Entidad.Encabezado== null)
                {
                    throw new Exception("No se obtuvo información del encabezado del pedido");
                }

                // Mapear el encabezado del DTO al OOB
                var re = r01.Entidad.Encabezado;
                var encabezado = new Models.EncabezadoCapturadoModel
                {
                    Id = re.Id,
                    FechaRegistro = re.FechaRegistro,
                    NombreEntidad = re.NombreEntidad,
                    CiRifEntidad = re.CiRifEntidad,
                    DirEntidad = re.DirEntidad,
                    TelefonoEntidad = re.TelefonoEntidad,
                    IdSucursal = re.IdSucursal,
                    IdDeposito = re.IdDeposito,
                    DescSucursal = re.DescSucursal,
                    DescDeposito = re.DescDeposito,
                    IdWebCliente = re.IdWebCliente,
                    ImporteMonRef = re.ImporteMonRef,
                    ImporteMonLocal = re.ImporteMonLocal,
                    TasaCambio = re.TasaCambio,
                    TasaSistema = re.TasaSistema,
                    CntArticulos = re.CntArticulos,
                    CntItems = re.CntItems,
                    PedidoNro = re.PedidoNro,
                    EstatusAnulado = re.EstatusAnulado,
                    EstatusProcesado = re.EstatusProcesado
                };
                rt.Encabezado = encabezado;

                if (r01.Entidad == null || r01.Entidad.Items == null)
                {
                    throw new Exception("No se encontraron items para trasladar.");
                }

                rt.Items = r01.Entidad.Items.Select(item => new Models.ItemCapturadoModel
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
                    isAdmDivisa = item.estatusDivisa.Trim().ToUpper()=="1",
                    exDisponible = item.exDisponible,
                    costoDivisa = item.costoDivisa,
                    contEmpqCompra = item.contEmpqCompra
                }).ToList();
                //
                return rt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool 
            AplicarTrasladoPisoVenta(Models.AplicarTrasladoModel aplicarTraslado)
        {
            try
            {
                var aplicar = new OOB.PedidoWeb.AplicarTrasladoPisoVenta()
                {
                    IdPedidoWeb = aplicarTraslado.IdPedidoWeb,
                    NroPedidoWeb = aplicarTraslado.NroPedidoWeb,
                    IdDeposito = aplicarTraslado.IdDeposito,
                    IdOperador = aplicarTraslado.IdOperador,
                    CiRifEntidad = aplicarTraslado.CiRifEntidad,
                    CntRenglones = aplicarTraslado.CntRenglones,
                    IdCliente = aplicarTraslado.IdCliente,
                    IdSucursal = aplicarTraslado.IdSucursal,
                    IdVendedor = aplicarTraslado.IdVendedor,
                    ImporteFullMonRef = aplicarTraslado.ImporteFullMonRef,
                    ImporteNetoMonLocal = aplicarTraslado.ImporteNetoMonLocal,
                    NombreEntidad = aplicarTraslado.NombreEntidad,
                    TasaCambioPos = aplicarTraslado.TasaCambioPos,
                    ItemsPisoVta = aplicarTraslado.Items.Where(w => w.CntDisponibleParaTrasladar > 0).Select(s =>
                    {
                        var _costo = 0m;
                        var _costoUnd = 0m;
                        var _pDivisaFull = 0m;

                        if (!s.isAdmDivisa)
                        {
                            if (s.contEmpqCompra > 0)
                            {
                                _costoUnd = (s.costoDivisa / s.contEmpqCompra) * aplicarTraslado.TasaCambioPos;
                            }
                            _costo = (_costoUnd * s.contEmpq);
                            _pDivisaFull = s.pDivisaFull;
                        }
                        else
                        {
                            if (s.contEmpqCompra > 0)
                            {
                                _costoUnd = (s.costoCompra / s.contEmpqCompra);
                            }
                            _costo = (_costoUnd * s.contEmpq);
                            if (aplicarTraslado.TasaSistema > 0m)
                            {
                                _pDivisaFull = s.pNeto / aplicarTraslado.TasaSistema;
                            }
                            else 
                            {
                                throw new Exception("TASA SISTEMA NO DEFINADA");
                            }
                        }
                        var it = new OOB.PedidoWeb.ItemPisoVentaTrasladar()
                        {
                            categoriaPrd = s.categoriaPrd,
                            cntSolicitada = s.CntDisponibleParaTrasladar,
                            codigoPrd = s.codigoPrd,
                            contEmpq = s.contEmpq,
                            costoCompra = _costo,
                            costoProm = _costo,
                            costoPromUnd = _costoUnd,
                            costoUnd = _costoUnd,
                            decimalesPrd = s.decimalesPrd,
                            descEmpq = s.descEmpq,
                            estatusDivisa = s.isAdmDivisa ? "1" : "0",
                            estatusPesado = s.estatusPesado,
                            idDepartamento = s.idDepartamento,
                            idGrupo = s.idGrupo,
                            idProducto = s.idProducto,
                            idSubGrupo = s.idSubGrupo,
                            idTasaFiscal = s.idTasaFiscal,
                            nombrePrd = s.nombrePrd,
                            pDivisaFull = _pDivisaFull,
                            pesoPrd = s.pesoPrd,
                            pNeto = s.pNeto,
                            tasaFiscal = s.tasaFiscal,
                            volumenPrd = s.volumenPrd,
                        };
                        return it;
                    }).ToList(),
                    PrdBloquearEx = aplicarTraslado.Items.Where(w => w.CntDisponibleParaTrasladar > 0).Select(s =>
                    {
                        var ex = new OOB.PedidoWeb.PrdBloqueoExTrasladar()
                        {
                            CntBloquear = s.CntDisponibleParaTrasladar * s.contEmpq,
                            IdProducto = s.idProducto,
                        };
                        return ex;
                    }).ToList(),
                };
                var rt = Sistema.MyData.PedidoWeb_AplicarTrasladoPisoventa(aplicar);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string 
            VerificarExistenciaEntidadWebEnCliente(string cadena)
        {
            try
            {
                var rt = Sistema.MyData.Cliente_GetFichaByCiRif(cadena);
                if (rt.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                return rt.Entidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Models.EntidadWeb 
            ObtenerEntidadWebSegunIdCliente(string idCliente)
        {
            try
            {
                var rt = Sistema.MyData.Cliente_GetFicha(idCliente);
                if (rt.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                if (rt.Entidad ==null)
                {
                    throw new Exception("ERROR AL CARGAR CLIENTE");
                }
                var c = rt.Entidad;
                return new Models.EntidadWeb()
                {
                    CiRifCliente = c.CiRif,
                    CodigoCliente = c.Codigo,
                    DirFiscalCliente = c.DireccionFiscal,
                    IdCliente = c.Id,
                    IsActivoCliente = c.Estatus.Trim().ToUpper() == "ACTIVO",
                    IsActivoCredito = c.EstatusCredito.Trim().ToUpper() == "1",
                    NombreCliente = c.Nombre,
                    TelefonoCliente = c.Telefono,
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool 
            VerificarSiHayVtaEnProcesao(int idOperador)
        {
            try
            {
                var rt = Sistema.MyData.Venta_VerificarSiHayVtaEnProceso(idOperador);
                return rt.Entidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}