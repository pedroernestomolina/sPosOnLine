using PosVerificador.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Data.Prov
{

    public partial class DataPrv : IData
    {

        public OOB.Resultado.FichaEntidad<OOB.Verificador.Entidad.Ficha> 
            Verificador_GetFichaById(int id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Verificador.Entidad.Ficha>();

            var r01 = MyData.Verificador_GetFichaById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            var s = r01.Entidad;
            var nr = new OOB.Verificador.Entidad.Ficha()
            {
                autoDoc = s.autoDoc,
                estatusAnulado = s.estatusAnulado,
                estatusVer = s.estatusVer,
                fechaVer = s.fechaVer,
                id = s.id,
                usuarioCodVer = s.usuarioCodVer,
                usuarioNombreVer = s.usuarioNombreVer,
            };
            result.Entidad = nr;

            return result;
        }
        public OOB.Resultado.FichaId
            Verificador_GetFichaByAutoDoc(string autoDoc)
        {
            var result = new OOB.Resultado.FichaId();

            var r01 = MyData.Verificador_GetFichaByAutoDoc(autoDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Id = r01.Id;

            return result;
        }
        public OOB.Resultado.Ficha 
            Verificador_VerificarFicha(OOB.Verificador.Verificar.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Verificador.Entidad.Ficha>();

            var fichaDTO = new DtoLibPos.Verificador.Verificar.Ficha()
            {
                id = ficha.id,
                estatusVer = ficha.estatusVer,
                usuarioCodVer = ficha.usuarioCodVer,
                usuarioNombreVer = ficha.usuarioNombreVer,
            };
            var r01 = MyData.Verificador_VerificarFicha (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

    }

}