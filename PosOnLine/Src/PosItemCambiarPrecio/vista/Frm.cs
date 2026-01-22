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
            CHB_CAMBIAR_VARIOS_PRECIOS.Checked = _controlador.Get_OpcionPermitirCambiarVariosPrecios_IsActiva;
            //
            L_PRODUCTO.Text = _controlador.Get_ProductoInfo;
            L_PRECIO_BS.Text = _controlador.Get_PrecioPagoBs.ToString("n2");
            L_PRODUCTO_NO_ADM_DIVISA.Text = "Precio Pago Producto No Divisa con " + _controlador.Get_PorctAumentoProductosNoDivisa.ToString("n2") + "%";
            L_PRECIO_PRD_NO_DIVISA.Text = _controlador.Get_PrecioPagoPrdNoDivisa.ToString("n2");
            L_PRECIO_DIVISA.Text = _controlador.Get_PrecioPagoDivisa.ToString("n2");
            L_UTILIDAD.Text = _controlador.Get_Utilidad.ToString("n2")+"%";
            //
            L_COSTO_EMPQ_VTA.Text = _controlador.Get_CostoEmpaqueVentaDescripcion;
            L_ADM_POR_DIVISA.Text = _controlador.Get_IsProductoAdmPorDivisa ? "SI" : "NO";
            L_TASA_SISTEMA.Text = _controlador.Get_TasaSistema.ToString("n2");
            //
            TB_PAGO_BS.Enabled = false;
            TB_PAGO_DIVISA.Enabled = false;
            TB_PAGO_NO_DIVISA.Enabled = false;
            TB_PAGO_BS.Text = "";
            TB_PAGO_DIVISA.Text = "";
            TB_PAGO_NO_DIVISA.Text = "";
            RB_PAGO_BS.Checked = false;
            RB_PAGO_DIVISA.Checked = false;
            RB_PAGO_PRD_NO_DIVISA.Checked = false;
            RB_PAGO_PRD_NO_DIVISA.Enabled = !_controlador.Get_IsProductoAdmPorDivisa;
            //
            CHB_ACTIVAR_PORC_AUMENTO.Visible = !_controlador.Get_IsProductoAdmPorDivisa;
            CHB_ACTIVAR_PORC_AUMENTO.Checked = _controlador.DarPorcentajeAumento;
            //
            CHB_MAS_MENOS_INF.Checked = false;
            P_PRECIO.Visible = true;
            P_INFO.Visible = false;
            //
            if (_controlador.Get_Utilidad >= 0m)
            {
                P_UTILIDAD.BackColor = Color.Green;
            }
            else
            {
                P_UTILIDAD.BackColor = Color.Brown;
            }
            //
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
        //
        private void CHB_CAMBIAR_VARIOS_PRECIOS_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            _controlador.setSwitchPermitirCambiarVariosPrecios(CHB_CAMBIAR_VARIOS_PRECIOS.Checked);
        }
        private void RB_PAGO_BS_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            TB_PAGO_BS.Enabled = RB_PAGO_BS.Checked;
        }
        private void RB_PAGO_PRD_NO_DIVISA_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            TB_PAGO_NO_DIVISA.Enabled = RB_PAGO_PRD_NO_DIVISA.Checked;
        }
        private void RB_PAGO_DIVISA_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            TB_PAGO_DIVISA.Enabled = RB_PAGO_DIVISA.Checked;
        }
        private void TB_PAGO_BS_Leave(object sender, EventArgs e)
        {
            var _monto = 0m;
            if (!string.IsNullOrEmpty(TB_PAGO_BS.Text.Trim()))
            {
                _monto = decimal.Parse(TB_PAGO_BS.Text.Trim());
            }
            _controlador.setPagoMontoBs(_monto);
            ActualizarPrecios();
        }
        private void TB_PAGO_NO_DIVISA_Leave(object sender, EventArgs e)
        {
            var _monto = 0m;
            if (!string.IsNullOrEmpty(TB_PAGO_NO_DIVISA.Text.Trim()))
            {
                _monto = decimal.Parse(TB_PAGO_NO_DIVISA.Text.Trim());
            }
            _controlador.setPagoProductoNoDivisa(_monto);
            ActualizarPrecios();
        }
        private void TB_PAGO_DIVISA_Leave(object sender, EventArgs e)
        {
            var _monto = 0m;
            if (!string.IsNullOrEmpty(TB_PAGO_DIVISA.Text.Trim()))
            {
                _monto = decimal.Parse(TB_PAGO_DIVISA.Text.Trim());
            }
            _controlador.setPagoDivisa(_monto);
            ActualizarPrecios();
        }
        private void CHB_MAS_MENOS_INF_CheckedChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) return;
            var info = "Mostar más Información";
            if (CHB_MAS_MENOS_INF.Checked)
            {
                info = "Mostar menos Información";
                P_INFO.Visible = true;
            }
            else 
            {
                P_INFO.Visible = false;
            }
            CHB_MAS_MENOS_INF.Text=info;
        }
        private void CHB_ACTIVAR_PORC_AUMENTO_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setSwitchPorcentajeAumento(CHB_ACTIVAR_PORC_AUMENTO.Checked);
            ActualizarPrecios();
        }
        //
        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            ProcesarCambio();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
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
        private void ActualizarPrecios() 
        {
            L_PRODUCTO_NO_ADM_DIVISA.Text = "Precio Pago Producto No Divisa con " + _controlador.Get_PorctAumentoProductosNoDivisa.ToString("n2") + "%";
            L_PRECIO_BS.Text = _controlador.Get_PrecioPagoBs.ToString("n2");
            L_PRECIO_PRD_NO_DIVISA.Text = _controlador.Get_PrecioPagoPrdNoDivisa.ToString("n2");
            L_PRECIO_DIVISA.Text = _controlador.Get_PrecioPagoDivisa.ToString("n2");
            L_UTILIDAD.Text = _controlador.Get_Utilidad.ToString("n2") + "%";
            if (_controlador.Get_Utilidad >= 0m)
            {
                P_UTILIDAD.BackColor = Color.Green;
            }
            else 
            {
                P_UTILIDAD.BackColor = Color.Brown;
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