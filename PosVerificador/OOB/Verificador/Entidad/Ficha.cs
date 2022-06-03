using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.OOB.Verificador.Entidad
{
    
    public class Ficha
    {

        public int id { get; set; }
        public string autoDoc { get; set; }
        public string usuarioCodVer { get; set; }
        public string usuarioNombreVer { get; set; }
        public DateTime fechaVer { get; set; }
        public string estatusVer { get; set; }
        public string estatusAnulado { get; set; }
        public bool IsVerificado { get { return estatusVer.Trim().ToUpper() == "1" ? true : false; } }
        public bool Isnulado { get { return estatusAnulado.Trim().ToUpper() == "1" ? true : false; } }


        public Ficha()
        {
            id = -1;
            autoDoc = "";
            usuarioCodVer = "";
            usuarioNombreVer = "";
            fechaVer = DateTime.Now.Date;
            estatusVer = "";
            estatusAnulado = "";
        }

    }

}