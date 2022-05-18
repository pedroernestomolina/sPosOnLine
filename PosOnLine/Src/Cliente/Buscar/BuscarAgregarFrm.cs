using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Cliente.Buscar
{

    public partial class BuscarAgregarFrm : Form
    {


        private Gestion _controlador;


        public BuscarAgregarFrm()
        {
            InitializeComponent();
        }


        private void BuscarAgregarFrm_Load(object sender, EventArgs e)
        {
            InicializarFicha();
            IrFoco();
        }

        private void RB_CI_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setCiRifMetodoBusqueda();
            IrFoco();
        }

        private void IrFoco()
        {
            panel11.Focus();
            TB_BUSCAR.Enabled = true;
            TB_BUSCAR.Focus();
            TB_BUSCAR.SelectAll();
        }

        private void RB_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setNombreMetodoBusqueda();
            IrFoco();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            IrFoco();
            this.Close();
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
            if (_controlador.HabilitarBusqueda)
                _controlador.setBuscar(TB_BUSCAR.Text);
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            _controlador.Limpiar();
            InicializarFicha();
        }

        private void InicializarFicha()
        {
            TB_BUSCAR.Enabled = true;
            RB_CI.Enabled = true;
            RB_NOMBRE.Enabled = true;
            BT_ACEPTAR.Enabled = false;
            BT_EDITAR.Enabled = false;
            BT_GUARDAR.Enabled = false;
            BT_LIMPIAR.Enabled = true;

            TB_BUSCAR.Text = "";
            TB_CIRIF.Text = _controlador.ClienteGetCiRif;
            TB_DIRFISCAL.Text = _controlador.ClienteGetDirFiscal;
            TB_NOMBRE.Text = _controlador.ClienteGetRazonSocial;
            TB_TELEFONO.Text = _controlador.ClienteGetTelefono;
            switch (_controlador.MetodoBusqueda)
            {
                case Gestion.enumMetodoBusqueda.CiRif:
                    RB_CI.Checked = true;
                    break;
                case Gestion.enumMetodoBusqueda.Nombre:
                    RB_NOMBRE.Checked = true;
                    break;
            }
            TB_CIRIF.Enabled = _controlador.HabilitarFicha;
            TB_DIRFISCAL.Enabled = _controlador.HabilitarFicha;
            TB_NOMBRE.Enabled = _controlador.HabilitarFicha;
            TB_TELEFONO.Enabled = _controlador.HabilitarFicha;
            if (_controlador.ClienteSeleccionadoIsOk) 
            {
                BT_ACEPTAR.Enabled = true;
                BT_EDITAR.Enabled = true;
            }

            IrFoco();
        }

        public void ActualizarCliente()
        {
            //TB_BUSCAR.Enabled = false;
            //RB_CI.Enabled = false;
            //RB_NOMBRE.Enabled = false;
            //BT_GUARDAR.Enabled = false;
            //BT_LIMPIAR.Enabled = true;

            TB_CIRIF.Text = _controlador.Cliente.CiRif;
            TB_DIRFISCAL.Text = _controlador.Cliente.DireccionFiscal;
            TB_NOMBRE.Text = _controlador.Cliente.Nombre;
            TB_TELEFONO.Text = _controlador.Cliente.Telefono;
            TB_CIRIF.Enabled = false;
            TB_DIRFISCAL.Enabled = false;
            TB_NOMBRE.Enabled = false;
            TB_TELEFONO.Enabled = false;

            BT_ACEPTAR.Enabled = true;
            BT_GUARDAR.Enabled = false;
            BT_LIMPIAR.Enabled = true;
            BT_ACEPTAR.Focus();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            AceptarCliente();
        }

        private void AceptarCliente()
        {
            _controlador.AceptarCliente();
            IrFoco();
        }

        public void Cerrar()
        {
            Salir();
        }

        public void LimpiarCtr()
        {
            InicializarFicha();
        }

        public void AgregarClienteCtr()
        {
            TB_BUSCAR.Enabled = false;
            RB_CI.Enabled = false;
            RB_NOMBRE.Enabled = false;

            BT_ACEPTAR.Enabled = false;
            BT_GUARDAR.Enabled = true;
            BT_LIMPIAR.Enabled = true;

            TB_CIRIF.Text = TB_BUSCAR.Text;
            _controlador.setCiRif(TB_BUSCAR.Text);
            TB_DIRFISCAL.Text = "";
            TB_NOMBRE.Text = "";
            TB_TELEFONO.Text = "";
            TB_CIRIF.Enabled = false;
            TB_DIRFISCAL.Enabled = true;
            TB_NOMBRE.Enabled = true;
            TB_TELEFONO.Enabled = true;
            TB_NOMBRE.Focus();
            TB_NOMBRE.SelectAll();
        }

        private void TB_CIRIF_Leave(object sender, EventArgs e)
        {
            _controlador.setCiRif(TB_CIRIF.Text.Trim().ToUpper());
        }

        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.setNombre(TB_NOMBRE.Text.Trim().ToUpper());
        }

        private void TB_DIRFISCAL_Leave(object sender, EventArgs e)
        {
            _controlador.setDirFiscal(TB_DIRFISCAL.Text.Trim().ToUpper());
        }

        private void TB_TELEFONO_Leave(object sender, EventArgs e)
        {
            _controlador.setTelefono(TB_TELEFONO.Text.Trim().ToUpper());
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            _controlador.Guardar();
            if (_controlador.GuardarIsOk)
            {
                ActualizarCliente();
            }
            else 
            {
                TB_NOMBRE.Focus();
            }
        }

        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            EditarCliente();
        }
        private void EditarCliente()
        {
            _controlador.EditarCliente();
            if (_controlador.EditarIsOk) 
            {
                TB_CIRIF.Text = _controlador.Cliente.CiRif;
                TB_DIRFISCAL.Text = _controlador.Cliente.DireccionFiscal;
                TB_NOMBRE.Text = _controlador.Cliente.Nombre;
                TB_TELEFONO.Text = _controlador.Cliente.Telefono;
            }
        }

    }

}