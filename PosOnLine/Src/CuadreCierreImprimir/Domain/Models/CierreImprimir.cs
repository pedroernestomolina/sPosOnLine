using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreImprimir.Domain.Models
{
    public class CierreImprimir
    {
        public DataCierre dataCierre { get; set; }
        public List<TipoDocumento> tiposDoc { get; set; }
        public List<FormaPago> formasPago { get; set; }
        public Totales totales { get; set; }
    }
}
