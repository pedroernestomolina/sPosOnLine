using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.MovCaja.View
{
    public partial class ViewFrm : Form
    {

        private IViewMov _controlador;


        public ViewFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            var f2 = new Font("Serif", 8, FontStyle.Regular);

            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Medio";
            c1.HeaderText = "Medio";
            c1.Visible = true;
            c1.MinimumWidth = 120;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f2;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Monto";
            c2.HeaderText = "Monto";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c2.DefaultCellStyle.Format = "n2";

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Importe";
            c3.HeaderText = "Importe";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Cant";
            c4.HeaderText = "Cant";
            c4.Visible = true;
            c4.Width = 60;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c4.DefaultCellStyle.Format = "n0";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c3);
        }

        public void setControlador(IViewMov ctr)
        {
            _controlador = ctr;
        }

        private void AgregarFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.GetListaMedios_Source;
            if (_controlador.GetTipoMov == "E")
            {
                P_TITULO.BackColor = Color.DarkBlue;
                L_TITULO.Text = "ENTRADA DINERO POR CAJA";
                L_TITULO.ForeColor = Color.White;
            }
            else 
            {
                P_TITULO.BackColor = Color.DarkRed;
                L_TITULO.Text = "SALIDA DINERO POR CAJA";
                L_TITULO.ForeColor = Color.White;
            }
            L_TOTAL.Text = "Total Movimiento Bs: " + _controlador.GetMontoMov.ToString("n2");
            L_FECHA_EMISION.Text = _controlador.GetFechaEmision.ToShortDateString();
            L_CONCEPTO.Text = _controlador.GetConcepto;
            L_DETALLES.Text = _controlador.GetDetalles;
            L_FACTOR_CAMBIO.Text = _controlador.GetFactorCambio.ToString("n2");
            L_MONTO_DIVISA_MOV.Text = _controlador.GetMontoDivisaMov.ToString("n2")+"$";
            L_TIPO_MOVIMIENTO.Text = _controlador.GetTipoMovDesc;
        }

        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void AbandonarFicha()
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
    }
}