using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Lib.Controles.BalanzaSoloPeso.BalanzaManual
{

    public partial class BalanzaFrm : Form
    {


        private decimal _peso;


        public decimal Peso 
        {
            get 
            {
                return _peso;
            }
        }


        public BalanzaFrm()
        {
            InitializeComponent();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Salida()
        {
            this.Close();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            var tb= TB_PESO.Text.Trim();
            if (tb!= "") 
            {
                _peso = decimal.Parse(tb);
                Salida();
            }
        }

        private void BalanzaFrm_Load(object sender, EventArgs e)
        {
            TB_PESO.Focus();
        }

        private void TB_PESO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

    }

}