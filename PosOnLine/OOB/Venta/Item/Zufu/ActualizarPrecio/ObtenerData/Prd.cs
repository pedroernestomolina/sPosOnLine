using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Venta.Item.Zufu.ActualizarPrecio.ObtenerData
{
    public class Prd
    {
        public string esDivisa { get; set; }
        public decimal costoEmpCompraMonDiv { get; set; }
        public decimal costoEmpCompraMonAct { get; set; }
        public int contEmpCompra { get; set; }
        public bool ManejadoEnDivisa { get { return esDivisa.Trim().ToUpper() == "1"; } }
        public string ManejadoEnDivisaDesc { get { return esDivisa.Trim().ToUpper() == "1" ? "SI" : "NO"; } }
        public decimal CostoUndMonDiv
        { 
            get 
            {
                var rt = 0m;
                if (contEmpCompra > 0) 
                {
                    rt = costoEmpCompraMonDiv / contEmpCompra;
                }
                return rt;
            } 
        }
        public decimal CostoUndMonAct
        {
            get
            {
                var rt = 0m;
                if (contEmpCompra > 0)
                {
                    rt = costoEmpCompraMonAct / contEmpCompra;
                }
                return rt;
            }
        }
    }
}