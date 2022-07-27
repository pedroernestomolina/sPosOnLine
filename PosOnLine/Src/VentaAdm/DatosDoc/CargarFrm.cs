using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.VentaAdm.DatosDoc
{

    public partial class CargarFrm : Form
    {

        private ICarga _controlador;


        public CargarFrm()
        {
            InitializeComponent();
            InicialzarCombos();
        }

        private void InicialzarCombos()
        {
            CB_COBRADOR.ValueMember = "id";
            CB_COBRADOR.DisplayMember = "desc";
            CB_DEPOSITO.ValueMember = "id";
            CB_DEPOSITO.DisplayMember = "desc";
            CB_SUCURSAL.ValueMember = "id";
            CB_SUCURSAL.DisplayMember = "desc";
            CB_TRANSPORTE.ValueMember = "id";
            CB_TRANSPORTE.DisplayMember = "desc";
            CB_VENDEDOR.ValueMember = "id";
            CB_VENDEDOR.DisplayMember = "desc";
        }


        public void setControlador(ICarga ctr)
        {
            _controlador = ctr;
        }


        private bool _modoInicializa;
        private void BuscarFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            CB_COBRADOR.DataSource = _controlador.GetCobradorSource;
            CB_DEPOSITO.DataSource = _controlador.GetDepositoSource;
            CB_SUCURSAL.DataSource = _controlador.GetSucursalSource;
            CB_TRANSPORTE.DataSource = _controlador.GetTransporteSource;
            CB_VENDEDOR.DataSource = _controlador.GetVendedorSource;
            L_CLIENTE.Text = _controlador.GetClienteInfo;
            //
            CB_COBRADOR.SelectedValue = _controlador.GetCobradorId;
            CB_DEPOSITO.SelectedValue = _controlador.GetDepositoId;
            CB_SUCURSAL.SelectedValue = _controlador.GetSucursalId;
            CB_TRANSPORTE.SelectedValue = _controlador.GetTransporteId;
            CB_VENDEDOR.SelectedValue = _controlador.GetVendedorId;
            //
            BT_BUSCAR_CLIENTE.Enabled = _controlador.HabilitarBusquedaCliente;
            CB_SUCURSAL.Enabled = _controlador.HabilitarSucursal;
            CB_DEPOSITO.Enabled = _controlador.HabilitarDeposito;
            //
            _modoInicializa = false;
        }


        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setSucursal("");
            if (CB_SUCURSAL.SelectedIndex !=-1)
            {
                _controlador.setSucursal(CB_SUCURSAL.SelectedValue.ToString());
            }
        }
        private void CB_VENDEDOR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setVendedor("");
            if (CB_VENDEDOR.SelectedIndex != -1)
            {
                _controlador.setVendedor(CB_VENDEDOR.SelectedValue.ToString());
            }
        }
        private void CB_COBRADOR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setCobrador("");
            if (CB_COBRADOR.SelectedIndex != -1)
            {
                _controlador.setCobrador(CB_COBRADOR.SelectedValue.ToString());
            }
        }
        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setDeposito("");
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                _controlador.setDeposito(CB_DEPOSITO.SelectedValue.ToString());
            }
        }
        private void CB_TRANSPORTE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa)
                return;
            _controlador.setTransporte("");
            if (CB_TRANSPORTE.SelectedIndex != -1)
            {
                _controlador.setTransporte(CB_TRANSPORTE.SelectedValue.ToString());
            }
        }
        private void CargarFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_BUSCAR_CLIENTE_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }
        private void BuscarCliente()
        {
            _controlador.BuscarCliente();
            if (_controlador.BusquedaClienteIsOk)
            {
                L_CLIENTE.Text = _controlador.GetClienteInfo;
            }
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            AceptarDatos();
        }
        private void AceptarDatos()
        {
            _controlador.Aceptar();
            if (_controlador.AceptarIsOK)
            {
                Salir();
            }
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarCambios();
        }
        private void AbandonarCambios()
        {
            _controlador.Abandonar();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }
        private void CargarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.AceptarIsOK)
            {
                e.Cancel = false;
            }
        }
      
    }

}