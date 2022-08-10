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

        public string Empaque_1 { get { return _item.descEmp_1 + "/ (" + _item.contEmp_1.ToString("n0") + ")"; } }
        public string Empaque_2 { get { return _item.descEmp_2 + "/ (" + _item.contEmp_2.ToString("n0") + ")"; } }
        public string Empaque_3 { get { return _item.descEmp_3 + "/ (" + _item.contEmp_3.ToString("n0") + ")"; } }
        public string Precio_1 { get { return full(_item.pnetoEmp_1).ToString("n2") + "/ ( $ " + _item.pfullDivEmp_1.ToString("n2") + ")"; } }
        public string Precio_2 { get { return full(_item.pnetoEmp_2).ToString("n2") + "/ ( $ " + _item.pfullDivEmp_2.ToString("n2") + ")"; } }
        public string Precio_3 { get { return full(_item.pnetoEmp_3).ToString("n2") + "/ ( $ " + _item.pfullDivEmp_3.ToString("n2") + ")"; } }


        public data()
        {
        }


        public data(OOB.Producto.Lista.Ficha it)
        {
            _item = it;
        }


        private decimal full(decimal p)
        {
            var rt = p;
            if (_item.TasaIva > 0) 
            {
                rt = rt + (p * _item.TasaIva / 100);
            }
            return rt;
        }

    }

}