using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.CtrlPendiente.DesProteger.vm
{
    public class DesprotegerImpl: IDesproteger
    {
        private Domain.UseCase.IUseCase _uc;
        private __.Domain.UseCase.IUseCase _uc2;
        private PosSolicitudUsuarioAdm.vm.ISolicitudUsuarioAdm _solicitarPermiso;
        //
        public DesprotegerImpl ()
        {
            _uc = new Domain.UseCase.UseCaseImpl();
            _uc2 = new __.Domain.UseCase.UseCaseImpl();
            _solicitarPermiso = new PosSolicitudUsuarioAdm.vm.SolicitudUsuarioAdmImpl();
        }
        public void DesProtegerCuenta(int idCta)
        {
            try
            {
                if (_uc2.VerificaSiCuentaAbrirEstaProtegida(idCta))
                {
                    _solicitarPermiso.Invoke("");
                    if (_solicitarPermiso.Get_AutorizaPermisoIsOk)
                    {
                        if (Helpers.Msg.Procesar("Desproteger Cuenta De Acceso No Autorizado ?"))
                        {
                            _uc.DesProtegerCuenta(idCta);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}
