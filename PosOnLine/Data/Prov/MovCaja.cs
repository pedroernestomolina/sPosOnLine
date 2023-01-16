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
        public OOB.Resultado.FichaId
            MovCaja_Registrar(OOB.MovCaja.Registrar.Ficha ficha)
        {
            var rt = new OOB.Resultado.FichaId();
            var fichaDTO = new DtoLibPos.MovCaja.Registrar.Ficha()
            {
                ConceptoMov = ficha.ConceptoMov,
                DetalleMov = ficha.DetalleMov,
                FactorCambio = ficha.FactorCambio,
                FechaMov = ficha.FechaMov,
                IdOperador = ficha.IdOperador,
                MontoDivisaMov = ficha.MontoDivisaMov,
                MontoMov = ficha.MontoMov,
                SignoMov = ficha.SignoMov,
                TipoMov = ficha.TipoMov,
                Detalles = ficha.Detalles.Select(s => 
                {
                    var nr = new DtoLibPos.MovCaja.Registrar.Detalle()
                    {
                        autoMedio = s.autoMedio,
                        cntDivisa = s.cntDivisa,
                        codigoMedio = s.codigoMedio,
                        descMedio = s.descMedio,
                        monto = s.monto,
                    };
                    return nr;
                }).ToList(),
            };
            var r01 = MyData.MovCaja_Registrar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            rt.Id = r01.Id;
            return rt;
        }
        public OOB.Resultado.Ficha 
            MovCaja_Anular(OOB.MovCaja.Anular.Ficha ficha)
        {
            var rt = new OOB.Resultado.Ficha();
            var fichaDTO = new DtoLibPos.MovCaja.Anular.Ficha()
            {
                AutoUsuAut = ficha.AutoUsuAut,
                CodigoUsuAut = ficha.CodigoUsuAut,
                IdMovimiento = ficha.IdMovimiento,
                IdOperador = ficha.IdOperador,
                Motivo = ficha.Motivo,
                NombreUsuAut = ficha.NombreUsuAut,
            };
            var r01 = MyData.MovCaja_Anular(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return rt;
        }
        public OOB.Resultado.FichaEntidad<OOB.MovCaja.Entidad.Ficha> 
            MovCaja_GetById(int id)
        {
            var rt = new OOB.Resultado.FichaEntidad<OOB.MovCaja.Entidad.Ficha>();
            var r01 = MyData.MovCaja_GetById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s=r01.Entidad;
            rt.Entidad = new OOB.MovCaja.Entidad.Ficha()
            {
                ConceptoMov = s.ConceptoMov,
                DetalleMov = s.DetalleMov,
                EstatusAnulado = s.EstatusAnulado,
                FactorCambio = s.FactorCambio,
                FechaMov = s.FechaMov,
                FechaRegistro = s.FechaRegistro,
                IdMov = s.IdMov,
                IdOperador = s.IdOperador,
                MontoDivisaMov = s.MontoDivisaMov,
                MontoMov = s.MontoMov,
                NumeroMov = s.NumeroMov,
                SignoMov = s.SignoMov,
                TipoMov = s.TipoMov,
                Detalles = s.Detalles.Select(ss => {
                    var nr = new OOB.MovCaja.Entidad.Detalle()
                    {
                        autoMedio = ss.autoMedio,
                        cntDivisa = ss.cntDivisa,
                        codigoMedio = ss.codigoMedio,
                        descMedio = ss.descMedio,
                        id = ss.id,
                        monto = ss.monto,
                    };
                    return nr;
                }).ToList(),
            };
            return rt;
        }
        public OOB.Resultado.Lista<OOB.MovCaja.Entidad.Ficha> 
            MovCaja_GetLista(OOB.MovCaja.Lista.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.MovCaja.Entidad.Ficha>();
            var lst = new List<OOB.MovCaja.Entidad.Ficha>();
            var filtroDTO= new DtoLibPos.MovCaja.Lista.Filtro()
            {
                 IdOperador=filtro.IdOperador,
            };
            var r01 = MyData.MovCaja_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            if (r01.Lista !=null)
            {
                if (r01.Lista.Count>0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var rg = new OOB.MovCaja.Entidad.Ficha()
                        {
                            ConceptoMov = s.ConceptoMov,
                            EstatusAnulado = s.EstatusAnulado,
                            FactorCambio = s.FactorCambio,
                            FechaMov = s.FechaMov,
                            FechaRegistro = s.FechaRegistro,
                            IdMov = s.IdMov,
                            IdOperador = s.IdOperador,
                            MontoDivisaMov = s.MontoDivisaMov,
                            MontoMov = s.MontoMov,
                            NumeroMov = s.NumeroMov,
                            SignoMov = s.SignoMov,
                            TipoMov = s.TipoMov,
                        };
                        return rg;
                    }).ToList();
                }
            };
            rt.ListaD = lst;
            return rt;
        }
    }
}