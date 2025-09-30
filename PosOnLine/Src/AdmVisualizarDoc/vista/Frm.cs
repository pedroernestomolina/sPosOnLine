using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.AdmVisualizarDoc.vista
{
    public partial class Frm : Form
    {
        private vm.IVisualizar _controlador;
        //
        private void InicializarDGV()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

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
            c1.DefaultCellStyle.Font = f1;
            //
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "NombrePrd";
            c3.HeaderText = "Nombre";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            //
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CantidadInfo";
            c2.HeaderText = "Cant";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "EmpaqueInfo";
            c6.HeaderText = "Empaque";
            c6.Visible = true;
            c6.Width = 120;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "PrecioMonLocal";
            c4.HeaderText = "Precio";
            c4.Visible = true;
            c4.Width = 120;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";
            //
            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "ImporteMonLocal";
            c5.HeaderText = "Importe";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";
            //
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
        }
        public Frm()
        {
            InitializeComponent();
            InicializarDGV();
        }
        public void setControlador(vm.IVisualizar ctr)
        {
            _controlador = ctr;
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Get_ItemSource;
            L_DOCUMENTO_TIPO.Text = _controlador.Get_Doc_Tipo;
            L_DOCUMENTO.Text = _controlador.Get_Doc_Numero;
            L_FECHA.Text = _controlador.Get_Doc_FechaEmision;
            L_CLIENTE.Text = _controlador.Get_Doc_ClienteInfo;
            L_TOTAL.Text = _controlador.Get_Doc_Importe;
            L_CREDITO.Visible = _controlador.Get_doc_IsCredito;
            L_ANULADO.Visible = _controlador.Get_doc_IsAnulado;
            DGV.Focus();
            DGV.Refresh();
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