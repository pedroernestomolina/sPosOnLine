using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Zufu.ClienteComp.Cliente.Handler
{
    public class Imp: Vista.IVista
    {
        private string _idClienteCargar;
        private Vista.IBusqueda _busqueda;
        private OOB.Cliente.Entidad.Ficha _cliente;
        private __.Ctrl.Boton.Salir.ISalir _btAceptar;
        private __.Ctrl.Boton.Salir.ISalir _btSalir;
        private __.Ctrl.Boton.Abandonar.IAbandonar _btAbandonar;


        public __.Ctrl.Boton.Salir.ISalir BtAceptar { get { return _btAceptar; } }
        public __.Ctrl.Boton.Salir.ISalir BtSalir { get { return _btSalir; } }
        public __.Ctrl.Boton.Abandonar.IAbandonar BtAbandonar { get { return _btAbandonar; } }
        public Vista.IBusqueda Busqueda { get { return _busqueda; } }
        public bool IsClienteOk { get { return (_cliente != null && _btAceptar.OpcionIsOK); } }
        public OOB.Cliente.Entidad.Ficha Cliente { get { return _cliente; } }
        public string ClienteCiRif { get { return _cliente == null ? "" : _cliente.CiRif; } }
        public string ClienteNombreRazonSocial { get { return _cliente == null ? "" : _cliente.Nombre; } }
        public string ClienteDirFiscal { get { return _cliente == null ? "" : _cliente.DireccionFiscal; } }
        public string ClienteTelefono { get { return _cliente == null ? "" : _cliente.Telefono; } }
        //
        public string ClienteData { get { return ""; } }
        public string GetVendedorId { get { return ""; } }
        public string GetSucursalId { get { return ""; } }
        public string GetDepositoId { get { return ""; } }


        public Imp()
        {
            _idClienteCargar = "";
            _cliente = null;
            _busqueda = new ImpBusqueda();
            _btSalir = new __.Ctrl.Boton.Salir.Imp();
            _btAbandonar = new __.Ctrl.Boton.Abandonar.Imp();
            _btAceptar = new __.Ctrl.Boton.Salir.Imp();
        }
        public void Inicializa()
        {
            _cliente = null;
            _busqueda.Inicializa();
            _btAceptar.Inicializa();
            _btSalir.Inicializa();
            _btAbandonar.Inicializa();
        }
        Vista.Frm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void Buscar()
        {
            buscarCliente();
            _busqueda.setBuscar("");
        }
        public void AceptarCliente()
        {
            if (_cliente !=null)
            {
                _btAceptar.Opcion();
            }
        }
        public void AbandonarFicha()
        {
            _btAbandonar.Opcion();
            if (_btAbandonar.OpcionIsOK) 
            {
                _cliente = null;
            }
        }
        public void CerrarSinSeleccionarFicha()
        {
            _cliente = null;
            _btSalir.Opcion();
        }
        public void CargarFicha(object ficha)
        {
            _cliente = (OOB.Cliente.Entidad.Ficha)ficha;
        }
        public void CargarCliente(string id)
        {
            if (id.Trim()!= "")
            {
                try
                {
                    cargarDataCliente(id);
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
        public void Limpiar()
        {
            _cliente = null;
        }
        public void setHabilitarBusqueda(bool _habilitar)
        {
        }
        public void setVendedor(string id)
        {
        }
        public void setSucursal(string id)
        {
        }
        public void setDeposito(string id)
        {
        }


        private bool cargarData()
        {
            _busqueda.CargarData();
            _busqueda.TipoBusqueda.setFichaById("1");
            return true;
        }
        private void buscarCliente()
        {
            try
            {
                var cadena = _busqueda.Get_TextoBuscar.Trim().ToUpper();
                if (cadena == "")
                    return;
                if (_busqueda.TipoBusqueda.GetItem==null) 
                    return ;

                if (_busqueda.TipoBusqueda.GetId =="1")
                {
                    var r01 = Sistema.MyData.Cliente_GetFichaByCiRif(cadena);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        throw new Exception(r01.Mensaje);
                    }
                    if (r01.Entidad != "")
                    {
                        cargarDataCliente(r01.Entidad);
                    }
                    else
                    {
                        var msg = MessageBox.Show("Cliente No Encontrado, Agregarlo ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (msg == DialogResult.Yes)
                        {
                            AgregarCliente(cadena);
                        }
                        else
                        {
                            Limpiar();
                        }
                    }
                }
                else
                {
                    ListaCliente(cadena);
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        Zufu.ClienteComp.AgregarEditar.Vista.IAgregar _agregar;
        private void AgregarCliente(string cirif)
        {
            if (_agregar == null)
            {
                _agregar = new Zufu.ClienteComp.AgregarEditar.Handler.Agregar();
            }
            _agregar.Inicializa();
            _agregar.setCiRif(cirif);
            _agregar.Inicia();
            if (_agregar.Procesar.OpcionIsOK)
            {
                cargarDataCliente(_agregar.IdNewCliente);
            }
        }
        private bool _editarIsOk = false;
        Zufu.ClienteComp.AgregarEditar.Vista.IEditar _editar;
        public bool EditarIsOk { get { return _editarIsOk; } }
        public void EditarCliente()
        {
            _editarIsOk = false;
            if (_editar == null)
            {
                _editar = new Zufu.ClienteComp.AgregarEditar.Handler.Editar();
            }
            _editar.Inicializa();
            _editar.setIdEditar(_cliente.Id);
            _editar.Inicia();
            if (_editar.Procesar.OpcionIsOK)
            {
                cargarDataCliente(_cliente.Id);
                _editarIsOk = true;
            }
        }
        private Zufu.ClienteComp.Listar.Vista.IVista _listaClient;
        public void ListaCliente(string buscar)
        {
            var filtroOOB = new OOB.Cliente.Lista.Filtro()
            {
                cadena = buscar,
                preferenciaBusqueda = OOB.Cliente.Lista.Enumerados.enumPreferenciaBusqueda.Nombre,
            };
            var r01 = Sistema.MyData.Cliente_GetLista(filtroOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            if (_listaClient == null)
            {
                _listaClient = new Zufu.ClienteComp.Listar.Handler.Imp();
            }
            _listaClient.Inicializa();
            _listaClient.setListaCargar(r01.ListaD.OrderBy(o => o.nombre).ToList());
            _listaClient.Inicia();
            if (_listaClient.Lista.ItemSeleccionadoIsOk)
            {
                var _clientSel = (Zufu.ClienteComp.Listar.Handler.dataList)_listaClient.Lista.ItemSeleccionado;
                cargarDataCliente(_clientSel.Ficha.auto);
            }
        }
        private void cargarDataCliente(string id)
        {
            var r01 = Sistema.MyData.Cliente_GetFicha(id);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            _cliente = r01.Entidad;
        }
    }
}