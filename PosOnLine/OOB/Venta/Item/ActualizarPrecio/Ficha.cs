using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Venta.Item.ActualizarPrecio
{

    public class Ficha
    {

        public int idOperador { get; set; }
        public int idItem { get; set; }
        public decimal precioNeto { get; set; }
        public decimal precioDivisa { get; set; }
        public string tarifaVenta { get; set; }
        

        public Ficha()
        {
            idOperador = -1;
            idItem = -1;
            precioNeto = 0.0m;
            precioDivisa = 0.0m;
            tarifaVenta = "";
        }

    }

}