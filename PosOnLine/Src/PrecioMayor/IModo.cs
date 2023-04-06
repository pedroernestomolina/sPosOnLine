using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PrecioMayor
{
    public interface IModo
    {
        bool PrecioSeleccionadoIsOk { get; }
        string AutoProducto { get; }
        string TarifaSeleccionada { get;  }

        void setAutoProducto(string _autoPrd);
        void setTarifaPrecio(string _tarifaPrecio);

        void Inicializa();
        void Inicia();
    }
}