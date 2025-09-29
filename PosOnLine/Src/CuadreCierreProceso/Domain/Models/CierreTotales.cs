using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreProceso.Domain.Models
{
    public class CierreTotales
    {
        public decimal vueltoCambioPorEfectivo { get; set; }
        public decimal vueltoCambioPorDivisa { get; set; }
        public decimal vueltoCambioPorPagoMovil { get; set; }
        public int cntDivisaPorVuelto { get; set; }
        public decimal totalCuadreMonLocal { get; set; }
        public string estatusCuadre { get; set; }
        public decimal totalCajaSegunSistemaMonLocal { get; set; }
        public decimal totalCajaSegunUsuarioMonLocal { get; set; }
        public CierreTotales()
        {
        }
        public  void Inicializa()
        {
            vueltoCambioPorEfectivo = 0m;
            vueltoCambioPorDivisa = 0m;
            cntDivisaPorVuelto = 0;
            totalCuadreMonLocal = 0m;
            estatusCuadre = "";
            totalCajaSegunSistemaMonLocal = 0m;
            totalCajaSegunUsuarioMonLocal = 0m;
            vueltoCambioPorPagoMovil = 0m;
        }
    }
}