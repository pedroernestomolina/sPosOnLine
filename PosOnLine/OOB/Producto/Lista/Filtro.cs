using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Producto.Lista
{
    
    public class Filtro
    {

        public string autoDeposito { get; set; }
        public string cadena { get; set; }
        public string idPrecioManejar { get; set; }
        public bool isPorPlu { get; set; }


        public Filtro()
        {
            cadena = "";
            autoDeposito = "";
            idPrecioManejar = "";
            isPorPlu = false;
        }


    }

}