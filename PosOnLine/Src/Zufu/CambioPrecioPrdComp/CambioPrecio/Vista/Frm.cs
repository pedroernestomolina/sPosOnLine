using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Zufu.CambioPrecioPrdComp.CambioPrecio.Vista
{
    public partial class Frm : Form
    {
        private IVista _controlador;


        public Frm()
        {
            InitializeComponent();
        }
        public void setControlador(IVista ctr)
        {
            _controlador = ctr;
        }
        private void CambioPrecioFrm_Load(object sender, EventArgs e)
        {
            L_INF_PRODUCTO.Text = _controlador.DataPanel.producto;
            L_INF_PRECIO_ACTUAL.Text = _controlador.DataPanel.precioActual.ToString("n2");
            L_UTILIDAD_ACTUAL.Text = _controlador.DataPanel.utilidadActual.ToString("n2") + "%";
            L_UTILIDAD_NUEVA.Text = _controlador.DataPanel.utilidadNueva.ToString("n2") + "%";
            TB_PRECIO_NUEVO.Text = "";
            CHB_APLICANDO_BONO.Checked = _controlador.DataFicha.Get_AplicaBono;
            CHB_APLICANDO_BONO.Checked = !CHB_APLICANDO_BONO.Checked;
            IrFocoPrincipal();
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.BtAbandonar.OpcionIsOK || _controlador.BtProcesar.OpcionIsOK)
            {
                e.Cancel = false;
            }
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
            var _precio = decimal.Parse(TB_PRECIO_NUEVO.Text);
            _controlador.setPrecioNuevo(_precio);
            L_UTILIDAD_NUEVA.Text = _controlador.DataPanel.utilidadNueva.ToString("n2") + "%";
        }
        private void CHB_APLICANDO_BONO_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.AplicarBono(CHB_APLICANDO_BONO.Checked);
            L_INF_PRECIO_ACTUAL.Text = _controlador.DataPanel.precioActual.ToString("n2");
            L_UTILIDAD_NUEVA.Text = _controlador.DataPanel.utilidadNueva.ToString("n2") + "%";
        }

        private void BT_PANEL_INF_Click(object sender, EventArgs e)
        {
            PanelInformativo();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            ProcesarCambios();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }

        //
        private void PanelInformativo()
        {
            _controlador.PanelInformativo();
        }
        private void AbandonarFicha()
        {
            IrFocoPrincipal();
            _controlador.BtAbandonar.Opcion();
            if (_controlador.BtAbandonar.OpcionIsOK )
            {
                Salir();
            }
        }
        private void ProcesarCambios()
        {
            _controlador.Procesar();
            if (_controlador.BtProcesar.OpcionIsOK)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
        private void IrFocoPrincipal()
        {
            TB_PRECIO_NUEVO.Focus();
        }
    }
}