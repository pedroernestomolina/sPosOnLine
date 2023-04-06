using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor.ModoAdm
{
    public class imp_existencia: IExistencia
    {
        private Existencia _ex;


        public string GetDisponibilidad { get { return _ex.cnt > 0m ? "SI" : "NO"; } }
        public string GetCantidad { get { return _ex.cnt.ToString(_ex.decimales); } }


        public imp_existencia()
        {
        }


        public void Inicializar()
        {
        }

        public void setData(Existencia existencia)
        {
            _ex = existencia;
        }
    }
}