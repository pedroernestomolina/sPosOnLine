using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.VentaAdm.ClienteAdm.Buscar
{
    
    public interface IBuscar: IGestion
    {


        bool ClienteSeleccionadoIsOk { get;  }
        string GetClienteSeleccionadoId { get; }
        void SeleccionarCliente();


        int GetCntItem { get; }
        BindingSource GetItemsSource { get; }


        void setCadena(string p);
        void ActivarBusqueda();


        BindingSource GetOpcBusqSource { get; }
        string GetOpcBusqId { get; }
        void SetOpcBusq(string id);


    }

}