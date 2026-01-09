using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.CtrlPendiente.Proteger.vm
{
    public interface IProteger
    {
        void ProtegerCuenta(int idCta);
    }
}