using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmAnularDoc.Domain.Models
{
    public class Documento
    {
        public string idDoc { get; set; }
        public string codigoDoc { get; set; }
        public string idDocCxc { get; set; }
        public string idReciboCxc { get; set; }
        public string idCliente { get; set; }
        public decimal montoPendCxc { get; set; }
        public bool isAnulado { get; set; }
        public bool isCredito { get; set; }
        public bool isDocFiscal { get; set; }
        //
        public _Domain.Models.Enumerados.enumTipoDoc  tipoDoc { get { return _Domain.Models.Enumerados.TipoDocumento(codigoDoc); } }
    }
}