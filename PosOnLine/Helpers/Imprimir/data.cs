using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    
    public class data
    {

        public class Negocio 
        {
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string CiRif { get; set; }
            public string Telefonos { get; set; }

            public Negocio()
            {
                Nombre = "";
                Direccion = "";
                CiRif = "";
                Telefonos = "";
            }
        }

        public class Encabezado
        {
            public string DocumentoNombre { get; set; }
            public string DocumentoNro { get; set; }
            public DateTime DocumentoFecha { get; set; }
            public string DocumentoControl { get; set; }
            public string DocumentoSerie { get; set; }
            public string DocumentoCondicionPago { get; set; }
            public DateTime DocumentoFechaVencimiento { get; set; }
            public int DocumentoDiasCredito { get; set; }
            public string DocumentoAplica { get; set; }
            public string DocumentoHora { get; set; }

            public string NombreCli { get; set; }
            public string DireccionCli { get; set; }
            public string CiRifCli { get; set; }
            public string CodigoCli { get; set; }
            public string TelefonoCli { get; set; }

            public decimal FactorCambio { get; set; }
            public decimal SubTotal { get; set; }
            public decimal Descuento { get; set; }
            public decimal DescuentoPorc { get; set; }
            public decimal Cargo{ get; set; }
            public decimal CargoPorc { get; set; }
            public decimal Total { get; set; }
            public decimal TotalDivisa { get; set; }
            public decimal CambioDar{ get; set; }

            public string EstacionEquipo { get; set; }
            public string Usuario { get; set; }

            public decimal SubTotalItemFull 
            { 
                get 
                {
                    var r = 0.0m;
                    r = SubTotal + Descuento - Cargo;
                    return r;
                } 
            }


            public Encabezado()
            {
                NombreCli = "";
                DireccionCli = "";
                CiRifCli = "";
                CodigoCli = "";
                TelefonoCli = "";

                DocumentoAplica = "";
                DocumentoCondicionPago = "";
                DocumentoControl = "";
                DocumentoDiasCredito = 0;
                DocumentoFecha = DateTime.Now.Date;
                DocumentoFechaVencimiento = DateTime.Now.Date;
                DocumentoNombre = "";
                DocumentoNro = "";
                DocumentoSerie = "";
                DocumentoHora = "";

                FactorCambio = 0.0m;
                SubTotal = 0.0m;
                Descuento = 0.0m;
                DescuentoPorc = 0.0m;
                Cargo = 0.0m;
                CargoPorc = 0.0m;
                CambioDar = 0.0m;
                Total = 0.0m;
                TotalDivisa = 0.0m;

                EstacionEquipo = "";
                Usuario = "";
            }

        }

        public class Item
        {
            public string NombrePrd { get; set; }
            public string CodigoPrd { get; set; }
            public decimal Cantidad { get; set; }
            public string Empaque { get; set; }
            public int Contenido { get; set; }
            public string DepositoCodigo { get; set; }
            public string DepositoDesc { get; set; }
            public decimal Precio { get; set; }
            public decimal PrecioDivisa { get; set; }
            public decimal Importe { get; set; }
            public decimal ImporteFull { get; set; }
            public decimal ImporteDivisa { get; set; }
            public decimal TotalUnd { get; set; }
            public decimal TasaIva { get; set; }
            public bool EsExento { get { return TasaIva == 0.0m; } }
            public decimal PrecioFull 
            { 
                get 
                {
                    var r = Precio;
                    if (!EsExento)
                    {
                        r = Precio + (Precio * TasaIva / 100);
                        r = Math.Round(r, 2, MidpointRounding.AwayFromZero);
                    }
                    return r; 
                }
            }


            public Item()
            {
                NombrePrd = "";
                CodigoPrd = "";
                Cantidad = 0.0m;
                Empaque = "";
                Contenido = 0;
                DepositoCodigo = "";
                DepositoDesc = "";
                Precio = 0.0m;
                PrecioDivisa = 0.0m;
                Importe = 0.0m;
                ImporteFull = 0.0m;
                ImporteDivisa = 0.0m;
                TotalUnd = 0.0m;
                TasaIva = 0.0m;
            }

        }

        public class MetodoPago 
        {
            public string descripcion { get; set; }
            public decimal monto { get; set; }


            public MetodoPago()
            {
                descripcion = "";
                monto = 0.0m;
            }
        }

        public Negocio negocio { get; set; }
        public Encabezado encabezado { get; set; }
        public List<Item> item { get; set; }
        public List<MetodoPago> metodoPago { get; set; }

    }

}
