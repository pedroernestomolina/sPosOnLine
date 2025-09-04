using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.Models
{
    public class ConfiguracionIGTF
    {
        public  bool aplica { get; set; }
        public decimal tasa { get; set; }
    }
}