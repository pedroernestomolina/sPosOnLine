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
        public OOB.Resultado.FichaEntidad<OOB.Sistema.SerieFiscal.Entidad.Ficha> 
            Sistema_Serie_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Sistema.SerieFiscal.Entidad.Ficha>();
            //
            var r01 = MyData.Sistema_Serie_GetFichaById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            //
            result.Entidad = new OOB.Sistema.SerieFiscal.Entidad.Ficha()
            {
                Auto = r01.Entidad.Auto,
                Control = r01.Entidad.Control,
                Serie = r01.Entidad.Serie,
                EstatusAplicaLibroVenta = r01.Entidad.AplicaLibroVenta.Trim().ToUpper() == "1",
            };
            //
            return result;
        }
        public OOB.Resultado.FichaEntidad<OOB.Sistema.SerieFiscal.Entidad.Ficha> 
            Sistema_Serie_GetFichaBySerie(string serie)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Sistema.SerieFiscal.Entidad.Ficha>();
            //
            var r01 = MyData.Sistema_Serie_GetFichaByNombre(serie);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            //
            result.Entidad = new OOB.Sistema.SerieFiscal.Entidad.Ficha()
            {
                Auto = r01.Entidad.Auto,
                Control = r01.Entidad.Control,
                Serie = r01.Entidad.Serie,
                EstatusAplicaLibroVenta = r01.Entidad.AplicaLibroVenta.Trim().ToUpper() == "1",
            };
            //
            return result;
        }
        public OOB.Resultado.Lista<OOB.Sistema.SerieFiscal.Entidad.Ficha> 
            Sistema_Serie_GetLista()
        {
            var result = new OOB.Resultado.Lista<OOB.Sistema.SerieFiscal.Entidad.Ficha>();
            var _lst = new List<OOB.Sistema.SerieFiscal.Entidad.Ficha>();
            //
            var r01 = MyData.Sistema_Serie_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            //
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    _lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Sistema.SerieFiscal.Entidad.Ficha()
                        {
                            Auto = s.Auto,
                            Control = s.Control,
                            Serie = s.Serie,
                            EstatusAplicaLibroVenta= s.AplicaLibroVenta.Trim().ToUpper()=="1",
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = _lst;
            //
            return result;
        }
    }
}