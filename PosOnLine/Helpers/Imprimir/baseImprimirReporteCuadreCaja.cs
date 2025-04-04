using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    abstract public class baseImprimirReporteCuadreCaja: IReporteCuadreCaja
    {
        protected dataCuadre _ds;
        //
        public baseImprimirReporteCuadreCaja()
        {
        }
        public void setData(dataCuadre ds)
        {
            _ds = ds;
        }
        abstract public void ImprimirDoc();
    }
}