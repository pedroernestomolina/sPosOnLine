using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor.ModoAdm
{
    public interface IExistencia
    {
        string GetDisponibilidad { get; }
        string GetCantidad { get;  }

        void Inicializar();

        void setData(Existencia existencia);
    }
}