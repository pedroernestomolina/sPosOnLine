using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Consultor.ModoAdm
{
    public partial class Frm : Form
    {
        private IModoAdm _controlador;


        public Frm() 
        {
            InitializeComponent();
        }

        private void ConsultorFrm_Load(object sender, EventArgs e)
        {
            TB_BUSCAR.Focus();
            Limpiar();
        }


        public void setControlador(IModoAdm ctr)
        {
            _controlador = ctr;
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
            L_OFERTA_1.Text = "";
            //
            L_NETO_2.Text = "";
            L_FULL_2.Text = "";
            L_EMPAQUE_2.Text = "";
            L_DIVISA_2.Text = "";
            L_OFERTA_2.Text = "";
            //
            L_NETO_3.Text = "";
            L_FULL_3.Text = "";
            L_EMPAQUE_3.Text = "";
            L_DIVISA_3.Text = "";
            L_OFERTA_3.Text = "";
        }


        private void TB_BUSCAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) 
            {
                _controlador.setCadenaBuscar(TB_BUSCAR.Text.Trim().ToUpper());
                _controlador.Buscar();
                if (_controlador.BusquedaIsOk)
                    ActualizarFicha();
                else
                    Limpiar();
                TB_BUSCAR.Text = "";
            }
        }


        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }


        private void ActualizarFicha()
        {
            Limpiar();
            L_PRODUCTO.Text = _controlador.Prd.GetNombrePrd;
            L_DEPARTAMENTO.Text = _controlador.Prd.GetDepartamento;
            L_GRUPO.Text = _controlador.Prd.GetGrupo;
            L_MARCA.Text = _controlador.Prd.GetMarca;
            L_MODELO.Text = _controlador.Prd.GetModelo;
            L_REFERENCIA.Text = _controlador.Prd.GetReferencia;
            L_PASILLO.Text = _controlador.Prd.GetPasillo;
            L_CODIGO.Text = _controlador.Prd.GetCodigoPrd;
            L_PLU.Text = _controlador.Prd.GetCodigoPlu;
            L_CODIGO_BARRA.Text = _controlador.Prd.GetCodigoBarra;
            L_TASA_IVA.Text = _controlador.Prd.GetTasaIvaDescripcion;

            L_EX_DISPONIBLE.Text = _controlador.Prd.Existencia.GetDisponibilidad;
            L_EX_CANTIDAD.Text = _controlador.Prd.Existencia.GetCantidad;

            L_NETO_1.Text = _controlador.Prd.Vta1.GetPNetoMonLocal.ToString("n2");
            L_FULL_1.Text = _controlador.Prd.Vta1.GetPFullMonLocal.ToString("n2");
            L_EMPAQUE_1.Text = _controlador.Prd.Vta1.GetEmpCont.ToString();
            L_DIVISA_1.Text = _controlador.Prd.Vta1.GetPFullDivisa.ToString("n2") + "$";
            L_OFERTA_1.Text = _controlador.Prd.Vta1.GetOferta;

            L_NETO_2.Text = _controlador.Prd.Vta2.GetPNetoMonLocal.ToString("n2");
            L_FULL_2.Text = _controlador.Prd.Vta2.GetPFullMonLocal.ToString("n2");
            L_EMPAQUE_2.Text = _controlador.Prd.Vta2.GetEmpCont.ToString();
            L_DIVISA_2.Text = _controlador.Prd.Vta2.GetPFullDivisa.ToString("n2") + "$";
            L_OFERTA_2.Text = _controlador.Prd.Vta2.GetOferta;

            L_NETO_3.Text = _controlador.Prd.Vta3.GetPFullMonLocal.ToString("n2");
            L_FULL_3.Text = _controlador.Prd.Vta3.GetPFullMonLocal.ToString("n2");
            L_EMPAQUE_3.Text = _controlador.Prd.Vta3.GetEmpCont.ToString();
            L_DIVISA_3.Text = _controlador.Prd.Vta3.GetPFullDivisa.ToString("n2") + "$";
            L_OFERTA_3.Text = _controlador.Prd.Vta3.GetOferta;
        }
        private void Salida() 
        {
            this.Close();
        }
    }
}