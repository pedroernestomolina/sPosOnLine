using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.MovCaja.Agregar
{
    public class medio
    {
        private decimal _factor;

        public Helpers.ficha Ficha { get; set; }
        public bool EsDivisa { get; set; }
        public decimal Monto { get; set; }
        public int Cant { get; set; }
        public decimal Importe { get { return EsDivisa ? (Cant * _factor) : Monto; } }
        public string Medio { get { return Ficha.desc; } }

        public medio()
        {
            Inicializa();
        }
        
        public void Inicializa()
        {
            _factor = 0m;
            Ficha = null;
            EsDivisa = false;
            Monto = 0m;
            Cant = 0;
        }

        public void setFactorCambio(decimal monto)
        {
            _factor = monto;
        }
    }
}