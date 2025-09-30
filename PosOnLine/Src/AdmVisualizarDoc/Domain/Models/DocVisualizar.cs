using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmVisualizarDoc.Domain.Models
{
    public class DocVisualizar
    {
        public Encabezado encabezado { get; set; }
        public List<Cuerpo> cuerpo{ get; set; }
    }
}