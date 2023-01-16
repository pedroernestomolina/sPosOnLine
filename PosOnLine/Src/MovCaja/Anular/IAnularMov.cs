using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.MovCaja.Anular
{
    public interface IAnularMov
    {
        void Inicializa();
        void Inicia();
        void setMovAnular(int id);
        void setIdOperadorActual(int id);
        bool AnularMovCajaIsOk { get; }
    }
}