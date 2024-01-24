using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.CambioPrecioPrdComp.CambioPrecio.Handler
{
    public class data: Vista.Idata
    {
        private string _idPrd;
        private decimal _precioActual;
        private decimal _tasaPos;
        private decimal _tasaBono;
        private bool _precioSeAplicaConBono;
        private OOB.Venta.Item.Zufu.ActualizarPrecio.ObtenerData.Ficha _prd;
        private Vista.IPrecio _pActual;
        private Vista.IPrecio _pNuevo;
        private Item.data _item;
        //
        public object Item_GetIdPrd { get { return _idPrd; } }
        public decimal Item_GetPrecioActual { get { return _precioActual; } }
        public bool Get_AplicaBono { get { return _precioSeAplicaConBono; } }
        public decimal Item_GetCostoActualEmpVta { get { return _pActual.Get_PrecioVta.Get_Costo; } }
        //
        public decimal UtilidadNueva { get { return _pNuevo == null ? 0m : _pNuevo.Get_PrecioVta.Get_Utilidad.porcent; } }
        public decimal Utilidad_Precio_Actual { get { return _pActual == null ? 0m : _pActual.Get_PrecioVta.Get_Utilidad.porcent; } }
        public Vista.IPrecio PrecioNuevo { get { return _pNuevo; } }
        public decimal PrecioNuevoNetoMonAct 
        { 
            get 
            {
                var _precioNuevoNetoMonAct = 0m;
                if (_precioSeAplicaConBono)
                {
                    _precioNuevoNetoMonAct = _pNuevo.PrecioSinBono(_pNuevo.Get_PrecioVta.Get_PNeto) * _prd.TasaActual;
                    _precioNuevoNetoMonAct = Math.Round(_precioNuevoNetoMonAct, 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    _precioNuevoNetoMonAct = _pNuevo.Get_PrecioVta.Get_PNeto * _prd.TasaActual;
                    _precioNuevoNetoMonAct = Math.Round(_precioNuevoNetoMonAct, 2, MidpointRounding.AwayFromZero);
                }
                return Math.Round(_precioNuevoNetoMonAct, 2, MidpointRounding.AwayFromZero);
            }
        }
        public decimal PrecioNuevoFullMonDiv
        {
            get
            {
                var _precioNuevoFullMonDiv = 0m;
                if (_precioSeAplicaConBono)
                {
                    _precioNuevoFullMonDiv = _pNuevo.PrecioSinBono(_pNuevo.Get_PrecioVta.Get_PFull);
                }
                else
                {
                    _precioNuevoFullMonDiv = _pNuevo.Get_PrecioVta.Get_PFull;
                }
                return Math.Round(_precioNuevoFullMonDiv, 2, MidpointRounding.AwayFromZero);
            }
        }


        public data()
        {
            _idPrd="";
            _precioActual=0m;
            _tasaPos = 0m;
            _tasaBono = 0m;
            _precioSeAplicaConBono = true;
            _pActual = new precio();
            _pNuevo= new precio();
            _item = null;
        }
        public void Inicializa()
        {
            _idPrd = "";
            _precioActual = 0m;
            _precioSeAplicaConBono = true;
            _pActual.Inicializa();
            _pNuevo.Inicializa();
        }
        public void Refresh()
        {
            refrescarData();
        }
        public void setItem(object item)
        {
            _item = (Item.data)item;
        }
        public void setPrd(object prd)
        {
            _prd = (OOB.Venta.Item.Zufu.ActualizarPrecio.ObtenerData.Ficha)prd;
        }
        private void refrescarData()
        {
            if (_item != null)
            {
                _idPrd = _item.Ficha.autoProducto;
            }
            if (_prd != null)
            {
                var _costoActual = _prd.Producto.CostoUndMonDiv * _item.ContenidoEmp;
                _precioActual = Math.Round(_item.PrecioFinal / _item.TasaCambio, 2, MidpointRounding.AwayFromZero);
                //
                _pActual.setPosTipoMoneda(__.Precio.Moneda.TipoMoneda.MonDivisa);
                _pActual.setPosPrecioNeto(_precioActual);
                _pActual.setPosCostoActual(_costoActual);
                _pActual.setPosBonoPorPagoEnDivisa(_tasaBono);
                _pActual.setPosTasaCambio(_item.TasaCambio);
                _pActual.setPosTasaIva(_item.Ficha.tasaIva);
                _pActual.setModoBonoIncluido(_precioSeAplicaConBono);
                _pActual.Refresh();
                _precioActual = _pActual.Get_PrecioVta.Get_PNeto;
                //
                _pNuevo.setPosTipoMoneda(__.Precio.Moneda.TipoMoneda.MonDivisa);
                _pNuevo.setPosPrecioNeto(0m);
                _pNuevo.setPosCostoActual(_costoActual);
                _pNuevo.setPosBonoPorPagoEnDivisa(_tasaBono);
                _pNuevo.setPosTasaCambio(_item.TasaCambio);
                _pNuevo.setModoBonoIncluido(_precioSeAplicaConBono);
                _pNuevo.setPosTasaIva(_item.Ficha.tasaIva);
                //
            }
        }

        public void setPrecioCambiar(decimal precio)
        {
            _pNuevo.setPosPrecioNeto(precio);
            _pNuevo.Refresh();
        }
        public void setAplicandoBono(bool modo)
        {
            _precioSeAplicaConBono = modo;
            _pActual.setModoBonoIncluido(modo);
            _pActual.Refresh();
            _precioActual = (modo ? _pActual.Get_PrecioVta.Get_PNeto : _pActual.PrecioSinBono(_pActual.Get_PrecioVta.Get_PNeto));
            _pNuevo.setModoBonoIncluido(modo);
            _pNuevo.Refresh();
        }
        public void setTasaPos(decimal tasa)
        {
            _tasaPos = tasa;
        }
        public void setTasaBonoAplicar(decimal tasa)
        {
            _tasaBono = tasa;
        }
        public bool VerificarData()
        {
            if (_pNuevo.Get_PrecioVta.Get_PNeto <= 0m) 
            {
                Helpers.Msg.Alerta("Precio No Pueder Ser Cero");
                return false;
            }
            if (_pNuevo.Get_PrecioVta.Get_Utilidad.porcent <= 0m)
            {
                Helpers.Msg.Alerta("Utilidad Por Debajo / Igual Al Costo");
                return false;
            }
            return true;
        }
    }
}