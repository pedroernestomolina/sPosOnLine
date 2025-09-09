using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPagoSolicitudPagoMovil.Domain.Models
{
    public class DataRetornar
    {
        public string EntidadCiRif{ get; set; }
        public string EntidadNombre { get; set; }
        public string EntidadTelefono { get; set; }
        public string AgenciaId { get; set; }
        public string AgenciaNombre { get; set; }
        public decimal Monto { get; set; }
    }
}