using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.CuadreCierre.vm
{
    public class CuadreImpl : ICuadre
    {
        //
        private Domain.Models.MyData _myData;
        private Domain.UseCase.IUseCase _uc;
        private _Domain.UseCase.ICargarMedioPagoPorBonoDivisa _ucCargarMedioPagoPorBonoDivisa;
        private _Domain.UseCase.ICargarMediosPago _ucCargarMediosPago;
        private _Domain.UseCase.ICargarMonedaLocal _ucCargarMonedaLocal;
        private _Domain.UseCase.ICargarMonedaReferencia _ucCargarMonedaReferencia;
        private _Domain.Models.MedioPago _medioPagoPorBonoDivisa;
        private BindingSource _bsResumen;
        private BindingSource _bsTipoDoc;
        private BindingSource _bsMetodosPago;
        private BindingList<Domain.Models.MetodoPagoUso> _blMetPagoUso;
        private string _estadoCuadreCierre;
        private decimal _montoPendSobrante;
        private Domain.Models.MetodoPagoUso _mpUsadoPorPagoBonoDivisa;
        private List<Domain.Models.MedioPago> _lstMedPagoMonLocal;
        private List<Domain.Models.MedioPago> _lstMedPagoMonReferencia;
        private BindingSource _bsMedPagoMonLocal;
        private BindingSource _bsMedPagoMonReferencia;
        private ICtrlMedPago _cbMedPagoMonLocal;
        private ICtrlMedPago _cbMedPagoMonReferencia;
        private IRepoPagoDetalle _repoPagoDetalle;
        private IRepoPagoResumen _repoPagoResumen;
        private IRepoVentaCredito _repoVentaCredito;
        private IRepoCambiosVuelto _repoCambiosVuelto;
        private IRepoPagoMovil _repoPagoMovil;
        private bool _procesarCierreIsOk;
        private __.Ctrl.Boton.Abandonar.IAbandonar _abandonarFicha;
        private CuadreCierreProceso.vm.ICierreProceso _cierreProceso;
        //
        public bool ProcesarCierreIsOk { get { return _procesarCierreIsOk; } }
        public bool AbandonarFichaIsOk { get { return _abandonarFicha.OpcionIsOK; } }
        public object Get_ResumenSource { get { return _bsResumen; } }
        public object Get_TipoDocSource { get { return _bsTipoDoc; } }
        public object Get_MetodosPagoSource { get { return _bsMetodosPago; } }
        public Domain.Models.MetodoPagoUso ItemMetodoPagoUsoActual { get { return (Domain.Models.MetodoPagoUso)_bsMetodosPago.Current; } }
        public decimal Get_ImporteRecibido { get { return _blMetPagoUso.Sum(s => s.importe); } }
        public string Get_EstadoPendSobrante { get { return _estadoCuadreCierre; } }
        public decimal Get_MontoPendSobrante { get { return _montoPendSobrante; } }
        public decimal MontoCuadrar { get { return _myData.MontoCuadrar; } }
        public string Get_DescMPPorPagoBonoDivisa { get { return _mpUsadoPorPagoBonoDivisa != null ? _mpUsadoPorPagoBonoDivisa.descripcionMP : ""; } }
        public decimal Get_MontoMPPorPagoBonoDivisa { get { return _mpUsadoPorPagoBonoDivisa != null ? _mpUsadoPorPagoBonoDivisa.totalMontoRecibidoMonLocal : 0m; } }
        public decimal Get_VueltoMontoPorEfectivo { get { return _myData.VueltoMontoPorEfectivo; } }
        public int Get_VueltoCntPorDivisa { get { return _myData.VueltoCntPorDivisa; } }
        public decimal Get_VueltoMontoPorDivisa { get { return _myData.VueltoMontoPorDivisa; } }
        public object Get_MediosPagoLocalSource { get { return _cbMedPagoMonLocal.GetSource; } }
        public string Get_IdMedioPagoLocal { get { return _cbMedPagoMonLocal.GetId; } }
        public object Get_MediosPagoReferenciaSource { get { return _cbMedPagoMonReferencia.GetSource; } }
        public string Get_IdMedioPagoReferencia { get { return _cbMedPagoMonReferencia.GetId; } }
        //
        public CuadreImpl()
        {
            _myData = new Domain.Models.MyData();
            //
            _uc = new Domain.UseCase.UseCaseImpl();
            _ucCargarMedioPagoPorBonoDivisa = new _Domain.UseCase.CargarMedioPagoPorBonoDivisaImpl();
            _ucCargarMediosPago = new _Domain.UseCase.CargarMediosPagoImpl();
            _ucCargarMonedaLocal = new _Domain.UseCase.CargarMonedaLocalImpl();
            _ucCargarMonedaReferencia = new _Domain.UseCase.CargarMonedaReferenciaImpl();
            //
            _repoPagoDetalle = new RepoPagoDetalleImpl();
            _repoPagoResumen = new RepoPagoResumenImpl();
            _repoVentaCredito = new RepoVentaCreditoImpl();
            _repoCambiosVuelto = new RepoCambiosVueltoImpl();
            _repoPagoMovil = new RepoPagoMovilImpl();
            //
            _bsResumen = new BindingSource();
            //
            _bsTipoDoc = new BindingSource();
            //
            _blMetPagoUso = new BindingList<Domain.Models.MetodoPagoUso>(_myData.MetodosPagoUsado);
            _bsMetodosPago = new BindingSource();
            _bsMetodosPago.DataSource = _blMetPagoUso;
            _bsMetodosPago.CurrencyManager.Refresh();
            //
            _lstMedPagoMonLocal = new List<Domain.Models.MedioPago>();
            _lstMedPagoMonReferencia = new List<Domain.Models.MedioPago>();
            _bsMedPagoMonLocal = new BindingSource();
            _bsMedPagoMonReferencia = new BindingSource();
            _bsMedPagoMonLocal.DataSource = _lstMedPagoMonLocal;
            _bsMedPagoMonReferencia.DataSource = _lstMedPagoMonReferencia;
            _bsMedPagoMonLocal.CurrencyManager.Refresh();
            _bsMedPagoMonReferencia.CurrencyManager.Refresh();
            _cbMedPagoMonLocal = new CtrlMedPagoImpl();
            _cbMedPagoMonReferencia = new CtrlMedPagoImpl();
            //
            _estadoCuadreCierre = "";
            _montoPendSobrante = 0m;
            //
            _procesarCierreIsOk = false;
            _abandonarFicha = new __.Ctrl.Boton.Abandonar.Imp();
            _cierreProceso = new CuadreCierreProceso.vm.CierreProcesoImpl();
        }
        public void Inicializa()
        {
            _procesarCierreIsOk = false;
            _abandonarFicha.Inicializa();
            _cierreProceso.Inicializa();
            _blMetPagoUso.Clear();
            _estadoCuadreCierre = "";
            _montoPendSobrante = 0m;
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
        public void setMedioPagoPorBonoDivisa(_Domain.Models.MedioPago mp)
        {
            _medioPagoPorBonoDivisa = mp;
        }
        private void setDataResumenRecolectada(Domain.Models.DataResumenRecolectada data)
        {
            _myData.setDataResumenRecolectada(data);
            var _idExcluir = "";
            if (_medioPagoPorBonoDivisa != null)
            {
                _idExcluir = _medioPagoPorBonoDivisa.idMp;
            }
            _blMetPagoUso.Clear();
            foreach (var dt in _myData.MetodosPagoUsado.Where(w => w.idMP != _idExcluir).ToList())
            {
                _blMetPagoUso.Add(dt);
            }
            _mpUsadoPorPagoBonoDivisa = _myData.MetodosPagoUsado.Where(w => w.idMP == _idExcluir).FirstOrDefault();
        }
        private void setMediosPago(List<_Domain.Models.MedioPago> list)
        {
            var lst = list.Select(s =>
            {
                return Domain.converter.MedioPago(s);
            }).ToList();
            _myData.setMediosPago(lst);
        }
        private void setMonedaReferencia(_Domain.Models.Moneda moneda)
        {
            _myData.setMonedaReferencia(moneda);
        }
        private void setMonedaLocal(_Domain.Models.Moneda moneda)
        {
            _myData.setMonedaLocal(moneda);
        }
        public void setVueltoMedPagoLocal(string id)
        {
            vueltoMedPagoLocal(id, Get_VueltoMontoPorEfectivo);
            recalcular();
        }
        public void LimpiarVueltoMonLocal()
        {
            var _id = _cbMedPagoMonLocal.GetId;
            vueltoMedPagoLocal(_id, 0m);
            _cbMedPagoMonLocal.setFichaById("");
            recalcular();
        }
        public void setVueltoMedPagoReferencia(string id)
        {
            vueltoMedPagoReferencia(id, Get_VueltoCntPorDivisa, Get_VueltoMontoPorDivisa);
            recalcular();
        }
        public void LimpiarVueltoMonReferencia()
        {
            var _id = _cbMedPagoMonReferencia.GetId;
            vueltoMedPagoReferencia(_id, 0, 0m);
            _cbMedPagoMonReferencia.setFichaById("");
            recalcular();
        }
        public void ProcesarCierre()
        {
            _cierreProceso.setMetodosPagoImplementados(_myData.MetodosPagoUsado);
            _procesarCierreIsOk = _cierreProceso.ProcesarCierre();
        }
        public void AbandonarFicha()
        {
            _abandonarFicha.Opcion();
        }
        //
        private bool cargarData()
        {
            try
            {
                setMonedaLocal(_ucCargarMonedaLocal.Invoke());
                setMonedaReferencia(_ucCargarMonedaReferencia.Invoke());
                setMediosPago(_ucCargarMediosPago.Invoke());
                setMedioPagoPorBonoDivisa(_ucCargarMedioPagoPorBonoDivisa.Invoke());
                setDataResumenRecolectada(_uc.CuadreResumen(Sistema.PosEnUso.idResumen));
                _lstMedPagoMonLocal = _myData.MediosPago.Where(w => w.codigoCurrencies == _myData.MonedaLocal.codigo).ToList();
                _lstMedPagoMonReferencia = _myData.MediosPago.Where(w => w.codigoCurrencies == _myData.MonedaReferencia.codigo).ToList();
                _cbMedPagoMonLocal.CargarData(_lstMedPagoMonLocal);
                _cbMedPagoMonReferencia.CargarData(_lstMedPagoMonReferencia);
                _bsTipoDoc.DataSource = _myData.DataResumenRecolectada.TiposDocumentoEmitidos;
                _bsTipoDoc.CurrencyManager.Refresh();
                _bsResumen.DataSource = _myData.DataResumen;
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        public void ActualizarImporteMetodoPago()
        {
            if (ItemMetodoPagoUsoActual != null)
            {
                ItemMetodoPagoUsoActual.Recalcular();
            }
            recalcular();
        }
        public void MsgAlerta(string msg)
        {
            Helpers.Msg.Alerta(msg);
        }
        public void LimpiarIngresoMetodosPagoUsado()
        {
            foreach (var it in _blMetPagoUso.ToList()) 
            {
                it.MontoSegunUsu = 0m;
                it.Recalcular();
            }
            recalcular();
        }
        public void reportePagoDetalle()
        {
            _repoPagoDetalle.setDataCargar(_uc.ReportePagoDetalle(Sistema.PosEnUso.idResumen));
            _repoPagoDetalle.setMonedaLocal(_myData.MonedaLocal);
            _repoPagoDetalle.Generar();
        }
        public void reportePagoResumen()
        {
            _repoPagoResumen.setDataCargar(_uc.ReportePagoResumen(Sistema.PosEnUso.idResumen));
            _repoPagoResumen.setMonedaLocal(_myData.MonedaLocal);
            _repoPagoResumen.Generar();
        }
        public void reporteVentaCredito()
        {
            _repoVentaCredito.setDataCargar(_uc.ReporteVentaCredito(Sistema.PosEnUso.idResumen));
            _repoVentaCredito.Generar();
        }
        public void reporteCambiosVuelto()
        {
            _repoCambiosVuelto.setDataCargar(_uc.ReporteCambiosVueltoEntregado(Sistema.PosEnUso.idResumen));
            _repoCambiosVuelto.Generar();
        }
        public void reportePagoMovil()
        {
            _repoPagoMovil.setDataCargar(_uc.ReportePagoMovilPorRealizar(Sistema.PosEnUso.idResumen));
            _repoPagoMovil.Generar();
        }
        //
        private void recalcular() 
        {
            _montoPendSobrante = (Get_ImporteRecibido - (MontoCuadrar - Get_MontoMPPorPagoBonoDivisa));
            if (_montoPendSobrante > 0m)
            {
                _estadoCuadreCierre = "Sobrante";
            }
            else if (_montoPendSobrante < 0m)
            {
                _estadoCuadreCierre = "Faltante";
            }
            else
            {
                _estadoCuadreCierre = "OK";
            }
            _montoPendSobrante = Math.Abs(_montoPendSobrante);
        }
        private void vueltoMedPagoLocal(string id, decimal monto)
        {
            _cbMedPagoMonLocal.setFichaById(id);
            if (id.Trim() != "")
            {
                foreach (var it in _blMetPagoUso.Where(w => w.codigoMon == _myData.MonedaLocal.codigo))
                {
                    it.setVueltoPorMontoDado(0m);
                    it.Recalcular();
                }
                var _mpUso = _blMetPagoUso.FirstOrDefault(f => f.idMP == id);
                if (_mpUso != null)
                {
                    _mpUso.setVueltoPorMontoDado(monto);
                    _mpUso.Recalcular();
                }
            }
        }
        private void vueltoMedPagoReferencia(string id, int cnt, decimal monto) 
        {
            _cbMedPagoMonReferencia.setFichaById(id);
            if (id.Trim() != "")
            {
                foreach (var it in _blMetPagoUso.Where(w => w.codigoMon == _myData.MonedaReferencia.codigo))
                {
                    it.setCantDivisaDevuelta(0);
                    it.setMontoDivisaDevuelta(0m);
                    it.Recalcular();
                }
                var _mpUso = _blMetPagoUso.FirstOrDefault(f => f.idMP == id);
                if (_mpUso != null)
                {
                    _mpUso.setCantDivisaDevuelta(cnt);
                    _mpUso.setMontoDivisaDevuelta(monto);
                    _mpUso.Recalcular();
                }
            }
        }
    }
}