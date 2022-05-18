using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Cliente.Editar
{

    public partial class EditarFrm : Form
    {

        private Gestion _controlador;


        public EditarFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;

        }

        private void EditarFrm_Load(object sender, EventArgs e)
        {
            L_CEDULA.Text= _controlador.GetCiRif;
            TB_NOMBRE.Text= _controlador.GetNombreRazonSocial;
            TB_DIRECCION.Text = _controlador.GetDireccion;
            TB_TELEFONO.Text = _controlador.GetTelefono;
            IrFoco();
        }

        private void IrFoco()
        {
            TB_NOMBRE.Focus();
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }
        private void GuardarCambios()
        {
            _controlador.GuardarCambios();
            if (_controlador.IsEditarOk)
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }

        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.setNombre(TB_NOMBRE.Text.Trim().ToUpper());
        }
        private void TB_DIRECCION_Leave(object sender, EventArgs e)
        {
            _controlador.setDireccion(TB_DIRECCION.Text.Trim().ToUpper());
        }
        private void TB_TELEFONO_Leave(object sender, EventArgs e)
        {
            _controlador.setTelefono(TB_TELEFONO.Text.Trim().ToUpper());
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void EditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.IsEditarOk || _controlador.AbandonarCambiosIsOk)
            {
                e.Cancel = false;
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void Abandonar()
        {
            _controlador.AbandonarCambios();
            if (_controlador.AbandonarCambiosIsOk) 
            {
                Salir();
            }
        }

    }

}