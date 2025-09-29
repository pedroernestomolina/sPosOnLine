using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreRepo.vm
{
    public class RepoCambiosVueltoImpl: IRepoCambiosVuelto
    {
        private List<Domain.Models.RepoCambiosVuelto> _lista;
        private Domain.UseCase.IUseCase _uc;
        //
        public RepoCambiosVueltoImpl()
        {
            _uc = new Domain.UseCase.UseCaseImpl();
        }
        //
        private void setDataCargar(List<Domain.Models.RepoCambiosVuelto> list)
        {
            _lista = list;
        }
        public void Generar()
        {
            setDataCargar(_uc.ReporteCambiosVueltoEntregado(Sistema.PosEnUso.idResumen));
            //
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"\Src\CuadreCierreRepo\repo\VueltosEntregado.rdlc";
            var ds = new repo.DS();
            //
            foreach (var rg in _lista.ToList())
            {
                DataRow p = ds.Tables["VueltosEnt"].NewRow();
                p["documento"] = rg.nroDoc + Environment.NewLine + rg.siglasDoc;
                p["fechaHora"] = rg.fechaEmisionDoc.ToShortDateString() + Environment.NewLine + rg.horaDoc;
                p["entNombre"] = rg.ciRifDoc + Environment.NewLine + rg.entidadDoc;
                p["entDir"] = rg.dirFiscal;
                p["entTelf"] = rg.telefono;
                p["montoDoc"] = rg.importeMonLocal;
                p["montoCambio"] = rg.cambioVueltoMonLocal;
                p["vueltoEfectivo"] = rg.vueltoEfectivoMonLocal;
                p["vueltoDivisa"] = rg.vueltoDivisaMonLocal;
                p["vueltoPagoMov"] = rg.vueltoPagoMovilMonLocal;
                p["cntVueltoDivisa"] = rg.cntDivisaEntregada;
                ds.Tables["VueltosEnt"].Rows.Add(p);
            }
            //
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("VueltosEnt", ds.Tables["VueltosEnt"]));
            //
            var frp = new __.Reporte.Frm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}