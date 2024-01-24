using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.Cliente.Vista
{
    public interface IBusqueda
    {
        ITipoBusq TipoBusqueda { get; }
        string  Get_TextoBuscar { get;  }
        void setBuscar(string texto);
        void Inicializa();
        void CargarData();
    }
}