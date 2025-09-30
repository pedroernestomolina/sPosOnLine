using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreRepo.vm
{
    public class RepoVentaCreditoImpl: IRepoVentaCredito
    {
        private List<Domain.Models.RepoVentaCredito> _lista;
        private Domain.UseCase.UseCaseImpl _uc;
        private int _idResumen;
        //
        public RepoVentaCreditoImpl()
        {
            _uc = new Domain.UseCase.UseCaseImpl();
        }
        public void setIdResumen(int id)
        {
            _idResumen = id;
        }
        private void setDataCargar(List<Domain.Models.RepoVentaCredito> list)
        {
            _lista = list;
        }
        //
        public void Generar()
        {
            setDataCargar(_uc.ReporteVentaCredito(_idResumen));
            //
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"\Src\CuadreCierreRepo\repo\VentCredito.rdlc";
            var ds = new repo.DS();
            //
            foreach (var dt in _lista.OrderBy(o => o.nroDoc).ToList())
            {
                var importeMonAct = dt.importeMonLocal * dt.signoDoc;
                var importeMonDiv = dt.importeMonReferencia * dt.signoDoc;
                var montoBonoDiv = dt.bonoPagoDivisaMonReferencia * dt.signoDoc;
                var montoSaldoPendMonDiv = dt.montoPendCxcMonReferencia * dt.signoDoc;
                if (dt.isAnulado) 
                {
                    importeMonAct = 0m;
                    importeMonDiv = 0m;
                    montoBonoDiv = 0m;
                    montoSaldoPendMonDiv = 0m;
                }
                DataRow p = ds.Tables["VentCredito"].NewRow();
                p["docNumero"] = dt.nroDoc+Environment.NewLine+dt.siglasDoc+ Environment.NewLine+dt.nroDocAplica;
                p["docEmision"] = dt.fechaEmisionDoc;
                p["entidad"] = dt.ciRifDoc + Environment.NewLine + dt.entidadDoc;
                p["importeMonAct"] = importeMonAct;
                p["importeMonDiv"] = importeMonDiv;
                p["montoBonoDiv"] = montoBonoDiv;
                p["portcBonoDiv"] = 0m;
                p["montoSaldoPendMonDiv"] = montoSaldoPendMonDiv;
                p["isAnulado"] = dt.isAnulado ? "1" : "";
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