using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.Listar.Vista
{
    public interface IVista: IGestion
    {
        IListaCliente Lista { get; }
       void setListaCargar(IEnumerable<object> lst);
    }
}