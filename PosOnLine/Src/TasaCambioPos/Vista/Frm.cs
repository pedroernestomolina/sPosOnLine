using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosOnLine.Src.TasaCambioPos.Vista
{
    public partial class Frm : Form
    {
        private Vm.ITasaCambioPos _controlador;
        //
        public Frm()
        {
            InitializeComponent();
        }
        public void setControlador(Vm.ITasaCambioPos ctr)
        {
            _controlador = ctr;
        }
        //
        private void Frm_Load(object sender, EventArgs e)
        {
            TB_TASA_POS.Text = _controlador.GetTasaPosInput.ToString();
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
            if (_controlador.AbandonarFichaIsOK || _controlador.CambioIsOK)
            {
                e.Cancel = false;
            }
        }
        //
        private void TB_TASA_POS_Leave(object sender, EventArgs e)
        {
            var _tasa = decimal.Parse(TB_TASA_POS.Text);
            _controlador.setTasaPos(_tasa);
        }
        //
        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            ProcesarFicha();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        //
        private void ProcesarFicha()
        {
            _controlador.ProcesarFicha();
            if (_controlador.CambioIsOK) 
            {
                salir();
            }
        }
        private void AbandonarFicha() 
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarFichaIsOK) 
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