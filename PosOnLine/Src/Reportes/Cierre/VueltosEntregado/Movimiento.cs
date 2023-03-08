using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Reportes.Cierre.VueltosEntregado
{
    
    public class Movimiento
    {

        private List<OOB.Reportes.Pos.VueltosEntregados.Ficha> _lst;


        public Movimiento(List<OOB.Reportes.Pos.VueltosEntregados.Ficha> lst)
        {
            _lst = lst;
        }


        public void Generar()
        {
            //var pt = AppDomain.CurrentDomain.BaseDirectory + @"Src\Reportes\VueltosEntregado.rdlc";
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"\VueltosEntregado.rdlc";
            var ds = new DS();

            foreach (var rg in _lst.ToList())
            {
                if (rg.isAnulado) continue;

                DataRow p = ds.Tables["VueltosEnt"].NewRow();
                p["documento"] = rg.documento + Environment.NewLine + rg.siglasDoc;
                p["fechaHora"] = rg.fecha.ToShortDateString() + Environment.NewLine + rg.hora;
                p["entNombre"] = rg.entNombre;
                p["entDir"] = rg.entDir;
                p["entTelf"] = rg.entTelf;
                p["montoDoc"] = rg.montoDoc;
                p["montoCambio"] = rg.montoCambio;
                p["vueltoEfectivo"] = rg.montoVueltoEfectivo;
                p["vueltoDivisa"] = rg.montoVueltoDivisa;
                p["vueltoPagoMov"] = rg.montoVueltoPagoMovil;
                p["cntVueltoDivisa"] = rg.cntVueltoDivisa;
                ds.Tables["VueltosEnt"].Rows.Add(p);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("VueltosEnt", ds.Tables["VueltosEnt"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}