using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir.Grafico
{
    
    public class CuadreDoc: ICuadreCaja
    {

        private dataCuadre _ds;


        public CuadreDoc()
        {
        }


        public void setData(dataCuadre ds)
        {
            _ds = ds;
        }

        public void ImprimirDoc()
        {
            Imprimir();
        }

        private void Imprimir()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Helpers\Imprimir\Grafico\Cuadre.rdlc";
            var ds = new ds();

            DataRow N = ds.Tables["CuadreCaja"].NewRow();
            N["cntFac"] = _ds.cntFAC;
            N["cntNCR"] = _ds.cntNCR;
            N["cntNEN"] = _ds.cntNEN;
            N["cntFacAnu"] = _ds.cntFACAnu;
            N["cntNCRAnu"] = _ds.cntNCRAnu;
            N["cntNENAnu"] = _ds.cntNENAnu;
            N["montoFac"] = _ds.montoFAC;
            N["montoFacAnu"] = _ds.montoFACAnu;
            N["montoNCR"] = _ds.montoNCR;
            N["montoNCRAnu"] = _ds.montoNCRAnu;
            N["montoNEN"] = _ds.montoNEN;
            N["montoNENAnu"] = _ds.montoNENAnu;
            N["montoVenta"] = _ds.montoVenta;
            N["montoVentaContado"] = _ds.montoVentaContado;
            N["montoVentaCredito"] = _ds.montoVentaCredito;
            N["efectivo_s"] = _ds.efectivo_s;
            N["divisa_s"] = _ds.divisa_s;
            N["electronico_s"] = _ds.electronico_s;
            N["otros_s"] = _ds.otros_s;
            N["devolucion_s"] = _ds.devoluciones_s;
            N["credito_s"] = _ds.credito_s;
            N["cambio_s"] = _ds.cambio_s;
            N["efectivo_u"] = _ds.efectivo_u;
            N["divisa_u"] = _ds.divisa_u;
            N["electronico_u"] = _ds.electronico_u;
            N["otros_u"] = _ds.otros_u;
            N["cnt_efectivo_s"] = _ds.cnt_efectivo_s;
            N["cnt_divisa_s"] = _ds.cnt_divisa_s;
            N["cnt_electronico_s"] = _ds.cnt_electronico_s;
            N["cnt_otros_s"] = _ds.cnt_otros_s;
            N["cnt_divisa_u"] = _ds.cnt_divisa_u;
            N["cuadre_s"] = _ds.cuadre_s;
            N["cuadre_u"] = _ds.cuadre_u;
            ds.Tables["CuadreCaja"].Rows.Add(N);

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("CuadreCaja", ds.Tables["CuadreCaja"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}