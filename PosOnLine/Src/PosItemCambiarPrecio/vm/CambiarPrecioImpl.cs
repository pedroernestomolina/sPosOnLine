using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosItemCambiarPrecio.vm
{
    public class CambiarPrecioImpl: IGestion, ICambiarPrecio
    {
        private int _idItemCambiarPrecio;
        private bool _procesarCambioIsOK;
        private __.Ctrl.Boton.Abandonar.IAbandonar _btAbandonar;
        private __.Ctrl.Boton.Procesar.IProcesar _btProcesar;
        private Domain.UseCase.IUseCase _uc;
        private Domain.Models.ItemCambio _itemCambio;
        private Domain.Models.Usuario _usuAutoriza;
        private decimal _precioFullMonDivisaActualizado;
        private decimal _precioNetoMonActualActualizado;
        private decimal _porctAumentoPrdNoAdmDivisa;
        private bool _opcionPermitirCambiarVariosPrecios;
        //
        public decimal Get_PrecioPagoBs { get { return _itemCambio.PrecioPagoBs; } }
        public decimal Get_PrecioPagoPrdNoDivisa { get { return _itemCambio.PrecioPagoPrdNoDivisa; } }
        public decimal Get_PrecioPagoDivisa { get { return _itemCambio.PrecioPagoDivisa; } }
        public string Get_ProductoInfo { get { return _itemCambio.ProductoInfo; } }
        public decimal Get_PorctAumentoProductosNoDivisa { get { return _itemCambio.PorctAumentoPrdNoAdmPorDivisa; } }
        public bool Get_IsProductoAdmPorDivisa { get { return _itemCambio.ProductoIsAdmPorDivisa; } }
        public decimal Get_Utilidad { get { return utilidadMargen(); } }
        public decimal Get_CostoEmpaqueVenta { get { return _itemCambio.CostoEmpqVta; } }
        public decimal Get_TasaSistema { get { return _itemCambio.TasaDivisaSistema; } }
        public bool DarPorcentajeAumento { get { return _itemCambio.PorctAumentoPrdNoAdmPorDivisa>0m; } }
        public bool AbandonarFichaIsOK { get { return _btAbandonar.OpcionIsOK; } }
        public bool ProcesarCambioIsOK { get { return _procesarCambioIsOK; } }
        public decimal PrecioFullMonDivisaActualizado { get { return _precioFullMonDivisaActualizado; } }
        public decimal PrecioNetoMonActualActualizado { get { return _precioNetoMonActualActualizado; } }
        public Domain.Models.Usuario Get_UsuarioAutoriza { get { return _usuAutoriza; } }
        public bool Get_OpcionPermitirCambiarVariosPrecios_IsActiva { get { return _opcionPermitirCambiarVariosPrecios; } }
        public string Get_CostoEmpaqueVentaDescripcion
        {
            get 
            {
                var _tMonAct = (_itemCambio.CostoEmpqVta * _itemCambio.TasaDivisaPos) / _itemCambio.TasaDivisaSistema;
                _tMonAct = Math.Round(_tMonAct, 4, MidpointRounding.AwayFromZero);
                var _tMonRef= _itemCambio.CostoEmpqVta;
                _tMonRef = Math.Round(_tMonRef, 2, MidpointRounding.AwayFromZero);
                var rt = _tMonRef.ToString("n2");
                //if (!_itemCambio.ProductoIsAdmPorDivisa) 
                //{
                //    rt +=" / " + _tMonAct.ToString("n4");
                //}
                rt += " / " + _tMonAct.ToString("n4");
                return rt;
            }
        }

        //
        public CambiarPrecioImpl()
        {
            _opcionPermitirCambiarVariosPrecios=false;
            _precioFullMonDivisaActualizado = 0m;
            _precioNetoMonActualActualizado = 0m;
            _procesarCambioIsOK = false;
            _btAbandonar = new __.Ctrl.Boton.Abandonar.Imp();
            _btProcesar = new __.Ctrl.Boton.Procesar.Imp();
            _uc = new Domain.UseCase.UseCaseImpl();
        }
        public void Invoke(int idItem, Domain.Models.Usuario autoriza)
        {
            setItemCambiarPrecio(idItem);
            setAutoriza(autoriza);
            Inicializa();
            Inicia();
        }
        private void setAutoriza(Domain.Models.Usuario autoriza)
        {
            _usuAutoriza = autoriza;
        }
        private void setItemCambiarPrecio(int idItem)
        {
            _idItemCambiarPrecio = idItem;
        }
        public void Inicializa()
        {
            _precioFullMonDivisaActualizado = 0m;
            _precioNetoMonActualActualizado = 0m;
            _procesarCambioIsOK = false;
            _btAbandonar.Inicializa();
            _btProcesar.Inicializa();
        }
        vista.Frm frm;
        public void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null) 
                {
                    frm = new vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setPagoMontoBs(decimal monto)
        {
            if (monto > 0m) 
            {
                _itemCambio.setPrecioPagoBs(monto);
            }
        }
        public void setPagoProductoNoDivisa(decimal monto)
        {
            if (monto > 0m)
            {
                _itemCambio.setPrecioPagoProductoNoDivisa(monto);
            }
        }
        public void setPagoDivisa(decimal monto)
        {
            if (monto > 0m)
            {
                _itemCambio.setPrecioPagoDivisa(monto);
            }
        }
        public void setSwitchPorcentajeAumento(bool sw)
        {
            if (sw)
            {
                _itemCambio.PorctAumentoPrdNoAdmPorDivisa=_porctAumentoPrdNoAdmDivisa;
            }
            else
            {
                _itemCambio.PorctAumentoPrdNoAdmPorDivisa=0m;
            }
        }
        public void setSwitchPermitirCambiarVariosPrecios(bool sw)
        {
            _opcionPermitirCambiarVariosPrecios = sw;
        }
        //
        private bool cargarData()
        {
            try
            {
                _itemCambio = _uc.CargarItem(_idItemCambiarPrecio);
                _porctAumentoPrdNoAdmDivisa = _itemCambio.PorctAumentoPrdNoAdmPorDivisa;
                if (!_itemCambio.ProductoIsAdmPorDivisa) 
                {
                    if (!_itemCambio.Item.aplicaPorcAumento) 
                    {
                        _itemCambio.PorctAumentoPrdNoAdmPorDivisa = 0m;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        public void AbandonarFicha()
        {
            _btAbandonar.Opcion();
            if (_btAbandonar.OpcionIsOK) 
            {
                verificarOpcionPermitirCambiarVariosPrecios();
            }
        }
        public void ProcesarCambio()
        {
            _procesarCambioIsOK = false;
            try
            {
                if (_usuAutoriza == null) 
                {
                    throw new Exception("DEBES INDICAR QUIEN AUTORIZA ESTE CAMBIO");
                }
                if (Get_Utilidad < 0m)
                {
                    throw new Exception("UTILIDAD NO PUEDE SER NEGATIVA");
                }
                _btProcesar.Opcion("Cambiar Precio De Item ?");
                if (_btProcesar.OpcionIsOK) 
                {
                    var _aplicarPorcAumento="N";
                    if (!Get_IsProductoAdmPorDivisa) 
                    {
                        _aplicarPorcAumento = DarPorcentajeAumento ? "" : "N";
                    }
                    var fichaCambioPrecio = new OOB.PosCambioPrecio.ProcesarCambiar.Ficha()
                    {
                        item = new OOB.PosCambioPrecio.ProcesarCambiar.DataItem()
                        {
                            idItem = _itemCambio.Item.idItem,
                            idOperador = _itemCambio.Item.idOperador,
                            pFullMonDiv = _itemCambio.Item.pFullMonReferencia,
                            pNetoMonAct = _itemCambio.Item.pNetoMonLocal,
                            AplicarPorcAumentoPrdNoDivisa = _aplicarPorcAumento,
                        },
                        logReg = new OOB.PosCambioPrecio.ProcesarCambiar.LogReg()
                        {
                            accion = "CAMBIO PRECIO PRODUCTO",
                            codigoUsuarioAutoriza = _usuAutoriza.codigoUsu,
                            descripcion = string.Format("PRODUCTO: {0}, CUYO EMPAQUE ES: {6} CON PRECIO DE {1:F2}, CAMBIO A {2:F2}, TASA (POS) DIVISA ACTUAL: {3:F3}, BONO (%) DE {4:F2}, UTILIDAD (%) DE: {5:F2}",
                            _itemCambio.ProductoInfo, _itemCambio.PrecioActualPagoBs, _itemCambio.PrecioPagoBs,
                            _itemCambio.TasaDivisaPos, _itemCambio.PorctBonoPorPagoDivsa, utilidadMargen(),
                            _itemCambio.Item.empaqVenta),
                            idOperador = _itemCambio.Item.idOperador,
                            idUsuarioAutoriza = _usuAutoriza.idUsu,
                            nombreUsuarioAutoriza = _usuAutoriza.NombreUsu,
                        },
                    };
                    _uc.ProcesarCambioPrecio(fichaCambioPrecio);
                    _precioFullMonDivisaActualizado =_itemCambio.Item.pFullMonReferencia;
                    _precioNetoMonActualActualizado = _itemCambio.Item.pNetoMonLocal;
                    _procesarCambioIsOK = true;
                    verificarOpcionPermitirCambiarVariosPrecios();
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        //
        private decimal utilidadMargen()
        {
            if (Get_IsProductoAdmPorDivisa)
            {
                var rt = 0m;
                rt = (1m - (_itemCambio.CostoEmpqVta / Get_PrecioPagoDivisa)) * 100;
                return rt;
            }
            else 
            {
                var rt = 0m;
                rt = (1m - (_itemCambio.CostoEmpqVta / Get_PrecioPagoBs)) * 100;
                return rt;
            }
        }
        private void verificarOpcionPermitirCambiarVariosPrecios()
        {
            if (!Get_OpcionPermitirCambiarVariosPrecios_IsActiva)
            {
                _usuAutoriza = null;
            }
        }
    }
}