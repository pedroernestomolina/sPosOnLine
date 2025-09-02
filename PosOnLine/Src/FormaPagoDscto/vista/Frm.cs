using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.FormaPagoDscto.vista
{
    public partial class Frm : Form
    {
        private FormaPagoDscto.vm.IDscto _controlador;
        //
        public Frm()
        {
            InitializeComponent();
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            irFoco();
            TB_CANTIDAD.Text = _controlador.Get_DsctoDado.ToString();
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
            if (_controlador.abandonarFichaIsOk || _controlador.procesarFichaIsOK)
            {
                e.Cancel = false;
            }
        }
        //
        public void setControlador(FormaPagoDscto.vm.IDscto ctr)
        {
            _controlador = ctr;
        }
        private void TB_CANTIDAD_Leave(object sender, EventArgs e)
        {
            if (TB_CANTIDAD.Text.Trim() == "") return;
            //
            var _porct = decimal.Parse(TB_CANTIDAD.Text.Trim());
            _controlador.setDsctoDar(_porct);
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            irFoco();
            abandonarFicha();
        }
        private void BT_OK_Click(object sender, EventArgs e)
        {
            irFoco();
            procesarFicha();
        }
        //
        private void irFoco() 
        {
            TB_CANTIDAD.Focus();
            TB_CANTIDAD.SelectAll();
        }
        private void procesarFicha()
        {
            _controlador.procesarFicha();
            if (_controlador.procesarFichaIsOK)
            {
                salir();
            }
        }
        private void abandonarFicha() 
        {
            _controlador.abandonarFicha();
            if (_controlador.abandonarFichaIsOk) 
            {
                salir();
            }
        }
        private void salir() 
        {
            this.Close();
        }
    }
}