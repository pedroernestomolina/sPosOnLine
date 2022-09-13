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

        private ILoteRef _controlador;


        public LoteReferenciaFrm()
        {
            InitializeComponent();
        }


        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        public void setControlador(ILoteRef ctr)
        {
            _controlador = ctr;
        }

        private void LoteReferenciaFrm_Load(object sender, EventArgs e)
        {
            TB_LOTE.Text = _controlador.GetNroLote;
            TB_REFERENCIA.Text = _controlador.GetNroReferencia;
            IrFoco();
        }

        private void IrFoco()
        {
            TB_LOTE.Focus();
            TB_LOTE.SelectAll();
        }

        private void TB_LOTE_Leave(object sender, EventArgs e)
        {
            _controlador.setNroLote(TB_LOTE.Text.Trim().ToUpper());
        }
        private void TB_REFERENCIA_Leave(object sender, EventArgs e)
        {
            _controlador.setNroReferencia(TB_REFERENCIA.Text.Trim().ToUpper());
        }


        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }
        private void Aceptar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOK)
            {
                IrFoco();
                Salir();
            }
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
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
        private void LoteReferenciaFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK || _controlador.ProcesarIsOK) 
            {
                e.Cancel = false;
            }
        }

    }

}