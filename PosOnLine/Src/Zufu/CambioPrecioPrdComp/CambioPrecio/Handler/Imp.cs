using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.CambioPrecioPrdComp.CambioPrecio.Handler
{
    public class Imp: Vista.IVista
    {
        private bool _cambioPrecioIsOk;
        private __.Ctrl.Boton.Abandonar.IAbandonar _btAbandonar;
        private __.Ctrl.Boton.Procesar.IProcesar _btProcesar;
        private Vista.Idata _data;
        private OOB.Usuario.Entidad.Ficha _usuAutoriza;
        private PanelInformativo.Vista.IVista _panelInf;
        private Item.data _item;
        private Vista.IdataPanel _dataPanel; 

        //
        public Vista.Idata DataFicha { get { return _data; } }
        public bool CambioPrecioIsOk { get { return _cambioPrecioIsOk; } }
        public decimal PrecioNuevo { get { return _data.PrecioNuevoNetoMonAct; } }
        public __.Ctrl.Boton.Abandonar.IAbandonar BtAbandonar { get { return _btAbandonar; } }
        public __.Ctrl.Boton.Procesar.IProcesar BtProcesar { get { return _btProcesar; } }
        public Vista.IdataPanel DataPanel { get { return _dataPanel; } }

        //
        public Imp()
        {
            _cambioPrecioIsOk = false;
            _data = new data();
            _btAbandonar = new __.Ctrl.Boton.Abandonar.Imp();
            _btProcesar = new __.Ctrl.Boton.Procesar.Imp();
            _dataPanel = new dataPanel();
        }
        public void Inicializa()
        {
            _cambioPrecioIsOk = false;
            _data.Inicializa();
            _btAbandonar.Inicializa();
            _btProcesar.Inicializa();
            _dataPanel.Inicializa();
        }
        Vista.Frm frm;
        public void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null) 
                {
                    frm = new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setDataItem(Item.data data)
        {
            _item = data;
            if (data != null) 
            {
                _dataPanel.setInfProducto (data.NombrePrd);
            }
        }
        public void setUsuarioAutoriza(object usuario)
        {
            _usuAutoriza = (OOB.Usuario.Entidad.Ficha)usuario;
        }
        public void setPrecioNuevo(decimal precio)
        {
            _data.setPrecioCambiar(precio);
            _dataPanel.setPrecioNuevo(precio);
            _dataPanel.setUtilidadNueva(_data.UtilidadNueva);
        }
        public void AplicarBono(bool modo)
        {
            _data.setAplicandoBono(modo);
            _dataPanel.setPrecioActual(_data.Item_GetPrecioActual);
            _dataPanel.setCostoEmpVta(_data.Item_GetCostoActualEmpVta);
            _dataPanel.setUtilidadNueva(_data.UtilidadNueva);
        }

        public void PanelInformativo()
        {
            if (_panelInf == null) 
            {
                _panelInf = new PanelInformativo.Handler.Imp();
            }
            _panelInf.Inicializa();
            _panelInf.setDataInf(_dataPanel);
            _panelInf.Inicia();
        }
        public void Procesar()
        {
            _btProcesar.setOpcion(false);
            if (_data.VerificarData()) 
            {
                if (_usuAutoriza == null) 
                {
                    Helpers.Msg.Alerta("DEBE HABER UN USUARIO QUIEN AUTORIZE EL PROCESO");
                    return;
                }
                _btProcesar.Opcion();
                if (_btProcesar.OpcionIsOK) 
                {
                    guardarCambios();
                }
            }
        }


        private bool cargarData()
        {
            try
            {
                _data.setItem(_item);
                if (_item == null) { throw new Exception("PROBLEMA AL CARGAR ITEM"); }
                //
                var r01 = Sistema.MyData.Venta_Item_Zufu_ActualizarPrecio_ObetnerData((string)_item.Ficha.autoProducto);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(r01.Mensaje);
                }
                _data.setPrd(r01.Entidad);
                var r02 = Sistema.MyData.Configuracion_ValorMaximoPorcentajeDescuento();
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
                _data.setTasaBonoAplicar(r02.Entidad);
                var r03 = Sistema.MyData.Configuracion_FactorDivisa(); 
                if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r03.Mensaje);
                }
                _data.setTasaPos(r03.Entidad);
                _data.Refresh();
                _dataPanel.setPrecioActual(_data.Item_GetPrecioActual);
                _dataPanel.setUtilidadActual(_data.Utilidad_Precio_Actual);
                _dataPanel.setCostoEmpVta(_data.Item_GetCostoActualEmpVta);
                _dataPanel.setManejadoPorDivisa(r01.Entidad.Producto.ManejadoEnDivisaDesc);
                _dataPanel.setTasaDivisaSist(r01.Entidad.TasaActual);
                _dataPanel.setTasaIvaPrd(_item.TasaIvaDescripcion);
                _dataPanel.setTasaPos(r03.Entidad);
                _dataPanel.setTasaBonoAplicar(r02.Entidad);
                _dataPanel.setEmpqVtaActual(_item.EmpaqueCont);
                //
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void guardarCambios()
        {
            _cambioPrecioIsOk = false;
            var fichaOOB = new OOB.Venta.Item.Zufu.ActualizarPrecio.Actualizar.Ficha()
            {
                data = new OOB.Venta.Item.Zufu.ActualizarPrecio.Actualizar.Data()
                {
                    idItem = _item.Id,
                    pNetoMonAct = _data.PrecioNuevoNetoMonAct,
                    pFullMonDiv = _data.PrecioNuevoFullMonDiv,
                },
                logReg = new OOB.Venta.Item.Zufu.ActualizarPrecio.Actualizar.LogReg()
                {
                    accion = "CAMBIO PRECIO PRODUCTO",
                    codigoUsuarioAutoriza = _usuAutoriza.codigo,
                    descripcion = string.Format("PRODUCTO: {0}, CUYO EMPAQUE ES: {6} CON PRECIO DE {1:F2}, CAMBIO A {2:F2}, TASA (POS) DIVISA ACTUAL: {3:F3}, BONO (%) DE {4:F2}, UTILIDAD (%) DE: {5:F2}", 
                    _dataPanel.producto, _dataPanel.precioActual, _dataPanel.precioNuevo,  
                    _dataPanel.tasaPos , _dataPanel.tasaBonoAplicar, _dataPanel.utilidadNueva, 
                    _dataPanel.EmpqVtaActual),
                    idOperador = _item.Ficha.idOperador,
                    idUsuarioAutoriza = _usuAutoriza.id,
                    nombreUsuarioAutoriza = _usuAutoriza.nombre,
                }
            };
            var r01 = Sistema.MyData.Venta_Item_Zufu_ActualizarPrecio_Actualizar(fichaOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            //
            _cambioPrecioIsOk = true;
        }
    }
}