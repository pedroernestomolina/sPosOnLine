﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Documento.Agregar
{
    
    abstract public class BasePagoMovil
    {

        public string autoAgencia { get; set; }
        public string nombre { get; set; }
        public string ciRif { get; set; }
        public string telefono { get; set; }
        public decimal monto { get; set; }

    }

}