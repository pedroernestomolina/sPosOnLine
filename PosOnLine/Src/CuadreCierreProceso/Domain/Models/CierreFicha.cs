using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreProceso.Domain.Models
{
    public class CierreFicha
    {
        public int idResumen { get; set; }
        public CierreTotales cierreTotal { get; set; }
        public List<CierrePorDocumento> cierrePorDoc { get; set; }
        public List<CierrePorMetodoPago> cierrePorMetPago { get; set; }
        //
        public CierreFicha()
        {
            idResumen = -1;
            cierreTotal = new CierreTotales();
            cierrePorDoc = new List<CierrePorDocumento>();
            cierrePorMetPago = new List<CierrePorMetodoPago>();
        }
        public void Inicializa()
        {
            idResumen = -1;
            cierreTotal.Inicializa();
            cierrePorDoc.Clear();
            cierrePorMetPago.Clear();
        }
    }
}