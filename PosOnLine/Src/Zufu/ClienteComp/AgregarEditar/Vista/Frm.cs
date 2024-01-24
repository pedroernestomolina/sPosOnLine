using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Zufu.ClienteComp.AgregarEditar.Vista
{
    public partial class Frm : Form
    {
        private IAgregarEditar _controlador;

        public Frm()
        {
            InitializeComponent();
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            IrFocoPrincipal();
            L_FICHA_ACCION.Text = _controlador.Get_AccionFicha;
            L_CI_RIF.Text = _controlador.DataFicha.Get_CiRif;
            TB_NOMBRE.Text = _controlador.DataFicha.Get_NombreRazonSocial;
            TB_DIR_FISCAL.Text = _controlador.DataFicha.Get_DirFiscal;
            TB_TELEFONO.Text = _controlador.DataFicha.Get_Telefono;
        }

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.Abandonar.OpcionIsOK || _controlador.Procesar.OpcionIsOK) 
            {
                e.Cancel = false;
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        public void setControlador(IAgregarEditar ctr)
        {
            _controlador = ctr;
        }


        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.DataFicha.setNombre(TB_NOMBRE.Text.Trim().ToUpper());
        }
        private void TB_DIR_FISCAL_Leave(object sender, EventArgs e)
        {
            _controlador.DataFicha.setDirFiscal(TB_DIR_FISCAL.Text.Trim());
        }
        private void TB_TELEFONO_Leave(object sender, EventArgs e)
        {
            _controlador.DataFicha.setTelefono(TB_TELEFONO.Text.Trim().ToUpper());
        }


        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            ProcesarFicha();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void IrFocoPrincipal()
        {
            TB_NOMBRE.Focus();
        }
        private void ProcesarFicha()
        {
            _controlador.ProcesarGuardar();
            if (_controlador.Procesar.OpcionIsOK) 
            {
                salir();
            }
        }
        private void AbandonarFicha()
        {
            _controlador.Abandonar.Opcion();
            if (_controlador.Abandonar.OpcionIsOK)
            {
                salir();
            }
        }
        private void salir()
        {
            this.Close();
        }
    }
}