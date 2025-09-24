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
        //
        public CierreProcesoImpl()
        {
            _uc = new Domain.UseCase.UseCaseImpl();
            _procesarCierre = new __.Ctrl.Boton.Procesar.Imp();
            _cierreFicha = new Domain.Models.CierreFicha();
        }
        //
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
            _procesarCierre.Inicializa();
        }
        public bool ProcesarCierre()
        {
            var rt = false;
            //
            _procesarCierre.Opcion();
            if (_procesarCierre.OpcionIsOK)
            {
                try
                {
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