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
        public bool ProductoIsAdmPorDivisa { get { return Item.isAdmPorDivisa; } }
        public string ProductoInfo { get { return Item.codigoPrd + Environment.NewLine + Item.descPrd; } }
        public decimal PrecioPagoBs{ get { return precioPagoBs(); } }
        public decimal PrecioPagoDivisa { get { return precioPagoDivisa(); } }
        public decimal PrecioPagoPrdNoDivisa { get { return precioPagoPrdNoDivisa(); } }
        public decimal PrecioActualPagoBs { get { return precioActualPagoBs(); } }
        public decimal CostoEmpqVta { get { return Item.costoEmpqVtaMonReferencia; } }
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
        public void setPrecioPagoBs(decimal monto)
        {
            var _pNetoMonLocal = 0m;
            var _pNetoMonReferencia = 0m;
            var _pFullMonReferencia = 0m;
            //
            if (ProductoIsAdmPorDivisa)
            {
                _pNetoMonLocal = monto * TasaDivisaPos;
                _pNetoMonLocal = Math.Round(_pNetoMonLocal, 2, MidpointRounding.AwayFromZero);
                _pNetoMonReferencia = _pNetoMonLocal / TasaDivisaSistema;
                _pNetoMonReferencia = Math.Round(_pNetoMonReferencia, 2, MidpointRounding.AwayFromZero);
                _pFullMonReferencia = Item.Full(_pNetoMonReferencia);
            }
            else
            {
                _pNetoMonLocal = monto * TasaDivisaPos;
                _pNetoMonLocal = Math.Round(_pNetoMonLocal, 2, MidpointRounding.AwayFromZero);
                _pFullMonReferencia = Item.Full(monto);
            }
            //
            Item.setPrecioNetoMonLocal(_pNetoMonLocal);
            Item.setPrecioFullMonReferencia(_pFullMonReferencia);
        }
        public void setPrecioPagoProductoNoDivisa(decimal monto)
        {
            var _pNetoMonLocal = 0m;
            var _pFullMonReferencia = 0m;
            //
            if (ProductoIsAdmPorDivisa)
            {
            }
            else 
            {
                var rt = monto / ((PorctAumentoPrdNoAdmPorDivisa / 100m) + 1m);
                rt = rt / ((100m - PorctBonoPorPagoDivsa) / 100m);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                //
                _pNetoMonLocal = rt * TasaDivisaPos;
                _pNetoMonLocal = Math.Round(_pNetoMonLocal, 2, MidpointRounding.AwayFromZero);
                _pFullMonReferencia = Item.Full(rt);
            }
            //
            Item.setPrecioNetoMonLocal(_pNetoMonLocal);
            Item.setPrecioFullMonReferencia(_pFullMonReferencia);
        }
        public void setPrecioPagoDivisa(decimal monto)
        {
            var _pNetoMonLocal = 0m;
            var _pNetoMonReferencia = 0m;
            var _pFullMonReferencia = 0m;
            //
            if (ProductoIsAdmPorDivisa)
            {
                _pNetoMonLocal = monto * TasaDivisaSistema;
                _pNetoMonLocal = Math.Round(_pNetoMonLocal, 2, MidpointRounding.AwayFromZero);
                _pFullMonReferencia = Item.Full(monto);
            }
            else
            {
                _pNetoMonReferencia = monto / ((100m - PorctBonoPorPagoDivsa) / 100m);
                _pNetoMonReferencia = Math.Round(_pNetoMonReferencia, 2, MidpointRounding.AwayFromZero);
                _pNetoMonLocal = _pNetoMonReferencia * TasaDivisaPos;
                _pNetoMonLocal = Math.Round(_pNetoMonLocal, 2, MidpointRounding.AwayFromZero);
                _pFullMonReferencia = Item.Full(_pNetoMonReferencia);
            }
            //
            Item.setPrecioNetoMonLocal(_pNetoMonLocal);
            Item.setPrecioFullMonReferencia(_pFullMonReferencia);
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
        private decimal precioActualPagoBs()
        {
            var rt = 0m;
            if (Item.isAdmPorDivisa)
            {
                rt = (Item.pActualNetoMonLocal / TasaDivisaPos);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                rt = Item.pActualNetoMonReferencia;
            }
            return rt;
        }

    }
}