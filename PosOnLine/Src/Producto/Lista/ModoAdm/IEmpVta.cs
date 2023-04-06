using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista.ModoAdm
{
    public interface IEmpVta
    {
        string GetDesc { get; }
        string GetPrecio { get; }
        string GetBono { get; }
        bool GetVisible { get; }
        string GetOferta { get; }

        void setPNeto(decimal monto);
        void setEmpCont(int cont);
        void setEmpDesc(string desc);
        void setPFullDivisa(decimal monto);
        void setOferta(string estatus, DateTime desde, DateTime hasta, decimal porct);
        void setTasaIva(decimal tasa);
        void setAdmDivisa(bool adm);
        void setTasaCambio(decimal tasa);
    }
}