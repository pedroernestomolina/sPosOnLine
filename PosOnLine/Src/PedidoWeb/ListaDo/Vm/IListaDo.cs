using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.ListaDo.Vm
{
    public interface IListaDo
    {
        object Get_SourceData { get; }
        //
        void Invoke();
    }
}
