using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Identificacion
{
    
    public class ImpLogin: ILogin
    {
        private bool _abandonarIsOk;
        private bool _isOk;
        private string _codigoUsu;
        private string _claveUsu;


        public bool LoginIsOk { get { return _isOk; } }

        
        public ImpLogin()
        {
            _abandonarIsOk = false;
            _isOk = false;
            _codigoUsu = "";
            _claveUsu = "";
        }

        public void Inicializa()
        {
            _abandonarIsOk = false;
            _isOk = false;
            _codigoUsu = "";
            _claveUsu = "";
        }
        IdentificacionFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new IdentificacionFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public  void Aceptar()
        {
            _isOk = VerificarUsuario();
        }
        public bool VerificarUsuario()
        {
            try
            {
                if (_codigoUsu == "") 
                {
                    return false;
                }
                if (_codigoUsu == Sistema.USUARIO_ADMINISTRATIVO && _claveUsu == Sistema.USUARIO_ADMINISTRATIVO_CLAVE)
                {
                    Sistema.Usuario = new OOB.Usuario.Entidad.Ficha();
                    Sistema.Usuario.setInvitado();
                    return true;
                }
                var ficha = new OOB.Usuario.Identificar.Ficha()
                {
                    codigo = _codigoUsu,
                    clave = _claveUsu,
                };
                var r01 = Sistema.MyData.Usuario_Identificar(ficha);
                Sistema.Usuario = r01.Entidad;
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

        public bool AbandonarIsOK { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }

        public string GetCodigo { get { return _codigoUsu; } }
        public string GetClave { get { return _claveUsu; } }
        public void setCodigo(string desc)
        {
            _codigoUsu = desc.Trim().ToUpper();
        }
        public void setClave(string psw)
        {
            _claveUsu = psw.Trim().ToUpper();
        }


        private bool CargarData()
        {
            return true;
        }
    }
}