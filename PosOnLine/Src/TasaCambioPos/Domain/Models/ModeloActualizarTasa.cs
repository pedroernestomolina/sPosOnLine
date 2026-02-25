using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.TasaCambioPos.Domain.Models
{
    public class ModeloActualizarTasa
    {
        public decimal TasaPos { get; set; }
        public int IdOperador { get; set; }
        //
        public ModeloActualizarTasa()
        {
        }
    }
}