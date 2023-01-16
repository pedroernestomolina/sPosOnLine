using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Anular
{
    
    public class ImpAnular: IAnular
    {
        private string _motivo;
        private bool _anularIsOk;
        private bool _procesarIsOk;

        public string Motivo { get { return _motivo; } }

        public ImpAnular()
        {
            _motivo = "";
            _anularIsOk = false;
            _procesarIsOk = false;
        }

        public void Inicializa()
        {
            _motivo = "";
            _anularIsOk = false;
            _procesarIsOk = false;
        }
        AnularFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AnularFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public bool AbandonarIsOK { get { return _anularIsOk; } }
        public void AbandonarFicha()
        {
            _anularIsOk = Helpers.Msg.Abandonar();
        }
        public bool ProcesarIsOK { get { return _procesarIsOk; } }
        public void Procesar()
        {
            _procesarIsOk = false;
            if (_motivo.Trim() != "")
            {
                _procesarIsOk = true;
            }
        }

        public string GetMotivo { get { return _motivo; } }
        public void setMotivo(string desc)
        {
            _motivo = desc;
        }
    }
}