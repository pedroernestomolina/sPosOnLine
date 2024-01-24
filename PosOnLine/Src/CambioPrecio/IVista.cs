using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CambioPrecio
{
    public interface IVista: ICambioPrecio
    {
        string Inf_Producto { get; }
        decimal Inf_PrecioActual { get; }
        decimal GetPrecioNuevo { get; }
        bool AbandonarIsOk { get; }
        bool ProcesarIsOk { get; }

        void setPrecioNuevo(decimal pn);
        void Abandonar();
        void Procesar();
    }
}