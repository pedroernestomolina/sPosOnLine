using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.OOB.PosCtaControl.Obtener
{
    public class Ficha
    {
        public int IdCtaControl { get; set; }
        public string IdCliente { get; set; }
        public decimal TasaPos { get; set; }
        public bool IsProtegida { get; set; }
    }
}