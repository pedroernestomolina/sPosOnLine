using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pos
{
    public interface IListaPorPlu
    {
        void setPrecioTarifa(string id);
        void setIdDepositoBuscar(string id);
        void setGestionListaModo(Producto.Lista.IListaModo ctr);
        void setGestionItemModo(Item.IModo ctr);
        void Gestiona();
        void Inicializa();
    }
}