using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pago.LoteReferencia
{

    public partial class LoteReferenciaFrm : Form
    {

        private Gestion _controlador;


        public LoteReferenciaFrm()
        {
            InitializeComponent();
        }


        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            _controlador.Aceptar();
            if (_controlador.IsOk)
            {
                IrFoco();
                Salir();
            }
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void LoteReferenciaFrm_Load(object sender, EventArgs e)
        {
            TB_LOTE.Text = _controlador.Lote;
            TB_REFERENCIA.Text = _controlador.Referencia;
            IrFoco();
        }

        private void IrFoco()
        {
            TB_LOTE.Focus();
            TB_LOTE.SelectAll();
        }

        private void TB_LOTE_Leave(object sender, EventArgs e)
        {
            _controlador.setLote(TB_LOTE.Text.Trim().ToUpper());
        }

        private void TB_REFERENCIA_Leave(object sender, EventArgs e)
        {
            _controlador.setReferencia(TB_REFERENCIA.Text.Trim().ToUpper());
        }

    }

}