using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Producto.Lista.ModoAdm
{
    public partial class Frm : Form
    {
        private IModoAdm _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializarDGV();
        }


        private void InicializarDGV()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            var f2 = new Font("Serif", 6, FontStyle.Regular);

            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Código";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Nombre";
            c3.HeaderText = "Nombre";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "CantidadEx";
            c4.HeaderText = "Ex/(Unidad)";
            c4.Visible = true;
            c4.Width = 90;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format ="n1";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Plu";
            c6.HeaderText = "PLU";
            c6.Visible = true;
            c6.Width = 50;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c4);
        }
        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                SeleccionarItem();
            }
        }
        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DGV.CurrentRow != null)
                {
                    if (DGV.CurrentRow.Index > -1)
                    {
                        SeleccionarItem();
                    }
                }
            }
        }


        public void setControlador(IModoAdm ctr)
        {
            _controlador = ctr;
        }


        private BindingSource _source;
        private void Frm_Load(object sender, EventArgs e)
        {
            _source = _controlador.Listar.GetSource;
            _source.CurrentChanged += _source_CurrentChanged;
            DGV.DataSource = _source;
            DGV.Focus();
            DGV.Refresh();
            ActualizarPanelInformativo();
        }
        void _source_CurrentChanged(object sender, EventArgs e)
        {
            ActualizarPanelInformativo();
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
            Salida();
        }


        private void ActualizarPanelInformativo()
        {
            L_PRD_DETALLE.Text = _controlador.Listar.Prd.GetDesc;

            L_EMP_1.Text = _controlador.Listar.Prd.EmpVta1.GetDesc;
            L_PRECIO_1.Text = _controlador.Listar.Prd.EmpVta1.GetPrecio;
            L_OFERTA_1.Text = _controlador.Listar.Prd.EmpVta1.GetOferta;
            P_EMP1.Visible = _controlador.Listar.Prd.EmpVta1.GetVisible;

            L_EMPAQUE_2.Text = _controlador.Listar.Prd.EmpVta2.GetDesc;
            L_PRECIO_2.Text = _controlador.Listar.Prd.EmpVta2.GetPrecio;
            L_OFERTA_2.Text = _controlador.Listar.Prd.EmpVta2.GetOferta;
            P_EMP2.Visible = _controlador.Listar.Prd.EmpVta2.GetVisible;

            L_EMPAQUE_3.Text = _controlador.Listar.Prd.EmpVta3.GetDesc;
            L_PRECIO_3.Text = _controlador.Listar.Prd.EmpVta3.GetPrecio;
            L_OFERTA_3.Text = _controlador.Listar.Prd.EmpVta3.GetOferta;
            P_EMP3.Visible = _controlador.Listar.Prd.EmpVta3.GetVisible;

            L_EX_EMP_COMPRA.Text = _controlador.Listar.Prd.Inv.EmpCompra.GetCnt.ToString();
            L_EMP_COMPRA.Text = _controlador.Listar.Prd.Inv.EmpCompra.GetDesc;
            L_EX_EMP_INV.Text = _controlador.Listar.Prd.Inv.EmpHndInv.GetCnt.ToString();
            L_EMP_INV.Text = _controlador.Listar.Prd.Inv.EmpHndInv.GetDesc;
            L_EX_EMP_UND.Text = _controlador.Listar.Prd.Inv.EmpUnd.GetCnt.ToString();
            L_EMP_UND.Text = _controlador.Listar.Prd.Inv.EmpUnd.GetDesc;
        }
        private void SubirItem()
        {
            _controlador.Listar.SubirItem(); ;
        }
        private void BajarItem()
        {
            _controlador.Listar.BajarItem();
        }
        private void SeleccionarItem()
        {
            _controlador.SeleccionItem();
            if (_controlador.ItemSeleccionIsOk) 
            {
                Salida();
            }
        }
        private void Salida()
        {
            this.Close();
        }
        public void Cerrar()
        {
            this.Close();
        }
    }
}