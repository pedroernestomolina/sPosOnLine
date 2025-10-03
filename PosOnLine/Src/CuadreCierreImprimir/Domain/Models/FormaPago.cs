using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreImprimir.Domain.Models
{
    public class FormaPago
    {
        public string codigoMP { get; set; }
        public string descMP { get; set; }
        public string codigoMon { get; set; }
        public string descMon { get; set; }
        public string simboloMon { get; set; }
        public decimal tasaFactorPonderadoMon { get; set; }
        public decimal montoSegunSistema { get; set; }
        public decimal montoSegunUsuario { get; set; }
        public decimal importeMonLocal { get; set; }
        //
        public string diferenciaDesc 
        { 
            get
            { 
                var rt = "";
                var dif = montoSegunSistema - montoSegunUsuario;
                if (dif > 0m) 
                {
                    rt = Math.Abs(dif).ToString("n2")+" En Contra";
                }
                else if (dif < 0m)
                {
                    rt = Math.Abs(dif).ToString("n2")+" A Favor";
                }
                else
                {
                    rt = Math.Abs(dif).ToString("n2")+" Ok";
                }
                return rt;
            } 
        }
    }
}