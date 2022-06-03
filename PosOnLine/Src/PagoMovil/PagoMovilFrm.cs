using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.PagoMovil
{

    public partial class PagoMovilFrm : Form
    {

        private IPagoMovil _controlador;
        private bool _modoInicializar;


        public PagoMovilFrm()
        {
            InitializeComponent();
            InicializaCB();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void AbandonarFicha()
        {
            IrFoco();
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOk) 
            {
                Salir();
            }
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            ProcesarFicha();
        }
        private void ProcesarFicha()
        {
            IrFoco();
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }

        private void PagoMovilFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk) 
            {
                e.Cancel = false;
            }
        }


        private void PagoMovilFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            L_MONTO.Text = _controlador.GetMontoPagoMovil.ToString("n2");
            TB_NOMBRE.Text = _controlador.GetNombrePersona;
            TB_CI_RIF.Text = _controlador.GetCiRifPersona;
            TB_TELEFONO.Text = _controlador.GetTelefonoPersona;
            CB_AGENCIA.DataSource = _controlador.GetAgenciaSource;
            CB_AGENCIA.SelectedIndex = -1;
            _modoInicializar = false;
            IrFoco();
        }

        public void setControlador(IPagoMovil ctrl)
        {
            _controlador = ctrl;
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.setNombre(TB_NOMBRE.Text);
        }
        private void TB_CI_RIF_Leave(object sender, EventArgs e)
        {
            _controlador.setCiRif(TB_CI_RIF.Text);
        }
        private void TB_TELEFONO_Leave(object sender, EventArgs e)
        {
            _controlador.setTelefono(TB_TELEFONO.Text);
        }
        private void InicializaCB()
        {
            CB_AGENCIA.DisplayMember = "desc";
            CB_AGENCIA.ValueMember = "id";
        }

        private void CB_AGENCIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setAgencia("");
            if (CB_AGENCIA.SelectedIndex != -1) 
            {
                _controlador.setAgencia(CB_AGENCIA.SelectedValue.ToString());
            }
        }
        private void IrFoco()
        {
            TB_NOMBRE.Focus();
            TB_NOMBRE.Select(0, 0);
        }

        private void L_AGENCIA_DoubleClick(object sender, EventArgs e)
        {
            AgregarAgencias();
        }
        private void AgregarAgencias()
        {
            _controlador.AgregarAgencias();
        }
   
    }

}