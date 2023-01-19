using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Identificacion
{

    public partial class IdentificacionFrm : Form
    {

        private ILogin _controlador;


        public IdentificacionFrm()
        {
            InitializeComponent();
        }
        private void IdentificacionFrm_Load(object sender, EventArgs e)
        {
            TB_CODIGO.Text = _controlador.GetCodigo;
            TB_CLAVE.Text = _controlador.GetClave;
            TB_CODIGO.Focus();
        }
        private void IdentificacionFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK || _controlador.LoginIsOk)
            {
                e.Cancel = false;
            }
        }
        public void setControlador(ILogin ctr)
        {
            _controlador = ctr;
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            _controlador.setCodigo(TB_CODIGO.Text);
        }
        private void TB_CLAVE_Leave(object sender, EventArgs e)
        {
            _controlador.setClave(TB_CLAVE.Text);
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOK)
            {
                Salir();
            }
        }
        private void Aceptar()
        {
            _controlador.Aceptar();
            if (_controlador.LoginIsOk)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
    }
}