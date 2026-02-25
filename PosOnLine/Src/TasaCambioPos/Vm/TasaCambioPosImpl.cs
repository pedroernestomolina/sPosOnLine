using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.TasaCambioPos.Vm
{
    public class TasaCambioPosImpl: ITasaCambioPos
    {
        private decimal _tasaPosActual;
        private decimal _tasaPosInput;
        private bool _cambioIsOk;
        private decimal _tasaSistemaActualizada;
        private decimal _dsctoBonoPagoDivisaActualizado;
        private List<OOB.Venta.Item.Entidad.Ficha> _listaItemsActualizados;
        private __.Ctrl.Boton.Abandonar.IAbandonar _btAbandonar;
        private __.Ctrl.Boton.Procesar.IProcesar _btProcesar;
        private PosSolicitudUsuarioAdm.vm.ISolicitudUsuarioAdm _solicitarPermiso;
        private Domain.USeCase.IUseCase _uc;
        //
        public decimal GetTasaPosInput { get { return _tasaPosInput; } }
        public bool AbandonarFichaIsOK { get { return _btAbandonar.OpcionIsOK; } }
        public bool CambioIsOK { get { return _cambioIsOk; } }
        public decimal GetTasaSistemaActualizada { get { return _tasaSistemaActualizada; } }
        public decimal GetDsctoBonoPagoDivisaActualizado { get { return _dsctoBonoPagoDivisaActualizado; } }
        public List<OOB.Venta.Item.Entidad.Ficha> GetListaItemsActualizados { get { return _listaItemsActualizados; } }
        //
        public TasaCambioPosImpl()
        {
            _tasaPosActual = 0m;
            _tasaPosInput = 0m;
            _cambioIsOk = false;
            _btAbandonar = new __.Ctrl.Boton.Abandonar.Imp();
            _btProcesar = new __.Ctrl.Boton.Procesar.Imp();
            _solicitarPermiso = new PosSolicitudUsuarioAdm.vm.SolicitudUsuarioAdmImpl();
            _uc = new Domain.USeCase.UseCaseImpl();
            //
            _tasaSistemaActualizada = 0m;
            _dsctoBonoPagoDivisaActualizado = 0m;
            _listaItemsActualizados = null;
        }
        public void Invoke()
        {
            Inicializa();
            Inicia();
        }
        //
        public void Inicializa() 
        {
            _tasaPosInput = 0m;
            _cambioIsOk = false;
            _btAbandonar.Inicializa();
            _btProcesar.Inicializa();
            //
            _tasaSistemaActualizada = 0m;
            _dsctoBonoPagoDivisaActualizado = 0m;
            _listaItemsActualizados = null;
        }
        Vista.Frm frm;
        public void Inicia() 
        {
            if (CargarDataInicial()) 
            {
                _solicitarPermiso.Invoke("");
                if (_solicitarPermiso.Get_AutorizaPermisoIsOk)
                {
                    _tasaPosInput = _tasaPosActual;
                    if (frm == null)
                    {
                        frm = new Vista.Frm();
                        frm.setControlador(this);
                    }
                    frm.ShowDialog();
                }
            }
        }
        //
        public void setTasaPos(decimal tasa)
        {
            _tasaPosInput = tasa;
        }
        //
        public void AbandonarFicha()
        {
            _btAbandonar.Opcion();
        }
        public void ProcesarFicha()
        {
            _cambioIsOk = false;
            _tasaSistemaActualizada = 0m;
            _dsctoBonoPagoDivisaActualizado = 0m;
            _listaItemsActualizados = null;
            if (_tasaPosInput <= 0m) 
            {
                return;
            }
            _btProcesar.Opcion("Procesar Esta Cambio de Tasa ?");
            if (_btProcesar.OpcionIsOK) 
            {
                ActualizarTasaPos();
            }
        }
        private void ActualizarTasaPos()
        {
            try
            {
                _listaItemsActualizados = null;
                var _modelo = new Domain.Models.ModeloActualizarTasa()
                {
                    IdOperador = Sistema.PosEnUso.id,
                    TasaPos = _tasaPosInput,
                };
                var rt = _uc.ActualizarTasaPos(_modelo);
                _listaItemsActualizados = rt.Items;
                _tasaSistemaActualizada = rt.TasaSistemaActualizada;
                _dsctoBonoPagoDivisaActualizado = rt.DsctoBonoPagoDivisaActualizado;
                _cambioIsOk = true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        //
        private bool CargarDataInicial()
        {
            try
            {
                _tasaPosActual= _uc.ObtenerTasaActualPos();
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