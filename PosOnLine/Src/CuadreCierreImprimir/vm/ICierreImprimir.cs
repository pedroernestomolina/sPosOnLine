using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreImprimir.vm
{
    public interface ICierreImprimir
    {
        void setIdOperador(int id);
        void Generar();
    }
}