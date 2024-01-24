using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src
{
    public interface IFabrica
    {
        Producto.Lista.IListaModo 
            CreateInstace_PosGestionListar();
        PrecioMayor.IModo 
            CreateInstace_PosGestionMayor();
        Consultor.IModo 
            CreateInstace_PosGestionConsultor();
        Item.IModo 
            CreateInstace_PosGestionItem();
        //
        Pos.ICliente
            CreateInstace_PosCliente();
        CambioPrecio.ICambioPrecio 
            CreateInstace_PosCambioPrecioPrd();
    }
}