using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Pedido.ListaResumen
{
    public class Entidad
    {
        public List<Resumen> Pedidos { get; set; }
        public bool HayPedidos { get { return Pedidos.Count > 0; } }
    }
}
