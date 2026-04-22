using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.OOB.PedidoWeb
{
    public enum EnumEstatusActual { SinDefinir=-1, SinProcesar=0, Procesado};
    public class Entidad
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string NombreEntidad { get; set; }
        public string CiRifEntidad { get; set; }
        public string DirEntidad { get; set; }
        public string TelefonoEntidad { get; set; }
        public string IdSucursal { get; set; }
        public string IdDeposito { get; set; }
        public decimal ImporteMonRef { get; set; }
        public decimal ImporteMonLocal { get; set; }
        public decimal TasaCambio { get; set; }
        public decimal TasaSistema { get; set; }
        public int CntArticulos { get; set; }
        public int CntItems { get; set; }
        public int PedidoNro { get; set; }
        public bool IsAnulado { get; set; }
        public EnumEstatusActual EstatusActual { get; set; }
        public string DescSucursal { get; set; }
        public string DescDeposito { get; set; }
        public int IdWebCliente { get; set; }
        public List<Detalle> Detalles { get; set; }
        //
        public Entidad()
        {
            Id = 0;
            FechaRegistro = DateTime.Now;
            NombreEntidad = "";
            CiRifEntidad = "";
            DirEntidad = "";
            TelefonoEntidad = "";
            IdSucursal = "";
            IdDeposito = "";
            ImporteMonRef = 0.0m;
            ImporteMonLocal = 0.0m;
            TasaCambio = 0.0m;
            TasaSistema = 0.0m;
            CntArticulos = 0;
            CntItems = 0;
            PedidoNro = 0;
            IsAnulado = false;
            EstatusActual = EnumEstatusActual.SinProcesar;
            DescSucursal = "";
            DescDeposito = "";
            IdWebCliente = 0;
            Detalles = new List<Detalle>();
        }
    }
    public class Detalle
    {
        public int Id { get; set; }
        public string IdProducto { get; set; }
        public string DescProducto { get; set; }
        public string DescWebProducto { get; set; }
        public int CntSolicitada { get; set; }
        public string IdEmpq { get; set; }
        public string DescEmpq { get; set; }
        public int ContEmpq { get; set; }
        public string EstatusPrdHot { get; set; }
        public string EstatusPrdDivisa { get; set; }
        public decimal PrecioNetoMonLocal { get; set; }
        public decimal PrecioFullMonRef { get; set; }
        public decimal ImporteNetoMonLocal { get; set; }
        public decimal ImporteMonRef { get; set; }
        //
        public Detalle()
        {
            Id = 0;
            IdProducto = "";
            DescProducto = "";
            DescWebProducto = "";
            CntSolicitada = 0;
            IdEmpq = "";
            DescEmpq = "";
            ContEmpq = 0;
            EstatusPrdHot = "";
            EstatusPrdDivisa = "";
            PrecioNetoMonLocal = 0.0m;
            PrecioFullMonRef = 0.0m;
            ImporteNetoMonLocal = 0.0m;
            ImporteMonRef = 0.0m;
        }
    }

    public class FiltrarLista 
    {
        public bool FiltrarSoloActivo { get; set; }
        public EnumEstatusActual FiltrarPorEstatusActual { get; set; }
    }
}
