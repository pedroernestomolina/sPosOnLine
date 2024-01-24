using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src
{
    public class FabModSuc: IFabrica
    {
        public Producto.Lista.IListaModo 
            CreateInstace_PosGestionListar()
        {
            return new Producto.Lista.Gestion();
        }
        public PrecioMayor.IModo 
            CreateInstace_PosGestionMayor()
        {
            return new PrecioMayor.Gestion();
        }
        public Consultor.IModo 
            CreateInstace_PosGestionConsultor()
        {
            return new Consultor.Gestion();
        }
        public Item.IModo 
            CreateInstace_PosGestionItem()
        {
            return new Item.Gestion();
        }
        //
        public Pos.ICliente 
            CreateInstace_PosCliente()
        {
            return new Zufu.ClienteComp.Cliente.Handler.Imp();
        }
        public CambioPrecio.ICambioPrecio 
            CreateInstace_PosCambioPrecioPrd()
        {
            //return new CambioPrecio.CambioPrecio();
            return new Zufu.CambioPrecioPrdComp.CambioPrecio.Handler.Imp();
        }
    }
}