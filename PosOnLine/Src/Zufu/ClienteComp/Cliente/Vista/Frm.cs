using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Zufu.ClienteComp.Cliente.Vista
{
    public partial class Frm : Form
    {
        private IVista _controlador;
        private bool _modoInicializar;


        private void InicializarCB()
        {
            CB_BUSQUEDA.DisplayMember = "desc";
            CB_BUSQUEDA.ValueMember = "id";
        }
        public Frm()
        {
            InitializeComponent();
            InicializarCB();
        }
        public void setControlador(IVista ctr)
        {
            _controlador = ctr;
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CB_BUSQUEDA.DataSource = _controlador.Busqueda.TipoBusqueda.GetSource;
            CB_BUSQUEDA.SelectedValue = _controlador.Busqueda.TipoBusqueda.GetId;
            irFocoPrincipal();
            actualizarCliente();
            _modoInicializar = false;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.BtSalir.OpcionIsOK || _controlador.BtAbandonar.OpcionIsOK || _controlador.BtAceptar.OpcionIsOK) 
            {
                e.Cancel = false;
            }
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void TB_BUSCAR_Leave(object sender, EventArgs e)
        {
            _controlador.Busqueda.setBuscar(TB_BUSCAR.Text);
        }
        private void CB_BUSQUEDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.Busqueda.TipoBusqueda.setFichaById("");
            if (CB_BUSQUEDA.SelectedIndex != -1)
            {
                _controlador.Busqueda.TipoBusqueda.setFichaById(CB_BUSQUEDA.SelectedValue.ToString());
            }
            irFocoPrincipal();
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            irFocoPrincipal();
            _controlador.Buscar();
            actualizarCliente();
        }
        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            AceptarCliente();
            if (_controlador.BtAceptar.OpcionIsOK)
            {
                salir();
            }
        }
        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            EditarCliente();
        }
        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            irFocoPrincipal();
            CerrarFicha();
        }


        private void AceptarCliente()
        {
            irFocoPrincipal();
            _controlador.AceptarCliente();
        }
        private void EditarCliente()
        {
            _controlador.EditarCliente();
            actualizarCliente();
        }
        private void Limpiar()
        {
            _controlador.Limpiar();
            actualizarCliente();
        }
        private void CerrarFicha()
        {
            if (_controlador.IsClienteOk)
            {
                _controlador.AbandonarFicha();
                if (_controlador.BtAbandonar.OpcionIsOK)
                {
                    salir();
                }
            }
            else 
            {
                _controlador.CerrarSinSeleccionarFicha();
                if (_controlador.BtSalir.OpcionIsOK)
                {
                    salir();
                }
            }
        }
        private void salir()
        {
            irFocoPrincipal();
            this.Close();
        }
        private void irFocoPrincipal()
        {
            TB_BUSCAR.Focus();
        }
        private void actualizarCliente()
        {
            TB_BUSCAR.Text = _controlador.Busqueda.Get_TextoBuscar;
            L_CI_RIF.Text = _controlador.ClienteCiRif;
            L_NOMBRE.Text = _controlador.ClienteNombreRazonSocial;
            L_DIR_FISCAL.Text = _controlador.ClienteDirFiscal;
            L_TELEFONO.Text = _controlador.ClienteTelefono;
            if (_controlador.Cliente !=null)
            {
                P_BUSQ_CLIENTE.Enabled = false;
                BT_ACEPTAR.Enabled = true;
                BT_EDITAR.Enabled = true;
                BT_LIMPIAR.Enabled = true;
                BT_ACEPTAR.Focus();
            }
            else
            {
                P_BUSQ_CLIENTE.Enabled = true;
                TB_BUSCAR.Text = "";
                BT_ACEPTAR.Enabled = false;
                BT_EDITAR.Enabled = false;
                BT_LIMPIAR.Enabled = true;
                irFocoPrincipal();
            }
        }
    }
}