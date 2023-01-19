using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Reportes.Pos.MovCaja
{
    public class Ficha
    {
        public List<FichaMov> mov { get; set; }
        public List<FichaDet> det { get; set; }
    }
}