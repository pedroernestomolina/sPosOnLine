using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Tools.Vendedor
{
    public interface IVendedor
    {
        BindingSource GetSource { get; }
        string GetId { get; }
        Helpers.ficha GetItem { get; }
        void setId(string id);

        void Inicializa();
        void CargarData();
    }
}