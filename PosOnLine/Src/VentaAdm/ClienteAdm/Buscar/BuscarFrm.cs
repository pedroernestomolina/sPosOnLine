using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.VentaAdm.ClienteAdm.Buscar
{

    public partial class BuscarFrm : Form
    {

        private IBuscar _controlador;


        public BuscarFrm()
        {
            InitializeComponent();
            InicializarDGV();
            InicializarCombo();
        }

        private void InicializarCombo()
        {
            CB_OPC.DisplayMember = "desc";
            CB_OPC.ValueMember = "id";
        }

        private void InicializarDGV()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

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
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 100;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CiRif";
            c2.HeaderText = "CiRif";
            c2.Visible = true;
            c2.Width = 110;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "NombreRazonSocial";
            c3.HeaderText = "Nombre/Razón Social";
            c3.Visible = true;
            c3.MinimumWidth = 220;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Estatus";
            c4.HeaderText = "Estatus";
            c4.Name = "Estatus";
            c4.Visible = true;
            c4.Width = 60;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
        }

        public void setControlador(IBuscar ctr)
        {
            _controlador = ctr;
        }


        private bool _modoInicializa;
        private void BuscarClienteFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            DGV.DataSource = _controlador.GetItemsSource;
            CB_OPC.DataSource = _controlador.GetOpcBusqSource;
            CB_OPC.SelectedValue = _controlador.GetOpcBusqId;
            ActualizarData();
            _modoInicializa = false;
        }

        private void ActualizarData()
        {
            TB_CADENA.Text = "";
            L_ITEMS.Text = _controlador.GetCntItem.ToString();
        }

        private void CB_OPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.SetOpcBusq("");
            if (CB_OPC.SelectedIndex != -1) 
            {
                _controlador.SetOpcBusq(CB_OPC.SelectedValue.ToString());
            }
        }
        private void TB_CADENA_Leave(object sender, EventArgs e)
        {
            _controlador.setCadena(TB_CADENA.Text);
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void Buscar()
        {
            _controlador.ActivarBusqueda();
            ActualizarData();
            GoInicio();
        }

        private void GoInicio()
        {
            TB_CADENA.Focus();
        }


        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarBusqueda();
        }
        private void LimpiarBusqueda()
        {
            //_controlador.LimpiarBusqueda();
            ActualizarData();
            GoInicio();
        }

        
        private void BT_AGREGAR_Click(object sender, EventArgs e)
        {
            AgregarCliente();
        }
        private void AgregarCliente()
        {
            //_controlador.AgregarCliente();
            //GoInicio();
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
        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                SeleccionarItem();
            }
        }
        private void SeleccionarItem()
        {
            _controlador.SeleccionarCliente();
            if (_controlador.ClienteSeleccionadoIsOk )
            {
                Salir();
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }
        private void Salir()
        {
            this.Close();
        }
      
    }

}