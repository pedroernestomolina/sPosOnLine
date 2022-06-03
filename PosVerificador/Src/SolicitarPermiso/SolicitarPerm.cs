using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Src.SolicitarPermiso
{
    
    public class SolicitarPerm: ISolicitarPermiso
    {

        private string _usuario;
        private string _password;
        private string _motivo;
        private bool _aceptarIsOk;
        private bool _abandonarIsOk;


        public bool IsOk { get { return _aceptarIsOk; } }
        public string GetUsuario { get { return _usuario; } }
        public string GetPassword { get { return _password; } }
        public string GetSolicitudMotivo { get { return _motivo; } }


        public SolicitarPerm() 
        {
            _aceptarIsOk = false;
            _abandonarIsOk = false;
            _usuario = "";
            _password = "";
            _motivo = "";
        }


        public void Inicializa()
        {
            _aceptarIsOk = false;
            _abandonarIsOk = false;
            _usuario = "";
            _password = "";
            _motivo = "";
        }
        SolicitarPermisoFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new SolicitarPermisoFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }


        public bool AceptarIsOk { get { return _aceptarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void Aceptar()
        {
            _aceptarIsOk = true;
        }
        public void Abandonar()
        {
            _abandonarIsOk = true;
        }
        public void setUsuario(string p)
        {
            _usuario = p;
        }
        public void setClave(string p)
        {
            _password = p;
        }
        public void setMotivoSolicitud(string mot)
        {
            _motivo = mot;
        }

    }

}
