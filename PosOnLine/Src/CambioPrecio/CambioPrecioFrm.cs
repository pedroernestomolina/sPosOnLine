using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.CambioPrecio
{

    public partial class CambioPrecioFrm : Form
    {

        private ICambioPrecio _controlador;


        public CambioPrecioFrm()
        {
            InitializeComponent();
        }


        public void setControlador(ICambioPrecio ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void AbandonarFicha()
        {
            IrFocoPrincipal();
            _controlador.Abandonar();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }
        private void CambioPrecioFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            IrFocoPrincipal();
            ProcesarCambios();
        }
        private void ProcesarCambios()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOk) 
            {
                Salir();
            }
        }

        private void CambioPrecioFrm_Load(object sender, EventArgs e)
        {
            L_INF_PRODUCTO.Text = _controlador.Inf_Producto;
            L_INF_PRECIO_ACTUAL.Text = _controlador.Inf_PrecioActual.ToString("n2");
            TB_PRECIO_NUEVO.Text = _controlador.GetPrecioNuevo.ToString("n2").Replace(".","");
            IrFocoPrincipal();
        }

        private void IrFocoPrincipal()
        {
            TB_PRECIO_NUEVO.Focus();
        }

        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TB_PRECIO_NUEVO_Leave(object sender, EventArgs e)
        {
            _controlador.setPrecioNuevo(decimal.Parse(TB_PRECIO_NUEVO.Text));
        }

    }

}