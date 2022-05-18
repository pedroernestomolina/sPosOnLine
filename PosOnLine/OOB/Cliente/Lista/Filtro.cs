using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Cliente.Lista
{
    
    public class Filtro
    {

        public string cadena { get; set; }
        public Enumerados.enumPreferenciaBusqueda preferenciaBusqueda { get; set; }


        public Filtro()
        {
            cadena = "";
            preferenciaBusqueda = Enumerados.enumPreferenciaBusqueda.SinDefinir;
        }

    }

}