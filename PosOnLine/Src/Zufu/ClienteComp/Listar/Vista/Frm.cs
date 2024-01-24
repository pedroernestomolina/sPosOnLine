using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Zufu.ClienteComp.Listar.Vista
{
    public partial class Frm : Form
    {
        private IVista _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializarDGV();
        }
        public void setControlador(IVista ctr)
        {
            _controlador = ctr;
        }
        private void InicializarDGV()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            //
            DGV.RowHeadersVisible = false;
            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;
            //
            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "ciRif";
            c1.HeaderText = "CI/Rif";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            //
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "nombreRazonSocial";
            c3.HeaderText = "Nombre/Razón Social";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            //
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
        }
        private void ListaFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Lista.GetSource;
            L_CNT_ITEM.Text = "Items Encontrados: "+_controlador.Lista.GetCantItem.ToString();
        }
        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1) 
            {
                SeleccionarItem();
            }
        }
        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarItem();
            }
        }


        private void BT_SUBIR_Click(object sender, EventArgs e)
        {
            SubirItem();
        }
        private void BT_BAJAR_Click(object sender, EventArgs e)
        {
            BajarItem();
        }
        private void BT_ENTER_Click(object sender, EventArgs e)
        {
            SeleccionarItem();
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            salida();
        }


        private void SeleccionarItem()
        {
            _controlador.Lista.Met_SeleccionarItem();
            if (_controlador.Lista.ItemSeleccionadoIsOk)
            {
                salida();
            }
        }
        private void SubirItem()
        {
            _controlador.Lista.Met_SubirItem();
        }
        private void BajarItem()
        {
            _controlador.Lista.Met_BajarItem();
        }
        private void salida()
        {
            this.Close();
        }
    }
}