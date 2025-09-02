using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.FormaPagoLoteRef.vista
{
    public partial class Frm : Form
    {
        private vm.ILoteRef _controlador;
        //
        public Frm()
        {
            InitializeComponent();
        }
        public void setControlador(FormaPagoLoteRef.vm.ILoteRef ctr)
        {
            _controlador = ctr;
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            goInicio();
            TB_LOTE.Text = _controlador.getLote;
            TB_REF.Text = _controlador.getReferencia;
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
            if (_controlador.salidaIsOk) 
            {
                e.Cancel = false;
            }
        }
        //
        private void TB_LOTE_Leave(object sender, EventArgs e)
        {
            _controlador.setLote(TB_LOTE.Text.Trim());
        }
        private void TB_REF_Leave(object sender, EventArgs e)
        {
            _controlador.setReferencia(TB_REF.Text.Trim());
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            goInicio();
            _controlador.salir();
            salir();
        }
        //
        private void goInicio()
        {
            TB_LOTE.Focus();
        }
        private void salir()
        {
            this.Close();
        }
    }
}