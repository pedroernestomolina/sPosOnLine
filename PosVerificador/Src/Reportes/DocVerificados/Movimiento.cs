using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Src.Reportes.DocVerificados
{

    public class Movimiento: IDocVerificados
    {


        private List<data> _lista;


        public Movimiento()
        {
            _lista = new List<data>();
        }


        public void setData(List<data> dat)
        {
            _lista = dat;
        }
        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Src\Reportes\DocVerificados.rdlc";
            var ds = new DS();
            var totalReg = 0;
            var totalSi = 0;
            var totalNo = 0;

            foreach (var rg in _lista.ToList())
            {
                totalReg += 1;
                if (rg.isVerificado) 
                { totalSi += 1; }
                else 
                { totalNo += 1; }

                DataRow p = ds.Tables["DocVerificados"].NewRow();
                p["docNro"] = rg.docNumero;
                p["docFecha"] = rg.docFecha;
                p["docMonto"] = rg.docMonto;
                p["docMontoDivisa"] = rg.docMontoDivisa;
                p["docCliente"] = rg.docCliente;
                p["verificado"] = rg.isVerificado ? "SI" : "";
                p["docIsAnulado"] = rg.docIsAnulado ? "ANULADO" : "";
                ds.Tables["DocVerificados"].Rows.Add(p);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("totalReg", totalReg.ToString()));
            pmt.Add(new ReportParameter("totalSi", totalSi.ToString("")));
            pmt.Add(new ReportParameter("totalNo", totalNo.ToString("")));
            Rds.Add(new ReportDataSource("DocVerificados", ds.Tables["DocVerificados"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}