using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Src.Reportes.DocVerificados
{
    
    public class data
    {

        public string docNumero { get; set; }
        public DateTime docFecha { get; set; }
        public decimal docMonto{ get; set; }
        public decimal docMontoDivisa { get; set; }
        public string docCliente { get; set; }
        public bool docIsAnulado { get; set; }
        public bool isVerificado { get; set; }


        public data() 
        {
            docNumero = "";
            docFecha = DateTime.Now;
            docMonto = 0m;
            docMontoDivisa = 0m;
            docCliente = "";
            docIsAnulado = false;
            isVerificado = false;
        }

    }

}