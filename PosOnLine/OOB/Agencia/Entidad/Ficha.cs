﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Agencia.Entidad
{

    public class Ficha: BaseFicha
    {

        public string auto { get; set; }


        public Ficha() 
        {
            auto = "";
            nombre = "";
        }

    }

}
