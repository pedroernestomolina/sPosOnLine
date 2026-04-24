using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PedidoWeb.Domain.Models
{
    public class EntidadWeb
    {
        public string IdCliente { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string CiRifCliente { get; set; }
        public string DirFiscalCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public bool IsActivoCliente { get; set; }
        public bool IsActivoCredito { get; set; }
        public EntidadWeb()
        {
            IdCliente = "";
            CodigoCliente = "";
            NombreCliente = "";
            CiRifCliente = "";
            DirFiscalCliente = "";
            TelefonoCliente = "";
            IsActivoCliente = true;
            IsActivoCredito = false;
        }
    }
}