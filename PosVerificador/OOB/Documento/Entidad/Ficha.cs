using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.OOB.Documento.Entidad
{
    
    public class Ficha
    {

        public string AutoDoc { get; set; }
        public string AutoCierreDoc { get; set; }
        public string NroDoc { get; set; }
        public DateTime FechaDoc { get; set; }
        public string RazonSocial { get; set; }
        public string DirFiscal { get; set; }
        public string CiRif { get; set; }
        public string CodigoDoc { get; set; }
        public decimal MontoDoc { get; set; }
        public string EstatusAnuladoDoc { get; set; }
        public string HoraDoc { get; set; }
        public bool Isnulado { get { return EstatusAnuladoDoc.Trim().ToUpper() == "1" ? true : false; } }


        public Ficha()
        {
            AutoDoc = "";
            AutoCierreDoc = "";
            NroDoc = "";
            CodigoDoc = "";
            FechaDoc = DateTime.Now.Date;
            RazonSocial = "";
            DirFiscal = "";
            CiRif = "";
            MontoDoc = 0m;
            EstatusAnuladoDoc = "";
            HoraDoc = "";
        }

    }

}