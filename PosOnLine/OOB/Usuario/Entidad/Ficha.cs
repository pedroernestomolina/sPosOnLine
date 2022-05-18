using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Usuario.Entidad
{

    public class Ficha
    {

        public string id { get; set; }
        public string idGrupo { get; set; }
        public string clave { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string nombreGrupo { get; set; }
        public bool IsInvitado { get { return id == ""; } }


        public Ficha()
        {
            id = "";
            idGrupo = "";
            clave = "";
            codigo = "";
            nombre = "";
            nombreGrupo = "";
        }


        public void setInvitado()
        {
            codigo = "ADMINISTRADOR";
            nombre = "ADMINISTRADOR";
        }

    }

}