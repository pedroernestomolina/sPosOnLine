using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor
{
    public interface IModo
    {
        void setGestionBuscar(Producto.Buscar.Gestion _gestionBuscar);
        void setTarifaPrecio(string _precioManejar);
        void setFactorCambio(decimal _tasaCambioActual);

        void Inicializa();
        void Inicia();
    }
}