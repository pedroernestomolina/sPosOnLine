using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Cierre.Fiscal
{
    public partial class Frm : Form
    {
        private ICierre _controlador;


        public Frm()
        {
            InitializeComponent();
        }
        private void Frm_Load(object sender, EventArgs e)
        {
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && e.KeyCode == Keys.N)
            {
                CierreNoFiscal();
            }
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK)
            {
                e.Cancel = false;
            }
        }


        public void setControador(ICierre ctr)
        {
            _controlador = ctr;
        }


        private void BT_REP_X_Click(object sender, EventArgs e)
        {
            _controlador.ReporteX();
        }
        private void BT_REP_Z_Click(object sender, EventArgs e)
        {
            _controlador.ReporteZ();
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void CierreNoFiscal()
        {
            _controlador.CierreNoFiscal();
        }
        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOK)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
    }
}