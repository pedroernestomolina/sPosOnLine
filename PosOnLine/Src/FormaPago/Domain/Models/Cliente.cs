using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.Models
{
    public class Cliente
    {
        public string id { get; set; }
        public string ciRif { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string dirFiscal { get; set; }
        public string telefonos { get; set; }
        //
        public string Descripcion { get { return ciRif.Trim() + Environment.NewLine + nombre.Trim(); } }
    }
}
