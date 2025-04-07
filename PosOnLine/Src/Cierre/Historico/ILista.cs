using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cierre.Historico
{
    public interface ILista
    {
        object ItemActual { get; }
        object GetSource { get; }
        //
        void Inicializa();
        void setData(IEnumerable<object> list);
    }
}
