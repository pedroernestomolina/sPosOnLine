using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreImprimir.vm
{
    public class CierreImprimirImpl: ICierreImprimir
    {
        private Domain.UseCase.IUseCase _uc;
        private int _idOperador;
        private System.Drawing.Printing.PrintDocument _printDoc;
        private Helpers.Imprimir.baseImprimirReporteCuadreCajaTicket _rpt;
        //
        public CierreImprimirImpl()
        {
            _uc = new Domain.UseCase.UseCaseImpl();
            _printDoc = new System.Drawing.Printing.PrintDocument();
            _printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
        }
        //
        public void setIdOperador(int id)
        {
            _idOperador= id;
        }
        //
        public void Generar()
        {
            try
            {
                var rst = _uc.CargarCierreOperador(_idOperador);
                var lst = new List<string>();

                lst.Clear();
                lst.Add("REPORTE CAJA");
                lst.Add("");
                lst.Add("NUMERO: " + rst.dataCierre.nroCierre);
                lst.Add("EQUIPO: " + rst.dataCierre.terminal);
                lst.Add("OPERAD: " + rst.dataCierre.Usuario);
                lst.Add("FECHA : " + rst.dataCierre.fechaHoraCierre);
                lst.Add("");
                lst.Add("");
                foreach(var doc in rst.tiposDoc)
                {
                    lst.Add("POR: "+doc.descDoc);
                    lst.Add("Movimientos Activo  : "+doc.cntMovActivo.ToString());
                    lst.Add("Importe Moneda Local: "+doc.importeMovActMonLocal.ToString("n2"));
                    lst.Add("Importe Moneda Ref  : "+doc.importeMovActivoMonReferencia.ToString("n2"));
                    lst.Add("----------------------");
                    lst.Add("");
                    lst.Add("CONTADO: ");
                    lst.Add("Cant Movimientos    : " + doc.cntMovContado.ToString());
                    lst.Add("Importe Moneda Local: " + doc.importeMovContadoMonLocal.ToString("n2"));
                    lst.Add("Importe Moneda Ref  : " + doc.importeMovContadoMonReferencia.ToString("n2"));
                    lst.Add("----------------------");
                    lst.Add("");
                    lst.Add("CREDITO: ");
                    lst.Add("Cant Movimientos    : " + doc.cntMovCredito.ToString());
                    lst.Add("Importe Moneda Local: " + doc.importeMovCreditoMonLocal.ToString("n2"));
                    lst.Add("Importe Moneda Ref  : " + doc.importeMovCreditoMonReferencia.ToString("n2"));
                    lst.Add("----------------------");
                    lst.Add("");
                    lst.Add("Movimientos Anulados: ");
                    lst.Add("Cant Movimientos    : " + doc.cntMovAnulado.ToString());
                    lst.Add("Importe Moneda Local: " + doc.importMovAnuladoMonLocal.ToString("n2"));
                    lst.Add("Importe Moneda Ref  : " + doc.importeMovAnuladoMonReferencia.ToString("n2"));
                    lst.Add("----------------------");
                    lst.Add("");
                    lst.Add("Cant Total/Mov      : "+ doc.cntTotalmov.ToString());
                    lst.Add("Total Moneda Local  : ");
                    lst.Add("Total Moneda Ref    : ");
                    lst.Add("----------------------");
                    lst.Add("");
                }


                Sistema.ImprimirReporteCuadreCaja.setListaDataImprimir(lst);
                if (Sistema.ImprimirReporteCuadreCaja is Helpers.Imprimir.IReporteCuadreCajaTicket)
                {
                    _printDoc.Print();
                }
                else
                    Sistema.ImprimirReporteCuadreCaja.ImprimirDoc();
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
        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            _rpt = (Helpers.Imprimir.baseImprimirReporteCuadreCajaTicket)Sistema.ImprimirReporteCuadreCaja;
            _rpt.setControladorTickera(e);
            _rpt.ImprimirDocLista();
        }
    }
}