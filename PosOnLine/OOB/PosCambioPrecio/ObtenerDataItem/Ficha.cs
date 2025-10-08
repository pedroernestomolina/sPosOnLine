using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.PosCambioPrecio.ObtenerDataItem
{
    public class Ficha
    {
        public int idItem { get; set; }
        public int idOperador { get; set; }
        public string codigoPrd { get; set; }
        public string descPrd { get; set; }
        public decimal pNetoMonLocal { get; set; }
        public decimal pFullMonReferencia { get; set; }
        public decimal tasaIva { get; set; }
        public int contEmpqVta { get; set; }
        public string descEmpqVta { get; set; }
        public bool isAdmPorDivisa { get; set; }
        public int contEmpqCompra { get; set; }
        public decimal costoEmpqCompraMonReferencia { get; set; }
        public decimal costoEmpqUndMonLocal { get; set; }
        public bool aplicaPorcAumento { get; set; }
    }
}