using PosOnLine.Data.Infra;
using ServicePos.MyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Prov
{

    public partial class DataPrv: IData
    {

        public OOB.Resultado.FichaEntidad<OOB.Usuario.Entidad.Ficha> Usuario_Identificar(OOB.Usuario.Identificar.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Usuario.Entidad.Ficha>();

            var fichaDTO = new DtoLibPos.Usuario.Identificar.Ficha()
            {
                codigo = ficha.codigo,
                clave = ficha.clave,
            };
            var r01 = MyData.Usuario_Identificar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent= r01.Entidad;
            var nr = new OOB.Usuario.Entidad.Ficha()
            {
                clave = ent.clave,
                codigo = ent.codigo,
                id = ent.id,
                idGrupo = ent.idGrupo,
                nombre = ent.nombre,
                nombreGrupo = ent.nombreGrupo,
            };
            result.Entidad = nr;

            return result;
        }

    }

}