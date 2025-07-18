using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pos.Modelos
{
    public class precioQR
    {
        public string idPrd { get; set; }
        public string descPrd { get; set; }
        public string esAdmDivisa { get; set; }
        public decimal precioFact { get; set; }
        public decimal porctBonoAplicar { get; set; }
        public decimal porctAumentoPrecioAplicar { get; set; }
        public decimal porctBonoCalculado { get; set; }
        public decimal precioCliente { get { return calcPrecioCliente(); } }
        public bool isPorDivisa { get { return esAdmDivisa.Trim().ToUpper() == "1"; } }
        public bool aplicaPorctAumento { get { return !isPorDivisa; } }
        //
        private decimal calcPrecioCliente()
        {
            var rt = precioFact;
            if (porctBonoAplicar > 0m) 
            {
                var dsct = precioFact * (porctBonoAplicar / 100m);
                rt -= dsct;
                if (esAdmDivisa.Trim().ToUpper() != "1") 
                {
                    if (porctAumentoPrecioAplicar > 0m) 
                    {
                        var aumento = rt * (porctAumentoPrecioAplicar / 100m);
                        rt += aumento;
                    }
                }
            }
            return rt;
        }
    }
}