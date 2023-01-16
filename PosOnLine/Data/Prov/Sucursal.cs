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
        public OOB.Resultado.FichaEntidad<OOB.Sucursal.Entidad.Ficha>
            Sucursal_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Sucursal.Entidad.Ficha>();
            var r01 = MyData.Sucursal_GetFichaById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            var ent = r01.Entidad;
            var nr = new OOB.Sucursal.Entidad.Ficha()
            {
                codigo = ent.codigo,
                id = ent.id,
                idPrecioManejar = ent.precioManejar,
                nombre = ent.nombre,
                nombreGrupo = ent.nombreGrupo,
                estatusVentaMayor = ent.estatusVentaMayor,
                estatusVentaCredito = ent.estatusVentaCredito,
                autoDepositoPrincipal = ent.autoDepositoPrincipal,
                estatus = ent.estatus,
                habilitaModGastoPos=ent.habilitaModGastoPos,
                habilitaVentaSurtidoPos=ent.habilitaVentaSurtidoPos,
                habilitaVueltoDivisaPos=ent.habilitaVueltoDivisaPos,
                modoVentaPos=ent.modoVentaPos,
            };
            result.Entidad = nr;
            return result;
        }
        public OOB.Resultado.Lista<OOB.Sucursal.Entidad.Ficha> 
            Sucursal_GetLista()
        {
            var result = new OOB.Resultado.Lista<OOB.Sucursal.Entidad.Ficha>();

            var filtroDTO = new DtoLibPos.Sucursal.Lista.Filtro();
            var r01 = MyData.Sucursal_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Sucursal.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Sucursal.Entidad.Ficha()
                        {
                            id = s.id,
                            codigo = s.codigo,
                            nombre = s.nombre,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }
        public OOB.Resultado.FichaEntidad<string> 
            Sucursal_GetFicha_ByCodigo(string codigo)
        {
            var result = new OOB.Resultado.FichaEntidad<string>();
            var r01 = MyData.Sucursal_GetFicha_ByCodigo(codigo);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            result.Entidad = r01.Entidad;
            return result;
        }
    }
}