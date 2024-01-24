using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Cliente.Buscar
{
    public class Gestion
    {
        public enum enumMetodoBusqueda { SinDefinir = 1, CiRif = 1, Nombre };


        private enumMetodoBusqueda _metodoBusqueda;
        private bool _habilitarFicha;
        private string _cadenaBusqueda;
        private Listar.Gestion _gestionLista;
        private OOB.Cliente.Entidad.Ficha _cliente;
        private bool _clienteSeleccionadoIsOk;
        private bool _habilitarBusqueda;
        private data _dataNewCliente;
        private bool _guardarIsOk;
        private Editar.Gestion _gEditar;


        public enumMetodoBusqueda MetodoBusqueda { get { return _metodoBusqueda; } }
        public bool HabilitarFicha { get { return _habilitarFicha; } }
        public bool ClienteSeleccionadoIsOk { get { return _clienteSeleccionadoIsOk; } }
        public OOB.Cliente.Entidad.Ficha Cliente { get { return _cliente; } }
        public bool HabilitarBusqueda { get { return _habilitarBusqueda; } }
        public bool GuardarIsOk { get { return _guardarIsOk; } }
        

        public Gestion()
        {
            _dataNewCliente = new data();
            _gestionLista = new Cliente.Listar.Gestion();
            _gEditar = new Editar.Gestion();
            Limpiar();
        }


        private BuscarAgregarFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm==null)
                {
                    frm = new BuscarAgregarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setCiRifMetodoBusqueda()
        {
            _metodoBusqueda = enumMetodoBusqueda.CiRif;
        }

        public void setNombreMetodoBusqueda()
        {
            _metodoBusqueda = enumMetodoBusqueda.Nombre;
        }

        public void Limpiar()
        {
            _dataNewCliente.Limpiar();
            _habilitarBusqueda = true;
            _habilitarFicha = false;
            _cadenaBusqueda = "";
            _metodoBusqueda = enumMetodoBusqueda.CiRif;
            _cliente = null;
            _clienteSeleccionadoIsOk = false;
        }

        public void Inicializar()
        {
            _gEditar.Inicializa();
            _guardarIsOk = false;
            Limpiar();
        }

        public void setBuscar(string texto)
        {
            try
            {
                var cadena = texto.Trim().ToUpper();
                if (cadena == "")
                    return;

                if (_metodoBusqueda == enumMetodoBusqueda.CiRif)
                {
                    var r01 = Sistema.MyData.Cliente_GetFichaByCiRif(cadena);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        throw new Exception(r01.Mensaje);
                    }
                    if (r01.Entidad != "")
                    {
                        cargarDataCliente(r01.Entidad);
                        frm.ActualizarCliente();
                    }
                    else
                    {
                        var msg = MessageBox.Show("Cliente No Encontrado, Agregarlo ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (msg == DialogResult.Yes)
                        {
                            AgregarCliente(cadena);
                            if (_cliente != null)
                            {
                                frm.ActualizarCliente();
                            }
                        }
                        else
                        {
                            Limpiar();
                            frm.LimpiarCtr();
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

        public void AceptarCliente()
        {
            _clienteSeleccionadoIsOk = true;
            frm.Cerrar();
        }

        public void setCiRif(string p)
        {
            _dataNewCliente.setCiRif(p);
        }

        public void setNombre(string p)
        {
            _dataNewCliente.setNombre(p);
        }

        public void setDirFiscal(string p)
        {
            _dataNewCliente.setDirFiscal(p);
        }

        public void setTelefono(string p)
        {
            _dataNewCliente.setTelefono(p);
        }

        public void Guardar()
        {
            _guardarIsOk = false;
            if (_dataNewCliente.IsOk()) 
            {
                var msg = MessageBox.Show("Guardar Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes) 
                {
                    var fichaOOb = new OOB.Cliente.Agregar.Ficha()
                    {
                        autoGrupo = "0000000001",
                        autoZona = "0000000001",
                        autoEstado = "0000000001",
                        autoCobrador = "0000000001",
                        autoVendedor = "0000000001",
                        ciRif = _dataNewCliente.CiRif ,
                        razonSocial = _dataNewCliente.Nombre ,
                        dirFiscal = _dataNewCliente.DirFiscal ,
                        telefono = _dataNewCliente.Telefono,
                        estatus = "Activo",
                        categoria = "Eventual",
                        estatusCredito = "0",
                        pais = "VZLA",
                        tarifa="0",
                        denominacionFiscal  = "No Contribuyente",
                        codigoSucursal=Sistema.Sucursal.codigo,
                    };
                    var r01 = Sistema.MyData.Cliente_AgregarFicha(fichaOOb);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }

                    var autoId = r01.Auto;
                    var r02 = Sistema.MyData.Cliente_GetFicha(autoId);
                    if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                        return;
                    }

                    _cliente = r02.Entidad;
                    _guardarIsOk = true;
                }
            }
        }

        public void CargarCliente(string autoId)
        {
            _clienteSeleccionadoIsOk = false;
            var r01 = Sistema.MyData.Cliente_GetFicha(autoId);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _clienteSeleccionadoIsOk=true;
            _cliente = r01.Entidad;
        }


        public string GetClienteData 
        {
            get 
            {
                var rt = "";
                if (_cliente != null) 
                {
                    rt = _cliente.CiRif + Environment.NewLine + _cliente.Nombre + Environment.NewLine + _cliente.DireccionFiscal;
                }
                return rt;
            }
        }


        public string ClienteGetCiRif
        {
            get
            {
                var rt = "";
                if (_cliente != null)
                {
                    rt = _cliente.CiRif;
                }
                return rt;
            }
        }
        public string ClienteGetDirFiscal
        {
            get
            {
                var rt = "";
                if (_cliente != null)
                {
                    rt = _cliente.DireccionFiscal;
                }
                return rt;
            }
        }
        public string ClienteGetRazonSocial
        {
            get
            {
                var rt = "";
                if (_cliente != null)
                {
                    rt = _cliente.Nombre;
                }
                return rt;
            }
        }
        public string ClienteGetTelefono
        {
            get
            {
                var rt = "";
                if (_cliente != null)
                {
                    rt = _cliente.Telefono;
                }
                return rt;
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
                _clienteSeleccionadoIsOk = true;
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
                _clienteSeleccionadoIsOk = true;
                _editarIsOk = true;
            }
        }

        private Zufu.ClienteComp.Listar.Vista.IVista _listaClient;
        public void ListaCliente(string buscar)
        {
            _clienteSeleccionadoIsOk = false;
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
                _habilitarBusqueda = false;
                var _clientSel = (Zufu.ClienteComp.Listar.Handler.dataList)_listaClient.Lista.ItemSeleccionado;
                cargarDataCliente(_clientSel.Ficha.auto);
                frm.ActualizarCliente();
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
        private bool CargarData()
        {
            return true;
        }
    }
}