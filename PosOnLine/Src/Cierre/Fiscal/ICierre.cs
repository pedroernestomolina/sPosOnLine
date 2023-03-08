using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cierre.Fiscal
{
    public interface ICierre:IGestion, Helpers.IAbandonar
    {
        void ReporteX();
        void ReporteZ();
        void CierreNoFiscal();
    }
}