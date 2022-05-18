using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CambioPrecio
{
    
    public interface ICambioPrecio: IGestion
    {

        bool CambioPrecioIsOk { get; }
        decimal PrecioNuevo { get; }


        void setDataItem(Item.data data);


        void Abandonar();
        bool AbandonarIsOk { get; }
        bool ProcesarIsOk { get; }
        void Procesar();


        string Inf_Producto { get; }
        decimal Inf_PrecioActual { get; }
        decimal  GetPrecioNuevo { get; }
        void setPrecioNuevo(decimal pn);

    }

}