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
        public OOB.Resultado.Lista<OOB.MediosPago.Entidad.Ficha> 
            MedioPago_GetLista()
        {
            var result = new OOB.Resultado.Lista<OOB.MediosPago.Entidad.Ficha>();
            //
            try
            {
                var filtroDTO = new DtoLibPos.MedioPago.Filtro();
                var rt = MyData.MedioPago_GetLista(filtroDTO);
                if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                var lst = new List<OOB.MediosPago.Entidad.Ficha>();
                if (rt.Lista != null)
                {
                    if (rt.Lista.Count > 0)
                    {
                        lst = rt.Lista.Select(s =>
                        {
                            var nr = new OOB.MediosPago.Entidad.Ficha()
                            {
                                idMp = s.idMp,
                                codigoMp = s.codigoMp,
                                nombreMp = s.nombreMp,
                                aplicaParaCobro = s.aplicaParaCobro.ToString().Trim().ToUpper() == "1",
                                aplicaParaPOS = s.aplicaParaPOS.ToString().Trim().ToUpper() == "1",
                                aplicaLoteRef = s.aplicaLoteReferencia.ToString().Trim().ToUpper()=="1",
                                aplicaBonoPagoDivisa = s.aplicaBonoPagoDivisa.ToString().Trim().ToUpper() == "1",
                                aplicaIGTF = s.aplicaIGTF.ToString().Trim().ToUpper() == "1",
                                idCurrencies = s.idCurrencies.HasValue ? s.idCurrencies.Value: -1,
                                codigoCurrencies = s.codigoCurrencies == null ? "" : s.codigoCurrencies,
                                simboloCurrencies = s.simboloCurrencies == null ? "" : s.simboloCurrencies,
                                nombreCurrencies = s.nombreCurrencies == null ? "" : s.nombreCurrencies,
                            };
                            return nr;
                        }).ToList();
                    }
                }
                result.ListaD = lst;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
        public OOB.Resultado.FichaEntidad<OOB.MediosPago.Entidad.Ficha> 
            MedioPago_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.MediosPago.Entidad.Ficha>();
            //
            try
            {
                var rt = MyData.MedioPago_GetFichaById(id);
                if (rt.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rt.Mensaje);
                }
                if (rt.Entidad == null) 
                {
                    throw new Exception("DATA NO CARAGADA");
                }
                var s = rt.Entidad;
                var ent = new OOB.MediosPago.Entidad.Ficha()
                {
                    idMp = s.idMp,
                    codigoMp = s.codigoMp,
                    nombreMp = s.nombreMp,
                    aplicaParaCobro = s.aplicaParaCobro.ToString().Trim().ToUpper() == "1",
                    aplicaParaPOS = s.aplicaParaPOS.ToString().Trim().ToUpper() == "1",
                    aplicaLoteRef = s.aplicaLoteReferencia.ToString().Trim().ToUpper() == "1",
                    aplicaBonoPagoDivisa = s.aplicaBonoPagoDivisa.ToString().Trim().ToUpper() == "1",
                    aplicaIGTF = s.aplicaIGTF.ToString().Trim().ToUpper() == "1",
                    idCurrencies = s.idCurrencies.HasValue ? -1 : s.idCurrencies.Value,
                    codigoCurrencies = s.codigoCurrencies == null ? "" : s.codigoCurrencies,
                    simboloCurrencies = s.simboloCurrencies == null ? "" : s.simboloCurrencies,
                    nombreCurrencies = s.nombreCurrencies == null ? "" : s.nombreCurrencies,
                };
                result.Entidad = ent;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
    }
}
