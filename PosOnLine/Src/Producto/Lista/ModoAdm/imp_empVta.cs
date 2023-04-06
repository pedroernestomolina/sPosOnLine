using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista.ModoAdm
{
    public class imp_empVta: IEmpVta
    {
        private int _cont;
        private decimal _neto;
        private decimal _fullDivisa;
        private string _desc;
        private DateTime _desdeOferta;
        private DateTime _hastaOferta;
        private string _estatusOferta;
        private decimal _porctOferta;
        private bool _admDivisa;
        private decimal _tasaIva;
        private decimal _tasaCambio;
        private bool _visible;


        public string GetDesc { get { return _desc + "/ (" + _cont.ToString("n0") + ")"; } }
        public string GetPrecio { get { return Precio(); } }
        public string GetBono { get { return ""; } }
        public string GetOferta { get { return Oferta(); } }
        public bool GetVisible { get { return _visible; } }


        public imp_empVta()
        {
            _cont = 0;
            _neto = 0m;
            _fullDivisa = 0m;
            _desc = "";
            _tasaIva = 0m;
            _admDivisa = false;
            _tasaCambio = 0m;
            _visible = true;
            _estatusOferta = "";
            _desdeOferta = DateTime.Now.Date;
            _hastaOferta = DateTime.Now.Date;
            _porctOferta = 0m;

        }


        public void setPNeto(decimal monto)
        {
            _visible = monto > 0m;
            _neto = monto;
        }
        public void setEmpCont(int cont)
        {
            _cont = cont;
        }
        public void setEmpDesc(string desc)
        {
            _desc = desc;
        }
        public void setPFullDivisa(decimal monto)
        {
            _fullDivisa = monto;
        }
        public void setOferta(string estatus, DateTime desde, DateTime hasta, decimal porct)
        {
            _desdeOferta = desde;
            _hastaOferta = hasta;
            _porctOferta = porct;
            _estatusOferta = estatus;
        }
        public void setTasaIva(decimal tasa)
        {
            _tasaIva = tasa;
        }
        public void setAdmDivisa(bool adm)
        {
            _admDivisa = adm;
        }
        public void setTasaCambio(decimal tasa)
        {
            _tasaCambio = tasa;
        }


        private string Precio()
        {
            var p = "";
            if (_admDivisa)
            {
                var _monedaLocal=(_fullDivisa*_tasaCambio);
                p += _monedaLocal.ToString("n2") + "/ ( $ " + _fullDivisa.ToString("n2") + ")";
            }
            else 
            {
                var _monedaLocal = Full(_neto);
                var _divisa = 0m;
                if (_tasaCambio > 0m) 
                {
                    _divisa = _monedaLocal / _tasaCambio;
                }
                p += _monedaLocal.ToString("n2") + "/ ( $ " + _divisa.ToString("n2") + ")";
            }
            return p;
        }
        private decimal Full(decimal neto)
        {
            var p = neto;
            if (_tasaIva>0m)
            {
                p += (p * (1 + (_tasaIva / 100m)));
            }
            return p;
        }
        private string Oferta()
        {
            var p = "";
            var _isOfertaActiva= _estatusOferta.Trim().ToUpper()=="1";
            if (_isOfertaActiva) 
            {
                var _fecActual =DateTime.Now.Date;
                if (_fecActual >= _desdeOferta && _fecActual <= _hastaOferta)
                {
                    p = "HASTA: " + _hastaOferta.ToShortDateString() + Environment.NewLine + "Dscto(%): " + _porctOferta.ToString("n2");
                }
            }
            return p;
        }
    }
}