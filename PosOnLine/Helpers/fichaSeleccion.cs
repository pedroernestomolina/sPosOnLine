using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers
{
    
    public class fichaSeleccion: ficha
    {
        
        public bool isAnulado {get;set;}
        public string estatus { get { return isAnulado ? "INACTIVO" : ""; } }


        public fichaSeleccion() 
            :base()
        {
            isAnulado=false;
        }

        public fichaSeleccion(string id, string cod, string des, bool isAnuladoInactivo)
            :this()
        {
            this.id = id;
            this.codigo = cod;
            this.desc = des;
            this.isAnulado = isAnuladoInactivo;
        }

    }

}