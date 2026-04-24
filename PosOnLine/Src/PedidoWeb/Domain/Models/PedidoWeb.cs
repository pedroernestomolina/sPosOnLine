using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.Domain.Models
{
    public enum EnumEstatusActual { SinDefinir = -1, SinProcesar = 0, Procesado, Pendiente };

    public class PedidoWeb
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
        public List<PedidoWebDetalle> Detalles { get; set; }
        //
        public string PedidoNroDesc { get { return PedidoNro.ToString().Trim().PadLeft(10, '0'); } }
        public DateTime FechaDesc { get { return FechaRegistro.Date; } }
        public string EntidadDesc { get { return NombreEntidad.Trim(); } }
        public string CiRifEntidadDEsc { get { return CiRifEntidad.Trim(); } }
        public string ImporteDesc { get { return ImporteMonRef.ToString("n2"); } }
        public string ItemsDesc { get { return CntItems.ToString(); } }
        //
        public PedidoWeb()
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
            EstatusActual = EnumEstatusActual.SinDefinir;
            DescSucursal = "";
            DescDeposito = "";
            IdWebCliente = 0;
        }
        public void setCambioEstatusPendiente()
        {
            EstatusActual = EnumEstatusActual.Pendiente;
        }
    }

    public class PedidoWebDetalle 
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
        public string ItemDesc { get { return DescProducto; } }
        public string ItemCnt { get { return CntSolicitada.ToString(); } }
        public string ItemEmpq { get { return DescEmpq.Trim() + "x" + ContEmpq.ToString(); } }
        public string ItemPrecio { get { return PrecioFullMonRef.ToString("n2"); } }
        public string ItemImporte { get { return ImporteMonRef.ToString("n2"); } }
        //
        public PedidoWebDetalle()
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
}