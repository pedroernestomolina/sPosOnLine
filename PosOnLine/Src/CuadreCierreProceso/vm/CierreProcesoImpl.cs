using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreProceso.vm
{
    public class CierreProcesoImpl: ICierreProceso
    {
        private Domain.UseCase.IUseCase _uc;
        private __.Ctrl.Boton.Procesar.IProcesar _procesarCierre;
        private Domain.Models.CierreFicha _cierreFicha;
        private Domain.ReglaNegocio.IRule _rule;
        //
        public CierreProcesoImpl()
        {
            _uc = new Domain.UseCase.UseCaseImpl();
            _rule = new Domain.ReglaNegocio.RuleImpl();
            //
            _procesarCierre = new __.Ctrl.Boton.Procesar.Imp();
            _cierreFicha = new Domain.Models.CierreFicha();
        }
        //
        public void setIdResumen(int id)
        {
            _cierreFicha.idResumen = id;
        }
        public void setTotalesCierre(Domain.Models.CierreTotales totales)
        {
            _cierreFicha.cierreTotal = totales;
        }
        public void setDocumentos(List<CuadreCierre.Domain.Models.TipoDocUso> list)
        {
            var rs = list.
                GroupBy(g => 
                    new 
                    {
                        g.codigoDoc, 
                        g.DescripcionDoc, 
                        g.signoDoc
                    }).
                Select(s =>     
                    new 
                    {
                        codDoc=s.Key.codigoDoc, 
                        descDoc= s.Key.DescripcionDoc, 
                        signoDoc= s.Key.signoDoc, 
                        list=s.ToList() 
                    }).
                ToList();
            var _lstDoc = rs.Select(doc =>
            {
                return new Domain.Models.CierrePorDocumento()
                {
                    cntTotalmov = doc.list.Sum(s => s.cntDoc),
                    cntMovActivo = doc.list.Where(w => w.esAnulado == false).Sum(s => s.cntDoc),
                    cntMovAnulado = doc.list.Where(w => w.esAnulado).Sum(s => s.cntDoc),
                    cntMovContado = doc.list.Where(w => w.esAnulado == false && w.esCredito == false).Sum(s => s.cntDoc),
                    cntMovCredito = doc.list.Where(w => w.esAnulado == false && w.esCredito).Sum(s => s.cntDoc),
                    codigoDoc = doc.codDoc,
                    descDoc = doc.descDoc,
                    signoDoc = doc.signoDoc,
                    siglasDoc = "",
                    importeMovActMonLocal = Math.Abs(doc.list.Where(w => w.esAnulado == false).Sum(s => s.montoMonLocal)),
                    importeMovActivoMonReferencia = Math.Abs(doc.list.Where(w => w.esAnulado == false).Sum(s => s.montoMonReferencia)),
                    importMovAnuladoMonLocal = Math.Abs(doc.list.Where(w => w.esAnulado).Sum(s => s.montoMonLocal)),
                    importeMovAnuladoMonReferencia = Math.Abs(doc.list.Where(w => w.esAnulado).Sum(s => s.montoMonReferencia)),
                    importteMovContadoMonLocal = Math.Abs(doc.list.Where(w => w.esAnulado == false && w.esCredito == false).Sum(s => s.montoMonLocal)),
                    importeMovContadoMonReferencia = Math.Abs(doc.list.Where(w => w.esAnulado == false && w.esCredito == false).Sum(s => s.montoMonReferencia)),
                    importeMovCreditoMonLocal = Math.Abs(doc.list.Where(w => w.esAnulado == false && w.esCredito).Sum(s => s.montoMonLocal)),
                    importeMovCreditoMonReferencia = Math.Abs(doc.list.Where(w => w.esAnulado == false && w.esCredito).Sum(s => s.montoMonReferencia)),
                    varianteDoc = "",
                };
            }).ToList();
            _cierreFicha.cierrePorDoc = _lstDoc;
        }
        public void setMetodosPagoImplementados(List<CuadreCierre.Domain.Models.MetodoPagoUso> list)
        {
            var lst = list.Select(s =>
            {
                return new Domain.Models.CierrePorMetodoPago()
                {
                    codigoMon = s.codigoMon,
                    codigoMP = s.codigoMP,
                    descMon = "",
                    descMP = s.descripcionMP,
                    importeMonLocal = s.importe,
                    montoSegunSistema = s.MontoSegunSistema,
                    montoSegunUsuario = s.MontoSegunUsu,
                    simboloMon = s.simboloMon,
                    tasaFactorPonderadoMon = s.tasaFactorPonderado,
                };
            }).ToList();
            _cierreFicha.cierrePorMetPago = lst;
        }
        //
        public void Inicializa()
        {
            _cierreFicha.Inicializa();
            _procesarCierre.Inicializa();
        }
        public bool ProcesarCierre()
        {
            var rt = false;
            //
            _procesarCierre.Opcion("Seguro De Realizar El Cierre De Caja?");
            if (_procesarCierre.OpcionIsOK)
            {
                try
                {
                    _rule.CuentasPendientes();
                    _uc.CerrarPos(_cierreFicha);
                    rt=true;
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
            //
            return rt;
        }
    }
}