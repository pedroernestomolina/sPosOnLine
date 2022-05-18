using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.PassWord
{

    public partial class PassWordFrm : Form
    {


        private Gestion _controlador;
 

        public PassWordFrm()
        {
            InitializeComponent();
        }


        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            IrFoco();
            Salir();
        }

        private void IrFoco()
        {
            TB_CLAVE.Focus();
            TB_CLAVE.SelectAll();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void TB_CLAVE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void PassWordFrm_Load(object sender, EventArgs e)
        {
            TB_CLAVE.Text = "";
            IrFoco();
        }

        private void TB_CLAVE_Leave(object sender, EventArgs e)
        {
            _controlador.setClave(TB_CLAVE.Text.Trim().ToUpper());
        }

    }

}