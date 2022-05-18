using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Pos.EnUso
{
    
    public class Ficha
    {

        public int id { get; set; }
        public string idAutoArqueoCierre { get; set; }
        public int idResumen { get; set; }
        public string idUsuario { get; set; }
        public string codUsuario { get; set; }
        public string nomUsuario { get; set; }
        public DateTime fechaApertura { get; set; }
        public string horaApertura { get; set; }
        public bool IsEnUso { get { return id != -1; } }


        public Ficha()
        {
            Inicializa();
        }

        public void Cerrar()
        {
            Inicializa();
        }

        private void Inicializa()
        {
            id = -1;
            idAutoArqueoCierre = "";
            idResumen = -1;
            idUsuario = "";
            codUsuario = "";
            nomUsuario = "";
            fechaApertura = DateTime.Now.Date;
            horaApertura = "";
        }

    }

}