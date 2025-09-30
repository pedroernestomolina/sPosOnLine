using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmVisualizarDoc.Domain.Models
{
    public class Cuerpo
    {
        public string codigoPrd { get ; set; }
        public string nombrePrd { get ; set; }
        public decimal precioMonLocal { get; set; }
        public decimal importeMonLocal { get; set; }
        public string empqNombre { get; set; }
        public int  empqCont  { get; set; }
        public bool isPesado { get; set; }
        public decimal cant { get; set; }
        //
        public string cantidadInfo { get { return isPesado ? cant.ToString("n3") : cant.ToString("n0"); } }
        public string empaqueInfo { get { return empqNombre.Trim() + "/" + empqCont.ToString().Trim(); } }
    }
}