using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Cierre
{

    public partial class CierreFrm : Form
    {


        private Gestion _controlador;


        public CierreFrm()
        {
            InitializeComponent();
        }

        private void CierreFrm_Load(object sender, EventArgs e)
        {
            Limpiar();
            ActualizarData();
        }

        private void ActualizarData()
        {
            L_ESTACION.Text = _controlador.Estacion;
            L_USUARIO.Text = _controlador.Usuario;
            L_FECHA_HORA.Text = _controlador.FechaHoraApertura;

            L_CNT_DOC_FACTURA.Text = _controlador.cntFactura.ToString("n0");
            L_CNT_DOC_NCREDITO.Text = _controlador.cntNCredito.ToString("n0");
            L_CNT_DOC_NENTREGA.Text = _controlador.cntNEntrega.ToString("n0");

            L_MONTO_DOC_FACTURA.Text = _controlador.montoFactura.ToString("n2");
            L_MONTO_DOC_NCREDITO.Text = _controlador.montoNCredito.ToString("n2");
            L_MONTO_DOC_NENTREGA.Text = _controlador.montoNEntrega.ToString("n2");
            L_MONTO_VENTA.Text = _controlador.montoVenta.ToString("n2");

            L_CNT_DOC_CONTADO.Text = _controlador.cntDocContado.ToString("n0");
            L_CNT_DOC_CREDITO.Text = _controlador.cntDocCredito.ToString("n0");
            L_MONTO_DOC_CONTADO.Text = _controlador.montoDocContado.ToString("n2");
            L_MONTO_DOC_CREDITO.Text = _controlador.montoDocCredito.ToString("n2");

            L_CNT_EFECTIVO.Text = _controlador.cntEfecitvo.ToString("n0"); ;
            L_CNT_DIVISA.Text = _controlador.cntDivisa.ToString("n0");
            L_CNT_TARJETAS.Text = _controlador.cntElectronico.ToString("n0");
            L_CNT_OTROS.Text = _controlador.cntOtros.ToString("n0");
            L_CNT_DEVOLUCION.Text = _controlador.cntNCredito.ToString("n0");
            L_CNT_CREDITO.Text = _controlador.cntDocCredito.ToString("n0");

            L_MONTO_EFECTIVO.Text = _controlador.montoEfectivo.ToString("n2");
            L_MONTO_DIVISA.Text = _controlador.montoDivisa.ToString("n2");
            L_MONTO_TARJETAS.Text = _controlador.montoElectronico.ToString("n2");
            L_MONTO_OTROS.Text = _controlador.montoOtros.ToString("n2");
            L_MONTO_DEVOLUCION.Text = _controlador.montoNCredito.ToString("n2");
            L_MONTO_CREDITO.Text = _controlador.montoDocCredito.ToString("n2");

            L_CNT_CAMBIO.Text = _controlador.cntCambio.ToString("n0");
            L_MONTO_DEVOLUCION_2.Text=_controlador.montoNCredito.ToString("n2");
            L_MONTO_CREDITO_2.Text=_controlador.montoDocCredito.ToString("n2");
            L_MONTO_CAMBIO.Text = _controlador.montoCambio.ToString("n2");
            L_MONTO_CAMBIO_2.Text = _controlador.montoCambio.ToString("n2");

            L_MONTO_DESGLOZE.Text = _controlador.montoDesgloze.ToString("n2");
            L_TOTAL_ENTRADA.Text = _controlador.montoEntrada.ToString("n2");
            L_MONTO_POR_DIVISA.Text = _controlador.montoEntradaDivisa.ToString("n2");

            L_CNT_DOC_FACTURA_ANULADA.Text = _controlador.cntFacturaAnulada.ToString("n0");
            L_MONTO_DOC_FACTURA_ANULADA.Text = _controlador.montoFacturaAnulada.ToString("n2"); 
            L_CNT_DOC_NCREDITO_ANULADA.Text = _controlador.cntNCreditoAnulada.ToString("n0");
            L_MONTO_DOC_NCREDITO_ANULADA.Text = _controlador.montoNCreditoAnulada.ToString("n2"); 
            L_CNT_DOC_NENTREGA_ANULADAS.Text = _controlador.cntNEntregaAnulada.ToString("n0"); 
            L_MONTO_DOC_NENTREGA_ANULADAS.Text = _controlador.montoNEntregaAnulada.ToString("n2"); 

            ActualizaDiferencia();
        }

        private void ActualizaDiferencia()
        {
            L_DIFERENCIA.ForeColor = Color.Yellow;
            if (_controlador.Diferencia > 0)
            {
                L_DIFERENCIA_TEXTO.Text = "Diferencia (SOBRANTE)";
                L_DIFERENCIA.ForeColor = Color.Blue;
            }
            else if (_controlador.Diferencia < 0)
            {
                L_DIFERENCIA_TEXTO.Text = "Diferencia (FALTANTE)";
                L_DIFERENCIA.ForeColor = Color.Red;
            }
            else
            {
                L_DIFERENCIA_TEXTO.Text = "";
            }
            L_DIFERENCIA.Text = _controlador.Diferencia.ToString("n2");
        }

        private void Limpiar()
        {
            L_FECHA_HORA.Text = "";
            L_USUARIO.Text = "";
            TB_EFECTIVO.Text = "0";
            TB_CNT_DIVISA.Text = "0";
            TB_OTRO.Text = "0";
            TB_TARJETA.Text = "0";
        }

        public void setControlador(Gestion ctr)
        {
            _controlador=ctr;
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            _controlador.Salir();
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

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.CierreIsOk) 
            {
                if (_controlador.IsTicket) 
                {
                    printDocument1.Print();
                }
                Salir();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Cancel = false;
            _controlador.Imprimir(e);
        }

        private void BT_DETALLE_Click(object sender, EventArgs e)
        {
            ReporteDetalle();
        }

        private void ReporteDetalle()
        {
           _controlador.ReporteDetalle();
        }

        private void BT_NC_DETALLE_Click(object sender, EventArgs e)
        {
            NCreditoDetalle();
        }

        private void NCreditoDetalle()
        {
          //  _controlador.NCreditoDetalle();
        }

        private void BT_PAGO_RESUMEN_Click(object sender, EventArgs e)
        {
            PagoResumen();
        }

        private void PagoResumen()
        {
           _controlador.PagoResumen();
        }

        private void TB_CNT_DIVISA_Leave(object sender, EventArgs e)
        {
            var cntDivisa = int.Parse(TB_CNT_DIVISA.Text);
            _controlador.setCntDivisa(cntDivisa);
            ActualizarData();
        }

        private void TB_EFECTIVO_Leave(object sender, EventArgs e)
        {
            var mEfectivo = decimal.Parse(TB_EFECTIVO.Text);
            _controlador.setEfectivo(mEfectivo);
            ActualizarData();
        }

        private void TB_TARJETA_Leave(object sender, EventArgs e)
        {
            var mTarjeta = decimal.Parse(TB_TARJETA.Text);
            _controlador.setTarjeta(mTarjeta);
            ActualizarData();
        }

        private void TB_OTRO_Leave(object sender, EventArgs e)
        {
            var mOtro = decimal.Parse(TB_OTRO.Text);
            _controlador.setOtro(mOtro);
            ActualizarData();
        }

        private void CierreFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.CierreIsOk || _controlador.AbandonarIsOk) 
            {
                e.Cancel = false;
            }
        }
    
    }

}