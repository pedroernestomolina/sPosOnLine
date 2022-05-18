using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cliente.Buscar
{
    
    public class data
    {


        private string _cirif;
        private string _nombre;
        private string _dirFiscal;
        private string _telefono;


        public string CiRif { get { return _cirif; } }
        public string Nombre{ get { return _nombre; } }
        public string DirFiscal{ get { return _dirFiscal; } }
        public string Telefono{ get { return _telefono; } }


        public data()
        {
            Limpiar();
        }

        public void Limpiar()
        {
            _cirif = "";
            _nombre = "";
            _dirFiscal = "";
            _telefono = "";
        }


        public void setCiRif(string p)
        {
            _cirif = p;
        }

        public void setNombre(string p)
        {
            _nombre = p;
        }

        public void setDirFiscal(string p)
        {
            _dirFiscal = p;
        }

        public void setTelefono(string p)
        {
            _telefono = p;
        }

        public bool IsOk()
        {
            var rt = true;
            if (_cirif.Trim() == "") 
            {
                Helpers.Msg.Error("CAMPO [ CI/RIF ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_nombre.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ NOMBRE ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_dirFiscal.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ DIRECCION FISCAL ] NO PUEDE ESTAR VACIO");
                return false;
            }

            return rt;
        }

    }

}