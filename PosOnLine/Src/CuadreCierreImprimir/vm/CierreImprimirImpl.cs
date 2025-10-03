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
                var _importeActMonLocal=0m;
                var _importeActMonRef=0m;
                foreach(var doc in rst.tiposDoc)
                {
                    _importeActMonLocal+= doc.importeMovActMonLocal;
                    _importeActMonRef += doc.importeMovActivoMonReferencia;
                    lst.Add("POR: "+doc.descDoc);
                    lst.Add("Movimientos Activo  : " + formateaCnt(doc.cntMovActivo));
                    lst.Add("Importe Moneda Local: " + formateaMnt(doc.importeMovActMonLocal));
                    lst.Add("Importe Moneda Ref  : " + formateaMnt(doc.importeMovActivoMonReferencia));
                    lst.Add("----------------------");
                    lst.Add("");
                    lst.Add("CONTADO: ");
                    lst.Add("Cant Movimientos    : " + formateaCnt(doc.cntMovContado));
                    lst.Add("Importe Moneda Local: " + formateaMnt(doc.importeMovContadoMonLocal));
                    lst.Add("Importe Moneda Ref  : " + formateaMnt(doc.importeMovContadoMonReferencia));
                    lst.Add("----------------------");
                    lst.Add("");
                    lst.Add("CREDITO: ");
                    lst.Add("Cant Movimientos    : " + formateaCnt(doc.cntMovCredito));
                    lst.Add("Importe Moneda Local: " + formateaMnt(doc.importeMovCreditoMonLocal));
                    lst.Add("Importe Moneda Ref  : " + formateaMnt(doc.importeMovCreditoMonReferencia));
                    lst.Add("----------------------");
                    lst.Add("");
                    lst.Add("Movimientos Anulados: ");
                    lst.Add("Cant Movimientos    : " + formateaCnt(doc.cntMovAnulado));
                    lst.Add("Importe Moneda Local: " + formateaMnt(doc.importMovAnuladoMonLocal));
                    lst.Add("Importe Moneda Ref  : " + formateaMnt(doc.importeMovAnuladoMonReferencia));
                    lst.Add("----------------------");
                    lst.Add("");
                    lst.Add("Cant Total/Mov      : "+ formateaCnt(doc.cntTotalmov));
                    lst.Add("----------------------");
                    lst.Add("");
                    lst.Add("");
                }
                lst.Add("Mov Activo M/Local  : " + formateaMnt(_importeActMonLocal));
                lst.Add("Mov Activo M/Ref    : " + formateaMnt(_importeActMonRef));
                lst.Add("----------------------");
                lst.Add("");
                lst.Add("");

                lst.Add("DESGLOZE DINERO");
                foreach (var mt in rst.formasPago)
                {
                    lst.Add("METODO/PAGO: " + mt.descMP);
                    lst.Add("Moneda              : " + mt.codigoMon+"("+mt.simboloMon+")");
                    lst.Add("Segun Sistema       : " + formateaMnt(mt.montoSegunSistema));
                    lst.Add("Segun Usuario       : " + formateaMnt(mt.montoSegunUsuario));
                    lst.Add("Diferencia          : " + mt.diferenciaDesc);
                    lst.Add("----------------------");
                    lst.Add("");
                }
                var t = rst.totales;
                lst.Add("");
                lst.Add("");
                lst.Add("Segun/Sistema       : " + formateaMnt(t.totalCajaSegunSistemaMonLocal));
                lst.Add("Segun/Usuario       : " + formateaMnt(t.totalCajaSegunUsuarioMonLocal));
                lst.Add("Estatus Del Cuadre  : " + t.estatusCuadre);
                lst.Add("Por Monto           : " + formateaMnt(t.totalCuadreMonLocal));
                lst.Add("--------------------- ");
                lst.Add("Vuelto Por Efectivo : " + formateaMnt(t.vueltoCambioPorEfectivo));
                lst.Add("Vuelto Por Divisa   : " + formateaMnt(t.vueltoCambioPorDivisa));
                lst.Add("Cant Divisa         : " + formateaCnt(t.cntDivisaPorVuelto));
                lst.Add("Vuelto Por Pag/Movil: " + formateaMnt(t.vueltoCambioPorPagoMovil));
                lst.Add("");
                lst.Add("");

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
        }
        private string formateaCnt(int cnt)
        {
            return string.Format("{0,15:n0}", cnt);
        }
        private string formateaMnt(decimal mnt)
        {
            return string.Format("{0,15:n2}", mnt);
        }
        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            _rpt = (Helpers.Imprimir.baseImprimirReporteCuadreCajaTicket)Sistema.ImprimirReporteCuadreCaja;
            _rpt.setControladorTickera(e);
            _rpt.ImprimirDocLista();
        }
    }
}