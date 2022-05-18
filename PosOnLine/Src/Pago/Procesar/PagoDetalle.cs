using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.Procesar
{
    
    public class PagoDetalle
    {

        public int Id { get; set; }
        public Enumerados.ModoPago Modo { get; set; }
        public decimal Tasa { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Monto { get; set; }
        public string Lote { get; set; }
        public string Referencia { get; set; }
        public string TarjetaNro { get; set; }
        public decimal Importe { get; set; }
        public decimal MontoRecibido { get; set; }

    }

}
