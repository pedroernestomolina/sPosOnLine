using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface IPosItem
    {
        OOB.Resultado.Ficha
            PosItem_ActualizarPrecioPorCambioTasa(OOB.PosItem.ActualizarPrecioPorCambioTasa.Ficha ficha);
    }
}