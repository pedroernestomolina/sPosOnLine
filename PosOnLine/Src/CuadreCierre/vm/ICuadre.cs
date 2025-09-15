using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.vm
{
    public interface ICuadre: IGestion
    {
        object Get_MetodosPagoSource { get; }
        //
        void ActualizarImporteMetodoPago();
    }
}
