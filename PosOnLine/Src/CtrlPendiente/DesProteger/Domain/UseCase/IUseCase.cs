using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.CtrlPendiente.DesProteger.Domain.UseCase
{
    public interface IUseCase
    {
        void DesProtegerCuenta(int idCta);
    }
}