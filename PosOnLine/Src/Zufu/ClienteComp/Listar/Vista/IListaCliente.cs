using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.Listar.Vista
{
    public interface IListaCliente: ILista, ILista_SeleccionItem
    {
        void Met_SubirItem();
        void Met_BajarItem();
    }
}