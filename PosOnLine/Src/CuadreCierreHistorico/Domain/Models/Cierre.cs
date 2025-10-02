using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreHistorico.Domain.Models
{
    public class Cierre
    {
        public int idOperador { get; set; }
        public int idResumen { get; set; }
        public string idArqueo { get; set; }
        public string fechaHoraCierre { get; set; }
        public string nroCierre { get; set; }
        public string terminal { get; set; }
        public string fechaHoraApertura { get; set; }
        public string Usuario{ get; set; }
        public string CabFechaHoraCierre { get { return fechaHoraCierre; } }
        public string CabTerminal{ get { return terminal; } }
        public string CabNroCierre { get { return nroCierre; } }
    }
}