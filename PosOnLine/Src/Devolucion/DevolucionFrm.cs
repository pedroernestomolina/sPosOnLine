using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Devolucion
{

    public partial class DevolucionFrm : Form
    {

        private Gestion _controlador;


        public DevolucionFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }


        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            var f2 = new Font("Serif", 8, FontStyle.Regular);

            DGV_DETALLE.AllowUserToAddRows = false;
            DGV_DETALLE.AllowUserToDeleteRows = false;
            DGV_DETALLE.AutoGenerateColumns = false;
            DGV_DETALLE.AllowUserToResizeRows = false;
            DGV_DETALLE.AllowUserToResizeColumns = false;
            DGV_DETALLE.AllowUserToOrderColumns = false;
            DGV_DETALLE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_DETALLE.MultiSelect = false;
            DGV_DETALLE.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "NombrePrd";
            c1.HeaderText = "Descripcion";
            c1.Visible = true;
            c1.MinimumWidth = 120;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f2;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Cantidad";
            c2.Name = "Cantidad";
            c2.HeaderText = "Cant";
            c2.Visible = true;
            c2.Width = 60;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "EmpaqueCont";
            c4.HeaderText = "Empaque";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Importe";
            c3.HeaderText = "Importe";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "TotalItem";
            c5.HeaderText = "SubTotal";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewCheckBoxColumn();
            c6.DataPropertyName = "EsPesado";
            c6.HeaderText = "Kg";
            c6.Name = "EsPesado";
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.Width = 30;

            DGV_DETALLE.Columns.Add(c1);
            DGV_DETALLE.Columns.Add(c2);
            DGV_DETALLE.Columns.Add(c4);
            DGV_DETALLE.Columns.Add(c3);
            DGV_DETALLE.Columns.Add(c5);
            DGV_DETALLE.Columns.Add(c6);
        }


        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void DevolucionFrm_Load(object sender, EventArgs e)
        {
            DGV_DETALLE.DataSource = _controlador.DataSource;
            ActualizarSubTotal();
            irFocoPrincipal();
        }

        private void irFocoPrincipal()
        {
            DGV_DETALLE.Focus();
        }

        private void BT_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarItem();
        }

        private void EliminarItem()
        {
            _controlador.EliminarItem();
            ActualizarSubTotal();
        }

        private void ActualizarSubTotal()
        {
            L_SUBTOTAL.Text = _controlador.MontoSubTotal.ToString("n2");
        }

        private void BT_DEVOLVER_Click(object sender, EventArgs e)
        {
            DevolerItem();
        }

        private void DevolerItem()
        {
            _controlador.DevolerItem();
            ActualizarSubTotal();
        }

        private void BT_SUBIR_Click(object sender, EventArgs e)
        {
            SubirItem();
        }

        private void SubirItem()
        {
            _controlador.SubirItem();
        }

        private void BT_BAJAR_Click(object sender, EventArgs e)
        {
            BajarItem();
        }

        private void BajarItem()
        {
            _controlador.BajarItem();
        }

        private void DGV_DETALLE_KeyDown(object sender, KeyEventArgs e)
        {
            if (DGV_DETALLE.CurrentRow != null)
            {
                if (DGV_DETALLE.CurrentRow.Index > -1)
                {
                    if (e.KeyCode == Keys.Subtract)
                    {
                        DevolerItem();
                    }
                    if (e.KeyCode == Keys.Delete)
                    {
                        EliminarItem();
                    }
                }
            }
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

    }

}