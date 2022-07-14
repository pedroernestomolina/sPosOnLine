﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Documento.Agregar
{
    
    public class BaseCxCDocumento
    {

        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public decimal Importe { get; set; }
        public string Operacion { get; set; }
        public int Dias { get; set; }
        public decimal CastigoP { get; set; }
        public decimal ComisionP { get; set; }
        public string CierreFtp { get; set; }
        //CAMPOS NUEVOS
        public decimal ImporteDivisa { get; set; }
        public string CodigoSucursal { get; set; }
        public string Notas { get; set; }

    }

}