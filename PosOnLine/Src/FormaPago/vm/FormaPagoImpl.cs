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
        private FormaPago.Domain.ReglaNegocio.IReglas _reglaNegocio;
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
        private bool _modoSoloFormasPagoConMonedaLocal;
        private decimal _porctDsctoDado;
        private Domain.Models.Cliente _clienteData;
        private decimal _totalMontoPorPagarDivisa;
        private decimal _totalMontoPorPagarLocal;
        private decimal _montoDsctoMonReferencia; //MONTO DESCTO CALCULADO
        private FormaPagoDscto.vm.IDscto _dsctoImpl;
        private decimal _igtfBaseAplicar; //MONTO SOBRE LA CUAL SE APLICARA EL IGTF
        private decimal _igtfMontoMonReferencia; //MONTO IGTF CALCULADO
        private bool _aplicandoIGTF; //INDICA SI SE ESTA APLICANDO /NO EL IGTF EN LA CUENTA
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
        public decimal Get_PorctBono { get { return _porctBono; } }
        public decimal Get_TasaFactorCambio { get { return _factorCambio; } }
        public string Get_ClienteData { get { return _clienteData==null ? "" : _clienteData.Descripcion; } }
        public decimal Get_TotalPagarMonLocal { get { return _totalMontoPorPagarLocal; } }
        public decimal Get_TotalPagarMonDivisa { get { return _totalMontoPorPagarDivisa; } }
        public decimal Get_PorctDesctoDado { get { return _porctDsctoDado; } }
        public decimal Get_MontoDscto { get { return _montoDsctoMonReferencia; } }
        public bool Get_DsctActivo { get { return _porctDsctoDado>0m; } }
        public decimal Get_PorctIGTFAplicar { get { return _myData.ConfgiuracionIGTF.tasa; } }
        public decimal Get_BaseAplicarIGTF { get { return _igtfBaseAplicar; } }
        public decimal GetMontoIGTF { get { return _igtfMontoMonReferencia; } }
        public bool Get_IGTFActivo { get { return _aplicandoIGTF; } }
        public bool ProcesoPagoIsOk { get { return !_isPendiente; } }
        public Domain.Models.DataRetornar Get_DataRetornar 
        { 
            get 
            {
                return dataRetornar();
            } 
        }
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
            _dsctoImpl = new FormaPagoDscto.vm.DsctoImpl();
            _reglaNegocio = new FormaPago.Domain.ReglaNegocio.ReglasImpl(_useCase);
            _igtfMontoMonReferencia = 0m;
            _igtfBaseAplicar = 0m;
            _aplicandoIGTF = false;
        }
        public void Inicializa()
        {
            _aplicandoIGTF = false;
            _igtfMontoMonReferencia = 0m;
            _igtfBaseAplicar = 0;
            _formaPagoPorBonoDivisa = new Domain.Models.FormaPago();
        }
        vista.Frm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                recalcular();
                if (frm == null)
                {
                    frm = new vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        private void recalcular()
        {
            igtfAplica();
            recalculaMontoPorPagarDivisa();
            bonoAplica();
            actualizaPendiente();
        }
        //
        private bool cargarData()
        {
            try
            {
                setMonedaLocal(_useCase.CargarMonedaLocal());
                setMonedaReferencia(_useCase.CargarMonedaReferencia());
                setMediosPago(_useCase.CargarMediosPagoUseCase());
                setMedioPagoPorBonoDivisa(_useCase.CargarMedioPagoPorBonoDivisa());
                setConfiguracionIGTF(_useCase.CargarConfiguracionIGTF());
                setMonedas(_useCase.CargarMonedas());
                setActivarBonoPorPagoDivsa(_useCase.CargarConfiguracionBonoPorPagoDivisa());
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void setMonedas(List<Domain.Models.Moneda> list)
        {
            _miConvertidor.setTasas(list);
        }
        private void setConfiguracionIGTF(Domain.Models.ConfiguracionIGTF configuracionIGTF)
        {
            _myData.setConfgiuracionIGTF(configuracionIGTF);
        }
        private void setMediosPago(List<Domain.Models.MedioPago> list)
        {
            _myData.setMediosPago(chequearUsoSoloMonedaLocal(list));
            _ctrlMedioPago.CargarData(_myData.mediosPago);
        }
        private void setMedioPagoPorBonoDivisa(Domain.Models.MedioPago medioPago)
        {
            _medioPagoPorBonoDivisa = medioPago;
        }
        private void setMonedaReferencia(Domain.Models.Moneda moneda)
        {
            _monedaReferencia = moneda;
        }
        private void setMonedaLocal(Domain.Models.Moneda moneda)
        {
            _monedaLocal = moneda;
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
                    var _montoSolicitar = _montoPendCambioMonReferencia;
                    if (_myData.medioPagoSeleccionado.aplicaBonoPagoDivisa)
                    {
                        if (_estatusBonoPorPagoDivisa)
                        {
                            var data = new dataCalcularMaxMontoPagarDivisa()
                            {
                                montoTotalDivisa = _montoPendCambioMonReferencia,
                                porctBono = _porctBono,
                            };
                            _montoSolicitar = _aplicarBono.calcularMaxMontoPagarDivisa(data);
                        }
                    }
                    var _aConvertir = new __.ConvertidorMonedas.Monto()
                    {
                        cantidad = _montoSolicitar,
                        codigoMoneda = _monedaReferencia.codigo,
                    };
                    _montoIngresar = _miConvertidor.Convertir(_aConvertir, _myData.medioPagoSeleccionado.codigoCurrencies);
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
            _totalMontoPorPagarLocal = Math.Round(monto, 2, MidpointRounding.AwayFromZero);
        }
        public void setMontoPorPagarMonDivisa(decimal monto)
        {
            _totalMontoPorPagarDivisa = Math.Round(monto, 2, MidpointRounding.AwayFromZero);
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
        public void setActivarModoSoloFormasPagoConMonedaLocal(bool modo)
        {
            _modoSoloFormasPagoConMonedaLocal = modo;
        }
        public void setClienteEntidad(Domain.Models.Cliente data)
        {
            _clienteData = data;
        }
        public void setDesctoDado(decimal porct)
        {
            _porctDsctoDado = porct;
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
                var montoDivisa = _miConvertidor.Convertir(monto, _monedaReferencia.codigo);
                montoDivisa = Math.Round(montoDivisa, 2, MidpointRounding.AwayFromZero);
                //
                monto = new __.ConvertidorMonedas.Monto()
                {
                    cantidad = montoDivisa,
                    codigoMoneda = _monedaReferencia.codigo ,
                };
                var montoLocal = _miConvertidor.Convertir(monto, _monedaLocal.codigo);
                montoLocal = Math.Round(montoLocal, 2, MidpointRounding.AwayFromZero);
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
                //
                _lote = "";
                _referencia = "";
                _montoIngresar = 0m;
                _myData.setMedioPago("");
                _agregarMedioPagoIsOk = true;
                //
                recalcular();
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
                }
            }
            recalcular();
        }
        public void limpiezaGeneral()
        {
            _blFormasPago.Clear();
            _myData.setMedioPago("");
            _montoIngresar = 0m;
            _agregarMedioPagoIsOk = false;
            //
            recalcular();
        }
        public void refrescarMontos()
        {
            recalcular();
        }
        public void apagarEncenderBonoPorPagoDivsa()
        {
            if (_activarBonoPorPagoDivisa) 
            {
                _estatusBonoPorPagoDivisa = !_estatusBonoPorPagoDivisa;
                recalcular();
            }
        }
        public void dsctoDar()
        {
            if (!_reglaNegocio.ParaDarDescuento())
            {
                return;
            }
            _dsctoImpl.Inicializa();
            _dsctoImpl.setDsctoDar(_porctDsctoDado);
            _dsctoImpl.Inicia();
            if (_dsctoImpl.procesarFichaIsOK)
            {
                setDesctoDado(_dsctoImpl.Get_DsctoDado);
                recalcular();
            }
        }
        public void ctaCredito()
        {
            if (_reglaNegocio.ParaDejarlaACredito(_clienteData.id))
            {
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
        private void igtfAplica()
        {
            _aplicandoIGTF = false;
            _igtfBaseAplicar = 0m;
            _igtfMontoMonReferencia = 0m;
            if (_myData.ConfgiuracionIGTF.aplica) 
            {
                _igtfBaseAplicar = _myData.formasPago.Where(w => w.medioPago.aplicaIGTF).Sum(s => s.montoMonedaRefenencia);
                if (_igtfBaseAplicar > 0m) 
                {
                    _aplicandoIGTF = true;
                    _igtfBaseAplicar = Math.Round(_igtfBaseAplicar, 2, MidpointRounding.AwayFromZero);
                    _igtfMontoMonReferencia = (_igtfBaseAplicar * _myData.ConfgiuracionIGTF.tasa / 100m);
                    _igtfMontoMonReferencia = Math.Round(_igtfMontoMonReferencia, 2, MidpointRounding.AwayFromZero);
                }
            }
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
        private List<Domain.Models.MedioPago> chequearUsoSoloMonedaLocal(List<Domain.Models.MedioPago> list)
        {
            var _lst = list;
            if (_modoSoloFormasPagoConMonedaLocal)
            {
                _lst = _lst.Where(w => w.codigoCurrencies == _monedaLocal.codigo).ToList();
            }
            return _lst;
        }
        private void recalculaMontoPorPagarDivisa()
        {
            _montoPorPagarDivisa = _totalMontoPorPagarDivisa;
            _montoDsctoMonReferencia = (_porctDsctoDado / 100m) * _montoPorPagarDivisa;
            _montoPorPagarDivisa -= _montoDsctoMonReferencia;
            _montoPorPagarDivisa = Math.Round(_montoPorPagarDivisa, 2, MidpointRounding.AwayFromZero);
            _montoPorPagarDivisa += _igtfMontoMonReferencia;
            _montoPorPagarDivisa = Math.Round(_montoPorPagarDivisa, 2, MidpointRounding.AwayFromZero);
            //
            var _aConvertir = new __.ConvertidorMonedas.Monto()
            {
                cantidad = _montoPorPagarDivisa,
                codigoMoneda = _monedaReferencia.codigo,
            };
            _montoPorPagarLocal = _miConvertidor.Convertir(_aConvertir, _monedaLocal.codigo);
        }
        //
        private Domain.Models.DataRetornar dataRetornar()
        {
            var rt = new Domain.Models.DataRetornar()
            {
            };
            return rt;
        }

    }
}