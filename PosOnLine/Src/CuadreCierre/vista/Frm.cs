using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.CuadreCierre.vista
{
    public partial class Frm : Form
    {
        private vm.ICuadre _controlador;
        private bool _modo_inicializar;
        //
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
            //
            var c0 = new DataGridViewTextBoxColumn();
            c0.DataPropertyName = "CabDescripcion";
            c0.HeaderText = "Descripcion";
            c0.Visible = true;
            c0.HeaderCell.Style.Font = f;
            c0.DefaultCellStyle.Font = f;
            c0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c0.MinimumWidth = 150;
            c0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CabMontoSist";
            c1.HeaderText = "Monto/Sist";
            c1.Visible = true;
            c1.Width = 140;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "MontoSegunUsu";
            c2.HeaderText = "Monto/Usu";
            c2.Name = "Monto";
            c2.Visible = true;
            c2.Width = 140;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c2.DefaultCellStyle.Format = "n2";
            c2.ReadOnly = false;
            c2.DefaultCellStyle.BackColor = Color.Yellow;
            //
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "CabFactor";
            c4.HeaderText = "Factor";
            c4.Visible = true;
            c4.MinimumWidth = 100;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "CabImporte";
            c5.HeaderText = "Importe";
            c5.Visible = true;
            c5.Width = 160;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            DGV.Columns.Add(c0);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            //DGV.Columns.Add(c3);
        }
        private void InicializaCB()
        {
            CB_MEDIOS_PAGO_LOCAL.DisplayMember = "desc";
            CB_MEDIOS_PAGO_LOCAL.ValueMember = "id";
            CB_MEDIOS_PAGO_REFERENCIA.DisplayMember = "desc";
            CB_MEDIOS_PAGO_REFERENCIA.ValueMember = "id";
        }
        private void InicializaDGVResumenTipoDoc()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            //
            DGV_RESUMEN_TIPO_DOC.RowHeadersVisible = false;
            DGV_RESUMEN_TIPO_DOC.AllowUserToAddRows = false;
            DGV_RESUMEN_TIPO_DOC.AllowUserToDeleteRows = false;
            DGV_RESUMEN_TIPO_DOC.AutoGenerateColumns = false;
            DGV_RESUMEN_TIPO_DOC.AllowUserToResizeRows = false;
            DGV_RESUMEN_TIPO_DOC.AllowUserToResizeColumns = false;
            DGV_RESUMEN_TIPO_DOC.AllowUserToOrderColumns = false;
            DGV_RESUMEN_TIPO_DOC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_RESUMEN_TIPO_DOC.MultiSelect = false;
            DGV_RESUMEN_TIPO_DOC.ReadOnly = true;
            //
            var c0 = new DataGridViewTextBoxColumn();
            c0.DataPropertyName = "CabCntDoc";
            c0.HeaderText = "Cnt/Doc";
            c0.Visible = true;
            c0.HeaderCell.Style.Font = f;
            c0.DefaultCellStyle.Font = f;
            c0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            c0.Width = 60;
            //
            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CabDescripcion";
            c1.HeaderText = "Descripcion";
            c1.Visible = true;
            c1.MinimumWidth = 180;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CabImporteMonLocal";
            c2.HeaderText = "Importe";
            c2.Name = "Monto";
            c2.Visible = true;
            c2.Width = 120;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "CabImporteMonReferencia";
            c4.HeaderText = "Importe $";
            c4.Visible = true;
            c4.Width = 120;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            DGV_RESUMEN_TIPO_DOC.Columns.Add(c0);
            DGV_RESUMEN_TIPO_DOC.Columns.Add(c1);
            DGV_RESUMEN_TIPO_DOC.Columns.Add(c2);
            DGV_RESUMEN_TIPO_DOC.Columns.Add(c4);
        }
        public Frm()
        {
            InitializeComponent();
            InicializaDGVResumenTipoDoc();
            InicializaDGV();
            InicializaCB();
        }
        public void setControlador(vm.ICuadre ctr)
        {
            _controlador = ctr;
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            _modo_inicializar = true;
            LB_RESUMEN.DataSource = _controlador.Get_ResumenSource;
            DGV.DataSource = _controlador.Get_MetodosPagoSource;
            DGV_RESUMEN_TIPO_DOC.DataSource = _controlador.Get_TipoDocSource;
            CB_MEDIOS_PAGO_LOCAL.DataSource = _controlador.Get_MediosPagoLocalSource;
            CB_MEDIOS_PAGO_LOCAL.SelectedValue = _controlador.Get_IdMedioPagoLocal;
            CB_MEDIOS_PAGO_REFERENCIA.DataSource = _controlador.Get_MediosPagoReferenciaSource;
            CB_MEDIOS_PAGO_REFERENCIA.SelectedValue = _controlador.Get_IdMedioPagoReferencia;
            L_IMPORTE_RECIBIDO.Text = _controlador.Get_ImporteRecibido.ToString("n2");
            L_BONO_PAGO_DIVISA.Text = _controlador.Get_DescMPPorPagoBonoDivisa;
            L_MONTO_BONO_PAGO_DIVISA.Text = _controlador.Get_MontoMPPorPagoBonoDivisa.ToString("n2");
            L_ESTADO_PEND_SOBRANTE.Text = _controlador.Get_EstadoPendSobrante;
            L_MONTO_PEND_SOBRANTE.Text = _controlador.Get_MontoPendSobrante.ToString("n2");
            L_VUELTO_POR_EFECTIVO.Text = _controlador.Get_VueltoMontoPorEfectivo.ToString("n2");
            L_VUELTO_POR_DIVISA.Text = _controlador.Get_VueltoCntPorDivisa.ToString();
            DGV.Refresh();
            _modo_inicializar = false;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
        }
        //
        private void BT_LIMPIAR_VUELTO_MON_LOCAL_Click(object sender, EventArgs e)
        {
            LimpiarVueltoMonLocal();
        }
        private void BT_LIMPIAR_VUELTO_MON_REFERENCIA_Click(object sender, EventArgs e)
        {
            LimpiarVueltoMonReferencia();
        }
        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarIngresoMetodosPagoUsado();
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
        }
        //
        private void DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (DGV.Columns[e.ColumnIndex].Name == "Monto") 
            {
                decimal valor;
                if (!decimal.TryParse(e.FormattedValue.ToString(), out valor)) 
                {
                    e.Cancel = true;
                    _controlador.MsgAlerta("Por Favor, Ingresa un valor valido");
                }
            }
        }
        private void DGV_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Columns[e.ColumnIndex].Name == "Monto") 
            {
                _controlador.ActualizarImporteMetodoPago();
                L_BONO_PAGO_DIVISA.Text = _controlador.Get_DescMPPorPagoBonoDivisa;
                L_MONTO_BONO_PAGO_DIVISA.Text = _controlador.Get_MontoMPPorPagoBonoDivisa.ToString("n2");
            }
            refrescarData();
        }
        private void CB_MEDIOS_PAGO_LOCAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modo_inicializar) return;
            _controlador.setVueltoMedPagoLocal("");
            if (CB_MEDIOS_PAGO_LOCAL.SelectedIndex != -1)
            {
                _controlador.setVueltoMedPagoLocal(CB_MEDIOS_PAGO_LOCAL.SelectedValue.ToString());
            }
            refrescarData();
        }
        private void CB_MEDIOS_PAGO_REFERENCIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modo_inicializar) return;
            _controlador.setVueltoMedPagoReferencia("");
            if (CB_MEDIOS_PAGO_REFERENCIA.SelectedIndex != -1)
            {
                _controlador.setVueltoMedPagoReferencia(CB_MEDIOS_PAGO_REFERENCIA.SelectedValue.ToString());
            }
            refrescarData();
        }
        //
        private void BT_REP_PAGO_DETALLE_Click(object sender, EventArgs e)
        {
            reportePagoDetalle();
        }
        private void BT_REPO_PAGO_RESUMEN_Click(object sender, EventArgs e)
        {
            reportePagoResumen();
        }
        private void BT_REPO_VENTA_CREDITO_Click(object sender, EventArgs e)
        {
            reporteVentaCredito();
        }
        private void BT_REPO_CAMBIOS_VUELTO_Click(object sender, EventArgs e)
        {
            reporteCambiosVuelto();
        }
        private void BT_REPO_PAGO_MOVIL_Click(object sender, EventArgs e)
        {
            reportePagoMovil();
        }
        //
        private void LimpiarVueltoMonLocal()
        {
            _controlador.LimpiarVueltoMonLocal();
            CB_MEDIOS_PAGO_LOCAL.SelectedValue = _controlador.Get_IdMedioPagoLocal;
            refrescarData();
        }
        private void LimpiarVueltoMonReferencia()
        {
            _controlador.LimpiarVueltoMonReferencia();
            CB_MEDIOS_PAGO_REFERENCIA.SelectedValue = _controlador.Get_IdMedioPagoReferencia;
            refrescarData();
        }
        private void LimpiarIngresoMetodosPagoUsado()
        {
            _controlador.LimpiarIngresoMetodosPagoUsado();
            refrescarData();
        }
        private void refrescarData()
        {
            L_IMPORTE_RECIBIDO.Text = _controlador.Get_ImporteRecibido.ToString("n2");
            L_ESTADO_PEND_SOBRANTE.Text = _controlador.Get_EstadoPendSobrante;
            L_MONTO_PEND_SOBRANTE.Text = _controlador.Get_MontoPendSobrante.ToString("n2");
            DGV.Refresh();
        }
        //
        private void reportePagoDetalle()
        {
            _controlador.reportePagoDetalle();
        }
        private void reportePagoResumen()
        {
            _controlador.reportePagoResumen();
        }
        private void reporteVentaCredito()
        {
            _controlador.reporteVentaCredito();
        }
        private void reporteCambiosVuelto()
        {
            _controlador.reporteCambiosVuelto();
        }
        private void reportePagoMovil()
        {
            _controlador.reportePagoMovil();
        }
    }
}