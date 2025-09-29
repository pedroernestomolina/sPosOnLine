using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmAnularDoc.Domain.Models
{
    public class DataAnular
    {
        public Documento doc { get; set; }
        public List<Kardex> kardex { get; set; }
    }
}