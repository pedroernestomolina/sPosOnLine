using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.Domain.Models
{
    public class TipoDocUso
    {
        public int cntDoc { get; set; }
        public decimal montoMonLocal { get; set; }
        public decimal montoMonReferencia { get; set; }
        public decimal montoRecibidoMonLocal { get; set; }
        public decimal montoRecibidoMonReferencia { get; set; }
        public decimal cambioVueltoMonLocal { get; set; }
        public decimal cambioVueltoMonReferencia { get; set; }
        public string codigoDoc { get; set; }
        public bool esCredito { get; set; }
        public bool esAnulado { get; set; }
        public string nombreDoc { get; set; }
        public string atributoDoc { get; set; }
        //
        public string DescripcionDoc { get { return nombreDoc + " " + atributoDoc; } }
    }
}