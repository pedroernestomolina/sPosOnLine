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

        private Gestion _controlador;


        public IdentificacionFrm()
        {
            InitializeComponent();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void Salir()
        {
            this.Close();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }
        private void Aceptar()
        {
            _controlador.Aceptar();
            if (_controlador.IsOk) 
            {
                Salir();
            }
        }

        private void Limpiar()
        {
            TB_CODIGO.Text = "";
            TB_CLAVE.Text = "";
            TB_CODIGO.Focus();
        }

        private void IdentificacionFrm_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            _controlador.SetCodigo(TB_CODIGO.Text);
        }
        private void TB_CLAVE_Leave(object sender, EventArgs e)
        {
            _controlador.SetClave(TB_CLAVE.Text);
        }

    }

}