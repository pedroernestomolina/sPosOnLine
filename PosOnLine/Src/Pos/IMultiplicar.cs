using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pos
{
    
    public interface IMultiplicar
    {

        bool MultiplicarIsOk { get; }
        int CantidadIngresar { get; }


        void Inicializa();
        void Inicia();

    }

}