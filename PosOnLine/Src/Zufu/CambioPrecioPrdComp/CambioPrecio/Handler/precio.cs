using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.CambioPrecioPrdComp.CambioPrecio.Handler
{
    public class precio: Vista.IPrecio
    {
        private decimal _costo;
        private decimal _tasaBono;
        private decimal _costoApBono;
        private decimal _pneto;
        private decimal _tasaIva;
        private bool _modoBonoIncluido;
        private bool _estatusCambioModoBono;
        private __.Precio.IPrecio _pVenta;
        //
        public __.Precio.IPrecio Get_PrecioVta { get { return _pVenta; } }
        //
        public precio()
        {
            _costo = 0m;
            _pneto = 0m;
            _tasaIva = 0m;
            _tasaBono = 0m;
            _costoApBono = 0m;
            _modoBonoIncluido = true;
            _estatusCambioModoBono = false;
            _pVenta = new __.Precio.Imp();
        }
        public void Inicializa()
        {
            inicializar();
        }
        public void setPosTipoMoneda(__.Precio.Moneda.TipoMoneda tipoMoneda)
        {
        }
        public void setPosPrecioNeto(decimal pneto)
        {
            _pneto= pneto;
        }
        public void setPosCostoActual(decimal costo)
        {
            _costo = costo;
        }
        public void setPosTasaCambio(decimal tasa)
        {
        }
        public void setPosTasaIva(decimal tasa)
        {
            _tasaIva = tasa;
        }
        public void setPosBonoPorPagoEnDivisa(decimal tasaBono)
        {
            _tasaBono = tasaBono;
        }
        public void setModoBonoIncluido(bool modo)
        {
            _modoBonoIncluido= modo;
            _estatusCambioModoBono = !_estatusCambioModoBono;
        }
        public decimal PrecioSinBono(decimal precio)
        {
            return precioSinBono(precio);
        }
        public void Refresh()
        {
            var precio = 0m;
            if (_modoBonoIncluido)
            {
                _costoApBono = costoConBono(_costo);
                precio = _pneto;
            }
            else
            {
                _costoApBono = Math.Round(_costo, 2, MidpointRounding.AwayFromZero);
                precio = _pneto;
            }
            _pVenta.setCosto(_costoApBono);
            _pVenta.setPrecioNeto(precio);
            _pVenta.setTasaIva(_tasaIva);
            _pVenta.Refresh();
        }
        //
        private void inicializar()
        {
            _costo = 0m;
            _pneto = 0m;
            _tasaIva = 0m;
            _tasaBono = 0m;
            _costoApBono = 0m;
            _estatusCambioModoBono = false;
            _pVenta.Inicializa();
        }
        private decimal costoConBono(decimal costo)
        {
            var rt = 0m;
            rt = Math.Round(costo / ((100m - _tasaBono) / 100m), 2, MidpointRounding.AwayFromZero);
            return rt;
        }
        private decimal precioSinBono(decimal precio)
        {
            var rt = 0m;
            var tBono = (1m + (_tasaBono / 100m));
            rt = Math.Round(precio / tBono, 2, MidpointRounding.AwayFromZero);
            return rt;
        }
    }
}