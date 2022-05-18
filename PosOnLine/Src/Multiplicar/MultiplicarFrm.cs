using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Multiplicar
{

    public partial class MultiplicarFrm : Form
    {

        private Gestion _controlador;


        public MultiplicarFrm()
        {
            InitializeComponent();
            Limpiar();
        }

        private void Limpiar()
        {
            TB_CANTIDAD.Text = "0";
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Salida()
        {
            this.Close();
        }

        private void MultiplicarFrm_Load(object sender, EventArgs e)
        {
            Limpiar();
            IrFoco();
        }

        private void IrFoco()
        {
            TB_CANTIDAD.Focus();
            TB_CANTIDAD.SelectAll();
        }

        private void Ctrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_OK.Focus();
            }
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void TB_CANTIDAD_Leave(object sender, EventArgs e)
        {
            _controlador.setCantidad(int.Parse(TB_CANTIDAD.Text.Trim()));
        }

        private void TB_OK_Click(object sender, EventArgs e)
        {
            _controlador.Procesar();
            IrFoco();
            Salida();
        }

    }

}