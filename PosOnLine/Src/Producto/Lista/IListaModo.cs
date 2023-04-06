using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Lista
{
    public interface IListaModo
    {
        bool ItemSeleccionIsOk { get; }
        string IdItemSeleccionado { get; }

        void Inicializa();
        void Inicia();

        void setData(List<OOB.Producto.Lista.Ficha> lst, decimal tasaCambio);
        void setCantidadVisible(bool p);
        void setPrecioVisible(bool p);
        void setFiltroPrdListar(OOB.Producto.Lista.Filtro filtro);
    }
}