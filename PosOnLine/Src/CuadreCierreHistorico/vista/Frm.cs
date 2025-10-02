using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.CuadreCierreHistorico.vista
{
    public partial class Frm : Form
    {
        private vm.IHistorico _controlador;
        //
        private void InicializaGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);
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
            c1.DataPropertyName = "CabFechaHoraCierre";
            c1.HeaderText = "Fecha/Hora";
            c1.Visible = true;
            c1.MinimumWidth = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "CabTerminal";
            c3.HeaderText = "Equipo";
            c3.Visible = true;
            c3.Width = 60;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CabNroCierre";
            c2.HeaderText = "Cierre Nro";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c2);
        }
        public Frm()
        {
            InitializeComponent();
            InicializaGrid();
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Get_ListaCierreSource;
        }
        public void setControlador(vm.IHistorico ctr)
        {
            _controlador = ctr;
        }
        //
        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            imprimirCierre();
        }
        private void BT_CREDITO_Click(object sender, EventArgs e)
        {
            ventCredito();
        }
        private void BT_DETALLE_Click(object sender, EventArgs e)
        {
            pagoDetalles();
        }
        private void BT_PAGO_RESUMEN_Click(object sender, EventArgs e)
        {
            pagoResumen();
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            salir();
        }
        //
        private void imprimirCierre()
        {
            _controlador.imprimirCierre();
        }
        private void ventCredito()
        {
            _controlador.repoVentaredito();
        }
        private void pagoDetalles()
        {
            _controlador.repoPagoDetalle();
        }
        private void pagoResumen()
        {
            _controlador.repoPagoResumen();
        }
        private void salir()
        {
            this.Close();
        }
    }
}