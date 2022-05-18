using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Configuracion
{

    public partial class ConfigurarFrm : Form
    {


        private Gestion _controlador;


        public ConfigurarFrm()
        {
            InitializeComponent();
        }


        private void Inicializar() 
        {
            CB_DEPOSITO.DisplayMember = "Nombre";
            CB_DEPOSITO.ValueMember = "Id";
            CB_DEPOSITO.DataSource =  _controlador._bs_Deposito;

            CB_COBRADOR.DisplayMember = "Nombre";
            CB_COBRADOR.ValueMember = "Id";
            CB_COBRADOR.DataSource = _controlador._bs_Cobrador;

            CB_VENDEDOR.DisplayMember = "Nombre";
            CB_VENDEDOR.ValueMember = "Id";
            CB_VENDEDOR.DataSource = _controlador._bs_Vendedor;

            CB_TRANSPORTE.DisplayMember = "Nombre";
            CB_TRANSPORTE.ValueMember = "Auto";
            CB_TRANSPORTE.DataSource = _controlador._bs_Transporte;

            CB_TRANSPORTE.DisplayMember = "Nombre";
            CB_TRANSPORTE.ValueMember = "Id";
            CB_TRANSPORTE.DataSource = _controlador._bs_Transporte;

            CB_FACTURA.DisplayMember = "Serie";
            CB_FACTURA.ValueMember = "Auto";
            CB_FACTURA.DataSource = _controlador._bs_SerieFactura;

            CB_NOTA_CREDITO.DisplayMember = "Serie";
            CB_NOTA_CREDITO.ValueMember = "Auto";
            CB_NOTA_CREDITO.DataSource = _controlador._bs_SerieNotaCredito;

            CB_NOTA_DEBITO.DisplayMember = "Serie";
            CB_NOTA_DEBITO.ValueMember = "Auto";
            CB_NOTA_DEBITO.DataSource = _controlador._bs_SerieNotaDebito;

            CB_NOTA_ENTREGA.DisplayMember = "Serie";
            CB_NOTA_ENTREGA.ValueMember = "Auto";
            CB_NOTA_ENTREGA.DataSource = _controlador._bs_SerieNotaEntrega;

            CB_MEDIO_EFECTIVO.DisplayMember = "Nombre";
            CB_MEDIO_EFECTIVO.ValueMember = "Id";
            CB_MEDIO_EFECTIVO.DataSource = _controlador._bs_MedioEfectivo;

            CB_MEDIO_DIVISA.DisplayMember = "Nombre";
            CB_MEDIO_DIVISA.ValueMember = "Id";
            CB_MEDIO_DIVISA.DataSource = _controlador._bs_MedioDivisa;

            CB_MEDIO_ELECTRONICO.DisplayMember = "Nombre";
            CB_MEDIO_ELECTRONICO.ValueMember = "Id";
            CB_MEDIO_ELECTRONICO.DataSource = _controlador._bs_MedioElectronico;

            CB_MEDIO_OTRO.DisplayMember = "Nombre";
            CB_MEDIO_OTRO.ValueMember = "Id";
            CB_MEDIO_OTRO.DataSource = _controlador._bs_MedioOtro;

            CB_MOV_VENTA.DisplayMember = "Nombre";
            CB_MOV_VENTA.ValueMember = "Id";
            CB_MOV_VENTA.DataSource = _controlador._bs_MovVenta;

            CB_MOV_DEV_VENTA.DisplayMember = "Nombre";
            CB_MOV_DEV_VENTA.ValueMember = "Id";
            CB_MOV_DEV_VENTA.DataSource = _controlador._bs_MovDevVenta;

            CB_MOV_SALIDA.DisplayMember = "Nombre";
            CB_MOV_SALIDA.ValueMember = "Id";
            CB_MOV_SALIDA.DataSource = _controlador._bs_MovSalida;

            ND_LIMITE_INFERIOR.Text = "0,0";
            ND_LIMITE_SUPERIOR.Text = "0,0";
            CHB_REPESAJE.Checked = false;
            CHB_ACTIVAR_BUSQUEDA_POR_DESCRIPCION.Checked =false;

            CB_DOC_VENTA.DisplayMember = "Nombre";
            CB_DOC_VENTA.ValueMember = "AutoID";
            CB_DOC_VENTA.DataSource = _controlador._bs_DocVenta;

            CB_DOC_NT_CRED.DisplayMember = "Nombre";
            CB_DOC_NT_CRED.ValueMember = "AutoId";
            CB_DOC_NT_CRED.DataSource = _controlador._bs_DocNtCredito;

            CB_DOC_NT_ENTREGA.DisplayMember = "Nombre";
            CB_DOC_NT_ENTREGA.ValueMember = "AutoId";
            CB_DOC_NT_ENTREGA.DataSource = _controlador._bs_DocNtEntrega;

            CB_SUCURSAL.DisplayMember = "Nombre";
            CB_SUCURSAL.ValueMember = "Id";
            CB_SUCURSAL.DataSource = _controlador._bs_Sucursal;

            CB_MODO_PRECIO.DisplayMember = "Nombre";
            CB_MODO_PRECIO.ValueMember = "Id";
            CB_MODO_PRECIO.DataSource = _controlador._bs_ModoPrecio;

            CB_TARIFA_PRECIO.DisplayMember = "Nombre";
            CB_TARIFA_PRECIO.ValueMember = "Id";
            CB_TARIFA_PRECIO.DataSource = _controlador._bs_TarifaPrecio;

            CB_CLAVE.DisplayMember = "Nombre";
            CB_CLAVE.ValueMember = "Id";
            CB_CLAVE.DataSource = _controlador._bs_Clave;
        }


        private void ConfigurarFrm_Load(object sender, EventArgs e)
        {
            Inicializar();

            CB_MEDIO_EFECTIVO.SelectedValue = _controlador.AutoMedioEfectivo;
            CB_MEDIO_DIVISA.SelectedValue = _controlador.AutoMedioDivisa;
            CB_MEDIO_ELECTRONICO.SelectedValue = _controlador.AutoMedioElectronico;
            CB_MEDIO_OTRO.SelectedValue = _controlador.AutoMedioOtro;

            CB_FACTURA.SelectedValue = _controlador.AutoSerieFactura;
            CB_NOTA_CREDITO.SelectedValue = _controlador.AutoSerieNotaCredito;
            CB_NOTA_DEBITO.SelectedValue = _controlador.AutoSerieNotaDebito;
            CB_NOTA_ENTREGA.SelectedValue = _controlador.AutoSerieNotaEntrega;

            CB_SUCURSAL.SelectedValue = _controlador.AutoSucursal;
            CB_DEPOSITO.SelectedValue = _controlador.AutoDeposito;
            CB_TRANSPORTE.SelectedValue = _controlador.AutoTransporte;
            CB_COBRADOR.SelectedValue = _controlador.AutoCobrador;
            CB_VENDEDOR.SelectedValue = _controlador.AutoVendedor;
            CB_MOV_VENTA.SelectedValue = _controlador.AutoConceptoVenta;
            CB_MOV_DEV_VENTA.SelectedValue = _controlador.AutoConceptoNtCredito;
            CB_MOV_SALIDA.SelectedValue = _controlador.AutoConceptoNtEntrega;
            CB_DOC_VENTA.SelectedValue = _controlador.AutoDocVenta;
            CB_DOC_NT_CRED.SelectedValue = _controlador.AutoDocNtCredito;
            CB_DOC_NT_ENTREGA.SelectedValue = _controlador.AutoDocNtEntrega;

            L_SUCURSAL_CODIGO.Text = _controlador.CodigoSucursal;
            L_EQUIPO_ID.Text = _controlador.IdEquipo;
            CHB_ACTIVAR_BUSQUEDA_POR_DESCRIPCION.Checked = !_controlador.ActivarBusquedaPorDescripcion;
            CHB_VALIDAR_EXISTENCIA.Checked = !_controlador.ValidarExistencia;
            CHB_REPESAJE.Checked = !_controlador.ActivarRepesaje;
            CB_MODO_PRECIO.SelectedValue = _controlador.AutoModoPrecio;
            CB_CLAVE.SelectedValue = _controlador.AutoClavePos;
            CB_TARIFA_PRECIO.SelectedValue = _controlador.AutoTarifaPrecio;
            ND_LIMITE_INFERIOR.Text = _controlador.LimiteInferiorRepesaje.ToString("n3");
            ND_LIMITE_SUPERIOR.Text = _controlador.LimiteSuperiorRepesaje.ToString("n3");
            CHB_ACTIVAR_BUSQUEDA_POR_DESCRIPCION.Checked = _controlador.ActivarBusquedaPorDescripcion;
            CHB_VALIDAR_EXISTENCIA.Checked = _controlador.ValidarExistencia;
            CHB_REPESAJE.Checked = _controlador.ActivarRepesaje;

            tabControl1.TabPages.Remove(tabPage3);
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

        private void CB_MEDIO_EFECTIVO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_MEDIO_EFECTIVO.SelectedIndex != -1)
            {
                v = CB_MEDIO_EFECTIVO.SelectedValue.ToString();
            }
            _controlador.setMedioPagoEfectivo(v);
        }

        private void CB_MEDIO_DIVISA_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_MEDIO_DIVISA.SelectedIndex != -1)
            {
                v = CB_MEDIO_DIVISA.SelectedValue.ToString();
            }
            _controlador.setMedioPagoDivisa(v);
        }

        private void CB_MEDIO_ELECTRONICO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_MEDIO_ELECTRONICO.SelectedIndex != -1)
            {
                v = CB_MEDIO_ELECTRONICO.SelectedValue.ToString();
            }
            _controlador.setMedioPagoElectronico(v);
        }

        private void CB_MEDIO_OTRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_MEDIO_OTRO.SelectedIndex != -1)
            {
                v = CB_MEDIO_OTRO.SelectedValue.ToString();
            }
            _controlador.setMedioPagoOtro(v);
        }

        private void CB_COBRADOR_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_COBRADOR.SelectedIndex != -1)
            {
                v = CB_COBRADOR.SelectedValue.ToString();
            }
            _controlador.setCobrador(v);
        }

        private void CB_VENDEDOR_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_VENDEDOR.SelectedIndex != -1)
            {
                v = CB_VENDEDOR.SelectedValue.ToString();
            }
            _controlador.setVendedor(v);
        }

        private void CB_TRANSPORTE_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_TRANSPORTE.SelectedIndex != -1)
            {
                v = CB_TRANSPORTE.SelectedValue.ToString();
            }
            _controlador.setTransporte(v);
        }

        private void CB_MOV_VENTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_MOV_VENTA.SelectedIndex != -1)
            {
                v = CB_MOV_VENTA.SelectedValue.ToString();
            }
            _controlador.setConceptoVenta(v);
        }

        private void CB_MOV_DEV_VENTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_MOV_DEV_VENTA.SelectedIndex != -1)
            {
                v = CB_MOV_DEV_VENTA.SelectedValue.ToString();
            }
            _controlador.setConceptoNtCredito(v);
        }

        private void CB_MOV_SALIDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_MOV_SALIDA.SelectedIndex != -1)
            {
                v = CB_MOV_SALIDA.SelectedValue.ToString();
            }
            _controlador.setConceptoNtEntrega(v);
        }

        private void CB_FACTURA_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_FACTURA.SelectedIndex != -1)
            {
                v = CB_FACTURA.SelectedValue.ToString();
            }
            _controlador.setSerieFactura(v);
        }

        private void CB_NOTA_CREDITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_NOTA_CREDITO.SelectedIndex != -1)
            {
                v = CB_NOTA_CREDITO.SelectedValue.ToString();
            }
            _controlador.setSerieNtCredito(v);
        }

        private void CB_NOTA_DEBITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_NOTA_DEBITO.SelectedIndex != -1)
            {
                v = CB_NOTA_DEBITO.SelectedValue.ToString();
            }
            _controlador.setSerieNtDebito(v);
        }

        private void CB_NOTA_ENTREGA_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_NOTA_ENTREGA.SelectedIndex != -1)
            {
                v = CB_NOTA_ENTREGA.SelectedValue.ToString();
            }
            _controlador.setSerieNtEntrega(v);
        }

        private void CB_CLAVE_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_CLAVE.SelectedIndex != -1)
            {
                v = CB_CLAVE.SelectedValue.ToString();
            }
            _controlador.setClave(v);
        }

        private void TB_ID_EQUIPO_TextChanged(object sender, EventArgs e)
        {
            //_controlador.CnfNueva.IdEquipo = TB_ID_EQUIPO.Text;  
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
            L_SUCURSAL_CODIGO.Text = _controlador.CodigoSucursal;
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

        private void CB_DOC_VENTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_DOC_VENTA.SelectedIndex != -1)
            {
                v = CB_DOC_VENTA.SelectedValue.ToString();
            }
            _controlador.setDocVenta(v);
        }

        private void CB_DOC_NT_CRED_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_DOC_NT_CRED.SelectedIndex != -1)
            {
                v = CB_DOC_NT_CRED.SelectedValue.ToString();
            }
            _controlador.setDocNtCredito(v);
        }

        private void CB_DOC_NT_ENTREGA_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_DOC_NT_ENTREGA.SelectedIndex != -1)
            {
                v = CB_DOC_NT_ENTREGA.SelectedValue.ToString();
            }
            _controlador.setDocNtEntrega(v);
        }

        private void CHB_VALIDAR_EXISTENCIA_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setValidarExistencia(CHB_VALIDAR_EXISTENCIA.Checked);
        }

        private void CHB_ACTIVAR_BUSQUEDA_POR_DESCRIPCION_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setActivarBusquedaPorDescripcion(CHB_ACTIVAR_BUSQUEDA_POR_DESCRIPCION.Checked);
        }

        private void CHB_REPESAJE_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setActivarRepesaje(CHB_REPESAJE.Checked);
            ND_LIMITE_INFERIOR.Enabled = CHB_REPESAJE.Checked;
            ND_LIMITE_SUPERIOR.Enabled = CHB_REPESAJE.Checked;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            CB_MEDIO_EFECTIVO.SelectedIndex = -1;
        }

        private void L_MC_DIVISA_Click(object sender, EventArgs e)
        {
            CB_MEDIO_DIVISA.SelectedIndex = -1;
        }

        private void L_MC_ELECTRONICO_Click(object sender, EventArgs e)
        {
            CB_MEDIO_ELECTRONICO.SelectedIndex = -1;
        }

        private void L_MC_OTRO_Click(object sender, EventArgs e)
        {
            CB_MEDIO_OTRO.SelectedIndex = -1;
        }

        private void L_SERIE_FACTURA_Click(object sender, EventArgs e)
        {
            CB_FACTURA.SelectedIndex = -1;
        }

        private void L_SERIE_NT_CREDITO_Click(object sender, EventArgs e)
        {
            CB_NOTA_CREDITO.SelectedIndex = -1;
        }

        private void L_SERIE_NT_DEBITO_Click(object sender, EventArgs e)
        {
            CB_NOTA_DEBITO.SelectedIndex = -1;
        }

        private void L_SERIE_NT_ENTREGA_Click(object sender, EventArgs e)
        {
            CB_NOTA_ENTREGA.SelectedIndex = -1;
        }

        private void L_SUCURSAL_Click(object sender, EventArgs e)
        {
            CB_SUCURSAL.SelectedIndex = -1;
        }

        private void L_DEPOSITO_Click(object sender, EventArgs e)
        {
            CB_DEPOSITO.SelectedIndex = -1;
        }

        private void L_COBRADOR_Click(object sender, EventArgs e)
        {
            CB_COBRADOR.SelectedIndex = -1;
        }

        private void L_VENDEDOR_Click(object sender, EventArgs e)
        {
            CB_VENDEDOR.SelectedIndex = -1;
        }

        private void L_TRANSPORTE_Click(object sender, EventArgs e)
        {
            CB_TRANSPORTE.SelectedIndex = -1;
        }

        private void L_CONCEPTO_VENTA_Click(object sender, EventArgs e)
        {
            CB_MOV_VENTA.SelectedIndex = -1;
        }

        private void L_CONCEPTO_NT_CREDITO_Click(object sender, EventArgs e)
        {
            CB_MOV_DEV_VENTA.SelectedIndex = -1;
        }

        private void L_CONCEPTO_NT_ENTREGA_Click(object sender, EventArgs e)
        {
            CB_MOV_SALIDA.SelectedIndex = -1;
        }

        private void L_DOC_VENTA_Click(object sender, EventArgs e)
        {
            CB_DOC_VENTA.SelectedIndex = -1;
        }

        private void L_DOC_NT_CREDITO_Click(object sender, EventArgs e)
        {
            CB_DOC_NT_CRED.SelectedIndex = -1;
        }

        private void L_DOC_NT_ENTREGA_Click(object sender, EventArgs e)
        {
            CB_DOC_NT_ENTREGA.SelectedIndex = -1;
        }

        private void L_CLAVE_Click(object sender, EventArgs e)
        {
            CB_CLAVE.SelectedIndex = -1;
        }

        private void ND_LIMITE_SUPERIOR_Leave(object sender, EventArgs e)
        {
            var v= decimal.Parse(ND_LIMITE_SUPERIOR.Text);
            _controlador.setLimiteSuperior(v);
        }

        private void ND_LIMITE_INFERIOR_Leave(object sender, EventArgs e)
        {
            var v = decimal.Parse(ND_LIMITE_INFERIOR.Text);
            _controlador.setLimiteInferior(v);
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void CB_MODO_PRECIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_MODO_PRECIO.SelectedIndex != -1)
            {
                v = CB_MODO_PRECIO.SelectedValue.ToString();
            }
            _controlador.setModoPrecio(v);
            CB_TARIFA_PRECIO.Enabled = _controlador.Habilitar_Tarifa_Precio;
            CB_TARIFA_PRECIO.SelectedIndex = -1;
        }

        private void L_MODO_PRECIO_Click(object sender, EventArgs e)
        {
            CB_TARIFA_PRECIO.SelectedIndex = -1;
            CB_MODO_PRECIO.SelectedIndex = -1;
        }

        private void CB_TARIFA_PRECIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = "";
            if (CB_TARIFA_PRECIO.SelectedIndex != -1)
            {
                v = CB_TARIFA_PRECIO.SelectedValue.ToString();
            }
            _controlador.setTarifaPrecio(v);
        }

        private void L_TARIFA_PRECIO_Click(object sender, EventArgs e)
        {
            CB_TARIFA_PRECIO.SelectedIndex = -1;
        }

    }

}