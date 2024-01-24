using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.CambioPrecioPrdComp.CambioPrecio.Handler
{
    public class dataPanel: Vista.IdataPanel
    {
        private string _producto;
        private decimal _precioActual;
        private decimal _utilidadActual;
        private decimal _precioNuevo ;
        private decimal _utilidadNueva;
        private decimal _costoEmpVta;
        private string _manejadoPorDivisa;
        private decimal _tasaDivisaSist;
        private string _tasaIva;
        private decimal _tasaPos;
        private decimal _tasaBonoAplicar;
        private string _empqVtaActual;
        //
        public string producto { get { return _producto; } }
        public decimal precioActual { get { return _precioActual; } }
        public decimal utilidadActual { get { return _utilidadActual; } }
        public decimal precioNuevo { get { return _precioNuevo; } }
        public decimal utilidadNueva { get { return _utilidadNueva; } }
        public decimal costoEmpVta { get { return _costoEmpVta; } }
        public string manejadoPorDivisa { get { return _manejadoPorDivisa ; } }
        public decimal tasaDivisaSist { get { return _tasaDivisaSist ; } }
        public string tasaIva { get { return _tasaIva; } }
        public decimal tasaPos { get { return _tasaPos; } }
        public decimal tasaBonoAplicar { get { return _tasaBonoAplicar; } }
        public string EmpqVtaActual { get { return _empqVtaActual; } }
        //
        public dataPanel()
        {
            _producto = "";
            _precioActual = 0m;
            _utilidadActual = 0m;
            _precioNuevo = 0m;
            _utilidadNueva = 0m;
            _costoEmpVta = 0m;
            _manejadoPorDivisa = "";
            _tasaDivisaSist = 0m;
            _tasaIva = "";
            _tasaPos=0m;
            _tasaBonoAplicar=0m;
            _empqVtaActual = "";
        }
        //
        public void Inicializa()
        {
            _producto = "";
            _precioActual = 0m;
            _utilidadActual = 0m;
            _precioNuevo = 0m;
            _utilidadNueva = 0m;
            _costoEmpVta = 0m;
            _manejadoPorDivisa = "";
            _tasaDivisaSist = 0m;
            _tasaIva = "";
            _tasaPos = 0m;
            _tasaBonoAplicar = 0m;
            _empqVtaActual = "";
        }
        public void setInfProducto(string desc)
        {
            _producto = desc;
        }
        public void setPrecioActual(decimal prec)
        {
            _precioActual = prec;
        }
        public void setUtilidadActual(decimal ut)
        {
            _utilidadActual = ut;
        }
        public void setPrecioNuevo(decimal precio)
        {
            _precioNuevo = precio;
        }
        public void setUtilidadNueva(decimal ut)
        {
            _utilidadNueva = ut;
        }
        public void setCostoEmpVta(decimal costo)
        {
            _costoEmpVta = costo;
        }
        public void setManejadoPorDivisa(string desc)
        {
            _manejadoPorDivisa = desc;
        }
        public void setTasaDivisaSist(decimal tasa)
        {
            _tasaDivisaSist = tasa;
        }
        public void setTasaIvaPrd(string desc)
        {
            _tasaIva = desc;
        }
        public void setTasaPos(decimal tasa)
        {
            _tasaPos = tasa;
        }
        public void setTasaBonoAplicar(decimal tasa)
        {
            _tasaBonoAplicar = tasa;
        }
        public void setEmpqVtaActual(string desc)
        {
            _empqVtaActual = desc;
        }
    }
}