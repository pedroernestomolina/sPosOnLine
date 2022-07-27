using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.VentaAdm
{
    
    public class Gestion: Pos.ICliente
    {

        private DatosDoc.dataConf _datConf;
        private DatosDoc.ICarga _gBuscar;


        public bool IsClienteOk { get { return _gBuscar.BusquedaClienteIsOk; } }
        public OOB.Cliente.Entidad.Ficha Cliente { get { return _gBuscar.GetCliente; } }
        public string ClienteData { get { return _gBuscar.GetClienteInfo; } }


        public Gestion() 
        {
            _datConf = new DatosDoc.dataConf();
            _gBuscar = new DatosDoc.Carga();
        }


        public void Inicializa()
        {
            _datConf.Inicializa();
            _gBuscar.Inicializa();
        }
        public void Inicia()
        {
            if (!_datConf.IsOk)
            {
                _datConf.setSucursal(Sistema.ConfiguracionActual.idSucursal);
                _datConf.setDeposito(Sistema.ConfiguracionActual.idDeposito);
                _datConf.setVendedor(Sistema.ConfiguracionActual.idVendedor);
            };
            _gBuscar.IniciaConEditar(_datConf);
            if (_gBuscar.BusquedaClienteIsOk)
            {
                _datConf.setVendedor(_gBuscar.GetVendedorId);
                _datConf.setCliente(_gBuscar.GetClienteId);

            }
        }
        public void CargarCliente(string id)
        {
            if (_gBuscar.CargarDataCliente(id))
            {
                _datConf.setCliente(id);
            }
        }
        public void Limpiar()
        {
            _datConf.Inicializa();
            _gBuscar.Inicializa();
        }


        public string GetSucursalId { get { return _datConf.GetIdSucursal; } }
        public string GetDepositoId { get { return _datConf.GetIdDeposito; } }
        public string GetVendedorId { get { return _datConf.GetIdVendedor; } }
        public void setHabilitarBusqueda(bool _habilitar)
        {
            _gBuscar.setHabilitarBusquedaCliente(_habilitar);
        }
        public void setVendedor(string id)
        {
            _gBuscar.setVendedor(id);
            _datConf.setVendedor(id);
        }
        public void setSucursal(string id)
        {
            _gBuscar.setSucursal(id);
            _datConf.setSucursal(id);
        }
        public void setDeposito(string id)
        {
            _gBuscar.setDeposito(id);
            _datConf.setDeposito(id);
        }

    }

}