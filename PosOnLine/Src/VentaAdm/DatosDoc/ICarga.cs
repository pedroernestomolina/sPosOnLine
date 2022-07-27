using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.VentaAdm.DatosDoc
{
    
    public interface ICarga: IGestion
    {

        bool AbandonarIsOk { get; }
        void Abandonar();

        bool AceptarIsOK { get; }
        void Aceptar();


        BindingSource GetCobradorSource { get;  }
        void setCobrador(string id);
        string GetCobradorId { get; }

        bool HabilitarDeposito { get; }
        BindingSource GetDepositoSource { get; }
        string GetDepositoId { get; }
        void setDeposito(string id);

        bool HabilitarSucursal { get; }
        BindingSource GetSucursalSource { get; }
        string GetSucursalId { get; }
        void setSucursal(string id);

        BindingSource GetTransporteSource { get; }
        string GetTransporteId { get; }
        void setTransporte(string id);

        BindingSource GetVendedorSource { get; }
        string GetVendedorId { get; }
        void setVendedor(string id);


        OOB.Cliente.Entidad.Ficha GetCliente { get; }
        string GetClienteId { get; }
        string GetClienteInfo { get; }
        void BuscarCliente();
        bool BusquedaClienteIsOk { get;  }
        bool HabilitarBusquedaCliente { get; }
        void setHabilitarBusquedaCliente(bool _habilitar);


        void IniciaConEditar(dataConf _datConf);
        bool CargarDataCliente(string id);

    }

}