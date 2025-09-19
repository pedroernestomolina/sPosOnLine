using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.vm
{
    public class RepoPagoResumenImpl: IRepoPagoResumen
    {
        private Domain.Models.RepoPagoResumen _data;
        private _Domain.Models.Moneda _monedaLocal;
        //
        public void setDataCargar(Domain.Models.RepoPagoResumen data)
        {
            _data = data;
        }
        public void setMonedaLocal(_Domain.Models.Moneda moneda)
        {
            _monedaLocal = moneda;
        }
        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"\Src\CuadreCierre\repo\PagoResumen.rdlc";
            var ds = new repo.DS();
            var xd = 0;
            var timporte = 0.0m;
            var tasa = "";
            foreach (var rg in _data.metodo.OrderBy(o => o.descMP).ToList())
            {
                xd += 1;
                timporte += rg.montoRecibidoMonLocal;
                tasa = "";
                if (_monedaLocal!=null)
                {
                    if (rg.codigoMoneda.Trim() != _monedaLocal.codigo)
                    {
                        tasa = "/" + rg.tasaRespectoMonReferencia.ToString("n2") + "*" + rg.tasaReferencia.ToString("n2");
                    }
                    else 
                    {
                        tasa = rg.tasaReferencia.ToString("n2");
                    }
                }
                DataRow p = ds.Tables["PagoResumen"].NewRow();
                p["id"] = xd.ToString().Trim().PadLeft(3,'0');
                p["medio"] = rg.descMP;
                p["tasa"] = tasa;
                p["lote"] = rg.recibido.ToString("n2") + rg.simboloMoneda;
                p["cntDivisa"] = 0;
                p["cntMov"] = rg.cntMov.ToString("n0");
                p["importe"] = rg.montoRecibidoMonLocal;
                ds.Tables["PagoResumen"].Rows.Add(p);
            }
            //
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("tImporte", timporte.ToString("n2")));
            pmt.Add(new ReportParameter("tCambio", _data.montoVueltoMonLocal.ToString("n2")));
            Rds.Add(new ReportDataSource("PagoResumen", ds.Tables["PagoResumen"]));
            //
            var frp = new __.Reporte.Frm ();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}