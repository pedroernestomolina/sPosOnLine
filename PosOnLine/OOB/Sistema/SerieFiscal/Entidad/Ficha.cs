﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Sistema.SerieFiscal.Entidad
{
    
    public class Ficha
    {

        public string Auto { get; set; }
        public string Serie { get; set; }
        public string Control { get; set; }


        public Ficha()
        {
            Auto = "";
            Serie = "";
            Control = "";
        }

    }

}