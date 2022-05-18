using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IJornada
    {

        OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha> Jornada_EnUso_GetByIdEquipo(string idEquipo);
        OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha> Jornada_EnUso_GetBy_EquipoSucursal(string idEquipo, string codSucursal);
        OOB.Resultado.FichaId Jornada_Abrir(OOB.Pos.Abrir.Ficha ficha);
        OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha> Jornada_EnUso_GetById(int id);
        OOB.Resultado.FichaEntidad<OOB.Pos.Resumen.Ficha> Jornada_Resumen_GetByIdResumen(int id);
        OOB.Resultado.Ficha Jornada_Cerrar(OOB.Pos.Cerrar.Ficha ficha);

    }

}