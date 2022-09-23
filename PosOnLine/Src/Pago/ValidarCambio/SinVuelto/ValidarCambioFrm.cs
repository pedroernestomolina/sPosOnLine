using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pago.ValidarCambio.SinVuelto
{
    
    public partial class ValidarCambioFrm : Form
    {


        private ISinVuelto _controlador;

        
        public ValidarCambioFrm()
        {
            InitializeComponent();
        }


        private void ValidarCambioFrm_Load(object sender, EventArgs e)
        {
            TB_MONTO.Text = "0";
            IrFoco();
        }

        private void TB_MONTO_Leave(object sender, EventArgs e)
        {
            var monto= decimal.Parse(TB_MONTO.Text);
            _controlador.setMontoCapturado(monto);
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            IrFoco();
            this.Close();
        }

        private void IrFoco()
        {
            TB_MONTO.Focus();
        }

        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            IrFoco();
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOK)
            {
                Salir();
            }
        }
        private void Salir()
        {
            Close();
        }

        private void ValidarCambioFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.ProcesarIsOK || _controlador.AbandonarIsOK)
                e.Cancel = false;
        }

        private void BT_PAGO_MOVIL_Click(object sender, EventArgs e)
        {
            PagoMovil();
        }
        private void PagoMovil()
        {
            _controlador.PagoMovil();
            if (_controlador.PagoMovilIsOk)
            {
                Salir();
            }
        }


        public void setControlador(ISinVuelto ctr)
        {
            _controlador = ctr;
        }

    }

}