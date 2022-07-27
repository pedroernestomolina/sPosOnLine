using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Configuracion.BusquedaCliente
{
    
    public class Ficha
    {

        public string PrefUsuario { get; set; }
        public Enumerados.EnumPreferenciaBusquedaCliente PrefBusqueda
        {
            get
            {
                switch (PrefUsuario.Trim().ToUpper())
                {
                    case "CODIGO":
                        return Enumerados.EnumPreferenciaBusquedaCliente.Codigo;
                    case "NOMBRE":
                        return Enumerados.EnumPreferenciaBusquedaCliente.Nombre;
                    case "CI/RIF":
                        return Enumerados.EnumPreferenciaBusquedaCliente.CiRif;
                    default:
                        return Enumerados.EnumPreferenciaBusquedaCliente.SnDefinir;
                }
            }
        }


        public Ficha()
        {
            PrefUsuario = "";
        }

    }

}