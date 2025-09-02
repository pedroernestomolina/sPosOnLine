using PosOnLine.Src.Zufu.ClienteComp.Cliente.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.FormaPago.vm
{
    public class FormaPagoImpl: IFormaPago
    {
        private IAplicarBono _aplicarBono;
        private FormaPago.Domain.UseCase.IUseCase _useCase;
        private FormaPago.Domain.Models.MyData _myData;
        private FormaPago.Domain.Models.Moneda _monedaLocal;
        private FormaPago.Domain.Models.Moneda _monedaReferencia;
        private FormaPago.Domain.Models.MedioPago _medioPagoPorBonoDivisa;
        private FormaPago.Domain.Models.FormaPago _formaPagoPorBonoDivisa;
        private ICtrlMedioPago _ctrlMedioPago;
        private decimal _montoIngresar;
        private bool _agregarMedioPagoIsOk;
        private FormaPagoLoteRef.vm.ILoteRef _loteRef;
        private BindingSource _bsFormasPago;
        private BindingList<FormaPago.Domain.Models.FormaPago> _blFormasPago;
        private __.ConvertidorMonedas.Convertidor _miConvertidor;
        private decimal _factorCambio;
        private decimal _montoPorPagarLocal;
        private decimal _montoPorPagarDivisa;
        private decimal _porctBono;
        private decimal _montoPendCambioMonLocal;
        private decimal _montoPendCambioMonReferencia;
        private bool _isPendiente;
        private bool _activarBonoPorPagoDivisa;
        private bool _estatusBonoPorPagoDivisa;
        //
        public object Get_MedioPagoSource { get { return _ctrlMedioPago.GetSource; } }
        public string Get_MedioPagoId { get { return _ctrlMedioPago.GetId; } }
        public string Get_SimboloMonedaFormaPago { get { return _myData.medioPagoSeleccionado == null ? "" : _myData.medioPagoSeleccionado.simboloCurrencies; } }
        public bool agregarMedioPagoIsOk { get { return _agregarMedioPagoIsOk; } }
        public object Get_FormasPagoSource { get { return _bsFormasPago; } }
        public decimal Get_MontoBonoMonedaLocal { get { return _formaPagoPorBonoDivisa.montoMonedaLocal; } }
        public decimal Get_MonoBonoMonedaReferencia { get { return _formaPagoPorBonoDivisa.montoMonedaRefenencia; } }
        public string Get_SimboloMonedaLocal { get { return _monedaLocal != null ? _monedaLocal.simbolo : ""; } }
        public string Get_SimboloMonedaReferencia { get { return _monedaReferencia != null ? _monedaReferencia.simbolo : ""; } }
        public decimal Get_MontoRestaCambioMonLocal { get { return _montoPendCambioMonLocal; } }
        public decimal Get_MontoRestaCambioMonReferencia { get { return _montoPendCambioMonReferencia; } }
        public bool IsCuentaPendiente { get { return _isPendiente; } }
        public bool EstatusBonoPagoPorDivisa { get { return _estatusBonoPorPagoDivisa; } }
        public decimal MontoMaxIngresarPagoDivisa { get { return _montoIngresar; } }
        //
        public FormaPagoImpl()
        {
            _myData = new Domain.Models.MyData();
            _useCase = new FormaPago.Domain.UseCase.UseCaseImpl();
            _ctrlMedioPago = new CtrlMedioPagoImpl();
            _loteRef = new FormaPagoLoteRef.vm.LoteRefImpl();
            _aplicarBono = new AplicarBonoImpl();
            _montoIngresar = 0m;
            _agregarMedioPagoIsOk=false;
            _blFormasPago = new BindingList<Domain.Models.FormaPago>(_myData.formasPago);
            _bsFormasPago = new BindingSource();
            _bsFormasPago.DataSource=_blFormasPago;
            _bsFormasPago.CurrencyManager.Refresh();
            _miConvertidor = new __.ConvertidorMonedas.Convertidor();
            _factorCambio=0m;
            _montoPorPagarLocal = 0m;
            _montoPorPagarDivisa = 0m;
            _porctBono=0m;
            _formaPagoPorBonoDivisa = new Domain.Models.FormaPago();
            _montoPendCambioMonLocal = 0m;
            _montoPendCambioMonReferencia = 0m;
            _isPendiente = true;
            _estatusBonoPorPagoDivisa = false;
        }
        public void Inicializa()
        {
            _formaPagoPorBonoDivisa = new Domain.Models.FormaPago();
        }
        vista.Frm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                refrescarMontos();
                actualizaPendiente();
                if (frm == null)
                {
                    frm = new vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        //
        private bool cargarData()
        {
            try
            {
                _myData.setMediosPago(_useCase.CargarMediosPagoUseCase());
                _monedaLocal=_useCase.CargarMonedaLocal();
                _monedaReferencia= _useCase.CargarMonedaReferencia();
                _medioPagoPorBonoDivisa= _useCase.CargarMedioPagoPorBonoDivisa();
                _miConvertidor.TasaCambio.Clear();
                _miConvertidor.TasaCambio.Add(_monedaLocal.codigo, _factorCambio);
                _miConvertidor.TasaCambio.Add(_monedaReferencia.codigo, 1m);
                _miConvertidor.TasaCambio.Add("EUR", 0.92m);
                _ctrlMedioPago.CargarData(_myData.mediosPago);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        public void setMedioPago(string id)
        {
            _ctrlMedioPago.setFichaById(id);
            _myData.setMedioPago(id);
            if (id != "")
            {
                if (_isPendiente)
                {
                    _montoIngresar = 0m;
                    if (_myData.medioPagoSeleccionado.aplicaBonoPagoDivisa)
                    {
                        if (_estatusBonoPorPagoDivisa)
                        {
                            var data = new dataCalcularMaxMontoPagarDivisa()
                            {
                                montoTotalDivisa = _montoPendCambioMonReferencia,
                                porctBono = _porctBono,
                            };
                            _montoIngresar = _aplicarBono.calcularMaxMontoPagarDivisa(data);
                        }
                    }
                    else
                    {
                        _montoIngresar = _montoPendCambioMonLocal;
                    }
                }
            }
        }
        public void setMontoIngresar(decimal monto)
        {
            _montoIngresar = monto;
        }
        public void setFactorCambio(decimal factorCambio)
        {
            _factorCambio = Math.Round(factorCambio,4, MidpointRounding.AwayFromZero);
        }
        public void setMontoPorPagarMonLocal(decimal monto)
        {
            _montoPorPagarLocal = Math.Round(monto, 2, MidpointRounding.AwayFromZero);
        }
        public void setMontoPorPagarMonDivisa(decimal monto)
        {
            _montoPorPagarDivisa = Math.Round(monto, 2, MidpointRounding.AwayFromZero);
        }
        public void setPorctBono(decimal porctBono)
        {
            _porctBono = Math.Round(porctBono, 4, MidpointRounding.AwayFromZero);
        }
        public void setActivarBonoPorPagoDivsa(bool modo)
        {
            _activarBonoPorPagoDivisa = modo;
            _estatusBonoPorPagoDivisa = modo;
        }
        //
        public void agregarMedioPago()
        {
            try
            {
                _agregarMedioPagoIsOk = false;
                var _lote = "";
                var _referencia = "";
                if (_myData.medioPagoSeleccionado == null)
                {
                    Helpers.Msg.Alerta("Debes indicar un medio de pago");
                    return;
                }
                if (_montoIngresar <= 0m)
                {
                    Helpers.Msg.Alerta("Monto A ingresar debe ser mayor a cero(0)");
                    return;
                }
                if (_myData.medioPagoSeleccionado.aplicaLoteRef)
                {
                    _loteRef.Inicializa();
                    _loteRef.Inicia();
                    if (_loteRef.DatosValidosIsOk)
                    {
                        _lote = _loteRef.getLote;
                        _referencia = _loteRef.getReferencia;
                    }
                    else
                    {
                        Helpers.Msg.Alerta("Datos Incorrectos en lote y referencia");
                        return;
                    }
                }
                var monto = new __.ConvertidorMonedas.Monto()
                {
                    cantidad = _montoIngresar,
                    codigoMoneda = _myData.medioPagoSeleccionado.codigoCurrencies,
                };
                var montoLocal = _miConvertidor.Convertir(monto, _monedaLocal.codigo);
                montoLocal = Math.Round(montoLocal, 2, MidpointRounding.AwayFromZero);
                //
                var montoDivisa = _miConvertidor.Convertir(monto, _monedaReferencia.codigo);
                montoDivisa = Math.Round(montoDivisa, 2, MidpointRounding.AwayFromZero);
                //
                if (_myData.medioPagoSeleccionado.aplicaBonoPagoDivisa)
                {
                    bonoAplica(montoDivisa);
                }
                var _fp = new FormaPago.Domain.Models.FormaPago()
                {
                    lote = _lote,
                    medioPago = _myData.medioPagoSeleccionado,
                    montoIngresado = _montoIngresar,
                    referencia = _referencia,
                    montoMonedaLocal = montoLocal,
                    montoMonedaRefenencia= montoDivisa,
                    simboloMonedaLocal=_monedaLocal.simbolo,
                    simboloMonedaReferencia=_monedaReferencia.simbolo,
                };
                _blFormasPago.Add(_fp);
                actualizaPendiente();
                //
                _lote = "";
                _referencia = "";
                _montoIngresar = 0m;
                _myData.setMedioPago("");
                _agregarMedioPagoIsOk = true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Alerta(e.Message);
            }
        }
        public void eliminarFormaPago()
        {
            if (_bsFormasPago.Current != null) 
            {
                if (Helpers.Msg.Procesar("Eliminar Esta Forma de pago ?")) 
                {
                    var it = (FormaPago.Domain.Models.FormaPago)_bsFormasPago.Current;
                    _blFormasPago.Remove(it);
                    bonoAplica();
                    actualizaPendiente();
                }
            }
        }
        public void limpiezaGeneral()
        {
            _blFormasPago.Clear();
            _myData.setMedioPago("");
            _montoIngresar = 0m;
            _agregarMedioPagoIsOk = false;
            actualizaPendiente();
        }
        public void refrescarMontos()
        {
            bonoAplica();
            actualizaPendiente();
        }
        public void ApagarEncenderBonoPorPagoDivsa()
        {
            if (_activarBonoPorPagoDivisa) 
            {
                _estatusBonoPorPagoDivisa = !_estatusBonoPorPagoDivisa;
                bonoAplica();
                refrescarMontos();
            }
        }
        //
        private void bonoAplica(decimal montoAplicar=0m) 
        {
            var _bonoDivisa = 0m;
            var _bonoLocal = 0m;
            if (_estatusBonoPorPagoDivisa)
            {
                var data = new dataAplicar()
                {
                    montoAplicarBono = montoAplicar + _myData.formasPago.Where(w => w.medioPago.aplicaBonoPagoDivisa).Sum(s => s.montoMonedaRefenencia),
                    montoTotalDivisa = _montoPorPagarDivisa,
                    porctBono = _porctBono,
                };
                _bonoDivisa = _aplicarBono.aplicar(data);
                _bonoLocal = _miConvertidor.Convertir(
                    new __.ConvertidorMonedas.Monto()
                    {
                        cantidad = _bonoDivisa,
                        codigoMoneda = _monedaReferencia.codigo
                    }, _monedaLocal.codigo);
            }
            _formaPagoPorBonoDivisa.lote = "";
            _formaPagoPorBonoDivisa.medioPago = _medioPagoPorBonoDivisa;
            _formaPagoPorBonoDivisa.montoIngresado = _montoIngresar;
            _formaPagoPorBonoDivisa.referencia = "";
            _formaPagoPorBonoDivisa.montoMonedaLocal = _bonoLocal;
            _formaPagoPorBonoDivisa.montoMonedaRefenencia = _bonoDivisa;
            _formaPagoPorBonoDivisa.simboloMonedaLocal = _monedaLocal.simbolo;
            _formaPagoPorBonoDivisa.simboloMonedaReferencia = _monedaReferencia.simbolo;
        }
        private void actualizaPendiente()
        {
            var _monRecaudadoLocal=_myData.formasPago.Sum(s=>s.montoMonedaLocal);
            var _monRecaudadoReferencia=_myData.formasPago.Sum(s=>s.montoMonedaRefenencia);
            _monRecaudadoLocal += _formaPagoPorBonoDivisa.montoMonedaLocal;
            _monRecaudadoReferencia += _formaPagoPorBonoDivisa.montoMonedaRefenencia;
            if (_montoPorPagarDivisa > _monRecaudadoReferencia)
            {
                _isPendiente = true;
                _montoPendCambioMonLocal = _montoPorPagarLocal - _monRecaudadoLocal;
                _montoPendCambioMonReferencia = _montoPorPagarDivisa - _monRecaudadoReferencia;
            }
            else 
            {
                _isPendiente = false;
                _montoPendCambioMonLocal = _monRecaudadoLocal - _montoPorPagarLocal;
                _montoPendCambioMonReferencia = _monRecaudadoReferencia - _montoPorPagarDivisa;
            }
        }
    }
}