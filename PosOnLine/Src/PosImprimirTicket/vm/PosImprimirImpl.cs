using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.PosImprimirTicket.vm
{
    public class PosImprimirImpl : IPosImprimir
    {
        private System.Windows.Forms.PrintDialog pDialog;
        private System.Drawing.Printing.PrintDocument pDocument;
        private Helpers.Imprimir.IDocTicket _imprimirDocTick;
        private Domain.UseCase.IUseCase _uc;
        //
        public PosImprimirImpl()
        {
            _uc = new Domain.UseCase.UsaeCaseImpl();
            pDialog = new PrintDialog();
            pDocument = new System.Drawing.Printing.PrintDocument();
            pDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pDocumentPrintPage);
            pDialog.Document = pDocument;
        }
        private void pDocumentPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            _imprimirDocTick.setEmpresa(Sistema.DatosEmpresa);
            _imprimirDocTick.setControladorTickera(e);
            _imprimirDocTick.ImprimirDoc();
        }
        public void
            ImprimirFactura(string idDoc)
        {
            try
            {
                var data = _uc.CargarDataDocumento(idDoc);
                var xdata = Domain.converter.fromDataToHelperData(data);
                var xdataQR = Domain.converter.fromDataToHelperDataQR(data.infoQR);
                //
                _imprimirDocTick = null;
                Sistema.ImprimirFactura.setData(xdata);
                Sistema.ImprimirFactura.setImprimirQR(xdataQR);
                if (Sistema.ImprimirFactura is Helpers.Imprimir.IDocTicket)
                {
                    _imprimirDocTick = (Helpers.Imprimir.DocumentoTicket)Sistema.ImprimirFactura;
                    pDocument.Print();
                }
                else
                {
                    Sistema.ImprimirFactura.ImprimirDoc();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void
            ImprimirNotaCredito(string idDoc)
        {
            try
            {
                var data = _uc.CargarDataDocumento(idDoc);
                var xdata = Domain.converter.fromDataToHelperData(data);
                //
                _imprimirDocTick = null;
                Sistema.ImprimirNotaCredito.setData(xdata);
                if (Sistema.ImprimirNotaCredito is Helpers.Imprimir.IDocTicket)
                {
                    _imprimirDocTick = (Helpers.Imprimir.DocumentoTicket)Sistema.ImprimirNotaCredito;
                    pDocument.Print();
                }
                else
                {
                    Sistema.ImprimirNotaCredito.ImprimirDoc();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void
            ImprimirNotaEntrega(string idDoc)
        {
            try
            {
                var data = _uc.CargarDataDocumento(idDoc);
                var xdata = Domain.converter.fromDataToHelperData(data);
                var xdataQR = Domain.converter.fromDataToHelperDataQR(data.infoQR);
                //
                _imprimirDocTick = null;
                Sistema.ImprimirNotaEntrega.setData(xdata);
                Sistema.ImprimirNotaEntrega.setImprimirQR(xdataQR);
                if (Sistema.ImprimirNotaEntrega is Helpers.Imprimir.IDocTicket)
                {
                    _imprimirDocTick = (Helpers.Imprimir.DocumentoTicket)Sistema.ImprimirNotaEntrega;
                    pDocument.Print();
                }
                else
                {
                    Sistema.ImprimirNotaEntrega.ImprimirDoc();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void
            ImprimirCopiaDocumento(string idDoc)
        {
            try
            {
                var data = _uc.CargarDataDocumento(idDoc, "COPIA ");
                var xdata = Domain.converter.fromDataToHelperData(data);
                var xdataQR = Domain.converter.fromDataToHelperDataQR(data.infoQR);
                //
                _imprimirDocTick = null;
                switch (data.tipoDocumento)
                {
                    case Domain.Models.Data.TipoDocumento.Factura:
                        Sistema.ImprimirFactura.setData(xdata);
                        Sistema.ImprimirFactura.setImprimirQR(xdataQR);
                        if (Sistema.ImprimirFactura is Helpers.Imprimir.IDocTicket)
                        {
                            _imprimirDocTick = (Helpers.Imprimir.DocumentoTicket)Sistema.ImprimirFactura;
                            pDocument.Print();
                        }
                        else
                            Sistema.ImprimirFactura.ImprimirCopiaDoc();
                        break;
                    case Domain.Models.Data.TipoDocumento.NotaCredito:
                        Sistema.ImprimirNotaCredito.setData(xdata);
                        if (Sistema.ImprimirNotaCredito is Helpers.Imprimir.IDocTicket)
                        {
                            _imprimirDocTick = (Helpers.Imprimir.DocumentoTicket)Sistema.ImprimirNotaCredito;
                            pDocument.Print();
                        }
                        else
                            Sistema.ImprimirNotaCredito.ImprimirCopiaDoc();
                        break;
                    case Domain.Models.Data.TipoDocumento.NotaEntrega:
                        Sistema.ImprimirNotaEntrega.setData(xdata);
                        if (Sistema.ImprimirNotaEntrega is Helpers.Imprimir.IDocTicket)
                        {
                            _imprimirDocTick = (Helpers.Imprimir.DocumentoTicket)Sistema.ImprimirNotaEntrega;
                            pDocument.Print();
                        }
                        else
                            Sistema.ImprimirNotaEntrega.ImprimirCopiaDoc();
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}