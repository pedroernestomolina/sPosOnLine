using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.CtrlPendiente.Proteger.Domain.UseCase
{
    public interface IUseCase
    {
        void ProtegerCuenta(int idCta);
    }
}