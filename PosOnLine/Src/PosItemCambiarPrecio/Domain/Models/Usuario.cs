using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosItemCambiarPrecio.Domain.Models
{
    public class Usuario
    {
        public string idUsu { get; set; }
        public string codigoUsu { get; set; }
        public string NombreUsu { get; set; }
        public Usuario()
        {
            idUsu = "";
            codigoUsu = "";
            NombreUsu = "";
        }
    }
}
