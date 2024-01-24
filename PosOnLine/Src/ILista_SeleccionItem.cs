using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src
{
    public interface ILista_SeleccionItem
    {
        bool ItemSeleccionadoIsOk { get; }
        object ItemSeleccionado { get; }
        void Met_SeleccionarItem();
    }
}