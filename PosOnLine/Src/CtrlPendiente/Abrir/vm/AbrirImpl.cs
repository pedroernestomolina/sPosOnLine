using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.CtrlPendiente.Abrir.vm
{
    public class AbrirImpl: IAbrir
    {
        private Domain.UseCase.IUseCase _uc;
        private __.Domain.UseCase.IUseCase _uc2;
        private PosSolicitudUsuarioAdm.vm.ISolicitudUsuarioAdm _solicitarPermiso;
        //
        public AbrirImpl()
        {
            _uc = new Domain.UseCase.UseCaseImpl();
            _uc2 = new __.Domain.UseCase.UseCaseImpl();
            _solicitarPermiso = new PosSolicitudUsuarioAdm.vm.SolicitudUsuarioAdmImpl();
        }
        public bool AbrirCuenta(int idCta)
        {
            var _isOk = false;
            try
            {
                var _paseVerificacion = true;
                if (_uc2.VerificaSiCuentaAbrirEstaProtegida(idCta))
                {
                    _solicitarPermiso.Invoke("");
                    if (!_solicitarPermiso.Get_AutorizaPermisoIsOk)
                    {
                        _paseVerificacion = false;
                    }
                }
                if (_paseVerificacion) 
                {
                    if (Helpers.Msg.Procesar("Abrir Cuenta Pendiente ?"))
                    {
                        _uc.AbrirCuentaPendiente(idCta);
                        _isOk=true;
                    }
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            return _isOk;
        }
    }
}