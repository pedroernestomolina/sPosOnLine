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

        public Models.CapturarTraslado
            CapturarTrasladoPisoVenta(int idPedido)
        {
            var rt = new Models.CapturarTraslado();
            //
            try
            {
                var r01 = Sistema.MyData.PedidoWeb_CapturarTrasladoPisoventa(idPedido);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }

                if (r01.Entidad == null || r01.Entidad.Items == null)
                {
                    throw new Exception("No se encontraron items para trasladar.");
                }

                rt.Items = r01.Entidad.Items.Select(item => new Models.ItemsTrasladar
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
                    exDisponible = item.exDisponible
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
            AplicarTrasladoPisoVenta(Models.AplicarTraslado aplicarTraslado)
        {
            try
            {
                var aplicar = new OOB.PedidoWeb.AplicarTrasladoPisoVenta()
                {
                    IdDeposito = aplicarTraslado.IdDeposito,
                    IdOperador = aplicarTraslado.IdOperador,
                    ItemsPisoVta = aplicarTraslado.Items.Where(w => w.CntDisponibleParaTrasladar > 0).Select(s => 
                    {
                        var it = new OOB.PedidoWeb.ItemPisoVentaTrasladar()
                        {
                            categoriaPrd = s.categoriaPrd,
                            cntSolicitada = s.CntDisponibleParaTrasladar,
                            codigoPrd = s.codigoPrd,
                            contEmpq = s.contEmpq,
                            costoCompra = s.costoCompra,
                            costoProm = s.costoProm,
                            costoPromUnd = s.costoPromUnd,
                            costoUnd = s.costoUnd,
                            decimalesPrd = s.decimalesPrd,
                            descEmpq = s.descEmpq,
                            estatusDivisa = s.estatusDivisa,
                            estatusPesado = s.estatusPesado,
                            idDepartamento = s.idDepartamento,
                            idGrupo = s.idGrupo,
                            idProducto = s.idProducto,
                            idSubGrupo = s.idSubGrupo,
                            idTasaFiscal = s.idTasaFiscal,
                            nombrePrd = s.nombrePrd,
                            pDivisaFull = s.pDivisaFull,
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
    }
}