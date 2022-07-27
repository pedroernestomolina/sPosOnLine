using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.VentaAdm.ClienteAdm.AgregarEditar
{
    
    public interface IGestion
    {

        string TituloFicha { get; }
        System.Windows.Forms.BindingSource SourceCategoria { get;  }
        System.Windows.Forms.BindingSource SourceNivel { get;  }
        System.Windows.Forms.BindingSource SourceTarifa { get; }
        System.Windows.Forms.BindingSource SourceGrupo { get; }
        System.Windows.Forms.BindingSource SourceZona { get; }
        System.Windows.Forms.BindingSource SourceVendedor { get; }
        System.Windows.Forms.BindingSource SourceCobrador { get; }
        System.Windows.Forms.BindingSource SourceEstado { get; }
        bool ProcesarIsoK { get; }
        bool AbandonarIsOk { get; }
        string IdGrupo { get; }
        string IdZona { get; }
        string IdCategoria { get; }
        string IdNivel { get; }
        string IdEstado { get; }
        string IdVendedor { get; }
        string IdCobrador { get; }
        string IdTarifa { get; }
        string CiRif { get; }
        string Codigo { get; }
        string RazonSocial { get; }
        string DirFiscal { get; }
        string DirDespacho { get; }
        string Pais { get; }
        string CodPostal { get; }
        string Contacto { get; }
        string Telefono1 { get; }
        string Telefono2 { get; }
        string Fax { get; }
        string WebSite { get; }
        string Email { get; }
        string Celular { get; }
        bool CreditoIsActivo { get; }
        bool CategoriaIsAdministrativo { get; }
        decimal Dscto { get; }
        decimal Cargo { get; }
        int DiasCredito { get; }
        int LimiteDoc { get; }
        decimal LimiteCredito { get; }
        string AutoClienteAgregado { get; }
        bool IsModoAgregar { get; }

        
        Boolean CargarData();
        void Inicializa();
        void setGrupo(string p);
        void setCategoria(string p);
        void setNivel(string p);
        void setEstado(string p);
        void setZona(string p);
        void setVendedor(string p);
        void setTarifa(string p);
        void setCobrador(string p);
        void setCiRif(string p);
        void setCodigo(string p);
        void setRazonSocial(string p);
        void setDirFiscal(string p);
        void setDirDespacho(string p);
        void setPais(string p);
        void setContacto(string p);
        void setTelefono1(string p);
        void setTelefono2(string p);
        void setEmail(string p);
        void setCelular(string p);
        void setFax(string p);
        void setWebSite(string p);
        void setCodPostal(string p);
        void Procesar();
        void Abandonar();
        void setCredito(bool p);
        void setDscto(decimal p);
        void setCargo(decimal p);
        void setDiasCredito(int p);
        void setLimiteCredito(decimal p);
        void setLimiteDoc(int p);
        void setFichaEditar(string autoId);

    }

}