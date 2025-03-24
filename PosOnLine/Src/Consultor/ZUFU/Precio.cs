using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor.ZUFU
{
    public class Precio
    {
        private decimal _neto;
        private decimal _tasa;
        private int _cont;
        private string _empaque;
        private decimal _fullDivisa;
        private decimal _factorCambio;
        //
        public decimal Neto { get { return _neto; } }
        public decimal Iva { get { return calIva(); } }
        public decimal Full { get { return calFull(); } }
        public decimal FullDivisa { get { return calDivisa(); } }
        public string EmpaqueContenidoDescripcion { get { return descEmpqCont(); } }
        //
        public Precio()
        {
            limpiar();
        }
        public void Inicializa()
        {
            limpiar();
        }
        public void setData(decimal neto, decimal tasa, int cont, string empaque, decimal pfd, decimal factorCambio)
        {
            _tasa = tasa;
            _neto= neto;
            _cont = cont;
            _empaque = empaque;
            _fullDivisa = pfd;
            _factorCambio = factorCambio;
        }
        //
        private decimal calIva()
        {
            var rt = 0.0m;
            rt = _neto * _tasa / 100;
            return rt;
        }
        private decimal calFull()
        {
            var rt = 0.0m;
            rt = _neto + calIva();
            rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            return rt;
        }
        private decimal calDivisa()
        {
            var rt = 0m;
            var _full = calFull();
            if (_factorCambio > 0m)
                rt = _full / _factorCambio;
            return rt;
        }
        private string descEmpqCont()
        {
            var rt = "";
            rt = _empaque + "(" + _cont.ToString("n0") + ")";
            return rt;
        }
        private void limpiar()
        {
            _tasa = 0.0m;
            _neto = 0.0m;
            _cont = 0;
            _empaque = "";
            _fullDivisa = 0.0m;
        }
    }
}