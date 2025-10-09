using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosSolicitudUsuarioAdm.vm
{
    public class SolicitudUsuarioAdmImpl: ISolicitudUsuarioAdm
    {
        private SolicitarPermiso.ISolicitarPermiso _vmSolicitarPermiso;
        private Domain.Models.UsuarioAutoriza _usuAutorizaPermiso;
        private bool _autorizaPermisoIsOk;
        //
        public bool Get_AutorizaPermisoIsOk { get { return _autorizaPermisoIsOk; } }
        public Domain.Models.UsuarioAutoriza Get_UsuarioAutorizoPermiso { get { return _usuAutorizaPermiso; } }
        //
        public SolicitudUsuarioAdmImpl()
        {
            _vmSolicitarPermiso = new SolicitarPermiso.SolicitarPerm();
        }
        public void Invoke()
        {
            _usuAutorizaPermiso = null;
            _autorizaPermisoIsOk = false;
            try
            {
                _vmSolicitarPermiso.Invoke();
                if (!_vmSolicitarPermiso.IsOk)
                {
                    return;
                }
                //
                var usuNombre = _vmSolicitarPermiso.GetUsuario;
                var usuPsw = _vmSolicitarPermiso.GetPassword;
                var _usuOOB = Helpers.VerificarPermiso.Verificar(usuNombre, usuPsw);
                _autorizaPermisoIsOk = true;
                _usuAutorizaPermiso = new Domain.Models.UsuarioAutoriza()
                {
                    idUsu = _usuOOB.id,
                    codigoUsu = _usuOOB.codigo,
                    nombreUsu = _usuOOB.nombre,
                    grupoUsu = _usuOOB.nombreGrupo,
                };
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}