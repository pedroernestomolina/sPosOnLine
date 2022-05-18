using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista
{

    public class data
    {

        private OOB.Producto.Lista.Ficha _item;


        public OOB.Producto.Lista.Ficha Item { get { return _item; } }
        public string Id { get { return _item.Auto; } }
        public string codigo { get { return _item.Codigo; } }
        public string nombre { get { return _item.Nombre; } }
        public decimal precio { get { return _item.PrecioFullDivisa; } }
        public string plu { get { return _item.PLU; } }
        public decimal precioMay { get { return _item.PrecioFullDivisaMay; } }
        public string empaqueMay 
        { 
            get 
            {
                var rt = "";
                if (_item.PrecioFullDivisaMay > 0) 
                {
                    rt="MAY/" + _item.ContenidoMay.ToString(); 
                }
                return rt;
            } 
        }

        public decimal cantidadEx 
        { 
            get 
            { 
                var x= 0.0m;
                if (_item.Contenido > 0) 
                {
                    x = _item.ExDisponible;
                        // / _item.Contenido;
                }
                return x;
            } 
        }


        public data()
        {
        }


        public data(OOB.Producto.Lista.Ficha it)
        {
            _item = it;
        }

    }

}