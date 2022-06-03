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
            _contrtolador.LeerCodigo();
            if (_contrtolador.LeerCodigoIsOk)
            {
                L_MSG_ERROR.Text = _contrtolador.MsgError;
                PB_RESULT.Image = Properties.Resources.dedo_arriba_2;
            }
            else 
            {
                L_MSG_ERROR.Text = _contrtolador.MsgError;
                PB_RESULT.Image = Properties.Resources.dedo_abajo_2;
            }
            this.Refresh();
            Thread.Sleep(3000);

            _modoInicializar = true;
            TB_CODIGO.Text = "";
            PB_RESULT.Image = null;
            L_MSG_ERROR.Text = "";
            _modoInicializar = false;
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
            L_TITULO.Text = "VERIFICADOR DE DOCUMENTOS";
            L_TITULO_2.Text = "Version: " + Environment.NewLine + Application.ProductVersion;
            TB_CODIGO.Text = "";
            L_MSG_ERROR.Text = "";
            L_USUARIO.Text = _contrtolador.GetUsuario;
            //TB_CODIGO.Text = "000002-1520000596-01-0000000588-330,31-1502000014";
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

    }

}