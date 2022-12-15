using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pago.Procesar
{
    
    public class dataRecolectar
    {

        public decimal PorctBonoPorPagoDivisa { get; set; }
        public decimal CantDivisaAplicaBonoPorPagoDivisa { get; set; }
        public decimal MontoBonoPorPagoDivisa { get; set; }
        public decimal MontoBonoEnDivisaPorPagoDivisa { get; set; }
        public decimal MontoPorVueltoEnEfectivo { get; set; }
        public decimal MontoPorVueltoEnDivisa { get; set; }
        public decimal MontoPorVueltoEnPagoMovil { get; set; }
        public int CantDivisaPorVueltoEnDivisa { get; set; }
        public bool AplicaPagoMovil { get { return DataPagoMovil != null; } }
        public PagoMovil.data DataPagoMovil { get; set; }
        public string estatusPorBonoPorPagoDivisa {get {return MontoBonoPorPagoDivisa>0 ? "1":"0";}}


        public dataRecolectar()
        {
            Limpiar();
        }


        public void Limpiar() 
        {
            PorctBonoPorPagoDivisa = 0m;
            CantDivisaAplicaBonoPorPagoDivisa = 0m;
            MontoBonoPorPagoDivisa = 0m;
            MontoBonoEnDivisaPorPagoDivisa = 0m;
            MontoPorVueltoEnEfectivo = 0m;
            MontoPorVueltoEnDivisa = 0m;
            MontoPorVueltoEnPagoMovil = 0m;
            CantDivisaPorVueltoEnDivisa = 0;
            DataPagoMovil = null;
        }

    }

}