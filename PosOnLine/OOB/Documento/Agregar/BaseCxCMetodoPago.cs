﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Documento.Agregar
{

    public class BaseCxCMetodoPago
    {

        public string AutoMedioPago { get; set; }
        public string AutoAgencia { get; set; }
        public string Medio { get; set; }
        public string Codigo { get; set; }
        public decimal MontoRecibido { get; set; }
        public string EstatusAnulado { get; set; }
        public string Numero { get; set; }
        public string Agencia { get; set; }
        public string AutoUsuario { get; set; }
        public string Lote { get; set; }
        public string Referencia { get; set; }
        public string AutoCobrador { get; set; }
        public string CierreFtp { get; set; }
        public string Cierre { get; set; }

    }

}