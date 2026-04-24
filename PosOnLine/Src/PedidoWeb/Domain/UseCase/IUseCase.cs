using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.Domain.UseCase
{
    public interface IUseCase
    {
        IEnumerable<Domain.Models.PedidoWeb>
            ObtenerListaDePedidosWebActivosSinProcesar();

        Domain.Models.PedidoWeb
            CargarPedidoWebById(int idPedidoCargar);

        Domain.Models.CapturarTrasladoModel
            CapturarTrasladoPisoVenta(int idPedido);

        bool
            AplicarTrasladoPisoVenta(Models.AplicarTrasladoModel aplicarTraslado);

        string 
            VerificarExistenciaEntidadWebEnCliente(string cadena);

        Models.EntidadWeb
            ObtenerEntidadWebSegunIdCliente(string idEntidad);
    }
}