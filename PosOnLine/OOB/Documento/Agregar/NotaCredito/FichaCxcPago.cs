﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Documento.Agregar.NotaCredito
{
    
    public class FichaCxCPago
    {

        public FichaCxC Pago { get; set; }
        public FichaCxCRecibo Recibo { get; set; }
        public FichaCxCDocumento Documento { get; set; }
        public List<FichaCxCMetodoPago> MetodoPago { get; set; }


        public FichaCxCPago() 
        {
            Pago = new FichaCxC();
            Recibo = new FichaCxCRecibo();
            Documento = new FichaCxCDocumento();
            MetodoPago = new List<FichaCxCMetodoPago>();
        }

    }

}
