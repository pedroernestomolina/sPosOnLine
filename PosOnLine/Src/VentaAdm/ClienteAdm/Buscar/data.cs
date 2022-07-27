using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.VentaAdm.ClienteAdm.Buscar
{
    
    public class data
    {

        public string Id { get; set; }
        public string Codigo { get; set; }
        public string NombreRazonSocial { get; set; }
        public string CiRif { get; set; }
        public string Estatus { get; set; }
        public bool IsActivo { get { return Estatus.Trim().ToUpper() == "ACTIVO" ? true : false; } }


        public data() 
        {
            limpiar();
        }


        public data(data it)
            :base()
        {
            Id = it.Id;
            Codigo = it.Codigo;
            CiRif = it.CiRif;
            NombreRazonSocial = it.NombreRazonSocial;
            Estatus= it.Estatus;
        }

       
        private void limpiar()
        {
            Id = "";
            Codigo = "";
            CiRif= "";
            NombreRazonSocial = "";
            Estatus = "";
        }

    }

}