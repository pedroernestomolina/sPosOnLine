using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Data.Infra
{
    public interface IPosCtaControl
    {
        OOB.Resultado.FichaEntidad<OOB.PosCtaControl.Obtener.Ficha>
            PosCtaControl_ObtenerDatosCtaControl(int idOperador);
        OOB.Resultado.FichaEntidad<bool>
            PosCtaControl_VerificaSiExisteParaEsteOperador(int idOperador);
        OOB.Resultado.Ficha
            PosCtaControl_LimpiarDadoOperador(int idOperador);
    }
}