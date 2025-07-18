using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CasoUso
{
    public class ObtenerPorcAumentoProdNoAdmPorDivisa
    {
        public decimal Execute() 
        {
            var rt = Sistema.MyData.Configuracion_PorcentajeAumentarEnPreciosDeProductosNoAdministradoPorDivisa();
            return rt.Entidad;
        }
    }
}
