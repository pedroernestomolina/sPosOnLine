using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Sucursal.Entidad
{
    
    public class Ficha
    {

        public string id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string nombreGrupo { get; set; }
        public int idPrecioManejar { get; set; }
        public string estatusVentaMayor { get; set; }
        public string estatus { get; set; }
        public string autoDepositoPrincipal { get; set; }
        public bool HabilitarVentaMayor { get { return estatusVentaMayor.Trim() == "1"; } }
        public bool isActivo { get { return estatus.Trim().ToUpper() == "1"; } }


        public Ficha()
        {
            id = "";
            idPrecioManejar = -1;
            codigo = "";
            nombre = "";
            nombreGrupo = "";
            estatusVentaMayor = "";
            estatus = "";
            autoDepositoPrincipal = "";
        }

    }

}