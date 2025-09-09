using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.vm
{
    public class AplicarBonoImpl: IAplicarBono
    {
        public bonoAplicado aplicar(dataAplicar data)
        {
            var _bonoMaxAceptar = (data.montoTotalDivisa * data.porctBono) / 100m;
            _bonoMaxAceptar = Math.Round(_bonoMaxAceptar, 2, MidpointRounding.AwayFromZero);
            //
            var _montoMaxPagarDivisa = data.montoTotalDivisa-_bonoMaxAceptar;
            _montoMaxPagarDivisa = Math.Round(_montoMaxPagarDivisa, 2, MidpointRounding.AwayFromZero);
            //
            var rt = 0m;
            var _montoQueAplicaBono=0m;
            if (_montoMaxPagarDivisa >= data.montoAplicarBono)
            {
                rt = (data.montoAplicarBono * _bonoMaxAceptar) / _montoMaxPagarDivisa;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                _montoQueAplicaBono= data.montoAplicarBono;
            }
            else 
            {
                rt = _bonoMaxAceptar;
                _montoQueAplicaBono= _montoMaxPagarDivisa;
            }
            //
            var bn = new bonoAplicado()
            {
                MontoSobreElCualAplicaBono_MonReferencia = _montoQueAplicaBono,
                MontoBono_MonReferencia = rt,
            };
            return bn;
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
        public decimal 
            calcularMaxBonoPorPagoDivisa(dataCalcularMaxMontoPagarDivisa data)
        {
            var rt = 0m;
            //
            rt = (data.montoTotalDivisa * data.porctBono) / 100m;
            rt= Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            //
            return rt;
        }
    }
}