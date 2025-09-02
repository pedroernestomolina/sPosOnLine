using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.vm
{
    public class AplicarBonoImpl: IAplicarBono
    {
        public decimal aplicar(dataAplicar data)
        {
            var rt = 0m;
            //
            var _bonoMaxAceptar = (data.montoTotalDivisa * data.porctBono) / 100m;
            _bonoMaxAceptar = Math.Round(_bonoMaxAceptar, 2, MidpointRounding.AwayFromZero);
            //
            var _montoMaxPagarDivisa = data.montoTotalDivisa-_bonoMaxAceptar;
            _montoMaxPagarDivisa = Math.Round(_montoMaxPagarDivisa, 2, MidpointRounding.AwayFromZero);
            //
            if (_montoMaxPagarDivisa >= data.montoAplicarBono)
            {
                rt = (data.montoAplicarBono * _bonoMaxAceptar) / _montoMaxPagarDivisa;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            else 
            {
                rt = _bonoMaxAceptar;
            }
            //
            return rt;
        }
        public decimal 
            calcularMaxMontoPagarDivisa(dataCalcularMaxMontoPagarDivisa data)
        {
            var rt = 0m;
            //
            var _bonoMaxAceptar = (data.montoTotalDivisa * data.porctBono) / 100m;
            _bonoMaxAceptar = Math.Round(_bonoMaxAceptar, 2, MidpointRounding.AwayFromZero);
            //
            var _montoMaxPagarDivisa = data.montoTotalDivisa - _bonoMaxAceptar;
            _montoMaxPagarDivisa = Math.Round(_montoMaxPagarDivisa, 2, MidpointRounding.AwayFromZero);
            //
            rt = _montoMaxPagarDivisa;
            //
            return rt;
        }
    }
}
