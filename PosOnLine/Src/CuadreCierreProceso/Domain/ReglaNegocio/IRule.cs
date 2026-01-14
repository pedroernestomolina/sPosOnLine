using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreProceso.Domain.ReglaNegocio
{
    public interface IRule
    {
        void CuentasPendientes();
        void HabilitarReglaCuentasPendientesEnCasoDeNoEstarProtegidas();
    }
}
