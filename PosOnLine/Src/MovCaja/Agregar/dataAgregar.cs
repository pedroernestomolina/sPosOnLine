using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.MovCaja.Agregar
{
    public class dataAgregar
    {
        public int IdOperador { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Monto { get; set; }
        public decimal FactorCambio { get; set; }
        public string Concepto { get; set; }
        public string Detalles { get; set; }
        public bool EsDivisa { get; set; }
        public decimal Tasa { get { return EsDivisa ? FactorCambio : 1m; } }
        public decimal TotalMov { get { return Monto * Tasa; } }
        public Helpers.ficha TipoMov { get; set; }
        public decimal MontoDivisa 
        {
            get 
            {
                var rt = 0m;
                if (FactorCambio > 0m)
                {
                    rt = TotalMov / FactorCambio;
                }
                return rt;
            }
        }


        public dataAgregar()
        {
            Inicializa();
        }

        public void Inicializa()
        {
            IdOperador = -1;
            FechaEmision = DateTime.Now.Date;
            Monto = 0m;
            FactorCambio = 1m;
            Concepto = "";
            Detalles = "";
            EsDivisa = false;
            TipoMov = null;
        }

        public void IsOk()
        {
            if (TipoMov==null)
                throw new Exception("INDIQUE EL TIPO DE MOVIMIENTO");
            if (Monto <= 0m)
                throw new Exception("MONTO INCORRECTO PARA EL MOVIMIENTO");
            if (FactorCambio <= 0m)
                throw new Exception("FACTOR CAMBIO INCORRECTO PARA EL MOVIMIENTO");
            if (Concepto.Trim()=="")
                throw new Exception("INDIQUE EL CONCEPTO PARA EL MOVIMIENTO");
        }
    }
}