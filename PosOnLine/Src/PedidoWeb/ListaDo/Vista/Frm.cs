using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosOnLine.Src.PedidoWeb.ListaDo.Vista
{
    public partial class Frm : Form
    {
        private Vm.IListaDo _controlador;
        //
        public Frm()
        {
            InitializeComponent();
            InicializaGrid();
        }
        private void InicializaGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);
            var f2 = new Font("Serif", 7, FontStyle.Regular);
            //
            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;
            DGV.RowHeadersVisible = false;
            //
            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "PedidoNroDesc";
            c1.HeaderText = "PedidoNro";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f2;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "FechaDesc";
            c3.HeaderText = "Fecha";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f2;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "EntidadDesc";
            c2.HeaderText = "Entidad";
            c2.Visible = true;
            c2.MinimumWidth = 200;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f2;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "CiRifEntidadDesc";
            c4.HeaderText = "CiRif";
            c4.Visible = true;
            c4.Width = 110;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f2;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //
            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "ImporteDesc";
            c5.HeaderText = "Importe $";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f2;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "ItemsDesc";
            c6.HeaderText = "Items";
            c6.Visible = true;
            c6.Width = 60;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f2;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
        }
        public void setControlador(Vm.IListaDo ctr)
        {
            _controlador = ctr;
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Get_SourceData;
        }
    }
}