using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pos
{
    public interface IMultiplicar
    {
        bool ProcesarIsOk { get; }
        int Cantidad { get; }
        //
        void Inicializa();
        void Inicia();
    }
}