using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.PosItemCambiarPrecio.vista
{
    public partial class Frm : Form
    {
        private bool _modoInicializa;
        private vm.ICambiarPrecio _controlador;
        //
        public Frm()
        {
            InitializeComponent();
        }
        public void setControlador(vm.ICambiarPrecio ctr)
        {
            _controlador = ctr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            IrFocoPrincipal();
            L_PRECIO_BS.Text = _controlador.Get_PrecioPagoBs.ToString("n2");
            L_PRECIO_PRD_NO_DIVISA.Text = _controlador.Get_PrecioPagoPrdNoDivisa.ToString("n2");
            L_PRECIO_DIVISA.Text = _controlador.Get_PrecioPagoDivisa.ToString("n2");
            TB_PRECIO.Text = _controlador.PrecioIngresado.ToString();
            /*
            L_INF_PRODUCTO.Text = _controlador.DataPanel.producto;
            L_INF_PRECIO_ACTUAL.Text = _controlador.DataPanel.precioActual.ToString("n2");
            L_UTILIDAD_ACTUAL.Text = _controlador.DataPanel.utilidadActual.ToString("n2") + "%";
            L_UTILIDAD_NUEVA.Text = _controlador.DataPanel.utilidadNueva.ToString("n2") + "%";
            TB_PRECIO_NUEVO.Text = "";
            CHB_APLICANDO_BONO.Checked = _controlador.DataFicha.Get_AplicaBono;
            CHB_APLICANDO_BONO.Checked = !CHB_APLICANDO_BONO.Checked;
            CHB_APLICAR_PORCT_AUMENTO.Enabled = !_controlador.DataFicha.EstatusDivisa;
            CHB_APLICAR_PORCT_AUMENTO.Checked = _controlador.DataFicha.AplicarPorcAumento;
             */
            _modoInicializa = false;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarFichaIsOK || _controlador.ProcesarCambioIsOK)
            {
                e.Cancel = false;
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            ProcesarCambio();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        /*
        private void TB_PRECIO_NUEVO_Leave(object sender, EventArgs e)
        {
            var _precio = 0m;
            if (TB_PRECIO_NUEVO.Text.Trim() != "") 
            {
                _precio = decimal.Parse(TB_PRECIO_NUEVO.Text);
            }
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
        private void CHB_CAMBIAR_VARIOS_PRECIOS_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setCambiarVariosPrecios();
        }

        private void CHB_APLICAR_PORCT_AUMENTO_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.setAplicarAumentoPorPorct(CHB_APLICAR_PORCT_AUMENTO.Checked);
        }
         */
        //
        private void ProcesarCambio()
        {
            IrFocoPrincipal();
            _controlador.ProcesarCambio();
            if (_controlador.ProcesarCambioIsOK )
            {
                salir();
            }
        }
        private void AbandonarFicha()
        {
            IrFocoPrincipal();
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarFichaIsOK)
            {
                salir();
            }
        }
        private void IrFocoPrincipal()
        {
        }
        private void salir()
        {
            this.Close();
        }
    }
}