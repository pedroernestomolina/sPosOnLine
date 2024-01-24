using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.AgregarEditar.Vista
{
    public interface IAgregar: IAgregarEditar
    {
        string IdNewCliente { get; }
        void setCiRif(string cirif);
    }
}