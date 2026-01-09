using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.CtrlPendiente.__.Domain.UseCase
{
    public interface IUseCase
    {
        bool VerificaSiCuentaAbrirEstaProtegida(int idCta);
    }
}