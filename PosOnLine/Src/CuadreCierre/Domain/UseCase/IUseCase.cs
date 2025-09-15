using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.Domain.UseCase
{
    public interface IUseCase
    {
        Domain.Models.DataResumenRecolectada
            CuadreResumen(int id);
    }
}