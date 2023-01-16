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

            var c9 = new DataGridViewTextBoxColumn();
            c9.DataPropertyName = "TipoMovDesc";
            c9.HeaderText = "Tipo Mov";
            c9.Visible = true;
            c9.Width = 100;
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f1;
            c9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Documento";
            c2.HeaderText = "Documento";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "DocNombre";
            c7.Name = "DocNombre";
            c7.HeaderText = "Tipo";
            c7.Visible = true;
            c7.Width = 90;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Renglones";
            c6.HeaderText = "# Reng";
            c6.Visible = true;
            c6.Width = 40;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n0";
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "CiRif";
            c3.HeaderText = "CiRif";
            c3.Visible = true;
            c3.Width = 90;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "NombreRazonSocial";
            c4.HeaderText = "Nombre / Razón Social";
            c4.Visible = true;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c4.MinimumWidth = 180;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Monto";
            c5.HeaderText = "Importe";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var cA = new DataGridViewTextBoxColumn();
            cA.DataPropertyName = "MontoDivisa";
            cA.HeaderText = "$";
            cA.Visible = true;
            cA.Width = 70;
            cA.HeaderCell.Style.Font = f;
            cA.DefaultCellStyle.Font = f1;
            cA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cA.DefaultCellStyle.Format = "n2";

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "EstatusDoc";
            c8.Name = "Estatus";
            c8.HeaderText = "Estatus";
            c8.Visible = true;
            c8.Width = 80;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;

            var cB = new DataGridViewTextBoxColumn();
            cB.DataPropertyName = "Signo";
            cB.Name = "Signo";
            cB.HeaderText = "Signo";
            cB.Visible = false;
            cB.Width = 10;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c9);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(cA);
            DGV.Columns.Add(c8);
            DGV.Columns.Add(cB);
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
    }
}