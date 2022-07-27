using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.VentaAdm.ClienteAdm.AgregarEditar
{
    
    public class Gestion
    {

        private IGestion _gestion;


        public string TituloFicha { get { return _gestion.TituloFicha; } }
        public BindingSource SourceGrupo { get { return _gestion.SourceGrupo; } }
        public BindingSource SourceZona { get { return _gestion.SourceZona; } }
        public BindingSource SourceCategoria { get { return _gestion.SourceCategoria; } }
        public BindingSource SourceNivel { get { return _gestion.SourceNivel; } }
        public BindingSource SourceTarifa { get { return _gestion.SourceTarifa; } }
        public BindingSource SourceVendedor { get { return _gestion.SourceVendedor; } }
        public BindingSource SourceCobrador { get { return _gestion.SourceCobrador; } }
        public BindingSource SourceEstado { get { return _gestion.SourceEstado; } }
        //
        public bool ProcesarIsoK { get { return _gestion.ProcesarIsoK; } }
        public bool AbandonarIsOk { get { return _gestion.AbandonarIsOk; } }
        //
        public string IdGrupo { get { return _gestion.IdGrupo; } }
        public string IdZona { get {  return _gestion.IdZona; } }
        public string IdCategoria { get { return _gestion.IdCategoria; } }
        public string IdNivel { get { return _gestion.IdNivel; } }
        public string IdTarifa { get { return _gestion.IdTarifa; } }
        public string IdEstado { get { return _gestion.IdEstado; } }
        public string IdVendedor { get { return _gestion.IdVendedor; } }
        public string IdCobrador { get { return _gestion.IdCobrador; } }
        public string CiRif { get { return _gestion.CiRif; } }
        public string Codigo { get { return _gestion.Codigo; } }
        public string RazonSocial { get { return _gestion.RazonSocial; } }
        public string DirFiscal { get { return _gestion.DirFiscal; } }
        public string DirDespacho { get { return _gestion.DirDespacho; } }
        public string Pais { get { return _gestion.Pais; } }
        public string CodPostal { get { return _gestion.CodPostal; } }
        public string Contacto { get { return _gestion.Contacto; } }
        public string Telefono1 { get { return _gestion.Telefono1; } }
        public string Telefono2 { get { return _gestion.Telefono2; } }
        public string Celular { get { return _gestion.Celular; } }
        public string Email { get { return _gestion.Email; } }
        public string WebSite { get { return _gestion.WebSite; } }
        public string Fax { get { return _gestion.Fax; } }
        public bool CreditoIsActivo { get { return _gestion.CreditoIsActivo; } }
        public bool CategoriaIsAdministrativo { get { return _gestion.CategoriaIsAdministrativo; } }
        public decimal Dscto { get { return _gestion.Dscto; } }
        public decimal Cargo { get { return _gestion.Cargo; } }
        public int DiasCredito { get { return _gestion.DiasCredito; } }
        public int LimiteDoc { get { return _gestion.LimiteDoc; } }
        public decimal LimiteCredito { get { return _gestion.LimiteCredito; } }
        //
        public string AutoClienteAgregado { get { return _gestion.AutoClienteAgregado; } }
        //
        public bool IsModoAgregar { get { return _gestion.IsModoAgregar; } }

        
        private AgregarEditarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return _gestion.CargarData();
        }

        public void Inicializa()
        {
            _gestion.Inicializa();
        }

        public void setGestion(IGestion gestion)
        {
            _gestion = gestion;
        }

        public void setGrupo(string p)
        {
            _gestion.setGrupo(p);
        }

        public void setCategoria(string p)
        {
            _gestion.setCategoria(p);
        }

        public void setNivel(string p)
        {
            _gestion.setNivel(p);
        }

        public void setEstado(string p)
        {
            _gestion.setEstado(p);
        }

        public void setZona(string p)
        {
            _gestion.setZona(p);
        }

        public void setVendedor(string p)
        {
            _gestion.setVendedor(p);
        }

        public void setTarifa(string p)
        {
            _gestion.setTarifa(p);
        }

        public void setCobrador(string p)
        {
            _gestion.setCobrador(p);
        }

        public void setCiRif(string p)
        {
            _gestion.setCiRif(p);
        }

        public void setCodigo(string p)
        {
            _gestion.setCodigo(p);
        }

        public void setRazonSocial(string p)
        {
            _gestion.setRazonSocial(p);
        }

        public void setDirFiscal(string p)
        {
            _gestion.setDirFiscal(p);
        }

        public void setDirDespacho(string p)
        {
            _gestion.setDirDespacho(p);
        }

        public void setPais(string p)
        {
            _gestion.setPais(p);
        }

        public void setContacto(string p)
        {
            _gestion.setContacto(p);
        }

        public void setTelefono1(string p)
        {
            _gestion.setTelefono1(p);
        }

        public void setTelefono2(string p)
        {
            _gestion.setTelefono2(p);
        }

        public void setEmail(string p)
        {
            _gestion.setEmail(p);
        }

        public void setCelular(string p)
        {
            _gestion.setCelular(p);
        }

        public void setFax(string p)
        {
            _gestion.setFax(p);
        }

        public void setWebSite(string p)
        {
            _gestion.setWebSite(p);
        }

        public void setCodPostal(string p)
        {
            _gestion.setCodPostal(p);
        }

        public void Procesar()
        {
            _gestion.Procesar();
        }

        public void Salir()
        {
            _gestion.Abandonar();
        }

        public void setCredito(bool p)
        {
            _gestion.setCredito(p);
        }

        public void setDscto(decimal p)
        {
            _gestion.setDscto(p);
        }

        public void setCargo(decimal p)
        {
            _gestion.setCargo(p);
        }

        public void setDiasCredito(int p)
        {
            _gestion.setDiasCredito(p);
        }

        public void setLimiteCredito(decimal p)
        {
            _gestion.setLimiteCredito(p);
        }

        public void setLimiteDoc(int p)
        {
            _gestion.setLimiteDoc(p);
        }

        public void setFichaEditar(string autoId)
        {
            _gestion.setFichaEditar(autoId);
        }

    }

}