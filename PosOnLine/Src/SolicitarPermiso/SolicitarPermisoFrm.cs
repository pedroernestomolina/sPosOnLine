using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.SolicitarPermiso
{

    public partial class SolicitarPermisoFrm : Form
    {

        private ISolicitarPermiso _controlador;


        public SolicitarPermisoFrm()
        {
            InitializeComponent();
        }


        public void setControlador(ISolicitarPermiso ctr)
        {
            _controlador = ctr;
        }

        private void SolicitarPermisoFrm_Load(object sender, EventArgs e)
        {
            TB_CODIGO.Text = _controlador.GetUsuario;
            TB_CLAVE.Text = _controlador.GetPassword;
            IrFocoPrincipal();
        }

        private void IrFocoPrincipal()
        {
            TB_CODIGO.Focus();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            IrFocoPrincipal();
            _controlador.Aceptar();
            if (_controlador.AceptarIsOk)
            {
                Salir();
            }
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            IrFocoPrincipal();
            _controlador.Abandonar();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }
        private void SolicitarPermisoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AceptarIsOk || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }

        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            _controlador.setUsuario(TB_CODIGO.Text.Trim().ToUpper());
        }
        private void TB_CLAVE_Leave(object sender, EventArgs e)
        {
            _controlador.setClave(TB_CLAVE.Text.Trim());
        }
        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

    }

}