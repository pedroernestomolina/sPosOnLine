using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ListaPorPlu
{
    public class Imp : Pos.IListaPorPlu
    {
        private string _precioTarifa;
        private string _idDepositoBuscar;
        private Producto.Lista.IListaModo _gestionListar;
        private Item.IModo _gestionItem;
        //
        private Src.CasoUso.ObtenerListaProductos _obtenerListaProductosUseCase;
        //
        public Imp()
        {
            _precioTarifa = "";
            _idDepositoBuscar = "";
            _gestionItem = null;
            _gestionListar = null;
            //
            _obtenerListaProductosUseCase = new CasoUso.ObtenerListaProductos();
        }
        public void Inicializa()
        {
        }
        public void setPrecioTarifa(string tarifa) 
        {
            _precioTarifa = tarifa;
        }
        public void setIdDepositoBuscar(string id) 
        {
            _idDepositoBuscar = id;
        }
        public void setGestionListaModo(Producto.Lista.IListaModo ctr) 
        {
            _gestionListar = ctr;
        }
        public void setGestionItemModo(Item.IModo ctr) 
        {
            _gestionItem = ctr;
        }
        public void Gestiona()
        {
            try
            {
                var filtro = new OOB.Producto.Lista.Filtro()
                {
                    autoDeposito = _idDepositoBuscar,
                    cadena = "",
                    idPrecioManejar = _precioTarifa,
                    isPorPlu = true,
                };
                //var r01 = Sistema.MyData.Producto_GetLista(filtro);
                var r01 = _obtenerListaProductosUseCase.Execute(filtro);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                var _lst=r01.ListaD;
                var r02 = Sistema.MyData.Configuracion_FactorDivisa();
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
                var _factorCambio = r02.Entidad;
                //
                _gestionListar.Inicializa();
                _gestionListar.setData(_lst, _factorCambio);
                _gestionListar.Inicia();
                if (_gestionListar.ItemSeleccionIsOk)
                {
                    _gestionItem.Inicializar();
                    _gestionItem.RegistraItem(_gestionListar.IdItemSeleccionado, _precioTarifa);
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}