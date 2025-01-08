using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pedido.Lista
{
    public interface Idata
    {
        int Id { get; set; }
        string PedidoTarjetaNum { get; set; }
        string Fecha { get; set; }
        string MontoMonAct { get; set; }
        string MontoMonDiv { get; set; }
        string CntRenglones { get; set; }
    }
}