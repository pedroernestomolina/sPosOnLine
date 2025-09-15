using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface ICuadreCierre
    {
        OOB.Resultado.Lista<OOB.CuadreCierre.CuadreResumen.MetodoPago>
           get_CuadreResumenMetodoPago_byId(int idResumen);
        OOB.Resultado.Lista<OOB.CuadreCierre.CuadreResumen.Documento>
           get_CuadreResumenDocumento_byId(int idResumen);
        OOB.Resultado.FichaEntidad<OOB.CuadreCierre.CuadreResumen.Totales>
           get_CuadreResumenTotalesd_byId(int idResumen);
    }
}