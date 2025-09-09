using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPagoSolicitudPagoMovil.vm
{
    public class PagoMovilImpl: IPagoMovil
    {
        private __.Ctrl.Boton.Salir.ISalir _abandonarFicha;
        private ICtrlAgencia _ctrlAgencia;
        private decimal _montoPagoMovil;
        private FormaPago.Domain.Models.Cliente _entidadCliente;
        private string _entidadNombre;
        private string _entidadCiRif;
        private string _entidadTelefono;
        private Domain.UseCase.IUseCase _useCase;
        private List<Domain.Models.Agencia> _agencias;
        private Domain.Models.Agencia _agenciaSeleccionada;
        private bool _solicitudIsOk;
        //
        public decimal Get_MontoPagoMovil { get { return _montoPagoMovil; } }
        public string Get_EntidadNombre { get { return _entidadNombre; } }
        public string Get_EntidadCiRif { get { return _entidadCiRif; } }
        public string Get_EntidadTelefono { get { return _entidadTelefono; } }
        public object Get_AgenciasSource { get { return _ctrlAgencia.GetSource; } }
        public string Get_AgenciaID { get { return _ctrlAgencia.GetId; } }
        public bool solicitudIsOk { get { return _solicitudIsOk; } }
        public Domain.Models.DataRetornar Get_DataRetornar { get { return dataRetornar(); } }
        public bool abandonarFichaIsOK { get { return _abandonarFicha.OpcionIsOK; } }
        //
        public PagoMovilImpl()
        {
            _solicitudIsOk = false;
            _montoPagoMovil = 0m;
            _abandonarFicha = new __.Ctrl.Boton.Salir.Imp();
            _ctrlAgencia = new CtrlAgenciaImpl();
            _entidadCliente = null;
            _entidadCiRif = "";
            _entidadNombre = "";
            _entidadTelefono = "";
            _useCase = new Domain.UseCase.UseCaseImpl();
            _agencias = new List<Domain.Models.Agencia>();
            _agenciaSeleccionada = null;
        }
        public void Inicializa()
        {
            _solicitudIsOk = false;
            _montoPagoMovil = 0m;
            _entidadCliente = null;
            _entidadCiRif = "";
            _entidadNombre = "";
            _entidadTelefono = "";
            _ctrlAgencia.Inicializa();
            _abandonarFicha.Inicializa();
            _agenciaSeleccionada = null;
        }
        vista.Frm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        //
        public void setMontoPagoMovil(decimal monto)
        {
            _montoPagoMovil = monto;
        }
        public void setEntidadCliente(FormaPago.Domain.Models.Cliente entidadCliente)
        {
            _entidadCliente = entidadCliente;
            if (_entidadCliente != null) 
            {
                _entidadNombre = _entidadCliente.nombre;
                _entidadCiRif = _entidadCliente.ciRif;
                _entidadTelefono = _entidadCliente.telefonos;
            }
        }
        public void setEntidadNombre(string data)
        {
            _entidadNombre = data;
        }
        public void setEntidadCiRif(string data)
        {
            _entidadCiRif = data;
        }
        public void setEntidadTelefono(string data)
        {
            _entidadTelefono = data;
        }
        public void setAgencia(string id)
        {
            _agenciaSeleccionada = null;
            _ctrlAgencia.setFichaById(id);
            if (id.Trim() != "") 
            {
                _agenciaSeleccionada = _agencias.Find(f => f.id == id);
            }
        }
        private void setAgencias(List<Domain.Models.Agencia> list)
        {
            _agencias= list;
            _ctrlAgencia.CargarData(list);
        }
        //
        public void procesarFicha()
        {
            _solicitudIsOk = false;
            if (_entidadNombre.Trim() == "") 
            {
                Helpers.Msg.Alerta("CAMPO [ NOMBRE ] NO PUEDE ESTAR VACIO");
                return;
            }
            if (_entidadCiRif.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ CI/RIF ] NO PUEDE ESTAR VACIO");
                return;
            }
            if (_entidadTelefono.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ TELEFONO ] NO PUEDE ESTAR VACIO");
                return;
            }
            if (_agenciaSeleccionada == null)
            {
                Helpers.Msg.Alerta("CAMPO [ AGENCIA ] NO PUEDE ESTAR VACIO");
                return;
            }
            _solicitudIsOk = true;
        }
        public void abandonarFicha()
        {
            _abandonarFicha.Opcion();
        }
        //
        private bool cargarData()
        {
            try
            {
                setAgencias(_useCase.CargarAgenciasUseCase());
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private Domain.Models.DataRetornar 
            dataRetornar()
        {
            var rt = new Domain.Models.DataRetornar()
            {
                AgenciaId = _agenciaSeleccionada.id,
                AgenciaNombre = _agenciaSeleccionada.desc,
                EntidadCiRif = _entidadCiRif,
                EntidadNombre = _entidadNombre,
                EntidadTelefono = _entidadTelefono,
                Monto = _montoPagoMovil,
            };
            return rt;
        }
    }
}