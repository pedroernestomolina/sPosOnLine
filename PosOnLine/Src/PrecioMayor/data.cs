using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PrecioMayor
{
    
    public class data
    {

        private string _id;
        private string _etiqueta;
        private string _empaque;
        private int _contenido;
        private decimal _pNeto;
        private decimal _pDivisa;


        public string ID { get { return _id; } }
        public string Etiqueta { get { return _etiqueta; } }
        public string Empaque { get { return _empaque+"/"+_contenido.ToString().Trim(); } }
        public decimal PNeto { get { return _pNeto; } }
        public decimal PDivisa { get { return _pDivisa; } }


        public data()
        {
            _id = "";
            _etiqueta = "";
            _empaque = "";
            _contenido = 0;
            _pNeto=0.0m;
            _pDivisa = 0m;
        }

        public data(string _id, string _et, precio ficha)
            : this()
        {
            this._id = _id;
            this._etiqueta = _et;
            this._empaque = ficha.DescEmpVenta;
            this._contenido = ficha.ContEmpVenta;
            this._pNeto = ficha.PrecioNeto;
            this._pDivisa = ficha.PDivisa;
        }

    }

}