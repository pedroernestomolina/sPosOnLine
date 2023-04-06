using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista.ModoAdm
{
    public interface IModoAdm: IListaModo
    {
        IListar Listar { get; }
        void SeleccionItem();
    }
}