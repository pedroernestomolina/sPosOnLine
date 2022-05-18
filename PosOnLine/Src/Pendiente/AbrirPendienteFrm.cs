using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pendiente
{

    public partial class AbrirPendienteFrm : Form
    {


        private Gestion _controlador;


        public AbrirPendienteFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }


        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

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
            c1.DataPropertyName = "Fecha";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Cliente";
            c2.HeaderText = "Cliente";
            c2.Visible = true;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

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
            c5.DataPropertyName = "ImporteDivisa";
            c5.HeaderText = "$";
            c5.Visible = true;
            c5.Width = 80;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Renglones";
            c4.HeaderText = "Renglones";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n0";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c4);
        }

        private void AbrirPendienteFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            DGV.Refresh();
            IrFoco();
        }


        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_ABRIR_Click(object sender, EventArgs e)
        {
            AbrirCta();
        }

        private void AbrirCta()
        {
            _controlador.AbrirCta();
            if (_controlador.AbrirCtaPendienteIsOk)
            {
                Salir();
            }
        }

        private void IrFoco()
        {
            DGV.Focus();
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (DGV.CurrentRow != null)
            {
                if (DGV.CurrentRow.Index > -1)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        AbrirCta();
                    }
                    if (e.KeyCode == Keys.Delete)
                    {
                        EliminarCta();
                    }
                }
            }
        }

        private void BT_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarCta();
        }

        private void EliminarCta()
        {
            //_controlador.EliminarCta();
        }

        private void AbrirPendienteFrm_Load_1(object sender, EventArgs e)
        {
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                AbrirCta();
            }
        }

    }

}