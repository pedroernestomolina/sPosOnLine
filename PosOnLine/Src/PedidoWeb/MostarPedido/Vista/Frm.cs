using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosOnLine.Src.PedidoWeb.MostarPedido.Vista
{
    public partial class Frm : Form
    {
        private Vm.IMostarPedido _controlador;
        //
        public Frm()
        {
            InitializeComponent();
            InicializaDGV();
        }
        private void InicializaDGV()
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
            c1.DataPropertyName = "ItemDesc";
            c1.HeaderText = "Descripcion";
            c1.Visible = true;
            c1.MinimumWidth = 240;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f2;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "ItemCnt";
            c2.HeaderText = "Cnt";
            c2.Visible = true;
            c2.Width = 60;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f2;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "ItemEmpq";
            c3.HeaderText = "Empaque";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f2;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "ItemPrecio";
            c4.HeaderText = "Precio $";
            c4.Visible = true;
            c4.Width = 100;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f2;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "ItemImporte";
            c5.HeaderText = "Importe $";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f2;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
        }
        //
        public void setControlador(Vm.IMostarPedido ctr)
        {
            _controlador = ctr;
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Get_DetallesSource;
            L_PEDIDO_NRO.Text = "Pedido Web Nro: "+_controlador.Get_PedidoNro.ToString().Trim().PadLeft(8,'0');
            L_ENTIDAD.Text = _controlador.Get_EntidadPedido;
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
    }
}