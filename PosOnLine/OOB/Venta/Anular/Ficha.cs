using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Venta.Anular
{
    
    public class Ficha
    {
        public int IdOperador { get; set; }
        public List<FichaItem> items { get; set; }
        public List<FichaDeposito> itemDeposito { get; set; }
        //
        public Ficha()
        {
            IdOperador = -1;
            items = new List<FichaItem>();
            itemDeposito = new List<FichaDeposito>();
        }
    }
}