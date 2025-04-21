using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Cierre.Historico
{
    public class Imp: IHistoria
    {
        private ILista _lista;
        private System.Drawing.Printing.PrintDocument _printDoc;
        private Helpers.Imprimir.baseImprimirReporteCuadreCajaTicket _rpt;
        //
        public object ItemActual { get { return _lista.ItemActual; } }
        public object GetDataSource { get { return _lista.GetSource; } }
        //
        public Imp() 
        {
            _lista = new impLista();
            _printDoc = new System.Drawing.Printing.PrintDocument();
            _printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
        }
        public void Inicializa()
        {
            _lista.Inicializa();
        }
        HistoriaFrm frm;
        public void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null) 
                {
                    frm = new HistoriaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void ImprimirCierre()
        {
            if (ItemActual == null) return;
            var _it = (data)ItemActual;
            cargarPrepararCierre(_it.id);
        }
        public void VentCredito()
        {
            if (ItemActual == null) return;
            var _it = (OOB.Cierre.Lista.Ficha)((data)ItemActual).Ficha;
            Utils.VentCredito(_it.idCierre);
        }
        public void PagoDetalles()
        {
            if (ItemActual == null) return;
            var _it = (OOB.Cierre.Lista.Ficha)((data)ItemActual).Ficha;
            Utils.ReporteDetalle(_it.idCierre);
        }
        public void PagoResumen()
        {
            if (ItemActual == null) return;
            var _it = (OOB.Cierre.Lista.Ficha)((data)ItemActual).Ficha;
            Utils.ReporteResumen(_it.idCierre);
        }
        //
        private bool cargarData()
        {
            try
            {
                var filtroOOb = new OOB.Cierre.Lista.Filtro();
                var r01 = Sistema.MyData.Cierre_Lista_GetByFiltro(filtroOOb);
                _lista.setData(r01.ListaD.OrderByDescending(o => o.cierreNro).ToList());
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void cargarPrepararCierre(int id)
        {
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
        }
        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (_rpt != null)
            {
                _rpt.setControladorTickera(e);
                _rpt.ImprimirDoc();
            }
        }
    }
}