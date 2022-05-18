using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cliente
{
    
    public class Gestion
    {


        private Buscar.Gestion _gestionBuscar;
        private bool _isClienteOk;


        public bool IsClienteOk { get { return _isClienteOk; } }
        public OOB.Cliente.Entidad.Ficha Cliente { get { return _gestionBuscar.Cliente; } }
        //public string ClienteData { get { return _gestionBuscar.Cliente != null ? _gestionBuscar.Cliente.Data : ""; } }
        public string ClienteData { get { return _gestionBuscar.GetClienteData; } }


        public Gestion() 
        {
            _gestionBuscar = new Buscar.Gestion();
        }


        public void Inicia()
        {
            _gestionBuscar.Inicia();
            _isClienteOk = _gestionBuscar.ClienteSeleccionadoIsOk;
            if (!_gestionBuscar.ClienteSeleccionadoIsOk)
                _gestionBuscar.Limpiar();
        }

        public void Limpiar()
        {
            _gestionBuscar.Limpiar();
            _isClienteOk = _gestionBuscar.ClienteSeleccionadoIsOk;
        }

        public void Inicializa()
        {
            _isClienteOk = false;
            _gestionBuscar.Inicializar();
        }

        public void CargarCliente(string autoId)
        {
            _gestionBuscar.CargarCliente(autoId);
            _isClienteOk = true;
        }

    }

}