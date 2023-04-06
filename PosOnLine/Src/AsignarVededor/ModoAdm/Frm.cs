using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.AsignarVededor.ModoAdm
{
    public partial class Frm : Form
    {
        IModoAdm _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializaCB();
        }

        private void InicializaCB()
        {
            CB_VENDEDOR.DisplayMember = "desc";
            CB_VENDEDOR.ValueMember = "id";
        }

        public void setControlador(IModoAdm ctr)
        {
            _controlador = ctr;
        }


        private bool _modoIni;
        private void Frm_Load(object sender, EventArgs e)
        {
            _modoIni = true;
            CB_VENDEDOR.DataSource = _controlador.Vendedor.GetSource;
            CB_VENDEDOR.SelectedValue = _controlador.Vendedor.GetId;
            _modoIni = false;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOK || _controlador.ProcesarIsOK)
            {
                e.Cancel = false;
            }
        }


        private void CB_VENDEDOR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoIni) { return; }
            _controlador.Vendedor.setId("");
            if (CB_VENDEDOR.SelectedIndex != -1) 
            {
                _controlador.Vendedor.setId(CB_VENDEDOR.SelectedValue.ToString());
            }
        }


        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Abandonar();
        }


        private void Aceptar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsOK)
            {
                salir();
            }
        }
        private void Abandonar()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOK)
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