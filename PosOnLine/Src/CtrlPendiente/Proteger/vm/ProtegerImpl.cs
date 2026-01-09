using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.CtrlPendiente.Proteger.vm
{
    public class ProtegerImpl: IProteger
    {
        private Domain.UseCase.IUseCase _uc;
        private __.Domain.UseCase.IUseCase _uc2;
        private PosSolicitudUsuarioAdm.vm.ISolicitudUsuarioAdm _solicitarPermiso;
        //
        public ProtegerImpl()
        {
            _uc = new Domain.UseCase.UseCaseImpl();
            _uc2 = new __.Domain.UseCase.UseCaseImpl();
            _solicitarPermiso = new PosSolicitudUsuarioAdm.vm.SolicitudUsuarioAdmImpl();
        }
        public void ProtegerCuenta(int idCta)
        {
            try
            {
                if (_uc2.VerificaSiCuentaAbrirEstaProtegida(idCta))
                {
                    throw new Exception("CUENTA YA PROTEGIDA");
                }
                _solicitarPermiso.Invoke("");
                if (_solicitarPermiso.Get_AutorizaPermisoIsOk)
                {
                    if (Helpers.Msg.Procesar("Proteger Cuenta De Acceso No Autorizado ?"))
                    {
                        _uc.ProtegerCuenta(idCta);
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