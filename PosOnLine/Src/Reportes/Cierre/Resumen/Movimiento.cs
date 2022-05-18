using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Reportes.Cierre.Resumen
{
    
    public class Movimiento
    {

        private decimal _montoNCredito;
        private decimal _montoCambioDar;
        private List<OOB.Reportes.Pos.PagoResumen.Ficha> _lista;


        public Movimiento(List<OOB.Reportes.Pos.PagoResumen.Ficha> list)
        {
            _montoCambioDar = 0.0m;
            _montoNCredito = 0.0m;
            _lista = list;
        }


        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Src\Reportes\PagoResumen.rdlc";
            var ds = new DS();

            var gf = _lista.GroupBy(g =>
                new
                {
                    g.mpCodigo ,
                    g.mpDescripcion,
                    g.tasaDivisa,
                }).Select(s => new { key = s.Key, data = s.ToList() }).ToList();

            var xd = 0;
            var timporte = 0.0m;
            foreach (var rg in gf.OrderBy(o => o.key.mpCodigo).ToList())
            {
                xd += 1;
                timporte += rg.data.Sum(r => r.montoRecibido);
                foreach (var dt in rg.data)
                {
                    var _tasa = "";
                    var _cntDivisa = "";
                    if (dt.tasaDivisa > 1)
                    {
                        _tasa = dt.tasaDivisa.ToString("n2");
                        _cntDivisa = rg.data.Sum(r => r.cntDivisa).ToString("n0");
                    }

                    DataRow p = ds.Tables["PagoResumen"].NewRow();
                    p["id"] = xd.ToString();
                    p["medio"] = dt.mpCodigo + "/ " + dt.mpDescripcion;
                    p["tasa"] = _tasa;
                    p["lote"] = dt.lote;
                    p["cntDivisa"] = _cntDivisa;
                    p["cntMov"] = rg.data.Count().ToString("n0");
                    p["importe"] = rg.data.Sum(r => r.montoRecibido);
                    ds.Tables["PagoResumen"].Rows.Add(p);
                }
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("tImporte", timporte.ToString("n2")));
            pmt.Add(new ReportParameter("tCambio", _montoCambioDar.ToString("n2")));
            pmt.Add(new ReportParameter("tNCredito", _montoNCredito.ToString("n2")));
            Rds.Add(new ReportDataSource("PagoResumen", ds.Tables["PagoResumen"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }


        public void setMontoNtCredito(decimal p)
        {
            _montoNCredito = p;
        }

        public void setMontoCambioDar(decimal p)
        {
            _montoCambioDar = p;
        }

    }

}