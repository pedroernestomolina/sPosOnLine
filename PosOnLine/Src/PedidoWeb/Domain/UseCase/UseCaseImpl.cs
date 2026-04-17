using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
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
                rt= r01.ListaD.Select(s =>
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
                        EstatusActual =  Models.EnumEstatusActual.SinProcesar,
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
    }
}
