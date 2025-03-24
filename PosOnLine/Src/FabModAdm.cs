using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src
{
    public class FabModAdm: IFabrica
    {
        public Producto.Lista.IListaModo 
            CreateInstace_PosGestionListar()
        {
            return new Producto.Lista.ModoAdm.ImpModoAdm();
        }
        public PrecioMayor.IModo 
            CreateInstace_PosGestionMayor()
        {
            return new PrecioMayor.ModoAdm.ImpModoAdm();
        }
        public Consultor.IModo 
            CreateInstace_PosGestionConsultor()
        {
            return new Consultor.ModoAdm.ImpModoAdm();
        }
        public Item.IModo 
            CreateInstace_PosGestionItem()
        {
            return new Item.ModoAdm.ImpModoAdm();
        }
        //
        public Pos.ICliente 
            CreateInstace_PosCliente()
        {
            //return new VentaAdm.Gestion();
            return new Zufu.ClienteComp.Cliente.Handler.Imp();
        }
        public CambioPrecio.ICambioPrecio 
            CreateInstace_PosCambioPrecioPrd()
        {
            return new Src.CambioPrecio.CambioPrecio();
        }

        public ReglasNegocio.IReglas 
            CreateInstace_ReglasNegocio()
        {
            return new ReglasNegocio.ReglaNegocioEverestMotor();
        }
        //
        public Producto.Buscar.IBuscarModo 
            CreateInstace_PosGestionBuscar()
        {
            return new Producto.Buscar.ZUFU.Imp();
        }
        //
        public Pos.IListaPorPlu 
            CreateInstace_PosListaPorPlu()
        {
            return null;
        }
    }
}