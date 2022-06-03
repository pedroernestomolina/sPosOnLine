using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Agencia.Agregar
{
    
    public class Agregar: IAgregar
    {

        private bool _abandonarIsOk;
        private bool _procesarIsOk;
        private string _nombre;


        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool IsOk { get { return _procesarIsOk; } }
        public string GetAgencia { get { return _nombre; } }


        public Agregar() 
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _nombre = "";
        }

        public void Inicializa()
        {
            _abandonarIsOk = false;
            _procesarIsOk = false;
            _nombre = "";
        }

        AgregarFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new AgregarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void AbandonarFicha()
        {
            _abandonarIsOk = false;
            var msg = MessageBox.Show("Abandonar Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                _abandonarIsOk = true;
            }
        }
        public void ProcesarFicha()
        {
            _procesarIsOk = false;
            if (_nombre.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ AGENCIA NOMBRE ] NO PUEDE ESTAR VACIO");
                return;
            }
            var msg = MessageBox.Show("Procesar Ingreso ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _procesarIsOk = true;
            }
        }
        public void setNombre(string p)
        {
            _nombre = p;
        }


        private bool CargarData()
        {
            var rt = true;

            return rt;
        }

    }

}