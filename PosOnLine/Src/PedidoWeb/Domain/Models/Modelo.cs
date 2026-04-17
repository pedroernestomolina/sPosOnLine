using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.Domain.Models
{
    public class Modelo
    {
        public List<PedidoWeb> ListaPedidos { get; set; }
        //
        public Modelo()
        {
            ListaPedidos = new List<PedidoWeb>();
        }
    }
}
