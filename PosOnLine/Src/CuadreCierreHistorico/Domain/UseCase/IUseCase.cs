using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreHistorico.Domain.UseCase
{
    public interface IUseCase
    {
        List<Models.Cierre> 
            CargarListaCierresHistorico();
    }
}