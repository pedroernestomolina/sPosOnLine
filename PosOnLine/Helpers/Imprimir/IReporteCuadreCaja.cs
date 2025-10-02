using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    public interface IReporteCuadreCaja
    {
        void setData(dataCuadre ds);
        void setListaDataImprimir(List<string> lst); 
        void ImprimirDoc();
        void ImprimirDocLista();
    }
}