﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Sistema.MedioPago.Entidad
{
    
    public class Ficha
    {

        public string id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }


        public Ficha()
        {
            id = "";
            codigo = "";
            nombre = "";
        }

    }

}