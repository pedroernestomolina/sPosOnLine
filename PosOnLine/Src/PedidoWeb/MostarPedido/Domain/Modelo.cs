using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.MostarPedido.Domain
{
    public class Modelo
    {
        public PedidoWeb.Domain.Models.PedidoWeb Pedido { get; set; }
        //
        public Modelo()
        {
            Pedido = new PedidoWeb.Domain.Models.PedidoWeb();
        }
        //
        public void Limpiar()
        {
            Pedido = new PedidoWeb.Domain.Models.PedidoWeb();
        }
    }
}