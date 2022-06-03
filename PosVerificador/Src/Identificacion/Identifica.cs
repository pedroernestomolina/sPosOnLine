using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Src.Identificacion
{
    
    public class Identifica: IIdentifica
    {


        private bool _isOk;
        private string _codigoUsu;
        private string _claveUsu;


        public bool IsOk { get { return _isOk; } }

        
        public Identifica()
        {
            Inicializa();
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
            }
            frm.ShowDialog();
        }
        public void Inicializa()
        {
            _isOk = false;
            _codigoUsu = "";
            _claveUsu = "";
        }
        public void SetCodigo(string p)
        {
            _codigoUsu = p.Trim().ToUpper();
        }
        public void SetClave(string p)
        {
            _claveUsu = p.Trim().ToUpper();
        }
        public  void Aceptar()
        {
            _isOk = false;
            VerificarUsuario();
        }


        private bool CargarData()
        {
            return true;
        }
        private void VerificarUsuario()
        {
            var ficha = new OOB.Usuario.Identificar.Ficha()
            {
                codigo = _codigoUsu,
                clave = _claveUsu,
            };
            var r01 = Sistema.MyData.Usuario_Identifica(ficha);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Sistema.Usuario = r01.Entidad;
            _isOk = true;
        }

    }

}