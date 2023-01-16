using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Prov
{
    public partial class DataPrv: IData
    {
        public OOB.Resultado.Lista<OOB.Agencia.Entidad.Ficha> 
            Agencia_GetLista(OOB.Agencia.Lista.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Agencia.Entidad.Ficha>();

            var filtroDTO = new DtoLibPos.Agencia.Lista.Filtro()
            {
            };
            var r01 = MyData.Agencia_GetLista (filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.Agencia.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.Agencia.Entidad.Ficha()
                        {
                            auto = s.auto,
                            nombre = s.nombre,
                        };
                    }).ToList();
                }
            }
            rt.ListaD = list;

            return rt;
        }
        public OOB.Resultado.FichaAuto 
            Agencia_Agregar(OOB.Agencia.Agregar.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaAuto();

            var fichaDTO = new DtoLibPos.Agencia.Agregar.Ficha()
            {
                codSucursal = ficha.codSucursal,
                nombre = ficha.nombre,
            };
            var r01 = MyData.Agencia_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            result.Auto = r01.Auto;
            return result;
        }
    }
}