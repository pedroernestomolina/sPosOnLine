using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cierre.NoFiscal
{
    public interface INoFiscal: IGestion
    {
        bool CierreIsOk { get; }
    }
}