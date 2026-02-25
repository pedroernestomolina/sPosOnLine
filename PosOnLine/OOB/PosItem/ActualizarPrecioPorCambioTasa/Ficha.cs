using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.PosItem.ActualizarPrecioPorCambioTasa
{
    public class Ficha
    {
        public decimal TasaPos { get; set; }
        public int IdOperador { get; set; }
        public List<Item> items { get; set; }
        public Ficha()
        {
            TasaPos = 0m;
            IdOperador = -1;
            items = new List<Item>();
        }
    }
}