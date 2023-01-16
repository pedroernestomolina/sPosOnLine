using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.MovCaja.Agregar
{
    public partial class AgregarFrm : Form
    {

        private IAgregar _controlador;


        public AgregarFrm()
        {
            InitializeComponent();
            InicializarCombo();
            InicializarGrid();
        }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            var f2 = new Font("Serif", 8, FontStyle.Regular);

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
            c1.DataPropertyName = "Medio";
            c1.HeaderText = "Medio";
            c1.Visible = true;
            c1.MinimumWidth = 120;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f2;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Monto";
            c2.HeaderText = "Monto";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Importe";
            c3.HeaderText = "Importe";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Cant";
            c4.HeaderText = "Cant";
            c4.Visible = true;
            c4.Width = 60;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c3);
        }
        private void InicializarCombo()
        {
            CB_TIPO_MOV.DisplayMember = "desc";
            CB_TIPO_MOV.ValueMember = "id";
            CB_MEDIO.DisplayMember = "desc";
            CB_MEDIO.ValueMember = "id";
        }

        public void setControlador(IAgregar ctr)
        {
            _controlador = ctr;
        }

        bool _modoInicializa;
        private void AgregarFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            DT_FECHA.Value = _controlador.GetFechaEmision;
            CB_TIPO_MOV.DataSource = _controlador.GetTipoMov_Source;
            CB_TIPO_MOV.SelectedValue = _controlador.GetTipoMov_Id;
            TB_MONTO.Text = _controlador.GetMontoMov.ToString();
            TB_FACTOR_CAMBIO.Text = _controlador.GetFactorCambio.ToString();
            TB_CONCEPTO.Text = _controlador.GetConcepto;
            TB_DETALLE.Text = _controlador.GetDetalles;
            CHB_DIVISA.Checked = _controlador.GetEsDivisa;
            DGV.DataSource = _controlador.GetListaMedios_Source;
            //
            CB_MEDIO.DataSource = _controlador.GetMedio_Source;
            CB_MEDIO.SelectedValue = _controlador.GetMedio_Id;
            CHB_MEDIO_ES_DIVISA.Checked = _controlador.GetMedioEsDivisa;
            TB_MONTO_MEDIO.Text = _controlador.GetMontoMedio.ToString();
            TB_CANT_MEDIO.Text = _controlador.GetCantMedio.ToString();
            _modoInicializa = false;
            TB_MONTO_MEDIO.Enabled = true;
            TB_CANT_MEDIO.Enabled = false;
            L_IMPORTE_MEDIO.Text = _controlador.GetImporteMedio.ToString("n2");
            CalculaTotal();
        }

        private void CalculaTotal()
        {
            L_TOTAL.Text = "Total Movimiento Bs: "+_controlador.GetTotalMov.ToString("n2");
            L_RESTA.Text = "Resta Bs: " + _controlador.GetResta.ToString("n2");
            this.Refresh();
        }

        private void DT_FECHA_Leave(object sender, EventArgs e)
        {
            _controlador.setFechaMov(DT_FECHA.Value);
        }
        private void TB_MONTO_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_MONTO.Text);
            _controlador.SetMontoMov(_monto);
            CalculaTotal();
        }
        private void CHB_DIVISA_Leave(object sender, EventArgs e)
        {
            _controlador.setEsDivisa(CHB_DIVISA.Checked);
            CalculaTotal();
        }
        private void TB_FACTOR_CAMBIO_Leave(object sender, EventArgs e)
        {
            var _monto = decimal.Parse(TB_FACTOR_CAMBIO.Text);
            _controlador.setFactorCambio(_monto);
            CalculaTotal();
            DGV.Refresh();
        }
        private void TB_CONCEPTO_Leave(object sender, EventArgs e)
        {
            _controlador.setConcepto(TB_CONCEPTO.Text.Trim());
        }
        private void TB_DETALLE_Leave(object sender, EventArgs e)
        {
            _controlador.setDetalles(TB_DETALLE.Text.Trim());
        }

        private void CB_TIPO_MOV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            _controlador.setTipoMov("");
            if (CB_TIPO_MOV.SelectedIndex != -1) 
            {
                _controlador.setTipoMov(CB_TIPO_MOV.SelectedValue.ToString());
            }
        }

        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void CHB_DIVISA_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setEsDivisa(CHB_DIVISA.Checked);
            CalculaTotal();
        }


        private void CB_MEDIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }
            _controlador.setMedio("");
            if (CB_MEDIO.SelectedIndex != -1)
            {
                _controlador.setMedio(CB_MEDIO.SelectedValue.ToString());
            }
        }
        private void CHB_MEDIO_ES_DIVISA_Leave(object sender, EventArgs e)
        {
            _controlador.setMedioEsDivisa(CHB_MEDIO_ES_DIVISA.Checked);
            ActualizaMedio();
        }
        private void CHB_MEDIO_ES_DIVISA_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setMedioEsDivisa(CHB_MEDIO_ES_DIVISA.Checked);
            ActualizaMedio();
        }
        private void TB_MONTO_MEDIO_Leave(object sender, EventArgs e)
        {
            var _monto= decimal.Parse( TB_MONTO_MEDIO.Text);
            _controlador.setMontoMedio(_monto);
            ActualizaImporteMedio();
        }
        private void TB_CANT_MEDIO_Leave(object sender, EventArgs e)
        {
            var _cnt= int.Parse(TB_CANT_MEDIO.Text);
            _controlador.setCantMedio(_cnt);
            ActualizaImporteMedio();
        }

        private void ActualizaImporteMedio()
        {
            L_IMPORTE_MEDIO.Text = _controlador.GetImporteMedio.ToString("n2");
        }
        private void ActualizaMedio()
        {
            TB_MONTO_MEDIO.Enabled = true;
            TB_CANT_MEDIO.Enabled = true;
            if (_controlador.GetMedioEsDivisa)
            {
                _controlador.setMontoMedio(0m);
                TB_MONTO_MEDIO.Text = _controlador.GetMontoMedio.ToString();
                TB_MONTO_MEDIO.Enabled = false;
            }
            else 
            {
                _controlador.setCantMedio(0);
                TB_CANT_MEDIO.Text = _controlador.GetCantMedio.ToString();
                TB_CANT_MEDIO.Enabled = false;
            }
            L_IMPORTE_MEDIO.Text = _controlador.GetImporteMedio.ToString("n2");
        }

        private void BT_ACEPTAR_MEDIO_Click(object sender, EventArgs e)
        {
            AcepterMedio();
        }
        private void AcepterMedio()
        {
            _controlador.AceptarMedio();
            if (_controlador.AceptarMedioIsok) 
            {
                ActualizarMedio();
            }
            L_RESTA.Text = "Resta Bs: " + _controlador.GetResta.ToString("n2");
        }
        private void ActualizarMedio()
        {
            CB_MEDIO.DataSource = _controlador.GetMedio_Source;
            CB_MEDIO.SelectedValue = _controlador.GetMedio_Id;
            CHB_MEDIO_ES_DIVISA.Checked = _controlador.GetMedioEsDivisa;
            TB_MONTO_MEDIO.Text = _controlador.GetMontoMedio.ToString();
            TB_CANT_MEDIO.Text = _controlador.GetCantMedio.ToString();
            L_IMPORTE_MEDIO.Text = _controlador.GetImporteMedio.ToString("n2");
            TB_MONTO_MEDIO.Enabled = true;
            TB_CANT_MEDIO.Enabled = false;
        }

        private void BT_ELIMINAR_MEDIO_Click(object sender, EventArgs e)
        {
            EliminarMedio();
        }
        private void EliminarMedio()
        {
            _controlador.EliminarMedio();
            L_RESTA.Text = "Resta Bs: " + _controlador.GetResta.ToString("n2");
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOK) 
            {
                Salir();
            }
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void AbandonarFicha()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOK)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }

        private void AgregarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK || _controlador.ProcesarIsOK)
            {
                e.Cancel = false;
            }
        }
    }
}