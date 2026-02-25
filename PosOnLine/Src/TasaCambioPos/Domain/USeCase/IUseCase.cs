using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.TasaCambioPos.Domain.USeCase
{
    public interface IUseCase
    {
        decimal ObtenerTasaActualPos();
        Models.ModeloRetornar ActualizarTasaPos(Models.ModeloActualizarTasa ficha);
    }
}