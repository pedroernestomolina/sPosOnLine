using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.VentaAdm.DatosDoc
{
    
    public class Carga: ICarga
    {

        private bool _abandonaIsOk;
        private bool _aceptarIsOk;
        private string _idClienteCargado;
        private bool _habilitarBusquedaCliente;
        private OOB.Cliente.Entidad.Ficha _cliente;
        private Helpers.Opcion.IOpcion _gDeposito;
        private Helpers.Opcion.IOpcion _gSucursal;
        private Helpers.Opcion.IOpcion _gVendedor;
        private Helpers.Opcion.IOpcion _gCobrador;
        private Helpers.Opcion.IOpcion _gTransporte;
        private ClienteAdm.Buscar.IBuscar _gBuscarCl;


        public string GetClienteId { get { return _cliente == null ? "" : _cliente.Id; } }
        public OOB.Cliente.Entidad.Ficha GetCliente { get { return _cliente; } }


        public Carga()
        {
            _abandonaIsOk = false;
            _aceptarIsOk = false;
            _cliente=null;
            _idClienteCargado = "";
            _gCobrador = new Helpers.Opcion.Gestion();
            _gVendedor= new Helpers.Opcion.Gestion();
            _gSucursal= new Helpers.Opcion.Gestion();
            _gDeposito= new Helpers.Opcion.Gestion();
            _gTransporte = new Helpers.Opcion.Gestion();
            _gBuscarCl = new ClienteAdm.Buscar.Buscar();
        }

        
        public void Inicializa()
        {
            _abandonaIsOk = false;
            _aceptarIsOk = false;
            _idClienteCargado = "";
            _cliente = null;
            _gCobrador.Inicializa();
            _gVendedor.Inicializa();
            _gDeposito.Inicializa();
            _gSucursal.Inicializa();
            _gTransporte.Inicializa();
        }
        CargarFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new CargarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public bool AbandonarIsOk { get { return _abandonaIsOk; } }
        public void Abandonar()
        {
            _abandonaIsOk = false;
            var xmsg = "Estas Seguro de Salir y Perder Los Datos ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                _abandonaIsOk = true;
                if (_idClienteCargado == "")
                {
                    _cliente = null;
                }
                else 
                {
                    CargarCliente(_idClienteCargado);
                }
            }
        }

        public bool AceptarIsOK { get { return _aceptarIsOk; } }
        public void Aceptar()
        {
            _aceptarIsOk= false;

            if (_idClienteCargado=="")
            {
                if (_cliente == null) 
                {
                    Helpers.Msg.Error("CAMPO [ CLIENTE ] NO PUEDE ESTAR VACIO");
                    return;
                }
            }
            if (_gSucursal.GetId == "") 
            {
                Helpers.Msg.Error("CAMPO [ SUCURSAL ] NO PUEDE ESTAR VACIO");
                return;
            }
            if (_gDeposito.GetId == "")
            {
                Helpers.Msg.Error("CAMPO [ DEPOSITO ] NO PUEDE ESTAR VACIO");
                return;
            }
            if (_gVendedor.GetId == "")
            {
                Helpers.Msg.Error("CAMPO [ VENDEDOR ] NO PUEDE ESTAR VACIO");
                return;
            }
            var xmsg = "Procesar Los Datos ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _aceptarIsOk = true;
                _idClienteCargado = _cliente.Id;
            }
        }


        public BindingSource GetCobradorSource { get { return _gCobrador.Source; } }
        public string GetCobradorId { get { return _gCobrador.GetId; } }
        public void setCobrador(string id)
        {
            _gCobrador.setFicha(id);
        }


        public bool HabilitarDeposito { get { return false; } }
        public BindingSource GetDepositoSource { get { return _gDeposito.Source; } }
        public string GetDepositoId { get { return _gDeposito.GetId; } }
        public void setDeposito(string id)
        {
            _gDeposito.setFicha(id);
        }


        public bool HabilitarSucursal { get { return false; } }
        public BindingSource GetSucursalSource { get { return _gSucursal.Source; } }
        public string GetSucursalId { get { return _gSucursal.GetId; } }
        public void setSucursal(string id)
        {
            _gSucursal.setFicha(id);
        }


        public BindingSource GetTransporteSource { get { return _gTransporte.Source; } }
        public string GetTransporteId { get { return _gTransporte.GetId; } }
        public void setTransporte(string id)
        {
            _gTransporte.setFicha(id);
        }


        public BindingSource GetVendedorSource { get { return _gVendedor.Source; } }
        public string GetVendedorId { get { return _gVendedor.GetId; } }
        public void setVendedor(string id)
        {
            _gVendedor.setFicha(id);
        }


        public bool BusquedaClienteIsOk { get { return _cliente!=null; } }
        public bool HabilitarBusquedaCliente { get { return _habilitarBusquedaCliente; } }
        public string GetClienteInfo { get { return _cliente != null ? _cliente.CiRif + Environment.NewLine + _cliente.Nombre+ Environment.NewLine+_cliente.DireccionFiscal : ""; } }
        public void BuscarCliente()
        {
            _gBuscarCl.Inicializa();
            _gBuscarCl.Inicia();
            if (_gBuscarCl.ClienteSeleccionadoIsOk)
            {
                CargarCliente(_gBuscarCl.GetClienteSeleccionadoId);
            }
        }

        private void CargarCliente(string id)
        {
            _cliente = null;
            var r01 = Sistema.MyData.Cliente_GetFicha(id);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _cliente = r01.Entidad;
        }
        

        private bool CargarData()
        {
            var rt = true;

            //SUCURSAL
            var r01 = Sistema.MyData.Sucursal_GetLista();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var _lst = new List<Helpers.ficha>();
            foreach (var rg in r01.ListaD.OrderBy(o => o.nombre).ToList())
            {
                var nr = new Helpers.ficha() { id = rg.id, codigo = "", desc = rg.nombre };
                _lst.Add(nr);
            }
            _gSucursal.setData(_lst);

            //VENDEDOR
            var r02 = Sistema.MyData.Vendedor_GetLista();
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var _lst_2 = new List<Helpers.ficha>();
            foreach (var rg in r02.ListaD.OrderBy(o => o.nombre).ToList())
            {
                var nr = new Helpers.ficha() { id = rg.id, codigo = "", desc = rg.nombre };
                _lst_2.Add(nr);
            }
            _gVendedor.setData(_lst_2);

            //TRANSPORTE
            var r03 = Sistema.MyData.Sistema_Transporte_GetLista();
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            var _lst_3 = new List<Helpers.ficha>();
            foreach (var rg in r03.ListaD.OrderBy(o => o.nombre).ToList())
            {
                var nr = new Helpers.ficha() { id = rg.id, codigo = "", desc = rg.nombre };
                _lst_3.Add(nr);
            }
            _gTransporte.setData(_lst_3);

            //COBRADOR
            var r04 = Sistema.MyData.Sistema_Cobrador_GetLista();
            if (r04.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            var _lst_4 = new List<Helpers.ficha>();
            foreach (var rg in r04.ListaD.OrderBy(o => o.nombre).ToList())
            {
                var nr = new Helpers.ficha() { id = rg.id, codigo = "", desc = rg.nombre };
                _lst_4.Add(nr);
            }
            _gCobrador.setData(_lst_4);

            //DEPOSITO
            var filtro = new OOB.Deposito.Lista.Filtro();
            var r05 = Sistema.MyData.Deposito_GetLista(filtro);
            if (r05.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            var _lst_5 = new List<Helpers.ficha>();
            foreach (var rg in r05.ListaD.OrderBy(o => o.nombre).ToList())
            {
                var nr = new Helpers.ficha() { id = rg.id, codigo = "", desc = rg.nombre };
                _lst_5.Add(nr);
            }
            _gDeposito.setData(_lst_5);

            return rt;
        }

        public void IniciaConEditar(dataConf dat)
        {
            if (CargarData())
            {
                _gSucursal.setFicha(dat.GetIdSucursal);
                _gDeposito.setFicha(dat.GetIdDeposito);
                _gVendedor.setFicha(dat.GetIdVendedor);
                _idClienteCargado= dat.GetIdCliente;
                if (frm == null)
                {
                    frm = new CargarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public bool CargarDataCliente(string id)
        {
            var rt = false;
            CargarCliente(id);
            if (_cliente != null)
            {
                _idClienteCargado = _cliente.Id;
                rt = true;
            }
            return rt;
       }

        public void setHabilitarBusquedaCliente(bool habilitar)
        {
            this._habilitarBusquedaCliente = habilitar;
        }

    }

}