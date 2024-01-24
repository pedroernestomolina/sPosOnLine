using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu
{
    public interface IPosZufuCliente: Pos.ICliente
    {
        void CargarFicha(object ficha);
    }
}