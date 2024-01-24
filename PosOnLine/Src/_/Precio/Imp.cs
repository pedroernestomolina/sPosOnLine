using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.__.Precio
{
    public class utilidad 
    {
        public decimal monto { get; set; }
        public decimal porcent { get; set; }
        public utilidad()
        {
            monto = 0m;
            porcent = 0m;
        }
        public void Inicializa()
        {
            monto = 0m;
            porcent = 0m;
        }
    }
    public class Imp: IPrecio
    {
        private decimal _pneto;
        private decimal _pfull;
        private decimal _tasaIva;
        private decimal _costo;
        private utilidad _utilidad;
        //
        public decimal Get_PNeto { get { return _pneto; } }
        public utilidad Get_Utilidad { get { return _utilidad; } }
        public decimal Get_Costo { get { return _costo; } }
        public decimal Get_PFull { get { return full(_pneto); } }
        //
        public Imp()
        {
            _pneto = 0m;
            _pfull = 0m;
            _tasaIva = 0m;
            _costo = 0m;
            _utilidad = new utilidad();
        }
        public void Inicializa()
        {
            inicializar();
        }
        public void setPrecioNeto(decimal pneto)
        {
            _pneto = pneto;
        }
        public void setTasaIva(decimal tasa)
        {
            _tasaIva = tasa;
        }
        public void setCosto(decimal costo)
        {
            _costo = costo;
        }
        public void Refresh()
        {
            _pfull = full(_pneto);
            _utilidad = calcUtilidad(_costo, _pneto);
        }
        public decimal CalcularNeto(decimal precio)
        {
            return neto(precio);
        }

        public decimal CalcularFull(decimal precio)
        {
            return full(precio);
        }
        public utilidad CalcularUtilidad(decimal costo, decimal precio)
        {
            return calcUtilidad(costo, precio);
        }


        private void inicializar()
        {
            _pneto = 0m;
            _pfull = 0m;
            _tasaIva = 0m;
            _costo = 0m;
            _utilidad.Inicializa();
        }
        private decimal neto(decimal precio)
        {
            var rt = precio;
            if (_tasaIva > 0m)
            {
                rt /= (1m + (_tasaIva / 100m));
            }
            return rt;
        }
        private decimal full(decimal precio)
        {
            var rt = precio;
            if (_tasaIva > 0m)
            {
                rt += (precio * (_tasaIva / 100m));
            }
            return rt;
        }
        private utilidad calcUtilidad(decimal costo , decimal precio)
        {
            var rt = new utilidad(); 
            if (_pneto>0m)
            {
                var t1 = costo / precio ;
                t1 *= 100;
                rt.porcent = 100 - t1;
                rt.porcent = Math.Round(rt.porcent, 2, MidpointRounding.AwayFromZero);
                rt.monto = precio - costo;
            }
            return rt;
        }
    }
}