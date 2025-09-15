using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.CuadreCierre.vm
{
    public class CuadreImpl: ICuadre
    {
        private Domain.Models.MyData _myData;
        private Domain.UseCase.IUseCase _uc;
        private _Domain.Models.MedioPago _medioPagoPorBonoDivisa;
        private _Domain.UseCase.ICargarMedioPagoPorBonoDivisa _ucCargarMedioPagoPorBonoDivisa;
        private BindingSource _bsMetodosPago;
        private BindingList<Domain.Models.MetodoPagoUso> _blMetPagoUso;
        //
        public object Get_MetodosPagoSource { get { return _bsMetodosPago; } }
        //
        public CuadreImpl()
        {
            _myData= new Domain.Models.MyData();
            _uc = new Domain.UseCase.UseCaseImpl();
            _ucCargarMedioPagoPorBonoDivisa= new _Domain.UseCase.CargarMedioPagoPorBonoDivisaImpl();
            _blMetPagoUso= new BindingList<Domain.Models.MetodoPagoUso>(_myData.MetodosPagoUsado);
            _bsMetodosPago= new BindingSource();
            _bsMetodosPago.DataSource=_blMetPagoUso;
            _bsMetodosPago.CurrencyManager.Refresh();
        }
        public void Inicializa()
        {
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
        }
        //
        private bool cargarData()
        {
            try
            {
                setMedioPagoPorBonoDivisa(_ucCargarMedioPagoPorBonoDivisa.Invoke());
                setDataResumenRecolectada(_uc.CuadreResumen(Sistema.PosEnUso.idResumen));
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
            if (_bsMetodosPago.Current != null) 
            {
                var rt = (Domain.Models.MetodoPagoUso)_bsMetodosPago.Current;
                Helpers.Msg.Alerta(rt.CabMontoUsu.ToString());
            }
        }
    }
}