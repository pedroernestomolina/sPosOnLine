using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pedido.SolicitarNumeroPedido
{
    public partial class Frm : Form
    {
        private ISolicitud _controlador;
        //
        public Frm()
        {
            InitializeComponent();
        }
        public void setControlador(ISolicitud ctr)
        {
            _controlador = ctr;
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            IrFocoPrincipal();
            _controlador.Procesar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            IrFocoPrincipal();
            _controlador.AbandonarFicha();
        }
        private void TB_NUM_Leave(object sender, EventArgs e)
        {
            var numPedTarj = Convert.ToInt32(TB_NUM.Text);
            _controlador.setNumeroPedidoTarjeta(numPedTarj);
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            var _titulo = "";
            var _colorFondo = Color.Transparent;
            switch (_controlador.GetModoSolicitud)
            { 
                case ModoSolicitud.Abrir:
                    _titulo = "(Tarjeta / Pedido) A Abrir ?";
                    _colorFondo = Color.Blue;
                    break;
                case ModoSolicitud.Guardar:
                    _titulo = "(Tarjeta / Pedido) A Guardar ?";
                    _colorFondo = Color.Green;
                    break;
                default:
                    break;
            }
            L_TITULO.Text = _titulo;
            L_TITULO.BackColor = _colorFondo;
            TB_NUM.Text = "";
            IrFocoPrincipal();

        }
        private void TB_NUM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        //
        private void IrFocoPrincipal()
        {
            TB_NUM.Focus();
        }

        private void TB_NUM_Validating(object sender, CancelEventArgs e)
        {
            var num = int.Parse(TB_NUM.Text);
            e.Cancel = !(_controlador.VerificarMaximoNumeroPermitidoIsOk(num));
        }
    }
}