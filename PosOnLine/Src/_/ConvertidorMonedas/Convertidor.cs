using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.__.ConvertidorMonedas
{
    public class Monto 
    {
        public decimal cantidad { get; set; }
        public string codigoMoneda { get; set; }
    }
    public class Convertidor
    {
        public Dictionary<string, decimal> TasaCambio { get; set; }
        public Convertidor()
        {
            TasaCambio = new Dictionary<string, decimal>();
        }
        public decimal Convertir(Monto monto, string codigoMoneda) 
        {
            try
            {
                if (monto.codigoMoneda == codigoMoneda)
                {
                    return Math.Round(monto.cantidad,2, MidpointRounding.AwayFromZero);
                }

                //Convertir el monto original a moneda base (Dolar)
                decimal montoDolares = monto.cantidad / TasaCambio[monto.codigoMoneda];

                //Convertir desde la moneda base a la moneda Destino
                decimal rt =montoDolares * TasaCambio[codigoMoneda];
                return Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            catch(KeyNotFoundException e1)
            {
                throw new Exception("MONEDA NO REGISTRADA");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}