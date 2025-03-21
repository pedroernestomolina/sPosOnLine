using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ListaProducto
{
    public interface Idata
    {
        string CodigoPrd { get; set; }
        string NombrePrd { get; set; }
        string ExTotalPrd { get; set; }
    }
}
