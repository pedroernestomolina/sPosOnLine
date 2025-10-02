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
        private List<string> _lstDataImprimir;
        //
        public List<string> ListaDataImprimir { get { return _lstDataImprimir; } }
        //
        public baseImprimirReporteCuadreCaja()
        {
        }
        public void setData(dataCuadre ds)
        {
            _ds = ds;
        }
        public void setListaDataImprimir(List<string> lst) 
        {
            _lstDataImprimir = lst;
        }
        abstract public void ImprimirDoc();
        abstract public void ImprimirDocLista();
    }
}