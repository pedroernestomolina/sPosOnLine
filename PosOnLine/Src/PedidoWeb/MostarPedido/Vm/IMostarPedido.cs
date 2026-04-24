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
        int Get_PedidoNro { get; }
        string Get_EntidadPedido { get; }
        //
        void setIdPedidoMostrar(int id);
        //
        void Invoke();
    }
}