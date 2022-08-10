using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Cierre.Historico
{

    public partial class HistoriaFrm : Form
    {

        private IHistoria _controlador;


        public HistoriaFrm()
        {
            InitializeComponent();
            InicializaGrid();
        }

        private void InicializaGrid()
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
            c1.MinimumWidth = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "IdEquipo";
            c3.HeaderText = "Equipo";
            c3.Visible = true;
            c3.Width = 60;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CierreNro";
            c2.HeaderText = "Cierre Nro";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c2);
        }



        public void setControlador(IHistoria ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void Salir()
        {
            this.Close();
        }

        private bool _modoInicializar;
        private void HistoriaFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            DGV.DataSource = _controlador.GetDataSource;
            printDialog1.Document = printDocument1;
            _modoInicializar = false;
        }

        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            ImprimirCierre();
        }
        private void ImprimirCierre()
        {
            _controlador.ImprimirCierre();
            if (_controlador.ImprimirIsOk)
            {
                printDocument1.Print();
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            _controlador.Imprimir(e);
        }

    }

}