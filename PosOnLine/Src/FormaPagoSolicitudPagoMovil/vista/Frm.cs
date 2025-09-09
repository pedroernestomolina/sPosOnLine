using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.FormaPagoSolicitudPagoMovil.vista
{
    public partial class Frm : Form
    {
        private vm.IPagoMovil _controlador;
        private bool _modoInicializar;
        //
        private void InicializaCB()
        {
            CB_AGENCIA.DisplayMember = "desc";
            CB_AGENCIA.ValueMember = "id";
        }
        public Frm()
        {
            InitializeComponent();
            InicializaCB();
        }
        public void setControlador(vm.IPagoMovil ctr)
        {
            _controlador = ctr;
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            irFoco();
            _modoInicializar = true;
            L_MONTO.Text = _controlador.Get_MontoPagoMovil.ToString("n2");
            TB_NOMBRE.Text = _controlador.Get_EntidadNombre;
            TB_CI_RIF.Text = _controlador.Get_EntidadCiRif;
            TB_TELEFONO.Text = _controlador.Get_EntidadTelefono;
            CB_AGENCIA.DataSource = _controlador.Get_AgenciasSource;
            CB_AGENCIA.SelectedValue = _controlador.Get_AgenciaID;
            _modoInicializar = false;
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.abandonarFichaIsOK || _controlador.solicitudIsOk)
            {
                e.Cancel = false;
            }
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            ProcesarFicha();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        //
        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.setEntidadNombre(TB_NOMBRE.Text);
        }
        private void TB_CI_RIF_Leave(object sender, EventArgs e)
        {
            _controlador.setEntidadCiRif(TB_CI_RIF.Text);
        }
        private void TB_TELEFONO_Leave(object sender, EventArgs e)
        {
            _controlador.setEntidadTelefono(TB_TELEFONO.Text);
        }
        private void CB_AGENCIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) return;
            _controlador.setAgencia("");
            if (CB_AGENCIA.SelectedIndex != -1) 
            {
                _controlador.setAgencia(CB_AGENCIA.SelectedValue.ToString());
            }
        }
        private void L_AGENCIA_DoubleClick(object sender, EventArgs e)
        {
            AgregarAgencias();
        }
        private void AgregarAgencias()
        {
            //_controlador.AgregarAgencias();
        }
        //
        private void irFoco()
        {
            TB_NOMBRE.Focus();
            TB_NOMBRE.Select(0, 0);
        }
        private void ProcesarFicha()
        {
            irFoco();
            _controlador.procesarFicha();
            if (_controlador.solicitudIsOk)
            {
                salir();
            }
        }
        private void AbandonarFicha()
        {
            irFoco();
            _controlador.abandonarFicha();
            if (_controlador.abandonarFichaIsOK)
            {
                salir();
            }
        }
        private void salir()
        {
            this.Close();
        }
    }
}