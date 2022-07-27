using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.VentaAdm.ClienteAdm.AgregarEditar.Agregar
{
    
    public class data
    {

        private Gestion.general _grupo;
        private Gestion.general _categoria;
        private Gestion.general _nivel;
        private Gestion.general _estado;
        private Gestion.general _zona;
        private Gestion.general _vendedor;
        private Gestion.general _cobrador;
        private Gestion.general _tarifa;
        private string _ciRif;
        private string _codigo;
        private string _razonSocial;
        private string _dirFiscal;
        private string _dirDespacho;
        private string _pais;
        private string _contacto;
        private string _telefono1;
        private string _telefono2;
        private string _email;
        private string _celular;
        private string _fax;
        private string _webSite;
        private string _codPostal;
        private bool _isCredito;
        private decimal _dscto;
        private decimal _cargo;
        private int _limiteDoc;
        private int _diasCredito;
        private decimal _limiteCredito;


        public Gestion.general Grupo { get { return _grupo; } }
        public Gestion.general Categoria{ get { return _categoria; } }
        public Gestion.general Nivel { get { return _nivel; } }
        public Gestion.general Estado { get { return _estado; } }
        public Gestion.general Zona { get { return _zona; } }
        public Gestion.general Vendedor { get { return _vendedor; } }
        public Gestion.general Cobrador { get { return _cobrador; } }
        public Gestion.general Tarifa { get { return _tarifa; } }
        public string CiRif { get { return _ciRif; } }
        public string Codigo { get { return _codigo; } }
        public string RazonSocial { get { return _razonSocial; } }
        public string DirFiscal { get { return _dirFiscal; } }
        public string DirDespacho { get { return _dirDespacho; } }
        public string Pais { get { return _pais; } }
        public string Contacto { get { return _contacto; } }
        public string Telefono_1 { get { return _telefono1; } }
        public string Telefono_2 { get { return _telefono2; } }
        public string Email { get { return _email; } }
        public string Celular { get { return _celular; } }
        public string Fax { get { return _fax; } }
        public string WebSite { get { return _webSite; } }
        public string CodPostal { get { return _codPostal; } }
        public bool IsCredito { get { return _isCredito; } }
        public decimal Dscto { get { return _dscto; } }
        public decimal Cargo { get { return _cargo; } }
        public int DiasCredito { get { return _diasCredito; } }
        public int LimiteDoc { get { return _limiteDoc; } }
        public decimal LimiteCredito { get { return _limiteCredito; } }


        public data()
        {
            limpiar();
        }

        private void limpiar()
        {
            _dscto = 0.0m;
            _cargo = 0.0m;
            _limiteCredito = 0.0m;
            _diasCredito = 0;
            _limiteDoc = 0;
            _grupo = null;
            _categoria = null;
            _nivel = null;
            _estado = null;
            _zona = null;
            _vendedor = null;
            _cobrador = null;
            _tarifa = null;
            _ciRif = "";
            _codigo = "";
            _razonSocial = "";
            _dirFiscal = "";
            _dirDespacho = "";
            _pais = "";
            _contacto = "";
            _telefono1 = "";
            _telefono2 = "";
            _email = "";
            _celular = "";
            _fax = "";
            _webSite = "";
            _codPostal = "";
            _isCredito = false;
        }


        public void setGrupo(Gestion.general ficha)
        {
            _grupo = ficha;
        }

        public void setCategoria(Gestion.general ficha)
        {
            _categoria = ficha;
        }

        public void setNivel(Gestion.general ficha)
        {
            _nivel = ficha;
        }

        public void setEstado(Gestion.general ficha)
        {
            _estado = ficha;
        }

        public void setZona(Gestion.general ficha)
        {
            _zona = ficha;
        }

        public void setVendedor(Gestion.general ficha)
        {
            _vendedor = ficha;
        }

        public void setTarifa(Gestion.general ficha)
        {
            _tarifa = ficha;
        }

        public void setCobrador(Gestion.general ficha)
        {
            _cobrador = ficha;
        }

        public void setCiRif(string p)
        {
            _ciRif = p;
        }

        public void setCodigo(string p)
        {
            _codigo = p;
        }

        public void setRazonSocial(string p)
        {
            _razonSocial = p;
        }

        public void setDirFiscal(string p)
        {
            _dirFiscal = p;
        }

        public void setDirDespacho(string p)
        {
            _dirDespacho = p;
        }

        public void setPais(string p)
        {
            _pais = p;
        }

        public void setContacto(string p)
        {
            _contacto = p;
        }

        public void setTelefono1(string p)
        {
            _telefono1 = p;
        }

        public void setTelefono2(string p)
        {
            _telefono2 = p;
        }

        public void setEmail(string p)
        {
            _email = p;
        }

        public void setCelular(string p)
        {
            _celular = p;
        }

        public void setFax(string p)
        {
            _fax = p;
        }

        public void setWebSite(string p)
        {
            _webSite = p;
        }

        public void setCodPostal(string p)
        {
            _codPostal = p;
        }

        public bool VerificarData()
        {
            var rt = true;

            if (_ciRif == "")
            {
                Helpers.Msg.Error("CI/RIF, CAMPO OBLIGATORIO, NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_razonSocial == "")
            {
                Helpers.Msg.Error("NOMBRE / RAZON SOCIAL, CAMPO OBLIGATORIO, NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_dirFiscal == "")
            {
                Helpers.Msg.Error("DIRECCION FISCAL, CAMPO OBLIGATORIO, NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_grupo== null)
            {
                Helpers.Msg.Error("GRUPO, CAMPO OBLIGATORIO, NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_categoria == null)
            {
                Helpers.Msg.Error("CATEGORIA, CAMPO OBLIGATORIO, NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_nivel == null)
            {
                Helpers.Msg.Error("NIVEL, CAMPO OBLIGATORIO, NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_estado == null)
            {
                Helpers.Msg.Error("ESTADO, CAMPO OBLIGATORIO, NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_zona== null)
            {
                Helpers.Msg.Error("ZONA, CAMPO OBLIGATORIO, NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_vendedor == null)
            {
                Helpers.Msg.Error("VENDEDOR, CAMPO OBLIGATORIO, NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_cobrador== null)
            {
                Helpers.Msg.Error("COBRADOR, CAMPO OBLIGATORIO, NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_tarifa == null)
            {
                Helpers.Msg.Error("TARIFA, CAMPO OBLIGATORIO, NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_dscto>=100)
            {
                Helpers.Msg.Error("DESCUENTO, CAMPO SUPERA EL LIMITE");
                return false;
            }

            if (_cargo >= 100)
            {
                Helpers.Msg.Error("CARGO, CAMPO SUPERA EL LIMITE");
                return false;
            }

            return rt;
        }

        public void Inicializa()
        {
            limpiar();
        }

        public void setCredito(bool p)
        {
            _isCredito = p;
        }

        public void setDscto(decimal p)
        {
            _dscto = p;
        }

        public void setCargo(decimal p)
        {
            _cargo = p;
        }

        public void setDiasCredito(int p)
        {
            _diasCredito = p;
        }

        public void setLimiteCredito(decimal p)
        {
            _limiteCredito = p;
        }

        public void setLimiteDoc(int p)
        {
            _limiteDoc = p;
        }

    }

}