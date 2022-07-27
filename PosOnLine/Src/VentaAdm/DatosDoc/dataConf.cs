using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.VentaAdm.DatosDoc
{
    
    public class dataConf
    {


        private string _idCliente;
        private string _idDeposito;
        private string _idSucursal;
        private string _idVendedor;


        public bool IsOk { get { return IsOK(); } }


        public dataConf() 
        {
            _idCliente = "";
            _idDeposito = "";
            _idSucursal = "";
            _idVendedor = "";
        }


        public void Inicializa()
        {
            _idCliente = "";
            _idDeposito = "";
            _idSucursal = "";
            _idVendedor = "";
        }

        public void setSucursal(string id)
        {
            _idSucursal = id;
        }
        public void setDeposito(string id)
        {
            _idDeposito = id;
        }
        public void setVendedor(string id)
        {
            _idVendedor = id;
        }
        public void setCliente(string id)
        {
            _idCliente = id;
        }


        private bool IsOK()
        {
            var rt=true;
            if (string.IsNullOrEmpty(_idSucursal) || 
                string.IsNullOrEmpty(_idDeposito) || 
                string.IsNullOrEmpty(_idVendedor) ||
                string.IsNullOrEmpty(_idCliente))
            {
                return false;
            }
            return rt;
        }


        public string GetIdSucursal { get { return _idSucursal; } }
        public string GetIdDeposito { get { return _idDeposito; } }
        public string GetIdVendedor { get { return _idVendedor; } }
        public string GetIdCliente { get { return _idCliente; } }


    }

}