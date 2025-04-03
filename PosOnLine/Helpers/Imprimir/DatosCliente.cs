using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    public class DatosCliente
    {
        public string cirif { get; set; }
        public string nombre_1 { get; set; }
        public string nombre_2 { get; set; }
        public string dirFiscal_1 { get; set; }
        public string dirFiscal_2 { get; set; }
        public string telefono_1 { get; set; }
        public string condicionpago { get; set; }
        public string estacion { get; set; }
        public string usuario { get; set; }
        public DatosCliente()
        {
            Limpiar();
        }
        public void Limpiar()
        {
            cirif = "";
            nombre_1 = "";
            nombre_2 = "";
            dirFiscal_1 = "";
            dirFiscal_2 = "";
            telefono_1 = "";
            condicionpago = "";
            usuario = "";
            estacion = "";
        }
    }
}
