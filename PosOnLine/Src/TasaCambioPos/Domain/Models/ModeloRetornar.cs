using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.TasaCambioPos.Domain.Models
{
    public class ModeloRetornar
    {
        public List<OOB.Venta.Item.Entidad.Ficha> Items { get; set; }
        public decimal TasaSistemaActualizada { get; set; }
        public decimal DsctoBonoPagoDivisaActualizado { get; set; }
    }
}