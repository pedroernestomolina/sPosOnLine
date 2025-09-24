using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreProceso.Domain.UseCase
{
    public interface IUseCase
    {
        void CerrarPos(Models.CierreFicha _cierreFicha);
    }
}
