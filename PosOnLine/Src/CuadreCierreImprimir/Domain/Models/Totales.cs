using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreImprimir.Domain.Models
{
    public class Totales
    {
        public string estatusCuadre { get; set; }
        public decimal totalCuadreMonLocal { get; set; }
        public decimal totalCajaSegunSistemaMonLocal { get; set; }
        public decimal totalCajaSegunUsuarioMonLocal { get; set; }
        public decimal vueltoCambioPorEfectivo { get; set; }
        public decimal vueltoCambioPorDivisa { get; set; }
        public decimal vueltoCambioPorPagoMovil { get; set; }
        public int cntDivisaPorVuelto { get; set; }
    }
}