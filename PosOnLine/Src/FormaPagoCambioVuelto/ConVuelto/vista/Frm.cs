using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.FormaPagoCambioVuelto.ConVuelto.vista
{
    public partial class Frm : Form
    {
        private ConVuelto.vm.IConCambioVuelto _controlador;
        //
        public Frm()
        {
            InitializeComponent();
        }
        public void setControlador(ConVuelto.vm.IConCambioVuelto ctr)
        {
            _controlador = ctr;
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            irFoco();
            L_MONTO_VALIDAR.Text = _controlador.Get_MontoValidar.ToString("n2");
            TB_MONTO_EFECTIVO.Text = _controlador.Get_MontoPorEfectivo.ToString();
            TB_CANT_DIVISA.Text = _controlador.Get_CntPorDivisa.ToString();
            TB_MONTO_PAGO_MOVIL.Text = _controlador.Get_MontoPorPagoMovil.ToString();
            L_MONTO_DIVISA.Text = _controlador.Get_MontoPorDivisa.ToString("n2");
            L_TOTAL.Text = _controlador.Get_SaldoTotal.ToString("n2");
            Actualizar();
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.abandonarIsOK || _controlador.validacionIsOk)
            {
                e.Cancel = false;
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        //
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            ProcesarFicha();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        //
        private void TB_MONTO_EFECTIVO_Leave(object sender, EventArgs e)
        {
            var monto = 0m;
            if (TB_MONTO_EFECTIVO.Text.Trim() != "") 
            {
                monto = decimal.Parse(TB_MONTO_EFECTIVO.Text);
            };
            _controlador.setMontoPorEfectivo(monto);
            Actualizar();
        }
        private void TB_CANT_DIVISA_Leave(object sender, EventArgs e)
        {
            var cnt = 0;
            if (TB_CANT_DIVISA.Text.Trim() != "") 
            {
                cnt = int.Parse(TB_CANT_DIVISA.Text);
            } 
            _controlador.setCntPorDivisa(cnt);
            Actualizar();
        }
        private void TB_MONTO_PAGO_MOVIL_Leave(object sender, EventArgs e)
        {
            var _monto = 0m;
            if (TB_MONTO_PAGO_MOVIL.Text.Trim() != "") 
            {
                _monto = decimal.Parse(TB_MONTO_PAGO_MOVIL.Text);
            } 
            _controlador.setMontoPorPagoMovil(_monto);
            Actualizar();
        }
        private void Actualizar()
        {
            L_MONTO_DIVISA.Text = _controlador.Get_MontoPorDivisa.ToString("n2");
            L_TOTAL.Text = Math.Abs(_controlador.Get_SaldoTotal).ToString("n2");
            L_ESTADO_FALTA_SOBRA_OK.Text = _controlador.Get_EstadoFaltaSobraOk;
        }
        //
        private void irFoco()
        {
            TB_MONTO_EFECTIVO.Focus();
        }
        private void ProcesarFicha()
        {
            irFoco();
            _controlador.procesarFicha();
            if (_controlador.validacionIsOk)
            {
                salir();
            }
        }
        private void AbandonarFicha()
        {
            irFoco();
            _controlador.abandonarFicha();
            if (_controlador.abandonarIsOK)
            {
                salir();
            }
        }
        private void salir()
        {
            Close();
        }
    }
}