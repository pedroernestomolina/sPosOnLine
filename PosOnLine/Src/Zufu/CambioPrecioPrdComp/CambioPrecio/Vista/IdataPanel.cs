using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.CambioPrecioPrdComp.CambioPrecio.Vista
{
    public interface IdataPanel
    {
        string producto { get; }
        decimal precioActual { get; }
        decimal utilidadActual { get; }
        decimal precioNuevo { get; }
        decimal utilidadNueva { get; }
        decimal costoEmpVta { get; }
        string manejadoPorDivisa { get; }
        decimal tasaDivisaSist { get; }
        string tasaIva { get; }
        decimal tasaPos { get; }
        decimal tasaBonoAplicar { get; }
        string EmpqVtaActual { get; }
        //
        void Inicializa();
        void setInfProducto(string desc);
        void setPrecioActual(decimal prec);
        void setUtilidadActual(decimal ut);
        void setPrecioNuevo(decimal precio);
        void setUtilidadNueva(decimal ut);
        void setCostoEmpVta(decimal costo);
        void setManejadoPorDivisa(string desc);
        void setTasaDivisaSist(decimal tasa);
        void setTasaIvaPrd(string desc);
        void setTasaPos(decimal tasa);
        void setTasaBonoAplicar(decimal tasa);
        void setEmpqVtaActual(string desc);
    }
}