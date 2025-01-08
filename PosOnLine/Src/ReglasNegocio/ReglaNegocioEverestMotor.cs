using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.ReglasNegocio
{
    public class ReglaNegocioEverestMotor: IReglas
    {
        public bool MontoAplicarNotaEntregaSinIva()
        {
            return true;
        }
    }
}