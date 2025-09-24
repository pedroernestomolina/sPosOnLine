using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.Domain.Models
{
    public class RepoPagoDetalleEnc
    {
        public string docNumero { get; set; }
        public DateTime docFecha { get; set; }
        public string docHora { get; set; }
        public string cliNombre { get; set; }
        public string cliDir { get; set; }
        public string cliCiRif { get; set; }
        public string cliTelf { get; set; }
        public decimal docMonto { get; set; }
        public string docSiglas { get; set; }
        public decimal docCambioDar { get; set; }
        public bool isAnulado { get; set; }
        public bool isCredito { get; set; }
        public decimal tasaReferencia { get; set; }
        public int docSigno { get; set; }
        public string nroDocAplica { get; set; }
        public List<RepoPagoDetalleDet> pagos { get; set; }
        //
        public bool isDocVenta
        {
            get
            {
                return (docSiglas.Trim().ToUpper() == "FAC" || docSiglas.Trim().ToUpper() == "NCR" || docSiglas.Trim().ToUpper() == "NEN");
            }
        }
    }
}