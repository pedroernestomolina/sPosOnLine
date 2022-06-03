﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Reportes.Pos.PagoMovil
{
    
    public class Ficha
    {

        public string docNro { get; set; }
        public string pmNombre { get; set; }
        public string pmCiRif { get; set; }
        public string pmTelefono { get; set; }
        public decimal pmMonto { get; set; }
        public string agencia { get; set; }
        public DateTime docFecha { get; set; }
        public string docRazonSocial { get; set; }
        public string docCiRif { get; set; }
        public string docEstatusAnulado { get; set; }
        public bool docIsAnulado { get { return docEstatusAnulado.Trim().ToUpper() == "1" ? true : false; } }


        public Ficha()
        {
            agencia = "";
            docNro = "";
            docCiRif = "";
            docEstatusAnulado = "";
            docFecha = DateTime.Now.Date;
            docRazonSocial = "";
            pmCiRif = "";
            pmMonto = 0m;
            pmNombre = "";
            pmTelefono = "";
        }

    }

}