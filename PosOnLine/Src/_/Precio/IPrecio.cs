using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.__.Precio
{
    public interface IPrecio
    {
        utilidad Get_Utilidad { get; }
        decimal Get_PNeto { get; }
        decimal Get_Costo { get; }
        decimal Get_PFull { get; }
        //
        void Inicializa();
        void setPrecioNeto(decimal pneto);
        void setTasaIva(decimal tasa);
        void setCosto(decimal costo);
        void Refresh();
        decimal CalcularNeto(decimal precio);
        decimal CalcularFull(decimal precio);
        utilidad CalcularUtilidad(decimal costo, decimal precio);
    }
}