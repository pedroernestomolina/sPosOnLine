using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.Pos.Domain.Models
{
    public class CuentaControl
    {
        public int idCtaControl { get; set; }
        public string idCliente { get; set; }
        public decimal TasaPos { get; set; }
        public bool isProtegida { get; set; }
    }
}