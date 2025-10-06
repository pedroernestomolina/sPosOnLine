using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosItemCambiarPrecio.Domain.Models
{
    public class ItemCambio
    {
        public decimal TasaDivisaPos { get; set; }
        public decimal TasaDivisaSistema { get; set; }
        public decimal PorctAumentoPrdNoAdmPorDivisa { get; set; }
        public Item Item { get; set; }
        //
        public string ProductoInfo { get { return Item.codigoPrd + Environment.NewLine + Item.descPrd; } }
        public decimal PrecioPagoBs{ get { return precioPagoBs(); } }
        public decimal PrecioPagoDivisa { get { return precioPagoDivisa(); } }
        public decimal PrecioPagoPrdNoDivisa { get { return precioPagoPrdNoDivisa(); } }
        public decimal PorctBonoPorPagoDivsa
        {
            get 
            {
                var rt = 0m;
                if (TasaDivisaSistema > 0m) 
                {
                    rt = (1 - (TasaDivisaPos / TasaDivisaSistema)) * 100;
                    rt = Math.Round(rt, 4, MidpointRounding.AwayFromZero);
                }
                return rt;
            }
        }
        //
        private decimal precioPagoBs()
        {
            var rt = 0m;
            if (Item.isAdmPorDivisa)
            {
                rt = (Item.pNetoMonLocal/TasaDivisaPos);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                rt = Item.pNetoMonReferencia;
            }
            return rt;
        }
        private decimal precioPagoPrdNoDivisa()
        {
            var rt = 0m;
            if (!Item.isAdmPorDivisa)
            {
                rt = Item.pNetoMonReferencia * ((100m - PorctBonoPorPagoDivsa) / 100m);
                rt = rt * ((PorctAumentoPrdNoAdmPorDivisa / 100m) + 1m);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            return rt;
        }

        private decimal precioPagoDivisa()
        {
            var rt = 0m;
            if (Item.isAdmPorDivisa)
            {
                rt = Item.pNetoMonReferencia;
            }
            else
            {
                rt = Item.pNetoMonReferencia * ((100m-PorctBonoPorPagoDivsa) / 100m);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            return rt;
        }
    }
}