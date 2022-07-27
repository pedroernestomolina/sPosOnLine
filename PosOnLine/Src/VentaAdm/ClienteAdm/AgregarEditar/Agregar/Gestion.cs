using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.VentaAdm.ClienteAdm.AgregarEditar.Agregar
{
    
    public class Gestion: IGestion
    {

        public class general 
        {

            public string id { get; set; }
            public string desc { get; set; }


            public general()
            {
                id = "";
                desc = "";
            }

            public general(string id, string desc):
                this()
            {
                this.id = id;
                this.desc= desc;
            }
        }


        private List<general> _lGrupo;
        private List<general> _lZona;
        private List<general> _lCategoria;
        private List<general> _lNivel;
        private List<general> _lTarifa;
        private List<general> _lVendedor;
        private List<general> _lCobrador;
        private List<general> _lEstado;
        private BindingSource _bsCategoria;
        private BindingSource _bsNivel ;
        private BindingSource _bsTarifa ;
        private BindingSource _bsGrupo;
        private BindingSource _bsZona;
        private BindingSource _bsVendedor;
        private BindingSource _bsCobrador;
        private BindingSource _bsEstado;
        //
        private data _data;
        private Boolean _procesarIsOk;
        private Boolean _abandonarIsOk; 
        private string _autoClienteAgregado;


        public string TituloFicha
        {
            get { return "Agregar Ficha"; }
        }

        public BindingSource SourceCategoria
        {
            get { return _bsCategoria; }
        }

        public BindingSource SourceNivel
        {
            get { return _bsNivel; }
        }

        public BindingSource SourceTarifa
        {
            get { return _bsTarifa; }
        }

        public BindingSource SourceGrupo
        {
            get { return _bsGrupo; }
        }

        public BindingSource SourceZona
        {
            get { return _bsZona; }
        }

        public BindingSource SourceVendedor
        {
            get { return _bsVendedor; }
        }

        public BindingSource SourceCobrador
        {
            get { return _bsCobrador; }
        }

        public BindingSource SourceEstado
        {
            get { return _bsEstado; }
        }

        public bool ProcesarIsoK
        {
            get { return _procesarIsOk; }
        }

        public bool AbandonarIsOk
        {
            get { return _abandonarIsOk; }
        }

        public string IdGrupo
        {
            get 
            {
                var rt =""; 
                if (_data.Grupo !=null)
                    rt = _data.Grupo.id;
                return rt;
            }
        }

        public string IdZona
        {
            get 
            {
                var rt =""; 
                if (_data.Zona !=null)
                    rt = _data.Zona.id;
                return rt;
            }
        }

        public string IdCategoria
        {
            get 
            {
                var rt =""; 
                if (_data.Categoria !=null)
                    rt = _data.Categoria.id;
                return rt;
            }
        }

        public string IdNivel
        {
            get 
            {
                var rt =""; 
                if (_data.Nivel !=null)
                    rt = _data.Nivel.id;
                return rt;
            }
        }

        public string IdEstado
        {
            get 
            {
                var rt =""; 
                if (_data.Estado !=null)
                    rt = _data.Estado.id;
                return rt;
            }
        }

        public string IdVendedor
        {
            get 
            {
                var rt =""; 
                if (_data.Vendedor !=null)
                    rt = _data.Vendedor.id;
                return rt;
            }
        }

        public string IdCobrador
        {
            get 
            {
                var rt =""; 
                if (_data.Cobrador !=null)
                    rt = _data.Cobrador.id;
                return rt;
            }
        }

        public string IdTarifa
        {
            get 
            {
                var rt =""; 
                if (_data.Tarifa !=null)
                    rt = _data.Tarifa.id;
                return rt;
            }
        }

        public string CiRif
        {
            get { return _data.CiRif; }
        }

        public string Codigo
        {
            get { return _data.Codigo; }
        }

        public string RazonSocial
        {
            get { return _data.RazonSocial; }
        }

        public string DirFiscal
        {
            get { return _data.DirFiscal; }
        }

        public string DirDespacho
        {
            get { return _data.DirDespacho; }
        }

        public string Pais
        {
            get { return _data.Pais; }
        }

        public string CodPostal
        {
            get { return _data.CodPostal; }
        }

        public string Contacto
        {
            get { return _data.Contacto; }
        }

        public string Telefono1
        {
            get { return _data.Telefono_1; }
        }

        public string Telefono2
        {
            get { return _data.Telefono_2; }
        }

        public string Fax
        {
            get { return _data.Fax; }
        }

        public string WebSite
        {
            get { return _data.WebSite; }
        }

        public string Email
        {
            get { return _data.Email; }
        }

        public string Celular
        {
            get { return _data.Celular; }
        }

        public bool CreditoIsActivo
        {
            get { return _data.IsCredito; }
        }

        public bool CategoriaIsAdministrativo
        {
            get { return IdCategoria == "01"; }
        }

        public decimal Dscto
        {
            get { return _data.Dscto; }
        }

        public decimal Cargo
        {
            get { return _data.Cargo; }
        }

        public int DiasCredito
        {
            get { return _data.DiasCredito; }
        }

        public int LimiteDoc
        {
            get { return _data.LimiteDoc; }
        }

        public decimal LimiteCredito
        {
            get { return _data.LimiteCredito; }
        }

        public string AutoClienteAgregado
        {
            get { return _autoClienteAgregado; }
        }


        public Gestion()
        {
            _data = new data();
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _autoClienteAgregado = "";
            //
            _lCategoria = new List<general>();
            _lNivel = new List<general>();
            _lTarifa = new List<general>();
            _lGrupo = new List<general>();
            _lZona = new List<general>();
            _lVendedor = new List<general>();
            _lCobrador = new List<general>();
            _lEstado= new List<general>();
            //
            _bsCategoria = new BindingSource();
            _bsNivel = new BindingSource();
            _bsTarifa = new BindingSource();
            _bsGrupo = new BindingSource();
            _bsZona = new BindingSource();
            _bsVendedor = new BindingSource();
            _bsCobrador = new BindingSource();
            _bsEstado = new BindingSource();
            //
            _bsCategoria.DataSource = _lCategoria;
            _bsNivel.DataSource = _lNivel;
            _bsTarifa.DataSource = _lTarifa;
            _bsGrupo.DataSource = _lGrupo;
            _bsZona.DataSource = _lZona;
            _bsVendedor.DataSource = _lVendedor;
            _bsCobrador.DataSource = _lCobrador;
            _bsEstado.DataSource = _lEstado;
        }


        public bool CargarData()
        {
            var rt = true;

            //var filtro = new OOB.Maestro.Grupo.Lista.Filtro();
            //var r01 = Sistema.MyData.ClienteGrupo_GetLista(filtro);
            //if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return false;
            //}
            //_lGrupo.Clear();
            //foreach (var it in r01.ListaD.OrderBy(o=>o.nombre).ToList())
            //{ 
            //    _lGrupo.Add(new general(it.auto, it.nombre));
            //}
            //_bsGrupo.CurrencyManager.Refresh();

            //var filtro2 = new OOB.Maestro.Zona.Lista.Filtro();
            //var r02 = Sistema.MyData.ClienteZona_GetLista(filtro2);
            //if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r02.Mensaje);
            //    return false;
            //}
            //_lZona.Clear();
            //foreach (var it in r02.ListaD.OrderBy(o=>o.nombre).ToList())
            //{ 
            //    _lZona.Add(new general(it.auto, it.nombre));
            //}
            //_bsZona.CurrencyManager.Refresh();

            //var r03 = Sistema.MyData.Sistema_Vendedor_GetLista();
            //if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r03.Mensaje);
            //    return false;
            //}
            //_lVendedor.Clear();
            //foreach (var it in r03.ListaD.OrderBy(o => o.nombre).ToList())
            //{
            //    _lVendedor.Add(new general(it.id, it.nombre));
            //}
            //_bsVendedor.CurrencyManager.Refresh();

            //var r04 = Sistema.MyData.Sistema_Cobrador_GetLista();
            //if (r04.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r04.Mensaje);
            //    return false;
            //}
            //_lCobrador.Clear();
            //foreach (var it in r04.ListaD.OrderBy(o => o.nombre).ToList())
            //{
            //    _lCobrador.Add(new general(it.id, it.nombre));
            //}
            //_bsCobrador.CurrencyManager.Refresh();

            //var r05 = Sistema.MyData.Sistema_Estado_GetLista();
            //if (r05.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r05.Mensaje);
            //    return false;
            //}
            //_lEstado.Clear();
            //foreach (var it in r05.ListaD.OrderBy(o => o.nombre).ToList())
            //{
            //    _lEstado.Add(new general(it.auto, it.nombre));
            //}
            //_bsEstado.CurrencyManager.Refresh();

            //_lCategoria.Clear();
            //_lCategoria.Add(new general("01", "Administrativo"));
            //_lCategoria.Add(new general("02", "Eventual"));
            //_bsCategoria.CurrencyManager.Refresh();

            //_lNivel.Clear();
            //_lNivel.Add(new general("00", "Sin Definir"));
            //_lNivel.Add(new general("01", "Tipo A"));
            //_lNivel.Add(new general("02", "Tipo B"));
            //_lNivel.Add(new general("03", "Tipo C"));
            //_bsNivel.CurrencyManager.Refresh();

            //_lTarifa.Clear();
            //_lTarifa.Add(new general("00", "Sin Definir"));
            //_lTarifa.Add(new general("01", "Precio 1"));
            //_lTarifa.Add(new general("02", "Precio 2"));
            //_lTarifa.Add(new general("03", "Precio 3"));
            //_lTarifa.Add(new general("04", "Precio 4"));
            //_lTarifa.Add(new general("05", "Precio 5"));
            //_bsTarifa.CurrencyManager.Refresh();

            return rt;
        }

        public void Inicializa()
        {
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _autoClienteAgregado = "";
            _data.Inicializa();
        }

        public void setGrupo(string p)
        {
            _data.setGrupo(_lGrupo.FirstOrDefault(f => f.id == p));
        }

        public void setCategoria(string p)
        {
            _data.setCategoria(_lCategoria.FirstOrDefault(f => f.id == p));
        }

        public void setNivel(string p)
        {
            _data.setNivel(_lNivel.FirstOrDefault(f => f.id == p));
        }

        public void setEstado(string p)
        {
            _data.setEstado(_lEstado.FirstOrDefault(f => f.id == p));
        }

        public void setZona(string p)
        {
            _data.setZona(_lZona.FirstOrDefault(f => f.id == p));
        }

        public void setVendedor(string p)
        {
            _data.setVendedor(_lVendedor.FirstOrDefault(f => f.id == p));
        }

        public void setTarifa(string p)
        {
            _data.setTarifa(_lTarifa.FirstOrDefault(f => f.id == p));
        }

        public void setCobrador(string p)
        {
            _data.setCobrador(_lCobrador.FirstOrDefault(f => f.id == p));
        }

        public void setCiRif(string p)
        {
            _data.setCiRif(p);
        }

        public void setCodigo(string p)
        {
            _data.setCodigo(p);
        }

        public void setRazonSocial(string p)
        {
            _data.setRazonSocial(p);
        }

        public void setDirFiscal(string p)
        {
            _data.setDirFiscal(p);
        }

        public void setDirDespacho(string p)
        {
            _data.setDirDespacho(p);
        }

        public void setPais(string p)
        {
            _data.setPais(p);
        }

        public void setContacto(string p)
        {
            _data.setContacto(p);
        }

        public void setTelefono1(string p)
        {
            _data.setTelefono1(p);
        }

        public void setTelefono2(string p)
        {
            _data.setTelefono2(p);
        }

        public void setEmail(string p)
        {
            _data.setEmail(p);
        }

        public void setCelular(string p)
        {
            _data.setCelular(p);
        }

        public void setFax(string p)
        {
            _data.setFax(p);
        }

        public void setWebSite(string p)
        {
            _data.setWebSite(p);
        }

        public void setCodPostal(string p)
        {
            _data.setCodPostal(p);
        }

        public void Procesar()
        {
            _procesarIsOk = false;
            if (_data.VerificarData()) 
            {
                var rt = MessageBox.Show("Guardar Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rt == DialogResult.Yes) 
                {
                    _procesarIsOk = GuardarFicha();
                    if (_procesarIsOk) 
                    {
                        Helpers.Msg.AgregarOk();
                    }
                }
            }
        }

        private bool  GuardarFicha()
        {
            var _isCredito = _data.IsCredito ? "1" : "0";
            var _diasCredito = 0;
            var _limiteCredito = 0.0m;
            var _limiteDoc = 0;
            if (_data.IsCredito) 
            {
                _diasCredito = _data.DiasCredito;
                _limiteCredito = _data.LimiteCredito;
                _limiteDoc = _data.LimiteDoc;
            }

            var _abc= "";
            switch (_data.Nivel.id) 
            { 
                case "01":
                    _abc = "A";
                    break;
                case "02":
                    _abc = "B";
                    break;
                case "03":
                    _abc = "C";
                    break;
            }
            var _tarifa= "";
            switch (_data.Tarifa.id)
            {
                case "01":
                    _tarifa = "1";
                    break;
                case "02":
                    _tarifa = "2";
                    break;
                case "03":
                    _tarifa = "3";
                    break;
                case "04":
                    _tarifa = "4";
                    break;
                case "05":
                    _tarifa = "5";
                    break;
            }

            //var ficha = new OOB.Maestro.Cliente.Agregar.Ficha()
            //{
            //    codigoSucursalRegistro = Sistema.Sucursal.codigo,
            //    autoGrupo = _data.Grupo.id,
            //    autoZona = _data.Zona.id,
            //    autoEstado = _data.Estado.id,
            //    autoAgencia = "0000000001",
            //    autoCobrador = _data.Cobrador.id,
            //    autoVendedor = _data.Vendedor.id,
            //    autoCodigoAnticipos = "0000000001",
            //    autoCodigoCobrar = "0000000001",
            //    autoCodigoIngreso = "0000000001",
            //    ciRif = _data.CiRif,
            //    codigo = _data.Codigo,
            //    razonSocial = _data.RazonSocial,
            //    dirFiscal = _data.DirFiscal,
            //    categoria = _data.Categoria.desc,
            //    abc = _abc,
            //    dirDespacho = _data.DirDespacho,
            //    pais = _data.Pais,
            //    codigoPostal = _data.CodPostal,
            //    telefono = _data.Telefono_1,
            //    telefono2 = _data.Telefono_2,
            //    celular = _data.Celular,
            //    fax = _data.Fax,
            //    contacto = _data.Contacto,
            //    email = _data.Email,
            //    webSite = _data.WebSite,
            //    estatus = "Activo",
            //    tarifa = _tarifa,
            //    denominacionFiscal = "No Contribuyente",
            //    estatusMorosidad = "0",
            //    estatusLunes = "0",
            //    estatusMartes = "0",
            //    estatusMiercoles = "0",
            //    estatusJueves = "0",
            //    estatusViernes = "0",
            //    estatusSabado = "0",
            //    estatusDomingo = "0",
            //    descuento = _data.Dscto,
            //    recargo = _data.Cargo,
            //    estatusCredito = _isCredito,
            //    diasCredito = _diasCredito,
            //    limiteCredito = _limiteCredito,
            //    docPendientes = _limiteDoc,
            //};
            //var r01 = Sistema.MyData.Cliente_Agregar(ficha);
            //if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return false;
            //}
            //_autoClienteAgregado= r01.Auto;
            return true;
        }

        public void Abandonar()
        {
            _abandonarIsOk = false;
            var rt = MessageBox.Show("Abandona Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rt == DialogResult.Yes)
            {
                _abandonarIsOk = true; 
            }
        }

        public void setCredito(bool p)
        {
            _data.setCredito(p);
        }

        public void setDscto(decimal p)
        {
            _data.setDscto(p);
        }

        public void setCargo(decimal p)
        {
            _data.setCargo(p);
        }

        public void setDiasCredito(int p)
        {
            _data.setDiasCredito(p);
        }

        public void setLimiteCredito(decimal p)
        {
            _data.setLimiteCredito(p);
        }

        public void setLimiteDoc(int p)
        {
            _data.setLimiteDoc(p);
        }

        public void setFichaEditar(string autoId)
        {
        }

        public bool IsModoAgregar
        {
            get { return true; }
        }

    }

}