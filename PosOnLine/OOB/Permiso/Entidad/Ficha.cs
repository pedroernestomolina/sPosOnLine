using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Permiso.Entidad
{
    
    public class Ficha
    {


        public enum enumNivel { SinDefinir = -1, Maximo = 1, Medio, Minimo };
        public bool permisoHabilitado { get; set; }
        public bool requiereClave { get; set;}
        public string seguridad { get; set; }


        public Ficha()
        {
            permisoHabilitado = false;
            requiereClave = false;
            seguridad = "";
        }


        public enumNivel Nivel 
        { 
            get 
            {
                var _nivel = enumNivel.SinDefinir;
                switch (seguridad.Trim().ToUpper()) 
                {
                    case "MAXIMA":
                        _nivel = enumNivel.Maximo;
                        break;
                    case "MEDIA":
                        _nivel = enumNivel.Medio;
                        break;
                    case "MINIMA":
                        _nivel = enumNivel.Minimo;
                        break;
                }
                return _nivel;
            } 
        }

    }

}