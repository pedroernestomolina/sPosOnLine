using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Producto.Lista.ZUFU.vistas
{
    public partial class Frm : Form
    {
        private ZUFU.IListaProducto _controlador;
        //
        private void InicializarDGV()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            var f2 = new Font("Serif", 6, FontStyle.Regular);
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
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Código";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f;
            //
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "NombrePrd";
            c3.HeaderText = "Nombre";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            //
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "ExTotalPrd";
            c4.HeaderText = "Ex/(Unidad)";
            c4.Visible = true;
            c4.Width = 90;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n3";
            c4.Name = "CNT";
            //
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
        }
        public Frm()
        {
            InitializeComponent();
            InicializarDGV();
        }
        public void setControlador(ZUFU.IListaProducto ctr)
        {
            _controlador = ctr;
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                SeleccionarItem();
            }
        }
        private void ListaFrm_Load(object sender, EventArgs e)
        {
            var _source = (BindingSource)_controlador.GetSource;
            _source.CurrentChanged += _source_CurrentChanged;
            DGV.DataSource = _source;
            L_TITULO_PRECIO_BONO.Text = _controlador.GetTituloPrecioBono;
            ActualizarPanelInformativo();
            DGV.Focus();
            DGV.Refresh();
        }
        void _source_CurrentChanged(object sender, EventArgs e)
        {
            ActualizarPanelInformativo();
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
        //
        private void ActualizarPanelInformativo()
        {
            L_PRD_DETALLE.Text = _controlador.GetDetalleProducto;
            P_EMP1.Visible = _controlador.GetIsOkEmp1;
            L_EMP_1.Text = _controlador.GetEmp1;
            L_PRECIO_1.Text = _controlador.GetPrecio1;
            L_PRECIO_1_BONO.Text = _controlador.GetPrecio1ConBono;
            //
            P_EMP2.Visible = _controlador.GetIsOkEmp2;
            L_EMPAQUE_2.Text = _controlador.GetEmp2;
            L_PRECIO_2.Text = _controlador.GetPrecio2;
            L_PRECIO_2_BONO.Text = _controlador.GetPrecio2ConBono;
            //
            P_EMP3.Visible = _controlador.GetIsOkEmp3;
            L_EMPAQUE_3.Text = _controlador.GetEmp3;
            L_PRECIO_3.Text = _controlador.GetPrecio3;
            L_PRECIO_3_BONO.Text = _controlador.GetPrecio3ConBono;
            //
            L_EX_EMP_COMPRA.Text = _controlador.GetInvEmpCompra.ToString();
            L_EMP_COMPRA.Text = _controlador.GetDescEmpCompra;
            L_EX_EMP_INV.Text = _controlador.GetInvEmpInv.ToString();
            L_EMP_INV.Text = _controlador.GetDescEmpInv;
            L_EX_EMP_UND.Text = _controlador.GetInvEmpUnd.ToString();
            L_EMP_UND.Text = _controlador.GetDescEmpUnd;
            //
            PB_IMAGEN.Image = Properties.Resources.bt_imagen_2;
            if (_controlador.GetPrdImagen != null)
            {
                PB_IMAGEN.Image = (System.Drawing.Image)_controlador.GetPrdImagen;
            }
        }
        private void SeleccionarItem()
        {
            _controlador.SeleccionarItem();
            if (_controlador.ItemSeleccionadoIsOk) 
            {
                Cerrar();
            }
        }
        private void SubirItem()
        {
            _controlador.FlechaArriba();
        }
        private void BajarItem()
        {
            _controlador.FlechaAbajo();
        }
        public void Cerrar()
        {
            this.Close();
        }
        private void Salida()
        {
            _controlador.SalirLista();
            this.Close();
        }
    }
}