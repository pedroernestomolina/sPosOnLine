using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cliente.Editar
{
    
    public class data
    {

        private string _ciRif;
        private string _nombre;
        private string _direccion;
        private string _telefono;


        public string GetCiRif { get { return _ciRif; } }
        public string GetNombreRazonSocial { get { return _nombre; } }
        public string GetDireccion { get { return _direccion; } }
        public string GetTelefono { get { return _telefono; } }


        public data() 
        {
            Limpiar();
        }


        public void Limpiar()
        {
            _ciRif = "";
            _nombre = "";
            _direccion = "";
            _telefono = "";
        }
        public void setCiRif(string p)
        {
            _ciRif = p;
        }
        public void setNombreRazonSocial(string p)
        {
            _nombre = p;
        }
        public void setDireccion(string p)
        {
            _direccion = p;
        }
        public void setTelefono(string p)
        {
            _telefono = p;
        }

    }

}