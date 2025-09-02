using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.FormaPago.vista
{
    public partial class Frm : Form
    {
        private vm.IFormaPago _controlador;
        //
        private void InicializaCombos()
        {
            CB_MEDIO_PAGO.DisplayMember = "desc";
            CB_MEDIO_PAGO.ValueMember = "id";
        }
        private void InicializaDGV() 
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            //
            DGV.RowHeadersVisible = false;
            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;
            //
            var c0 = new DataGridViewTextBoxColumn();
            c0.DataPropertyName = "CabDescripcion";
            c0.HeaderText = "Medio Pago";
            c0.Visible = true;
            c0.HeaderCell.Style.Font = f;
            c0.DefaultCellStyle.Font = f;
            c0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c0.MinimumWidth = 120;
            c0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CabMonto";
            c1.HeaderText = "Monto";
            c1.Visible = true;
            c1.Width = 140;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CabMoneda";
            c2.HeaderText = "Moneda";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            var c3 = new DataGridViewButtonColumn();
            c3.Name = "btEliminar";
            c3.HeaderText = "Eliminar";
            c3.Text = "Eliminar";
            c3.UseColumnTextForButtonValue = true;
            //
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "CabLoteRef";
            c4.HeaderText = "Lote/Ref";
            c4.Visible = true;
            c4.MinimumWidth=120;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "CabMontoCambio";
            c5.HeaderText = "Monto/Cambio";
            c5.Visible = true;
            c5.MinimumWidth = 180;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            DGV.Columns.Add(c0);
            DGV.Columns.Add(c1);
            //DGV.Columns.Add(c2);
            //DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c3);
        }
        public Frm()
        {
            InitializeComponent();
            InicializaCombos();
            InicializaDGV();
        }
        public void setControlador(vm.IFormaPago ctr)
        {
            _controlador = ctr;
        }
        private bool _modoInicio;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicio = true;
            CB_MEDIO_PAGO.DataSource = _controlador.Get_MedioPagoSource;
            CB_MEDIO_PAGO.SelectedValue = _controlador.Get_MedioPagoId;
            DGV.DataSource = _controlador.Get_FormasPagoSource;
            DGV.Refresh();
            L_SIMBOLO_MONEDA.Text = _controlador.Get_SimboloMonedaFormaPago;
            //
            P_BONO_POR_PAGO_DIVISA.Visible = _controlador.EstatusBonoPagoPorDivisa;
            actualizaMontoBono();
            L_SIMBOLO_MON_LOCAL.Text = _controlador.Get_SimboloMonedaLocal;
            L_SIMBOLO_MON_REFERENCIA.Text = _controlador.Get_SimboloMonedaReferencia;
            //
            actualizaMontoRestaCambio();
            //
            _modoInicio = false;
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && e.KeyCode == Keys.V)
            {
                _controlador.ApagarEncenderBonoPorPagoDivsa();
                P_BONO_POR_PAGO_DIVISA.Visible = _controlador.EstatusBonoPagoPorDivisa;
                actualizaMontoBono();
                actualizaMontoRestaCambio();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        //
        private void CB_MEDIO_PAGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicio) return;
            _controlador.setMedioPago("");
            if (CB_MEDIO_PAGO.SelectedIndex != -1) 
            {
                _controlador.setMedioPago(CB_MEDIO_PAGO.SelectedValue.ToString());
                L_SIMBOLO_MONEDA.Text = _controlador.Get_SimboloMonedaFormaPago;
                if (_controlador.MontoMaxIngresarPagoDivisa > 0m) 
                {
                    _modoInicio = true;
                    TB_MONTO_INGRESADO.Text = _controlador.MontoMaxIngresarPagoDivisa.ToString(); 
                    _modoInicio =false;
                }
            }
        }
        private void TB_MONTO_INGRESADO_Leave(object sender, EventArgs e)
        {
            var _monto=0m;
            if (TB_MONTO_INGRESADO.Text.Trim() != "") 
            {
                _monto = decimal.Parse(TB_MONTO_INGRESADO.Text);
            }
            _controlador.setMontoIngresar(_monto);
        }
        private void BT_AGREGAR_Click(object sender, EventArgs e)
        {
            _controlador.agregarMedioPago();
            if (_controlador.agregarMedioPagoIsOk) 
            {
                TB_MONTO_INGRESADO.Text = "";
                CB_MEDIO_PAGO.SelectedIndex = -1;
                L_SIMBOLO_MONEDA.Text = "";
                actualizaMontoBono();
                actualizaMontoRestaCambio();
                DGV.Refresh();
            }
        }
        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void BT_REFRESH_Click(object sender, EventArgs e)
        {
            Refrescar();
        }
        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGV.Columns["btEliminar"].Index && e.RowIndex >= 0) 
            {
                _controlador.eliminarFormaPago();
                L_MONTO_BONO_LOCAL.Text = _controlador.Get_MontoBonoMonedaLocal.ToString("n2");
                L_MONTO_BONO_DIVISA.Text = _controlador.Get_MonoBonoMonedaReferencia.ToString("n2");
                actualizaMontoRestaCambio();
                DGV.Refresh();
            }
        }
        private void actualizaMontoBono() 
        {
            L_MONTO_BONO_LOCAL.Text = _controlador.Get_MontoBonoMonedaLocal.ToString("n2");
            L_MONTO_BONO_DIVISA.Text = _controlador.Get_MonoBonoMonedaReferencia.ToString("n2");
        }
        private void actualizaMontoRestaCambio() 
        {
            if (_controlador.IsCuentaPendiente) 
            {
                P_RESTA_CAMBIO.BackColor = Color.Maroon;
                L_RESTA_CAMBIO.Text = "Monto Resta" + Environment.NewLine + "Pendiente";
            }
            else
            {
                P_RESTA_CAMBIO.BackColor=Color.DarkBlue;
                L_RESTA_CAMBIO.Text = "Monto Cambio" + Environment.NewLine + "Vuelto a Dar";
            }
            var _monRestaMonLocal = _controlador.Get_MontoRestaCambioMonLocal.ToString("n2") + _controlador.Get_SimboloMonedaLocal;
            var _monRestaMonRef = _controlador.Get_MontoRestaCambioMonReferencia.ToString("n2") + _controlador.Get_SimboloMonedaReferencia;
            L_MONTO_RESTA_CAMBIO_MON_LOCAL.Text = _monRestaMonLocal;
            L_MONTO_RESTA_CAMBIO_MON_REFERENCIA.Text = _monRestaMonRef;
        }
        private void Limpiar() 
        {
            _controlador.limpiezaGeneral();
            TB_MONTO_INGRESADO.Text = "";
            CB_MEDIO_PAGO.SelectedIndex = -1;
            L_SIMBOLO_MONEDA.Text = "";
            L_MONTO_BONO_LOCAL.Text = _controlador.Get_MontoBonoMonedaLocal.ToString("n2");
            L_MONTO_BONO_DIVISA.Text = _controlador.Get_MonoBonoMonedaReferencia.ToString("n2");
            actualizaMontoRestaCambio();
            DGV.Refresh();
        }
        private void Refrescar() 
        {
            _controlador.refrescarMontos();
            actualizaMontoRestaCambio();
            DGV.Refresh();
        }
    }
}