using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.PosCambioPrecio.ProcesarCambiar
{
    public class DataItem
    {
        public int idItem { get; set; }
        public int idOperador { get; set; }
        public decimal pNetoMonAct { get; set; }
        public decimal pFullMonDiv  { get; set; }
        public string AplicarPorcAumentoPrdNoDivisa { get; set; }
    }
}