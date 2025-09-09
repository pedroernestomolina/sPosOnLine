using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPago.Domain.Models
{
    public class FormaPagoBono: FormaPago
    {
        public decimal MontoSobreElCualAplicaBono_MonReferencia { get; set; }
        public FormaPagoBono()
            :base()
        {
            MontoSobreElCualAplicaBono_MonReferencia = 0m;
        }
    }
}
