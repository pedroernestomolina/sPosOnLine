using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src
{
    public interface ILista
    {
        BindingSource GetSource { get; }
        object GetItemActual { get;  }
        int GetCantItem { get ; }
        void Inicializa();
        void setLista(List<object> _lst);
    }
}