using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Reportes.Cierre.MovCaja
{
    public class Movimiento
    {
        private OOB.Reportes.Pos.MovCaja.Ficha ficha;

        public Movimiento(OOB.Reportes.Pos.MovCaja.Ficha ficha)
        {
            this.ficha = ficha;
        }
        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"\MovCaja.rdlc";
            var ds = new DS();
            foreach (var rg in ficha.mov.OrderByDescending(o=>o.idMov).ToList())
            {
                var monto = rg.montoMov * rg.signoMov;
                var montoDivisa = rg.montoDivisaMov * rg.signoMov; ;
                var tipo="ENTRADA";
                var estatus = "";
                if (rg.estatusAnuladoMov == "1")
                {
                    estatus = "ANULADO";
                    monto = 0m;
                    montoDivisa = 0m;
                }
                if (rg.tipoMov.Trim().ToUpper() != "E")
                {
                    tipo = "SALIDA";
                }
                DataRow p = ds.Tables["MovCaja"].NewRow();
                p["numeroMov"] = rg.numeroMov;
                p["fecha"] = rg.fechaMov;
                p["monto"] = monto;
                p["montoDivisa"] = montoDivisa;
                p["concepto"] = rg.conceptoMov;
                p["tipoMov"] = tipo;
                p["estatus"] = estatus;
                ds.Tables["MovCaja"].Rows.Add(p);
            }
            foreach (var rg in ficha.det)
            {
                var monto = rg.monto;
                if (rg.esDivisa.Trim().ToUpper()=="1") { monto = 0m; }
                DataRow p = ds.Tables["MovCajaDet"].NewRow();
                p["medio"] = rg.descMed+"/"+rg.codigoMed;
                p["monto"] = monto;
                p["cnt"] = rg.cntDivisa ;
                ds.Tables["MovCajaDet"].Rows.Add(p);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("montoTotal", montoTotal.ToString("n2")));
            //pmt.Add(new ReportParameter("cambioDarTotal", cambioDarTotal.ToString("n2")));
            Rds.Add(new ReportDataSource("MovCaja", ds.Tables["MovCaja"]));
            Rds.Add(new ReportDataSource("MovCajaDet", ds.Tables["MovCajaDet"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}