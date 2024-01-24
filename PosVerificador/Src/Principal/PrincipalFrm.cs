using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosVerificador.Src.Principal
{

    public partial class PrincipalFrm : Form
    {


        private IPrincipal _contrtolador;
        private bool _modoInicializar;


        public PrincipalFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }


        private void InicializarGrid()
        {
            var f = new Font("Serif", 18, FontStyle.Bold);
            var f1 = new Font("Serif", 18, FontStyle.Regular);
            var f2 = new Font("Serif", 18, FontStyle.Regular);

            DGV_1.AllowUserToAddRows = false;
            DGV_1.AllowUserToDeleteRows = false;
            DGV_1.AutoGenerateColumns = false;
            DGV_1.AllowUserToResizeRows = false;
            DGV_1.AllowUserToResizeColumns = false;
            DGV_1.AllowUserToOrderColumns = false;
            DGV_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_1.MultiSelect = false;
            DGV_1.ReadOnly = true;

            var c0 = new DataGridViewTextBoxColumn();
            c0.DataPropertyName = "PrdCod";
            c0.HeaderText = "Codigo";
            c0.Visible = true;
            c0.Width = 100;
            c0.HeaderCell.Style.Font = f;
            c0.DefaultCellStyle.Font = f2;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "PrdDesc";
            c1.HeaderText = "Descripcion";
            c1.Visible = true;
            c1.MinimumWidth = 140;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f2;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Cnt";
            c2.HeaderText = "Cant";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c2.DefaultCellStyle.Format = "n0";

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "EmpaqueCont";
            c3.HeaderText = "Empaque";
            c3.Visible = true;
            c3.Width = 160;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            //DGV_1.Columns.Add(c0);
            DGV_1.Columns.Add(c1);
            DGV_1.Columns.Add(c2);
            DGV_1.Columns.Add(c3);
        }


        public void setControlador(IPrincipal ctr)
        {
            _contrtolador = ctr;
        }

        private void BT_LEER_Click(object sender, EventArgs e)
        {
            IrFocoPrincipal();
            LeerCodigo();
        }
        private void LeerCodigo()
        {
            _modoInicializar = true;
            TB_CODIGO.Text = "";
            TL_OK.Visible = false;
            P_FONDO.BackgroundImage = null;
            L_DOCUMENTO.Text = "";
            L_CLIENTE.Text = "";
            P_DATA.Visible = false;
            _modoInicializar = false;
            L_MSG_ERROR.Text = "";
            this.Refresh();

            _contrtolador.LeerCodigo();
            if (_contrtolador.LeerCodigoIsOk)
            {
                TL_OK.Visible = true;
                P_FONDO.BackgroundImage = null;
                P_DATA.Visible = true;
                L_DOCUMENTO.Text = _contrtolador.GetDocumento;
                L_CLIENTE.Text = _contrtolador.GetCliente;
                Helpers.Sonido.SonidoOk();
                this.Refresh();
            }
            else 
            {
                L_MSG_ERROR.Text = _contrtolador.MsgError;
                TL_OK.Visible = false;
                P_FONDO.BackgroundImage = Properties.Resources.error_red;
                Helpers.Sonido.Error();
                this.Refresh();
            }
        }

        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;
            var _cod = TB_CODIGO.Text.Trim().Replace("'", "-");
            _contrtolador.setCodigo(_cod);
            if (!string.IsNullOrEmpty(_cod))
            {
                BT_LEER.PerformClick();
            }
        }
        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void PrincipalFrm_Load(object sender, EventArgs e)
        {
            IrFocoPrincipal();
            _modoInicializar = true;
            TL_OK.Visible = false;
            P_DATA.Visible = false;
            P_FONDO.BackgroundImage = null;
            L_MSG_ERROR.Text = "";
            DGV_1.DataSource = _contrtolador.Data;
            L_TITULO.Text = "VERIFICADOR DE DOCUMENTOS";
            L_TITULO_2.Text = "Version: " + Environment.NewLine + Application.ProductVersion;
            TB_CODIGO.Text = "";
            L_USUARIO.Text = _contrtolador.GetUsuario;
            L_DOCUMENTO.Text = "";
            L_CLIENTE.Text = "";
            //TB_CODIGO.Text = "000437-1520001447-01-0000001427-1.919,61-1502000020";
            _modoInicializar = false; ;
        }
        private void IrFocoPrincipal()
        {
            TB_CODIGO.Focus();
        }

        private void MenuArchivoSalida_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void AbandonarFicha()
        {
            _contrtolador.Abandonar();
            if (_contrtolador.IsAbandonarOk) 
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
        private void PrincipalFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_contrtolador.IsAbandonarOk) 
            {
                e.Cancel = false;
            }
        }

        private void MenuReporteDocumetosVerificados_Click(object sender, EventArgs e)
        {
            ReporteDocumentosVerificados();
        }

        private void ReporteDocumentosVerificados()
        {
            _contrtolador.ReporteDocumentosVerificados();
        }

        private void TSM_CONFIGURACION_DAR_ALTA_TODAS_Click(object sender, EventArgs e)
        {
            DarAltaTodosDocumento();
        }
        private void DarAltaTodosDocumento()
        {
            _contrtolador.DarAltaTodosDocumento();
        }
    }
}