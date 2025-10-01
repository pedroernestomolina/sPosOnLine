using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreImprimir.vm
{
    public class CierreImprimirImpl: ICierreImprimir
    {
        private int _idCierre;
        private Domain.UseCase.IUseCase _uc;
        //
        public CierreImprimirImpl()
        {
            _uc = new Domain.UseCase.UseCaseImpl();
        }
        //
        public void setIdCierre(int id)
        {
            _idCierre = id;
        }
        //
        public void Generar()
        {
            try
            {
                _uc.
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            /*
            try
            {
                var r01 = Sistema.MyData.Cierre_GetById(id);
                var _dat = new dataCierre(r01.Entidad);
                //
                var dat = new Helpers.Imprimir.dataCuadre();
                dat.cntFAC = _dat.cntFac;
                dat.cntNCR = _dat.cntNCR;
                dat.montoFAC = _dat.montoFAC;
                dat.montoNCR = _dat.montoNCR;
                dat.montoVenta = _dat.montoVenta;
                dat.montoVentaContado = _dat.montoVentaContado;
                dat.montoVentaCredito = _dat.montoVentaCredito;
                dat.devoluciones_s = _dat.devoluciones_s;
                dat.credito_s = _dat.credito_s;
                dat.efectivo_s = _dat.efectivo_s;
                dat.divisa_s = _dat.divisa_s;
                dat.electronico_s = _dat.electronico_s;
                dat.otros_s = _dat.otros_s;
                dat.cnt_divisa_s = _dat.cnt_divisa_s;
                dat.cnt_efectivo_s = _dat.cnt_efectivo_s;
                dat.cnt_electronico_s = _dat.cnt_electronico_s;
                dat.cnt_otros_s = _dat.cnt_otros_s;
                dat.cuadre_s = _dat.cuadre_s;
                //desgloze segun usuario
                dat.efectivo_u = _dat.efectivo_u;
                dat.divisa_u = _dat.divisa_u;
                dat.electronico_u = _dat.electronico_u;
                dat.otros_u = _dat.otros_u;
                dat.cnt_divisa_u = _dat.cnt_divisa_u;
                dat.cuadre_u = _dat.cuadre_u;
                dat.vueltoPorPagoMovil = _dat.vueltoPorPagoMovil;
                //
                dat.Usuario = _dat.Usuario;
                dat.cntDocContado = _dat.cntDocContado;
                dat.cntDocCredito = _dat.cntDocCredito;
                dat.nroCierre = _dat.nroCierre;
                //
                Sistema.ImprimirReporteCuadreCaja.setData(dat);
                if (Sistema.ImprimirReporteCuadreCaja is Helpers.Imprimir.IReporteCuadreCajaTicket)
                {
                    _rpt = (Helpers.Imprimir.baseImprimirReporteCuadreCajaTicket)Sistema.ImprimirReporteCuadreCaja;
                    _printDoc.Print();
                }
                else
                    Sistema.ImprimirReporteCuadreCaja.ImprimirDoc();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
             **/
        }
    }
}