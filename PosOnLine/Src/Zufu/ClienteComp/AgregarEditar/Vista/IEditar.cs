using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.AgregarEditar.Vista
{
    public interface IEditar : IAgregarEditar
    {
        void setIdEditar(string id);
    }
}