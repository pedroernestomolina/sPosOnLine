using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Agencia.Agregar
{

    public partial class AgregarFrm : Form
    {


        private IAgregar _controlador;
        private bool _modoInicializar;


        public AgregarFrm()
        {
            InitializeComponent();
        }

        private void AgregarFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            TB_NOMBRE.Text = _controlador.GetAgencia;
            _modoInicializar = false;
            IrFoco();
        }

        public void setControlador(IAgregar ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void AbandonarFicha()
        {
            IrFoco();
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOk) 
            {
                Salir();
            }
        }
        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            ProcesarFicha();
        }
        private void ProcesarFicha()
        {
            IrFoco();
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarIsOk)
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
            if (_controlador.AbandonarIsOk || _controlador.ProcesarIsOk)
            {
                e.Cancel = false;
            }
        }
        private void IrFoco()
        {
            TB_NOMBRE.Focus();
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.setNombre(TB_NOMBRE.Text);
        }

    }

}