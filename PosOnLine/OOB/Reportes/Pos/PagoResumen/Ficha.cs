﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Reportes.Pos.PagoResumen
{
    
    public class Ficha
    {


        private string _loteCntDivisa ;
        public string loteCntDivisa 
        { 
            get 
            { 
                if (_loteCntDivisa.Trim()=="")
                {
                    _loteCntDivisa="0";
                }
                return _loteCntDivisa;
            }
            set
            {
                _loteCntDivisa = value;
            }
        }
        public string refTasaDivisa { get; set; }
        public string mpCodigo { get; set; }
        public string mpDescripcion { get; set; }
        public decimal montoRecibido { get; set; }
        public string estatusCredito { get; set; }
        public decimal importeDoc { get; set; }
        //
        public bool isDivisa { get { return mpCodigo.Trim().ToUpper() == "02"; } }
        public string lote { get { return isDivisa ? "" : loteCntDivisa; } }
        public string referencia { get { return isDivisa ? "" : refTasaDivisa; } }
        public decimal cntDivisa { get { return isDivisa ? decimal.Parse(loteCntDivisa) : 0.0m; } }
        public decimal tasaDivisa { get { return isDivisa ? decimal.Parse(refTasaDivisa) : 0.0m; } }
        public bool esCredito { get { return estatusCredito == "1"; } }


        public Ficha() 
        {
            loteCntDivisa="";
            refTasaDivisa="";
            mpCodigo = "";
            mpDescripcion = "";
            montoRecibido = 0.0m;
            estatusCredito = "";
            importeDoc = 0m;
        }

    }

}