using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Reportes.Cierre.PagoMovil
{
    
    public class Movimiento
    {

        private List<OOB.Reportes.Pos.PagoMovil.Ficha> _lista;


        public Movimiento(List<OOB.Reportes.Pos.PagoMovil.Ficha> list)
        {
            _lista = list;
        }


        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Src\Reportes\PagoMovil.rdlc";
            var ds = new DS();

            foreach (var rg in _lista.OrderBy(o => o.docNro).ToList())
            {
                DataRow p = ds.Tables["PagoMovil"].NewRow();
                p["docNro"] = rg.docNro;
                p["docFecha"] = rg.docFecha ;
                p["docCliente"] = rg.docCiRif + Environment.NewLine + rg.docRazonSocial;
                p["docEstatus"] = rg.docIsAnulado ? "ANULADO":"";
                p["pmCliente"] = rg.pmCiRif + Environment.NewLine + rg.pmNombre;
                p["pmTelefono"] = rg.pmTelefono;
                p["pmMonto"] = rg.docIsAnulado ? 0m : rg.pmMonto;
                p["pmAgencia"] = rg.agencia;
                ds.Tables["PagoMovil"].Rows.Add(p);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("montoTotal", montoTotal.ToString("n2")));
            //pmt.Add(new ReportParameter("cambioDarTotal", cambioDarTotal.ToString("n2")));
            Rds.Add(new ReportDataSource("PagoMovil", ds.Tables["PagoMovil"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}