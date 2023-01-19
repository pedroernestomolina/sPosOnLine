using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.MovCaja.Adm
{
    public class data
    {
        public int IdMov { get; set; }
        public string NroMov { get; set; }
        public string TipoMov { get; set; }
        public string TipoMovDesc { get { return TipoMov.Trim().ToUpper() == "E" ? "ENTRADA" : "SALIDA"; } }
        public string EstatusAnulado { get; set; }
        public string ConceptoMov { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoDivisaMov { get; set; }
        public bool IsAnulado { get { return EstatusAnulado == "1" ? true: false; } }
        public string EstatusMov { get { return IsAnulado ? "ANULADO" : ""; } }

        public void setEstatusAnulado()
        {
            EstatusAnulado = "1";
        }
    }
}