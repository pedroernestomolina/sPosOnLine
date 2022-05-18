using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Consultor
{

    public partial class ConsultorFrm : Form
    {


        private Gestion _controlador;


        public ConsultorFrm() 
        {
            InitializeComponent();
        }

        private void ConsultorFrm_Load(object sender, EventArgs e)
        {
            Limpiar();
            TB_BUSCAR.Focus();
        }

        private void Limpiar()
        {
            L_INACTIVO.Visible = false;
            P_PRODUCTO.BackColor = Color.Navy;
            L_PRODUCTO.ForeColor = Color.White;

            L_PRODUCTO.Text = "Por Favor, Pase El Producto Por El Lector De Barra !!!";
            L_CODIGO.Text = "";
            L_CODIGO_BARRA.Text = "";
            L_PLU.Text = "";
            L_DEPARTAMENTO.Text = "";
            L_GRUPO.Text = "";
            L_MARCA.Text = "";
            L_MODELO.Text = "";
            L_REFERENCIA.Text = "";
            L_PASILLO.Text = "";
            L_TASA_IVA.Text = "";
            L_EX_DISPONIBLE.Text = "";
            L_EX_CANTIDAD.Text = "";
            //
            L_NETO_1.Text = "";
            L_FULL_1.Text = "";
            L_EMPAQUE_1.Text = "";
            L_DIVISA_1.Text = "";
            //
            L_NETO_2.Text = "";
            L_FULL_2.Text = "";
            L_EMPAQUE_2.Text = "";
            L_DIVISA_2.Text = "";
            //
            L_NETO_3.Text = "";
            L_FULL_3.Text = "";
            L_EMPAQUE_3.Text = "";
            L_DIVISA_3.Text = "";
        }

        private void TB_BUSCAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) 
            {
                _controlador.BuscarProducto(TB_BUSCAR.Text.Trim().ToUpper());
                if (_controlador.BusquedaIsOk)
                    ActualizarFicha();
                else
                    Limpiar();
                TB_BUSCAR.Text = "";
            }
        }

        private void ActualizarFicha()
        {
            Limpiar();
            L_PRODUCTO.Text = _controlador.NombrePrd;
            L_DEPARTAMENTO.Text = _controlador.Departamento;
            L_GRUPO.Text = _controlador.Grupo;
            L_MARCA.Text = _controlador.Marca;
            L_MODELO.Text = _controlador.Modelo;
            L_REFERENCIA.Text = _controlador.Referencia;
            L_PASILLO.Text = _controlador.Pasillo;
            L_CODIGO.Text = _controlador.CodigoPrd;
            L_PLU.Text = _controlador.CodigoPlu;
            L_CODIGO_BARRA.Text = _controlador.CodigoBarra;
            L_TASA_IVA.Text = _controlador.TasaIvaDescripcion;

            L_EX_DISPONIBLE.Text = _controlador.Existencia.HayDisponibilidad?"SI":"NO";
            L_EX_CANTIDAD.Text = _controlador.Existencia.Cantidad.ToString("n1");

            L_NETO_1.Text = _controlador.PrecioNeto_1.ToString("n2");
            L_FULL_1.Text = _controlador.PrecioFull_1.ToString("n2");
            L_EMPAQUE_1.Text = _controlador.EmpaqueContenido_1;
            L_DIVISA_1.Text = _controlador.PrecioDivisa_1.ToString("n2") + "$";

            L_NETO_2.Text = _controlador.PrecioNeto_2.ToString("n2");
            L_FULL_2.Text = _controlador.PrecioFull_2.ToString("n2");
            L_EMPAQUE_2.Text = _controlador.EmpaqueContenido_2;
            L_DIVISA_2.Text = _controlador.PrecioDivisa_2.ToString("n2") + "$";

            L_NETO_3.Text = _controlador.PrecioNeto_3.ToString("n2");
            L_FULL_3.Text = _controlador.PrecioFull_3.ToString("n2");
            L_EMPAQUE_3.Text = _controlador.EmpaqueContenido_3;
            L_DIVISA_3.Text = _controlador.PrecioDivisa_3.ToString("n2") + "$";

        }

        private void Salida() 
        {
            this.Close();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

    }

}