using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.CuadreCierre.CuadreResumen
{
    public class Documento
    {
        public int cntDoc { get; set; }
        public decimal montoMonLocal { get; set; }
        public decimal montoMonReferencia { get; set; }
        public decimal montoRecibidoMonLocal { get; set; }
        public decimal montoRecibidoMonReferencia { get; set; }
        public decimal cambioVueltoMonLocal { get; set; }
        public decimal cambioVueltoMonReferencia { get; set; }
        public string codigoDoc { get; set; }
        public string varianteDoc { get; set; }
        public bool esCredito { get; set; }
        public bool esAnulado { get; set; }
        public int signoDoc { get; set; }
    }
}
