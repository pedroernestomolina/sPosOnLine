using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosItemCambiarPrecio.Domain.Models
{
    public class Item
    {
        public int idItem { get; set; }
        public int idOperador { get; set; }
        public string codigoPrd { get; set; }
        public string descPrd { get; set; }
        public decimal pNetoMonLocal { get; set; }
        public decimal pFullMonReferencia { get; set; }
        public decimal tasaIva { get; set; }
        public int contEmpqVta { get; set; }
        public bool isAdmPorDivisa { get; set; }
        public decimal costoEmpqUndMonLocal { get; set; }
        public int contEmpqCompra { get; set; }
        public decimal costoEmpqCompraMonReferencia { get; set; }
        public decimal pActualNetoMonLocal { get; set; }
        public decimal pActualFullMonReferencia { get; set; }
        public string descEmpqVta { get; set; }
        public bool aplicaPorcAumento { get; set; }
        //
        public string empaqVenta { get { return descEmpqVta + "/" + contEmpqVta.ToString(); } }
        public decimal pNetoMonReferencia { get { return get_Neto(pFullMonReferencia, tasaIva); } }
        public decimal pActualNetoMonReferencia { get { return get_Neto(pActualFullMonReferencia, tasaIva); } }
        public decimal costoPorUndEmpqCompraMonReferencia 
        { 
            get
            {
                var rt = 0m;
                if (contEmpqCompra>0m)
                {
                    rt = costoEmpqCompraMonReferencia / contEmpqCompra;
                    rt = Math.Round(rt, 4, MidpointRounding.AwayFromZero);
                }
                return rt;
            }
        }
        public decimal costoEmpqVtaMonReferencia
        { 
            get 
            {
                var rt = 0m;
                rt = costoPorUndEmpqCompraMonReferencia * contEmpqVta;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        public decimal costoEmpqVtaMonLocal 
        { 
            get 
            {
                var rt = 0m;
                rt = costoEmpqUndMonLocal * contEmpqVta;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        //
        public void setPrecioNetoMonLocal(decimal precio)
        {
            pNetoMonLocal = precio;
        }
        public void setPrecioFullMonReferencia(decimal precio)
        {
            pFullMonReferencia = precio;
        }
        //
        private decimal get_Neto(decimal pfull, decimal tasaIva)
        {
            var rt = pfull;
            if (tasaIva > 0m)
            {
                rt = pfull / ((tasaIva / 100m) + 1m);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            return rt;
        }
        public decimal Full(decimal monto)
        {
            var rt = monto;
            if (tasaIva > 0m) 
            {
                rt=monto * ((tasaIva / 100m) + 1m);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            return rt;
        }
    }
}