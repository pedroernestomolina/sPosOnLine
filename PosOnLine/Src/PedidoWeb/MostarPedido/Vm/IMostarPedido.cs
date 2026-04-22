using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.MostarPedido.Vm
{
    public interface IMostarPedido
    {
        object Get_DetallesSource { get; }
        //
        void setIdPedidoMostrar(int id);
        //
        void Invoke();
    }
}