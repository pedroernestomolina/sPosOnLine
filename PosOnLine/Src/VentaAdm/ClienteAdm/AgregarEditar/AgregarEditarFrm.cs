using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.VentaAdm.ClienteAdm.AgregarEditar
{

    public partial class AgregarEditarFrm : Form
    {

        private Gestion _controlador;


        public AgregarEditarFrm()
        {
            InitializeComponent();
            InicializarCombos();
        }

        private void InicializarCombos()
        {
            CB_VENDEDOR.ValueMember = "id";
            CB_VENDEDOR.DisplayMember = "desc";

            CB_COBRADOR.ValueMember = "id";
            CB_COBRADOR.DisplayMember = "desc";

            CB_GRUPO.ValueMember = "id";
            CB_GRUPO.DisplayMember = "desc";

            CB_ZONA.ValueMember = "id";
            CB_ZONA.DisplayMember = "desc";

            CB_NIVEL.ValueMember = "id";
            CB_NIVEL.DisplayMember = "desc";

            CB_CATEGORIA.ValueMember = "id";
            CB_CATEGORIA.DisplayMember = "desc";

            CB_TARIFA.ValueMember = "id";
            CB_TARIFA.DisplayMember = "desc";

            CB_ESTADO.ValueMember = "id";
            CB_ESTADO.DisplayMember = "desc";
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        bool isModoInicializar;
        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            L_TITULO.Text = _controlador.TituloFicha;

            TB_DIAS_CREDITO.Enabled = false;
            TB_LIMITE_CREDITO.Enabled = false;
            TB_LIMITE_DOC.Enabled = false;

            isModoInicializar = true;
            CB_VENDEDOR.DataSource = _controlador.SourceVendedor;
            CB_COBRADOR.DataSource = _controlador.SourceCobrador;
            CB_GRUPO.DataSource = _controlador.SourceGrupo;
            CB_ZONA.DataSource = _controlador.SourceZona;
            CB_CATEGORIA.DataSource = _controlador.SourceCategoria;
            CB_NIVEL.DataSource = _controlador.SourceNivel;
            CB_TARIFA.DataSource = _controlador.SourceTarifa;
            CB_ESTADO.DataSource = _controlador.SourceEstado;
            CHB_CREDITO.CheckState = CheckState.Indeterminate ;

            CHB_CREDITO.CheckState = CheckState.Unchecked;
            if (_controlador.CreditoIsActivo)
            {
                CHB_CREDITO.CheckState = CheckState.Checked;
                TB_DIAS_CREDITO.Enabled = true;
                TB_LIMITE_CREDITO.Enabled = true;
                TB_LIMITE_DOC.Enabled = true;
            }

            isModoInicializar = false;

            TB_CIRIF.Text = _controlador.CiRif;
            TB_CODIGO.Text = _controlador.Codigo;
            TB_RAZON_SOCIAL.Text = _controlador.RazonSocial;
            TB_DIR_FISCAL.Text = _controlador.DirFiscal;
            TB_DIR_DESPACHO.Text = _controlador.DirDespacho;
            TB_PAIS.Text = _controlador.Pais;
            TB_COD_POSTAL.Text = _controlador.CodPostal;
            TB_CONTACTO.Text = _controlador.Contacto;
            TB_TEL_1.Text = _controlador.Telefono1;
            TB_TEL_2.Text = _controlador.Telefono2;
            TB_CEL.Text = _controlador.Celular;
            TB_FAX.Text = _controlador.Fax;
            TB_EMAIL.Text = _controlador.Email;
            TB_WEB_SITE.Text = _controlador.WebSite;

            TB_DSCTO.Text = _controlador.Dscto.ToString("n2");
            TB_CARGO.Text = _controlador.Cargo.ToString("n2");
            TB_DIAS_CREDITO.Text = _controlador.DiasCredito.ToString("n0");
            TB_LIMITE_DOC.Text = _controlador.LimiteDoc.ToString("n0");
            TB_LIMITE_CREDITO.Text = _controlador.LimiteCredito.ToString();

            if (_controlador.IsModoAgregar)
            {
                CB_GRUPO.SelectedIndex = -1;
                CB_ZONA.SelectedIndex = -1;
                CB_CATEGORIA.SelectedIndex = -1;
                CB_NIVEL.SelectedIndex = -1;
                CB_TARIFA.SelectedIndex = -1;
                CB_ESTADO.SelectedIndex = -1;
                CB_VENDEDOR.SelectedIndex = -1;
                CB_COBRADOR.SelectedIndex = -1;
            }
            else
            {
                if (_controlador.IdGrupo != "")
                    CB_GRUPO.SelectedValue = _controlador.IdGrupo;
                if (_controlador.IdZona != "")
                    CB_ZONA.SelectedValue = _controlador.IdZona;
                if (_controlador.IdCategoria != "")
                    CB_CATEGORIA.SelectedValue = _controlador.IdCategoria;
                if (_controlador.IdNivel != "")
                    CB_NIVEL.SelectedValue = _controlador.IdNivel;
                if (_controlador.IdTarifa != "")
                    CB_TARIFA.SelectedValue = _controlador.IdTarifa;
                if (_controlador.IdEstado != "")
                    CB_ESTADO.SelectedValue = _controlador.IdEstado;
                if (_controlador.IdVendedor != "")
                    CB_VENDEDOR.SelectedValue = _controlador.IdVendedor;
                if (_controlador.IdCobrador != "")
                    CB_COBRADOR.SelectedValue = _controlador.IdCobrador;
            }
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ProcesarIsoK)
            {
                this.Close();
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            _controlador.Salir();
            if (_controlador.ProcesarIsoK)
            {
                this.Close();
            }
        }

        private void AgregarEditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_controlador.ProcesarIsoK || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        public void Cerrar()
        {
            this.Close();
        }

        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isModoInicializar)
                return;
            _controlador.setGrupo("");
            if (CB_GRUPO.SelectedIndex != -1)
            {
                _controlador.setGrupo(CB_GRUPO.SelectedValue.ToString());
            }
        }

        private void CB_CATEGORIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isModoInicializar)
                return;

            _controlador.setCategoria("");
            if (CB_CATEGORIA.SelectedIndex != -1)
            {
                _controlador.setCategoria(CB_CATEGORIA.SelectedValue.ToString());
            }

            CHB_CREDITO.Enabled = _controlador.CategoriaIsAdministrativo;
            if (!_controlador.CategoriaIsAdministrativo)
            {
                CHB_CREDITO.Checked = false;
            }
        }

        private void CB_NIVEL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isModoInicializar)
                return;
            _controlador.setNivel("");
            if (CB_NIVEL.SelectedIndex != -1)
            {
                _controlador.setNivel(CB_NIVEL.SelectedValue.ToString());
            }
        }

        private void CB_ESTADO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isModoInicializar)
                return;
            _controlador.setEstado("");
            if (CB_ESTADO.SelectedIndex != -1)
            {
                _controlador.setEstado(CB_ESTADO.SelectedValue.ToString());
            }
        }

        private void CB_ZONA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isModoInicializar)
                return;
            _controlador.setZona("");
            if (CB_ZONA.SelectedIndex != -1)
            {
                _controlador.setZona(CB_ZONA.SelectedValue.ToString());
            }
        }

        private void CB_VENDEDOR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isModoInicializar)
                return;
            _controlador.setVendedor("");
            if (CB_VENDEDOR.SelectedIndex != -1)
            {
                _controlador.setVendedor(CB_VENDEDOR.SelectedValue.ToString());
            }
        }

        private void CB_TARIFA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isModoInicializar)
                return;
            _controlador.setTarifa("");
            if (CB_TARIFA.SelectedIndex != -1)
            {
                _controlador.setTarifa(CB_TARIFA.SelectedValue.ToString());
            }
        }

        private void CB_COBRADOR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isModoInicializar)
                return;
            _controlador.setCobrador("");
            if (CB_COBRADOR.SelectedIndex != -1)
            {
                _controlador.setCobrador(CB_COBRADOR.SelectedValue.ToString());
            }
        }

        private void Ctrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_CIRIF_Leave(object sender, EventArgs e)
        {
            _controlador.setCiRif(TB_CIRIF.Text.Trim().ToUpper());
        }

        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            _controlador.setCodigo(TB_CODIGO.Text.Trim().ToUpper());
        }

        private void TB_RAZON_SOCIAL_Leave(object sender, EventArgs e)
        {
            _controlador.setRazonSocial(TB_RAZON_SOCIAL.Text.Trim().ToUpper());
        }

        private void TB_DIR_FISCAL_Leave(object sender, EventArgs e)
        {
            _controlador.setDirFiscal(TB_DIR_FISCAL.Text.Trim().ToUpper());
        }

        private void TB_DIR_DESPACHO_Leave(object sender, EventArgs e)
        {
            _controlador.setDirDespacho(TB_DIR_DESPACHO.Text.Trim().ToUpper());
        }

        private void TB_PAIS_Leave(object sender, EventArgs e)
        {
            _controlador.setPais(TB_PAIS.Text.Trim().ToUpper());
        }

        private void TB_CONTACTO_Leave(object sender, EventArgs e)
        {
            _controlador.setContacto(TB_CONTACTO.Text.Trim().ToUpper());
        }

        private void TB_TEL_1_Leave(object sender, EventArgs e)
        {
            _controlador.setTelefono1(TB_TEL_1.Text.Trim().ToUpper());
        }

        private void TB_TEL_2_Leave(object sender, EventArgs e)
        {
            _controlador.setTelefono2(TB_TEL_2.Text.Trim().ToUpper());
        }

        private void TB_EMAIL_Leave(object sender, EventArgs e)
        {
            _controlador.setEmail(TB_EMAIL.Text.Trim().ToUpper());
        }

        private void TB_CEL_Leave(object sender, EventArgs e)
        {
            _controlador.setCelular(TB_CEL.Text.Trim().ToUpper());
        }

        private void TB_FAX_Leave(object sender, EventArgs e)
        {
            _controlador.setFax(TB_FAX.Text.Trim().ToUpper());
        }

        private void TB_WEB_SITE_Leave(object sender, EventArgs e)
        {
            _controlador.setWebSite(TB_WEB_SITE.Text.Trim().ToUpper());
        }

        private void TB_COD_POSTAL_Leave(object sender, EventArgs e)
        {
            _controlador.setCodPostal(TB_COD_POSTAL.Text.Trim().ToUpper());
        }

        private void CHB_CREDITO_CheckedChanged(object sender, EventArgs e)
        {
            if (isModoInicializar)
                return;
            _controlador.setCredito(CHB_CREDITO.Checked);
            TB_DIAS_CREDITO.Enabled = _controlador.CreditoIsActivo;
            TB_LIMITE_CREDITO.Enabled = _controlador.CreditoIsActivo;
            TB_LIMITE_DOC.Enabled = _controlador.CreditoIsActivo;
        }

        private void TB_DSCTO_Leave(object sender, EventArgs e)
        {
            _controlador.setDscto(decimal.Parse(TB_DSCTO.Text));

        }
        private void TB_CARGO_Leave(object sender, EventArgs e)
        {
            _controlador.setCargo(decimal.Parse(TB_CARGO.Text));
        }

        private void TB_DIAS_CREDITO_Leave(object sender, EventArgs e)
        {
            _controlador.setDiasCredito(int.Parse(TB_DIAS_CREDITO.Text));
        }

        private void TB_LIMITE_CREDITO_Leave(object sender, EventArgs e)
        {
            _controlador.setLimiteCredito(decimal.Parse(TB_LIMITE_CREDITO.Text));
        }

        private void TB_LIMITE_DOC_Leave(object sender, EventArgs e)
        {
            _controlador.setLimiteDoc(int.Parse(TB_LIMITE_DOC.Text));
        }

    }

}