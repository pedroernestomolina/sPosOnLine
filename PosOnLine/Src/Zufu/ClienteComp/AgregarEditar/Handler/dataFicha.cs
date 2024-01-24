using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.AgregarEditar.Handler
{
    public class dataFicha: Vista.IDataFicha
    {
        private string _id;
        private string _ciRif;
        private string _nombreRazonSocial;
        private string _dirFiscal;
        private string _telefono;


        public string Get_Id { get { return _id; } }
        public string Get_CiRif { get { return _ciRif; } }
        public string Get_NombreRazonSocial { get { return _nombreRazonSocial; } }
        public string Get_DirFiscal { get { return _dirFiscal; } }
        public string Get_Telefono { get { return _telefono; } }


        public dataFicha()
        {
            _id = "";
            _ciRif = "";
            _nombreRazonSocial = "";
            _dirFiscal = "";
            _telefono = "";
        }
        public void Inicializa()
        {
            _id = "";
            _ciRif = "";
            _nombreRazonSocial = "";
            _dirFiscal = "";
            _telefono = "";
        }
        public void setCiRif(string dato)
        {
            _ciRif = dato;
        }
        public void setNombre(string dato)
        {
            _nombreRazonSocial = dato;
        }
        public void setDirFiscal(string dato)
        {
            _dirFiscal = dato;
        }
        public void setTelefono(string dato)
        {
            _telefono = dato;
        }
        public void setCliente(OOB.Cliente.Entidad.Ficha ficha)
        {
            _id = ficha.Id;
            _ciRif = ficha.CiRif;
            _nombreRazonSocial = ficha.Nombre;
            _dirFiscal = ficha.DireccionFiscal;
            _telefono = ficha.Telefono;
        }
        public bool VerificarDataIsOk()
        {
            if (_ciRif.Trim() == "") 
            {
                Helpers.Msg.Alerta("CAMPO [ CI/RIF ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_nombreRazonSocial.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ NOMBRE / RAZON SOCIAL ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_dirFiscal.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ DIRECION FISCAL ] NO PUEDE ESTAR VACIO");
                return false;
            }
            return true;
        }
    }
}