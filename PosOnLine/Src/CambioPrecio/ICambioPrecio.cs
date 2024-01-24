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
        void setUsuarioAutoriza(object usuario);
    }
}