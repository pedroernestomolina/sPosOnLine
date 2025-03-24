using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor.ZUFU
{
    public class Existencia
    {
        private OOB.Producto.Existencia.Entidad.Ficha _ficha;
        private int _contenido;
        //
        public decimal Cantidad { get { return disponible(); } }
        public bool HayDisponibilidad { get { return Cantidad > 0; } }
        //
        public Existencia()
        {
            limpiar();
        }
        public void Inicializa()
        {
            limpiar();
        }
        public void setData(OOB.Producto.Existencia.Entidad.Ficha fichaEx, int p)
        {
            _ficha = fichaEx;
            _contenido = p;
        }
        //
        private decimal disponible()
        {
            var x = 0m;
            if (_contenido > 0)
            {
                x = _ficha.exDisponible;
            }
            return x;
        }
        public void limpiar()
        {
            _ficha = null;
            _contenido = 0;
        }
    }
}