using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.CuadreCierre.ObtenerCierre
{
    public class Ficha
    {
        public DateTime fechaCierre { get; set; }
        public string horaCierre { get; set; }
        public string nroCierre { get; set; }
        public string terminal { get; set; }
        public DateTime fechaApertura { get; set; }
        public string horaApertura { get; set; }
        public string codigoSucursal { get; set; }
        public int idResumen { get; set; }
        public string idArqueo { get; set; }
        public string codigoUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public bool isCerradoOperador { get; set; }
        public int idOperador { get; set; }
    }
}