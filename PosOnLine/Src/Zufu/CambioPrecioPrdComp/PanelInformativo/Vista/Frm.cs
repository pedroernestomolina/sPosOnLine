using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosOnLine.Src.Zufu.CambioPrecioPrdComp.PanelInformativo.Vista
{
    public partial class Frm : Form
    {
        private IVista _controlador;

        //
        public Frm()
        {
            InitializeComponent();
        }
        public void setControlador(Vista.IVista ctr)
        {
            _controlador = ctr;
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            L_COSTO_INF.Text = _controlador.DataInf.costoEmpVta.ToString("n2");
            L_MANEJADO_POR_DIVISA.Text = _controlador.DataInf.manejadoPorDivisa;
            L_TASA_DIVISA.Text = _controlador.DataInf.tasaDivisaSist.ToString("n2");
            L_TASA_IVA.Text = _controlador.DataInf.tasaIva;
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.BtSalir.OpcionIsOK) 
            {
                e.Cancel = false;
            }
        }

        //
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            _controlador.BtSalir.Opcion();
            if (_controlador.BtSalir.OpcionIsOK) 
            {
                salir();
            }
        }

        //
        private void salir()
        {
            this.Close();
        }
    }
}