using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.vm
{
    public class RepoVentaCreditoImpl: IRepoVentaCredito
    {
        private List<Domain.Models.RepoVentaCredito> _lista;
        //
        public RepoVentaCreditoImpl()
        {
        }
        public void setDataCargar(List<Domain.Models.RepoVentaCredito> list)
        {
            _lista = list;
        }
        //
        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"\Src\CuadreCierre\repo\VentCredito.rdlc";
            var ds = new repo.DS();
            //
            foreach (var dt in _lista.OrderBy(o => o.nroDoc).ToList())
            {
                DataRow p = ds.Tables["VentCredito"].NewRow();
                p["docNumero"] = dt.nroDoc;
                p["docEmision"] = dt.fechaEmisionDoc;
                p["entidad"] = dt.ciRifDoc + Environment.NewLine + dt.entidadDoc;
                p["importeMonAct"] = dt.importeMonLocal;
                p["importeMonDiv"] = dt.importeMonReferencia;
                p["montoBonoDiv"] = dt.bonoPagoDivisaMonReferencia;
                p["portcBonoDiv"] = 0m;
                p["montoSaldoPendMonDiv"] = dt.montoPendCxcMonReferencia;
                ds.Tables["VentCredito"].Rows.Add(p);
            }
            //
            var Rds = new List<ReportDataSource>();
            Rds.Add(new ReportDataSource("VentCredito", ds.Tables["VentCredito"]));
            //
            var frp = new __.Reporte.Frm ();
            frp.rds = Rds;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}