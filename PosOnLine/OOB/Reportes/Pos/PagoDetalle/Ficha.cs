using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Reportes.Pos.PagoDetalle
{

    public class Ficha
    {

        public string idRecibo { get; set; }
        public string docNumero { get; set; }
        public DateTime docFecha { get; set; }
        public string docHora { get; set; }
        public string cliNombre { get; set; }
        public string cliDir { get; set; }
        public string cliCiRif { get; set; }
        public string cliTelf { get; set; }
        public decimal docMonto { get; set; }
        public string docEstatus { get; set; }
        public string docTipo { get; set; }
        public decimal docCambioDar { get; set; }
        public List<Detalle> pagos { get; set; }
        public bool isActivo { get { return docEstatus.Trim().ToUpper() == "0"; } }
        public bool isFactura { get { return docTipo.Trim().ToUpper() == "FAC"; } }


        public Ficha()
        {
            idRecibo = "";
            docNumero = "";
            docFecha = DateTime.Now.Date;
            docHora = "";
            cliNombre= "";
            cliDir = "";
            cliCiRif= "";
            cliTelf = "";
            docMonto = 0.0m;
            docCambioDar = 0.0m;
            docEstatus = "";
            docTipo= "";
            pagos = new List<Detalle>();
        }

    }

}