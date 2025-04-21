using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cierre.Historico
{
    public class data: Idata
    {
        private object _ficha;
        //
        public int id { get; set; }
        public string idEquipo { get; set; }
        public string fechaHora { get; set; }
        public string cierreNro { get; set; }
        public object Ficha { get { return _ficha; } }
        //
        public data(object ficha)
        {
            var ss = (OOB.Cierre.Lista.Ficha)ficha;
            _ficha = ficha;
            id = ss.id;
            fechaHora = ss.fecha.ToShortDateString() + ", " + ss.hora;
            idEquipo = ss.idEquipo;
            cierreNro = ss.cierreNro.ToString().Trim().PadLeft(6, '0');
        }
    }
}