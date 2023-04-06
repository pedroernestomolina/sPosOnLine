using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Producto.Lista.ModoAdm
{
    public interface IListar
    {
        BindingSource GetSource { get; }
        IDataPrd Prd { get; }

        void Inicializa();
        void SubirItem();
        void BajarItem();

        void setDataListar(List<IDataPrd> _lst);
        object ItemActual { get; }
    }
}