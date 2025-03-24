using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor
{
    public interface IModo
    {
        void Inicializa();
        void setGestionBuscar(Producto.Buscar.IBuscarModo _gestionBuscar);
        void setTarifaPrecio(string _precioManejar);
        void Inicia();
    }
}