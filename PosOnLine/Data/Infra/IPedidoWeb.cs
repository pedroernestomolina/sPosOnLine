using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Data.Infra
{
    public interface IPedidoWeb
    {
        OOB.Resultado.Lista<OOB.PedidoWeb.Entidad>
            PedidoWeb_ObtenerListaPedidos(OOB.PedidoWeb.FiltrarLista ficha);
    
        OOB.Resultado.FichaEntidad<OOB.PedidoWeb.Entidad>
            PedidoWeb_ObtenerUnPedido(int idPedido);
    }
}
