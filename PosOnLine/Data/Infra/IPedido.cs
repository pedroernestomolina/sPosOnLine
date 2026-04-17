using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface IPedido
    {
        OOB.Resultado.Ficha
            PedidoWeb_ObtenerListaPedidos(OOB.Pedido.Guardar.Ficha ficha);
        OOB.Resultado.FichaEntidad<int>
            Pedido_GetIdBy_Numero(int numero);
        OOB.Resultado.Ficha
            Pedido_TrasladarVenta(OOB.Pedido.TrasladarVenta.Ficha ficha);
        OOB.Resultado.FichaEntidad<OOB.Pedido.ListaResumen.Entidad>
            Pedido_GetListaResumen(OOB.Pedido.ListaResumen.Filtros filtros);
    }
}