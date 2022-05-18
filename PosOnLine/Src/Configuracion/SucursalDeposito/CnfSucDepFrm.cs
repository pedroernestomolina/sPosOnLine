using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Configuracion.SucursalDeposito
{

    public partial class CnfSucDepFrm : Form
    {

        Gestion _controlador;


        public CnfSucDepFrm()
        {
            InitializeComponent();
        }


        private void Inicializar() 
        {
            CB_DEPOSITO.DisplayMember = "Nombre";
            CB_DEPOSITO.ValueMember = "Id";
            CB_DEPOSITO.DataSource =  _controlador._bs_Deposito;

            CB_SUCURSAL.DisplayMember = "Nombre";
            CB_SUCURSAL.ValueMember = "Id";
            CB_SUCURSAL.DataSource = _controlador._bs_Sucursal;
        }


        private void ConfigurarFrm_Load(object sender, EventArgs e)
        {
            Inicializar();

            CB_SUCURSAL.SelectedValue = _controlador.AutoSucursal;
            CB_DEPOSITO.SelectedValue = _controlador.AutoDeposito;
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        public void GuardarCambios()
        {
            _controlador.Procesar();
            if (_controlador.ConfiguracionIsOk) 
            {
                Salir();
            }
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_SUCURSAL.SelectedIndex != -1) 
            {
                v = CB_SUCURSAL.SelectedValue.ToString();
            }
            _controlador.setSucursal(v);
            CB_DEPOSITO.SelectedIndex = -1;
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                v = CB_DEPOSITO.SelectedValue.ToString();
            }
            _controlador.setDeposito(v);
        }

        private void L_SUCURSAL_Click(object sender, EventArgs e)
        {
            CB_SUCURSAL.SelectedIndex = -1;
        }

        private void L_DEPOSITO_Click(object sender, EventArgs e)
        {
            CB_DEPOSITO.SelectedIndex = -1;
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

    }

}