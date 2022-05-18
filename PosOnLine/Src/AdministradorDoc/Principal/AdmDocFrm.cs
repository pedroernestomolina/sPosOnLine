using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.AdministradorDoc.Principal
{

    public partial class AdmDocFrm : Form
    {

        private Gestion _controlador;


        public AdmDocFrm()
        {
            InitializeComponent();
            InicializarGRid();
        }


        private void InicializarGRid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);

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
            c1.DataPropertyName = "FechaHora";
            c1.HeaderText = "Fecha/Hora";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c9 = new DataGridViewTextBoxColumn();
            c9.DataPropertyName = "Serie";
            c9.HeaderText = "Serie";
            c9.Visible = true;
            c9.Width = 60;
            c9.HeaderCell.Style.Font = f;
            c9.DefaultCellStyle.Font = f1;
            c9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Documento";
            c2.HeaderText = "Documento";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "DocNombre";
            c7.Name = "DocNombre";
            c7.HeaderText = "Tipo";
            c7.Visible = true;
            c7.Width = 90;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Renglones";
            c6.HeaderText = "# Reng";
            c6.Visible = true;
            c6.Width =40;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n0";
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "CiRif";
            c3.HeaderText = "CiRif";
            c3.Visible = true;
            c3.Width = 90;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "NombreRazonSocial";
            c4.HeaderText = "Nombre / Razón Social";
            c4.Visible = true;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c4.MinimumWidth = 180;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Monto";
            c5.HeaderText = "Importe";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var cA = new DataGridViewTextBoxColumn();
            cA.DataPropertyName = "MontoDivisa";
            cA.HeaderText = "$";
            cA.Visible = true;
            cA.Width = 70;
            cA.HeaderCell.Style.Font = f;
            cA.DefaultCellStyle.Font = f1;
            cA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cA.DefaultCellStyle.Format = "n2";
        
            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "EstatusDoc";
            c8.Name = "Estatus";
            c8.HeaderText="Estatus";
            c8.Visible = true;
            c8.Width = 80;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;

            var cB = new DataGridViewTextBoxColumn();
            cB.DataPropertyName = "Signo";
            cB.Name = "Signo";
            cB.HeaderText = "Signo";
            cB.Visible = false;
            cB.Width = 10;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c9);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(cA);
            DGV.Columns.Add(c8);
            DGV.Columns.Add(cB);
        }

        private void ListartFrm_Load(object sender, EventArgs e)
        {
            L_ITEMS.Text = _controlador.TotItems;
            DGV.DataSource = _controlador.Source;
            DGV.Refresh();
            printDialog1.Document = printDocument1;
        }

        private void IrFocoPrincipal()
        {
            DGV.Focus();
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

        private void BT_ANULAR_Click(object sender, EventArgs e)
        {
            AnularDocumento();
        }

        private void AnularDocumento()
        {
            _controlador.AnularDocumento();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_NOTA_CREDITO_Click(object sender, EventArgs e)
        {
            NotaCredito();
        }

        private void NotaCredito()
        {
            _controlador.NotaCredito();
            if (_controlador.NotaCreditoIsOk)
            {
                Salir();
            }
        }

        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            ImprimirDocumento();
        }

        private void ImprimirDocumento()
        {
            if (Helpers.PassWord.PassWIsOk(Sistema.FuncionAdmReimprimirDocumento))
            {
                _controlador.ImprimirDocumento();
                if (_controlador.IsTickeraOk)
                {
                    printDocument1.Print();
                }
            }
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if ((string)row.Cells["Estatus"].Value != "") 
                {
                    row.Cells["Estatus"].Style.BackColor = Color.Red ;
                    row.Cells["Estatus"].Style.ForeColor = Color.White;
                }

                if ((int)row.Cells["Signo"].Value ==-1)
                {
                    row.Cells["DocNombre"].Style.BackColor = Color.Red;
                    row.Cells["DocNombre"].Style.ForeColor = Color.White;
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            _controlador.Imprimir(e);
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VisualizarDocumento();
        }

        private void VisualizarDocumento()
        {
            _controlador.VisualizarDocumento();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

    }

}
