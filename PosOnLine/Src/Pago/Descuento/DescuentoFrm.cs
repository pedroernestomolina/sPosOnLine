using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pago.Descuento
{

    public partial class DescuentoFrm : Form
    {

        private Gestion _controlador;
        

        public DescuentoFrm()
        {
            InitializeComponent();
        }


        private void TB_CANTIDAD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_OK_Click(object sender, EventArgs e)
        {
            _controlador.Aceptar();
            if (_controlador.IsOk)
            {
                IrFoco();
                Salir();
            }
            IrFoco();
        }

        private void DescuentoFrm_Load(object sender, EventArgs e)
        {
            TB_CANTIDAD.Text = _controlador.Descuento.ToString("n2");
            IrFoco();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void TB_CANTIDAD_Leave(object sender, EventArgs e)
        {
            _controlador.setPorcentaje(decimal.Parse(TB_CANTIDAD.Text.Trim()));
        }

        private void IrFoco() 
        {
            TB_CANTIDAD.Focus();
            TB_CANTIDAD.SelectAll();
        }

    }

}