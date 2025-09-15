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
            c2.DataPropertyName = "CabMontoUsu";
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
            c4.MinimumWidth = 120;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "CabImporte";
            c5.HeaderText = "Importe";
            c5.Visible = true;
            c5.MinimumWidth = 180;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            DGV.Columns.Add(c0);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            //DGV.Columns.Add(c3);
        }
        public Frm()
        {
            InitializeComponent();
            InicializaDGV();
        }
        public void setControlador(vm.ICuadre ctr)
        {
            _controlador = ctr;
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Get_MetodosPagoSource;
            DGV.Refresh();
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
        }
        //
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
        }

        private void DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (DGV.Columns[e.ColumnIndex].Name == "Monto") 
            {
                decimal valor;
                if (!decimal.TryParse(e.FormattedValue.ToString(), out valor)) 
                {
                    e.Cancel = true;
                    MessageBox.Show("Por Favor, Ingresa un valor valido");
                }
            }
        }
        private void DGV_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Columns[e.ColumnIndex].Name == "Monto") 
            {
                _controlador.ActualizarImporteMetodoPago();
            }
        }
    }
}