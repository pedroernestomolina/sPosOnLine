using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.vm
{
    public class RepoPagoMovilImpl: IRepoPagoMovil
    {
        private List<Domain.Models.RepoPagoMovil> _lista;
        //
        public RepoPagoMovilImpl()
        {
        }
        //
        public void setDataCargar(List<Domain.Models.RepoPagoMovil> list)
        {
            _lista = list;
        }
        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"\Src\CuadreCierre\repo\PagoMovil.rdlc";
            var ds = new repo.DS();
            //
            foreach (var rg in _lista.OrderBy(o => o.nroDoc).ToList())
            {
                DataRow p = ds.Tables["PagoMovil"].NewRow();
                p["docNro"] = rg.nroDoc;
                p["docFecha"] = rg.fechaEmisionDoc;
                p["docCliente"] = rg.ciRifEntidad + Environment.NewLine + rg.entidad;
                p["docEstatus"] = "";
                p["pmCliente"] = rg.ciRifDestinoPM + Environment.NewLine + rg.entidadDestinoPM;
                p["pmTelefono"] = rg.telefonoDestinoPM;
                p["pmMonto"] = rg.montoPM;
                p["pmAgencia"] = rg.agenciaDestino;
                ds.Tables["PagoMovil"].Rows.Add(p);
            }
            //
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("PagoMovil", ds.Tables["PagoMovil"]));
            //
            var frp = new __.Reporte.Frm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}