using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreImprimir.Domain.Models
{
    public class DataCierre
    {
        public string fechaHoraCierre { get; set; }
        public string nroCierre { get; set; }
        public string terminal { get; set; }
        public string fechaHoraApertura { get; set; }
        public string Usuario { get; set; }
    }
}