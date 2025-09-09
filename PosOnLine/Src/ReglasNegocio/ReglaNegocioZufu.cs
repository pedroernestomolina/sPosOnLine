using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.ReglasNegocio
{
    public class ReglaNegocioZufu: IReglas
    {
        public bool MontoAplicarNotaEntregaSinIva()
        {
            return false;
        }
        public bool DocVentaProcesar_EsCredito_MontoCobrar_AplicarBonoFull()
        {
            return true;
        }
    }
}