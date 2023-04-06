using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor.ModoAdm
{
    public interface IModoAdm: IModo
    {
        IPrdConsultar Prd { get; }
        bool BusquedaIsOk { get; }
        void setCadenaBuscar(string cad);
        void Buscar();
    }
}