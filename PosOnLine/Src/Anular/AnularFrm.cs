using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Anular
{

    public partial class AnularFrm : Form
    {


        private Gestion _controlador;


        public AnularFrm()
        {
            InitializeComponent();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            IrFoco();
            this.Close();
        }

        public  void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.IsAnularOK) 
            {
                IrFoco();
                Salir();
            }
        }

        private void IrFoco()
        {
            TB_MOTIVO.Focus();
            TB_MOTIVO.SelectAll();
        }

        private void TB_MOTIVO_Leave(object sender, EventArgs e)
        {
            _controlador.Motivo = TB_MOTIVO.Text;
        }

        private void AnularFrm_Load(object sender, EventArgs e)
        {
            TB_MOTIVO.Text = _controlador.Motivo;
            IrFoco();
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
      
    }

}