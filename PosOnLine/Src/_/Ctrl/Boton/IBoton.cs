using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.__.Ctrl.Boton
{
    public interface IBoton
    {
        bool OpcionIsOK { get; }
        void Inicializa();
        void Opcion();
    }
}