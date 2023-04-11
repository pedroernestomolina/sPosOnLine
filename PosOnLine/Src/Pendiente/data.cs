﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pendiente
{
    
    public class data
    {
        private OOB.Pendiente.Lista.Ficha _it;


        public DateTime Fecha { get { return _it.fecha; } }
        public string Cliente { get { return _it.nombreCliente; } }
        public decimal Importe { get { return _it.monto; } }
        public decimal ImporteDivisa { get { return _it.montoDivisa; } }
        public int Renglones { get { return _it.renglones; } }
        public OOB.Pendiente.Lista.Ficha Ficha { get { return _it; } }
        public string UsuCodigo { get { return _it.usuCodigo.Trim(); } }
        public string Usuario { get { return _it.usuDescripcion.Trim(); } }
        public string Vendedor { get { return _it.codVend.Trim() + "(" + _it.nombreVend.Trim() + ")"; } }


        public data(OOB.Pendiente.Lista.Ficha it)
        {
            this._it = it;
        }
    }
}