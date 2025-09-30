using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmVisualizarDoc.Domain.Models
{
    public class Encabezado
    {
        public string documentoNro { get; set; }
        public DateTime documentoFechaEmision { get; set; }
        public decimal documentoImporteMonReferencia { get; set; }
        public decimal documentoImporteMonLocal { get; set; }
        public string documentoNombre { get; set; }
        public bool documentoIsAnulado { get; set; }
        public bool documentoIsCredito { get; set; }
        public string clienteCiRif { get; set; }
        public string clienteNombre { get; set; }
        public string clienteCodigo { get; set; }
        public string clienteDirFiscal { get; set; }
        public string clienteInfo { get { return clienteCiRif + Environment.NewLine + clienteNombre + Environment.NewLine + clienteDirFiscal; } }
    }
}
