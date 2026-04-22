using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.TrasladarPisoVta.Models
{
    public class Modelo
    {
        public Domain.Models.CapturarTraslado PedidoTrasladar { get; set; }
        //
        public Modelo()
        {
            PedidoTrasladar = null;
        }
        //
        public void Limpiar()
        {
            PedidoTrasladar = null;
        }
    }
}