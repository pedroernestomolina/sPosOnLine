using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor
{
    

    public class Existencia
    {


        private OOB.Producto.Existencia.Entidad.Ficha _ficha;
        private int _contenido;


        public decimal Cantidad 
        { 
            get 
            {
                var x = 0.0m;
                if (_contenido > 0) 
                {
                    x = _ficha.exDisponible ; 
                }
                return x; 
            } 
        }
        public bool HayDisponibilidad { get { return Cantidad > 0; } }


        public Existencia()
        {
            Limpiar();
        }


        public void Limpiar()
        {
            _ficha = null;
            _contenido = 0;
        }

        public void setData(OOB.Producto.Existencia.Entidad.Ficha fichaEx, int p)
        {
            _ficha = fichaEx;
            _contenido = p;
        }

    }

}