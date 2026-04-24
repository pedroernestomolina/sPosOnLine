using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.TrasladarPisoVta.Vm
{
    public interface ITrasladarPisoVta
    {
        void setIdPedidoTrasaldar(int idPedido);
        //
        bool TrasladoPisoVtaExitoso { get; }
        //
        void Invoke();
    }
}