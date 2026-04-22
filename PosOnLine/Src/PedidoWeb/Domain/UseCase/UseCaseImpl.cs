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
    }
}