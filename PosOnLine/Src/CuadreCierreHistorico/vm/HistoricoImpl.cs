using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.CuadreCierreHistorico.vm
{
    public class HistoricoImpl: IHistorico
    {
        private Domain.UseCase.IUseCase _uc;
        private List<Domain.Models.Cierre> _lCierre;
        private BindingSource _bsCierre;
        CuadreCierreImprimir.vm.ICierreImprimir _imprimirCierre;
        CuadreCierreRepo.vm.IRepoVentaCredito _repoVtaCredito;
        CuadreCierreRepo.vm.IRepoPagoDetalle _repoPagoDetalle;
        CuadreCierreRepo.vm.IRepoPagoResumen _repoPagoResumen;
        //
        public object Get_ListaCierreSource { get { return _bsCierre; } }
        public object itemActual { get { return _bsCierre.Current; } }
        //
        public HistoricoImpl()
        {
            _uc = new Domain.UseCase.UseCaseImpl();
            _lCierre = new List<Domain.Models.Cierre>();
            _bsCierre = new BindingSource();
            _bsCierre.DataSource = _lCierre;
            _imprimirCierre = new CuadreCierreImprimir.vm.CierreImprimirImpl();
            _repoVtaCredito = new CuadreCierreRepo.vm.RepoVentaCreditoImpl();
            _repoPagoDetalle = new CuadreCierreRepo.vm.RepoPagoDetalleImpl();
            _repoPagoResumen = new CuadreCierreRepo.vm.RepoPagoResumenImpl();
        }
        public void Invoke()
        {
            Inicializa();
            Inicia();
        }
        public void Inicializa()
        {
            _lCierre.Clear();
            _bsCierre.ResetBindings(false);
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
        public void imprimirCierre()
        {
            if (itemActual != null)
            {
                var _it = (Domain.Models.Cierre)itemActual;
                _imprimirCierre.setIdOperador(_it.idOperador);
                _imprimirCierre.Generar();
            }
        }
        public void repoVentaredito()
        {
            if (itemActual != null) 
            {
                var _it = (Domain.Models.Cierre)itemActual;
                _repoVtaCredito.setIdResumenHistorico(_it.idResumen, _it.nroCierre);
                _repoVtaCredito.Generar();
            }
        }
        public void repoPagoDetalle()
        {
            if (itemActual != null)
            {
                var _it = (Domain.Models.Cierre)itemActual;
                _repoPagoDetalle.setIdResumenHistorico(_it.idResumen, _it.nroCierre);
                _repoPagoDetalle.Generar();
            }
        }
        public void repoPagoResumen()
        {
            if (itemActual != null)
            {
                var _it = (Domain.Models.Cierre)itemActual;
                _repoPagoResumen.setIdResumenHistorico(_it.idResumen, _it.nroCierre);
                _repoPagoResumen.Generar();
            }
        }
        //
        private bool cargarData()
        {
            try
            {
                _lCierre.Clear();
                var _lst = _uc.CargarListaCierresHistorico();
                foreach (var rg in _lst)
                {
                    _lCierre.Add(rg);
                }
                _bsCierre.ResetBindings(false);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}