using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreHistorico.vm
{
    public interface IHistorico: IGestion
    {
        object Get_ListaCierreSource { get; }
        void Invoke();
        void imprimirCierre();
        void repoVentaredito();
        void repoPagoDetalle();
        void repoPagoResumen();
    }
}