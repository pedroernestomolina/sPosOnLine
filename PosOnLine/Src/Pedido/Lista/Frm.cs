using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pedido.Lista
{
    public partial class Frm : Form
    {
        private IListaPedidos _controlador;
        //
        private void InicializarGrid()
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
            c0.DataPropertyName = "PedidoTarjetaNum";
            c0.HeaderText = "Tarjeta";
            c0.Visible = true;
            c0.MinimumWidth= 100;
            c0.HeaderCell.Style.Font = f;
            c0.DefaultCellStyle.Font = f;
            c0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Fecha";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 90;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            //
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "MontoMonAct";
            c3.HeaderText = "Importe";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "MontoMonDiv";
            c5.HeaderText = "Importe ($)";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "CntRenglones";
            c4.HeaderText = "#Reng";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            DGV.Columns.Add(c0);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c4);
        }
        //
        public Frm()
        {
            InitializeComponent();
            InicializarGrid();
        }
        public void setControlador(IListaPedidos ctr)
        {
            _controlador = ctr;
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.DataSource;
            DGV.Refresh();
            IrFoco();
        }
        //
        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                AbrirCta();
            }
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }
        //
        private void Salir()
        {
            this.Close();
        }
        private void IrFoco()
        {
            DGV.Focus();
        }
        private void AbrirCta()
        {
            _controlador.AbrirTarjetaPedido();
            if (_controlador.AbrirTarjetaIsOk) 
            {
                Salir();
            }
        }
    }
}
