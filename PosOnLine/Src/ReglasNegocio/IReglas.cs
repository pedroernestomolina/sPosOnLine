using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.ReglasNegocio
{
    public interface IReglas
    {
        bool MontoAplicarNotaEntregaSinIva();
        bool DocVentaProcesar_EsCredito_MontoCobrar_AplicarBonoFull();
    }
}