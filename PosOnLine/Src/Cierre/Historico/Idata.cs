using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cierre.Historico
{
    public interface Idata
    {
        int id { get; set; }
        string idEquipo { get; set; }
        string fechaHora { get; set; }
        string cierreNro { get; set; }
    }
}
