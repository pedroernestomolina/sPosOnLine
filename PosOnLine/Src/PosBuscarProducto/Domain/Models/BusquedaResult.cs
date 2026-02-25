using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PosBuscarProducto.Domain.Models
{
    public class BusquedaResult
    {
        public string IdPrdEncontrado { get; set; }
        public List <Pos.Domain.Models.PosProducto> LstPrdEncontrado { get; set; }
    }
}