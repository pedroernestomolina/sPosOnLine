using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pedido.Lista
{
    public interface IListaPedidos: IGestion
    {
        BindingSource DataSource { get; }
        bool AbrirTarjetaIsOk { get; }
        object TarjetaPedidoAbrir { get; }
        void setData(object data);
        void AbrirTarjetaPedido();
    }
}