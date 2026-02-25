using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.Pos.Domain.Models
{
    public class PosPrdFiltrarLista 
    {
        public string PorIdDeposito { get; set; }
        public string CadenaBuscar  { get; set; }
        public string PorIdPrecioManejar { get; set; }
        public bool IsPorPlu  { get; set; }
    }
    public class PosPrdEmpaque 
    {
        public int contEmp { get; set; }
        public string descEmp { get; set; }
    }
    public class PosPrdPrecio 
    {
        public decimal pnetoEmp { get; set; }
        public decimal pfullDiv { get; set; }
        //public decimal pfullEmp { get; }
        //public decimal pnetoDiv { get; }
        //public decimal pnetoUnd { get; }
        //public decimal pfullUnd { get; }
        //public decimal pnetoDivUnd { get; }
        //public decimal pfullDivUnd { get; }
    }
    public class PosPrdExistencia 
    {
        public decimal Fisica { get; set; }
        public decimal Disponible { get; set; }
    }
    public class PosPrdInfo
    {
        public string IdPrd { get; set; }
        public string CodigoPrd { get; set; }
        public string CodigoPLUPrd { get; set; }
        public string NombrePrd { get; set; }
        public bool IsActivo { get; set; }
        public bool IsPorDivisa { get; set; }
        public bool IsPesado { get; set; }
        public decimal TasaIvaFiscal { get; set; }
        public string DescTasaIvaFiscal { get; set; }
        public string CntDecimalesManejar { get; set; }
        public byte[] ImagenPrd { get; set; }
        public bool IsPrecioActualizado { get; set; }
    }
    public class PosProducto
    {
        public PosPrdInfo Info { get; set; }
        public PosPrdEmpaque EmpqCompra { get; set; }
        public PosPrdEmpaque EmpqVta_1 { get; set; }
        public PosPrdEmpaque EmpqVta_2 { get; set; }
        public PosPrdEmpaque EmpqVta_3 { get; set; }
        public PosPrdPrecio PrecioVta_1 { get; set; }
        public PosPrdPrecio PrecioVta_2 { get; set; }
        public PosPrdPrecio PrecioVta_3 { get; set; }
        public PosPrdExistencia Existencia { get; set; }
    }
}