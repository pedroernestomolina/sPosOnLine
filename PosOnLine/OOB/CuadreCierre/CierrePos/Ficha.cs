using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.CuadreCierre.CierrePos
{
    public class Ficha
    {
        public int idResumen { get; set; }
        public string codigoSucursal { get; set; }
        public Total totales { get; set; }
        public List<Documento> documentos { get; set; }
        public List<MetodoPago> metPago { get; set; }
        public Pos.Cerrar.Ficha MetodoViejo { get; set; }
    }
}