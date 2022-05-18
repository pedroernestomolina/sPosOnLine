using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Pos.Abrir
{
    
    public class Operador
    {

        public string idUsuario { get; set; }
        public string idEquipo { get; set; }
        public string estatus { get; set; }


        public Operador()
        {
            idUsuario = "";
            idEquipo = "";
            estatus = "";
        }

        public void setData(string _idUsuario, string _idEquipo, string _estatus)
        {
            idUsuario = _idUsuario;
            idEquipo = _idEquipo;
            estatus = _estatus;
        }

    }

}