using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pago.Procesar
{

    public partial class ProcesarFrm : Form
    {

        private Gestion _controlador;


        public ProcesarFrm()
        {
            InitializeComponent();
        }

        private void PagoFrm_Load(object sender, EventArgs e)
        {
            Limpiar();

            L_CLIENTE.Text = _controlador.ClienteData;
            L_SUBTOTAL_MONTO_PAGAR.Text = _controlador.SubTotalMontoPagar.ToString("n2");
            L_TASA_CAMBIO.Text = _controlador.TasaCambio.ToString("n3");
            L_VENTA_MONEDA_NACIONAL.Text = _controlador.MontoPagar.ToString("n2");
            L_VENTA_DIVISA.Text = "$" + _controlador.MontoPagarDivisa.ToString("n2");
            L_RESTA_MONEDA_NACIONAL.Text = _controlador.MontoResta_MonedaNacional.ToString("n2");
            L_RESTA_DIVISA.Text = "$" + _controlador.MontoResta_Divisa.ToString("n2");
            L_CNT_DIVISA_RECOMIENDA.Text = "";
            ActualizaMontoResta();
        }

        private void Limpiar()
        {
            L_MONTO_VENTA.Text = "Monto Venta,  Descuento: "+ _controlador.DescuentoPorct.ToString("n2") + "%";
            L_CLIENTE.Text = "";
            L_VENTA_MONEDA_NACIONAL.Text = "0.00";
            L_VENTA_DIVISA.Text = "$0.00";
            LimpiarPago();
        }

        private void LimpiarPago()
        {
            TB_EFECTIVO.Select();
            L_RESTA_MONEDA_NACIONAL.Text = "0.00";
            L_RESTA_DIVISA.Text = "$0.00";
            L_LOTE_1.Text = "";
            L_LOTE_2.Text = "";
            L_LOTE_3.Text = "";
            L_LOTE_4.Text = "";
            L_REF_1.Text = "";
            L_REF_2.Text = "";
            L_REF_3.Text = "";
            L_REF_4.Text = "";
            TB_EFECTIVO.Text = "0";
            TB_DIVISA_CNT.Text = "0";
            TB_DIVISA_MONTO.Text = "0.00";
            TB_MONTO_RECIBIDO.Text = "0.00";
            TB_ELECT_1.Text = "0";
            TB_ELECT_2.Text = "0";
            TB_ELECT_3.Text = "0";
            TB_OTRO.Text = "0";
            L_CNT_DIVISA_RECOMIENDA.Text = "";
            ActualizaMontoResta();
        }

        private void Salir()
        {
            this.Close();
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void ActualizaMontoResta()
        {
            if (_controlador.IsCreditoOk)
            {
                panel12.BackColor = Color.Green;
                L_RESTA_CAMBIO_DAR.Text = "CREDITO HABILITADO";
                L_RESTA_MONEDA_NACIONAL.Text = _controlador.MontoResta_MonedaNacional.ToString("n2");
                L_RESTA_DIVISA.Text = "$" + _controlador.MontoResta_Divisa.ToString("n2");
            }
            else
            {
                if (_controlador.MontoCambioDar_MonedaNacional < 0)
                {
                    panel12.BackColor = Color.Maroon;
                    L_RESTA_CAMBIO_DAR.Text = "Resta/Pendiente";
                    L_RESTA_MONEDA_NACIONAL.Text = _controlador.MontoResta_MonedaNacional.ToString("n2");
                    L_RESTA_DIVISA.Text = "$" + _controlador.MontoResta_Divisa.ToString("n2");
                }
                else
                {
                    panel12.BackColor = Color.Navy;
                    L_RESTA_CAMBIO_DAR.Text = "Cambio Dar";
                    L_RESTA_MONEDA_NACIONAL.Text = _controlador.MontoCambioDar_MonedaNacional.ToString("n2");
                    L_RESTA_DIVISA.Text = "$" + _controlador.MontoCambioDar_Divisa.ToString("n2");
                }
            }
            TB_DIVISA_MONTO.Text = _controlador.MontoDivisa.ToString("n2");
            TB_MONTO_RECIBIDO.Text = _controlador.MontoRecibido.ToString("n2");
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            Limpieza();
        }

        private void Limpieza()
        {
            _controlador.LimpiarPagos();
            if (_controlador.LimpiarPagosIsOk) 
            {
                LimpiarPago();
                ActualizarMonto();
                ActualizaMontoResta();
            }
            IrFocoPrincipal();
        }

        private void IrFocoPrincipal()
        {
            TB_EFECTIVO.Focus();
        }

        private void BT_CALCULADORA_Click(object sender, EventArgs e)
        {
            ActivarCalculadora();
        }

        private void ActivarCalculadora()
        {
            _controlador.Calculadora();
            IrFocoPrincipal();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Salida()
        {
            this.Close();
        }

        private void BT_DESCUENTO_Click(object sender, EventArgs e)
        {
            DarDescuento();
        }

        private void DarDescuento()
        {
            _controlador.DarDescuento();
            ActualizarMonto();
            ActualizaMontoResta();
            IrFocoPrincipal();
        }

        private void ActualizarMonto()
        {
            L_MONTO_VENTA.Text = "Monto Venta,  Descuento: " + _controlador.DescuentoPorct.ToString("n2") + "%";
            L_VENTA_MONEDA_NACIONAL.Text = _controlador.MontoPagar.ToString("n2");
            L_VENTA_DIVISA.Text = "$" + _controlador.MontoPagarDivisa.ToString("n2");
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.PagoIsOk)
            {
                this.Close();
            }
            IrFocoPrincipal();
        }

        private void TB_MONTO_RECIBIDO_Leave(object sender, EventArgs e)
        {
            if (_controlador.MontoResta_MonedaNacional > 0)
            {
                IrFocoPrincipal();
            }
            else
            {
                BT_PROCESAR.Select();
            }
        }

        private void PagoFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                DarDescuento();
            }
            if (e.KeyCode == Keys.F3)
            {
                DarCredito();
            }
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_CREDITO_Click(object sender, EventArgs e)
        {
            DarCredito();
        }
        private void DarCredito()
        {
            IrFocoPrincipal();
            _controlador.DarCredito();
            if (_controlador.IsCreditoOk)
            {
                LimpiarPago();
                ActualizaMontoResta();
                this.Close();
            }
        }

        private void TB_DIVISA_CNT_Leave(object sender, EventArgs e)
        {
            var monto = 0.0m;
            monto = decimal.Parse(TB_DIVISA_CNT.Text);
            _controlador.AddDivisa(monto);
            TB_OTRO.Text = Math.Round(_controlador.GetPagoOtro, 2, MidpointRounding.AwayFromZero).ToString();
            L_LOTE_4.Text = _controlador.PagoElectronico_LOTE_4;
            L_REF_4.Text = _controlador.PagoElectronico_REF_4;
            L_CNT_DIVISA_RECOMIENDA.Text = _controlador.GetCntDivisaRecomendar.ToString();
            ActualizaMontoResta();
        }
        private void TB_EFECTIVO_Leave(object sender, EventArgs e)
        {
            var monto = 0.0m;
            monto = decimal.Parse(TB_EFECTIVO.Text);
            _controlador.AddEfectivo(monto);
            ActualizaMontoResta();
        }
        private void TB_ELECT_1_Leave(object sender, EventArgs e)
        {
            var monto = 0.0m;
            monto = decimal.Parse(TB_ELECT_1.Text);
            _controlador.AddElectronico(monto, 1);
            L_LOTE_1.Text = _controlador.PagoElectronico_LOTE_1;
            L_REF_1.Text = _controlador.PagoElectronico_REF_1;
            ActualizaMontoResta();
        }
        private void TB_ELECT_2_Leave(object sender, EventArgs e)
        {
            var monto = 0.0m;
            monto = decimal.Parse(TB_ELECT_2.Text);
            _controlador.AddElectronico(monto, 2);
            L_LOTE_2.Text = _controlador.PagoElectronico_LOTE_2;
            L_REF_2.Text = _controlador.PagoElectronico_REF_2;
            ActualizaMontoResta();
        }
        private void TB_ELECT_3_Leave(object sender, EventArgs e)
        {
            var monto = 0.0m;
            monto = decimal.Parse(TB_ELECT_3.Text);
            _controlador.AddElectronico(monto, 3);
            L_LOTE_3.Text = _controlador.PagoElectronico_LOTE_3;
            L_REF_3.Text = _controlador.PagoElectronico_REF_3;
            ActualizaMontoResta();
        }
        private void TB_OTRO_Leave(object sender, EventArgs e)
        {
            var monto = 0.0m;
            monto = decimal.Parse(TB_OTRO.Text);
            _controlador.AddElectronico(monto, 4);
            L_LOTE_4.Text = _controlador.PagoElectronico_LOTE_4;
            L_REF_4.Text = _controlador.PagoElectronico_REF_4;
            ActualizaMontoResta();
        }
       
    }

}