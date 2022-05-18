using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor
{

    public class Precio
    {

        private decimal _neto;
        private decimal _tasa;
        private int _cont;
        private string _empaque;
        private decimal _fullDivisa;


        public decimal Neto
        {
            get
            {
                var rt = 0.0m;
                rt = _neto; 
                return rt;
            }
        }

        public decimal Iva
        {
            get
            {
                var rt = 0.0m;
                rt = _neto * _tasa / 100;
                return rt;
            }
        }

        public decimal Full
        {
            get
            {
                var rt = 0.0m;
                rt = Neto + Iva;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }

        public decimal FullDivisa 
        {
            get 
            {
                return _fullDivisa;
            }
        }

        public string ContenidoDescripcion 
        {
            get 
            {
                var rt = "";
                rt = _cont.ToString("n0")+" Unidades";
                return rt;
            }
        }

        public int Contenido 
        {
            get
            {
                return _cont;
            }
        }

        public string EmpaqueContenidoDescripcion
        {
            get
            {
                var rt = "";
                rt = _empaque+"("+_cont.ToString("n0") +")";
                return rt;
            }
        }

        public Precio()
        {
            Limpiar();
        }

        public void setData(decimal neto, decimal tasa, int cont, string empaque, decimal pfd)
        {
            _tasa = tasa;
            _neto= neto;
            _cont = cont;
            _empaque = empaque;
            _fullDivisa = pfd;
        }

        public void Limpiar()
        {
            _tasa = 0.0m;
            _neto = 0.0m;
            _cont = 0;
            _empaque = "";
            _fullDivisa = 0.0m;
        }

    }

}