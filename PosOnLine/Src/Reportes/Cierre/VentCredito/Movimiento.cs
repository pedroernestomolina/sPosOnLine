using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Reportes.Cierre.VentCredito
{
    public class Movimiento
    {
        private List<OOB.Reportes.Pos.VentCredito.Ficha> _lista;
        //
        public Movimiento(List<OOB.Reportes.Pos.VentCredito.Ficha> list)
        {
            _lista = list;
        }
        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"\VentCredito.rdlc";
            var ds = new DS();
            //
            foreach (var dt in _lista.OrderBy(o=>o.docNumero).ToList())
            {
                DataRow p = ds.Tables["VentCredito"].NewRow();
                p["docNumero"] = dt.docNumero;
                p["docEmision"] = dt.docEmision;
                p["entidad"] = dt.clienteCiRif+Environment.NewLine+dt.clienteNombre;
                p["importeMonAct"] = dt.docImporteMonAct;
                p["importeMonDiv"] = dt.docImporteMonDiv;
                p["montoBonoDiv"] = dt.montoBonoDiv;
                p["portcBonoDiv"] = dt.porctBonoDiv;
                p["montoSaldoPendMonDiv"] = dt.docSaldoPendMonDiv;
                ds.Tables["VentCredito"].Rows.Add(p);
            }
            //
            var Rds = new List<ReportDataSource>();
            Rds.Add(new ReportDataSource("VentCredito", ds.Tables["VentCredito"]));
            //
            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}