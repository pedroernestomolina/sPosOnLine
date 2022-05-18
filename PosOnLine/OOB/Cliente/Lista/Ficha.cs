﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Cliente.Lista
{
    
    public class Ficha
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string ciRif { get; set; }
        public string nombre { get; set; }
        public string estatus { get; set; }
        public string dirFiscal { get; set; }

        public Ficha()
        {
            auto = "";
            codigo = "";
            ciRif = "";
            nombre = "";
            dirFiscal = "";
        }

    }

}