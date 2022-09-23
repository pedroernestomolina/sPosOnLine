using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pago.ValidarCambio.ConVuelto
{
    
    public partial class ValidarCambioFrm : Form
    {


        private IConVuelto _controlador;

        
        public ValidarCambioFrm()
        {
            InitializeComponent();
        }


        private void ValidarCambioFrm_Load(object sender, EventArgs e)
        {
            L_MONTO_VALIDAR.Text = _controlador.GetMontoValidar.ToString("n2");
            L_MONTO_DIVISA.Text = _controlador.GetMontoDivisa.ToString("n2");
            L_TOTAL.Text = _controlador.GetTotal.ToString("n2");
            TB_MONTO_EFECTIVO.Text = _controlador.GetMontoEfectivoEnt.ToString();
            TB_CANT_DIVISA.Text = _controlador.GetCntDivisaEnt.ToString();
            Actualizar();
            IrFoco();
        }
        
        private void IrFoco()
        {
            TB_MONTO_EFECTIVO.Focus();
        }

        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            IrFoco();
            _controlador.Procesar();
            if (_controlador.ProcesarIsOK)
            {
                Salir();
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void Abandonar()
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
            {
                e.Cancel = false;
            }
        }


        public void setControlador(IConVuelto ctr)
        {
            _controlador = ctr;
        }


        private void TB_MONTO_EFECTIVO_Leave(object sender, EventArgs e)
        {
            var _monto= decimal.Parse(TB_MONTO_EFECTIVO.Text);
            _controlador.PagoPorEfectivo(_monto);
            Actualizar();
        }
        private void TB_CANT_DIVISA_Leave(object sender, EventArgs e)
        {
            var _cnt = int.Parse(TB_CANT_DIVISA.Text);
            _controlador.PagoPorDivisa(_cnt);
            Actualizar();
        }
        private void TB_MONTO_PAGO_MOVIL_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_MONTO_PAGO_MOVIL.Text);
            _controlador.PagoPorPagoMovil(_monto);
            Actualizar();
        }
        private void Actualizar()
        {
            L_MONTO_DIVISA.Text = _controlador.GetMontoDivisa.ToString("n2");
            TB_MONTO_PAGO_MOVIL.Text = _controlador.GetMontoPagoMovilEnt.ToString();
            L_TOTAL.Text = _controlador.GetVueltoMonto.ToString("n2");
            L_VUELTO.Text = _controlador.GetVueltoDesc;
        }


    }

}