using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.Procesar
{
    
    public class PgDivisa
    {

        private bool _habilitarBono;
        private decimal _tasaBono;
        private decimal _tasaDivisa;


        public PgDivisa()
        {
            _habilitarBono = false;
            _tasaBono = 0m;
            _tasaDivisa = 0m;
        }

        public void setHabilitarBono(bool habilita) 
        {
            _habilitarBono = habilita;
        }
        public void setTasaBono(decimal tasa)
        {
            _tasaBono = tasa;
        }
        public void setTasaDivisa(decimal tasa)
        {
            _tasaDivisa = tasa;
        }
        public void AgregarPago(decimal montoSeRecibeEnDivisa, decimal montoPendBs) 
        {
            _montoBonoDivisa = 0m;
            _montoBonoBs = 0m;
            _montoRecibeBs = 0m;
            var _factorBono = 0m;
            if (_habilitarBono)
            {
                _factorBono = (_tasaBono / 100);
            }
            var _montoPendDiv = Math.Round(montoPendBs / _tasaDivisa, 2, MidpointRounding.AwayFromZero);
            var rt = (_montoPendDiv / (1 + _factorBono));
            var _cntDivisaTomar = 0m;
            _cntDivisaTomar = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            if (_cntDivisaTomar > 0m)
            {
                if (montoSeRecibeEnDivisa < _cntDivisaTomar)
                {
                    _cntDivisaTomar = (int)montoSeRecibeEnDivisa;
                }
            }
            _montoBonoDivisa = _cntDivisaTomar * _factorBono;
            _montoBonoBs = Math.Round(_montoBonoDivisa * _tasaDivisa, 2, MidpointRounding.AwayFromZero);
            _montoRecibeBs = Math.Round(montoSeRecibeEnDivisa * _tasaDivisa, 2, MidpointRounding.AwayFromZero);
            _cntDivisaRecomendar = _cntDivisaTomar;
        }

        private decimal _montoBonoDivisa;
        private decimal _montoBonoBs;
        private decimal _montoRecibeBs;
        private decimal _cntDivisaRecomendar;
        public decimal GetMontoBonoBs { get { return _montoBonoBs; } }
        public decimal GetMontoRecibeBs { get { return _montoRecibeBs; } }
        public decimal GetMontoBonoDivisa { get { return _montoBonoDivisa; } }
        public decimal GetCntDivisaRecomendar { get { return _cntDivisaRecomendar; } }

    }

}