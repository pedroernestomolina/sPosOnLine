using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosOnLine.Src.MovCaja.Adm
{
    public partial class AdmFrm : Form
    {
        private IAdm _controlador;

        public AdmFrm()
        {
            InitializeComponent();
            InicializaGrid();
        }

        private void InicializaGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);

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
            c1.DataPropertyName = "NroMov";
            c1.HeaderText = "Nro Mov";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "TipoMovDesc";
            c2.Name = "TipoMov";
            c2.HeaderText = "Tipo Mov";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "FechaEmision";
            c3.HeaderText = "Fecha";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "Monto";
            c7.HeaderText = "Monto";
            c7.Visible = true;
            c7.Width = 80;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n2";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "MontoDivisaMov";
            c4.HeaderText = "Monto($)";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "ConceptoMov";
            c5.HeaderText = "Concepto";
            c5.Visible = true;
            c5.MinimumWidth = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "EstatusMov";
            c6.Name = "EstatusMov";
            c6.HeaderText = "Estatus";
            c6.Visible = true;
            c6.Width = 70;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
        }
        private void AdmFrm_Load(object sender, EventArgs e)
        {
            L_ITEMS.Text = "" + _controlador.GetData_CantItem.ToString();
            DGV.DataSource = _controlador.GetData_Source;
            DGV.Refresh();
        }
        public void setControlador(IAdm ctr)
        {
            _controlador = ctr;
        }

        private void BT_SUBIR_Click(object sender, EventArgs e)
        {
            Subir();
        }
        private void BT_BAJAR_Click(object sender, EventArgs e)
        {
            Bajar();
        }
        private void BT_ANULAR_Click(object sender, EventArgs e)
        {
            AnularMov();
        }
        private void BT_AGREGAR_Click(object sender, EventArgs e)
        {
            AgregarMov();
        }
        private void BT_VIEW_Click(object sender, EventArgs e)
        {
            ViewMov();
        }

        private void Subir()
        {
            _controlador.Subir();
        }
        private void Bajar()
        {
            _controlador.Bajar();
        }
        private void AnularMov()
        {
            _controlador.AnularMov();
        }
        private void AgregarMov()
        {
            _controlador.AgregarMov();
        }
        private void ViewMov()
        {
            _controlador.ViewMov();
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if ((string)row.Cells["EstatusMov"].Value != "")
                {
                    row.Cells["EstatusMov"].Style.BackColor = Color.Red;
                    row.Cells["EstatusMov"].Style.ForeColor = Color.White;
                }
                var _tipoMov = (string)row.Cells["TipoMov"].Value;
                switch (_tipoMov.Trim().ToUpper())
                { 
                    case "ENTRADA":
                        row.Cells["TipoMov"].Style.ForeColor = Color.DarkGreen;
                        break;
                    case "SALIDA":
                        row.Cells["TipoMov"].Style.ForeColor = Color.DarkRed;
                        break;
                }
            }
        }
    }
}