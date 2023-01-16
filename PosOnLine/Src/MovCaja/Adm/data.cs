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
        public bool IsAnulado { get { return EstatusAnulado == "1" ? true: false; } }

        public void setEstatusAnulado()
        {
            EstatusAnulado = "1";
        }
    }
}