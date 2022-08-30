using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Producto.Lista
{

    public partial class ListaFrm : Form
    {


        private Gestion _controlador;


        public ListaFrm()
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

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Precio";
            c5.HeaderText = "P/Und $";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Plu";
            c6.HeaderText = "PLU";
            c6.Visible = true;
            c6.Width = 50;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "precioMay";
            c7.HeaderText = "P/Mayor $";
            c7.Visible = true;
            c7.Width = 100;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "EmpaqueMay";
            c8.HeaderText = "E/Mayor";
            c8.Visible = true;
            c8.Width = 80;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            //DGV.Columns.Add(c7);
            //DGV.Columns.Add(c8);
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                SeleccionarItem();
            }
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Salida()
        {
            this.Close();
        }

        private BindingSource _source;
        private void ListaFrm_Load(object sender, EventArgs e)
        {
            _source = _controlador.Source;
            _source.CurrentChanged += _source_CurrentChanged;
            DGV.DataSource = _source;
            DGV.Columns[3].Visible = _controlador.IsCantidadVisible;
            DGV.Columns[4].Visible = _controlador.IsPrecioVisible;
            DGV.Focus();
            DGV.Refresh();
            L_EMP_1.Text = _controlador.GetEmp_1;
            L_PRECIO_1.Text = _controlador.GetPrecio_1;
            L_EMPAQUE_2.Text = _controlador.GetEmp_2;
            L_PRECIO_2.Text = _controlador.GetPrecio_2;
            L_EMPAQUE_3.Text = _controlador.GetEmp_3;
            L_PRECIO_3.Text = _controlador.GetPrecio_3;
            L_PRECIO_1_BONO.Text = _controlador.GetPrecio_1_Bono;
            L_PRECIO_2_BONO.Text = _controlador.GetPrecio_2_Bono;
            L_PRECIO_3_BONO.Text = _controlador.GetPrecio_3_Bono;
            L_TITULO_PRECIO_BONO.Text = _controlador.GetTituloPrecioBono;
        }

        void _source_CurrentChanged(object sender, EventArgs e)
        {
            ActualizarPanelInformativo();
        }

        private void ActualizarPanelInformativo()
        {
            L_EMP_1.Text = _controlador.GetEmp_1;
            L_PRECIO_1.Text = _controlador.GetPrecio_1;
            L_PRECIO_1_BONO.Text = _controlador.GetPrecio_1_Bono;

            L_EMPAQUE_2.Text = _controlador.GetEmp_2;
            L_PRECIO_2.Text = _controlador.GetPrecio_2;
            L_PRECIO_2_BONO.Text = _controlador.GetPrecio_2_Bono;

            L_EMPAQUE_3.Text = _controlador.GetEmp_3;
            L_PRECIO_3.Text = _controlador.GetPrecio_3;
            L_PRECIO_3_BONO.Text = _controlador.GetPrecio_3_Bono;
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

        private void SubirItem()
        {
            _controlador.Subir();
        }

        private void BT_BAJAR_Click(object sender, EventArgs e)
        {
            BajarItem();
        }

        private void BajarItem()
        {
            _controlador.Bajar();
        }
     
        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_ENTER_Click(object sender, EventArgs e)
        {
            SeleccionarItem();
        }        
        private void SeleccionarItem()
        {
            _controlador.Seleccionar();
        }

        public void Cerrar()
        {
            this.Close();
        }

    }

}