using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.vm
{
    public class RepoPagoDetalleImpl: IRepoPagoDetalle
    {
        private List<Domain.Models.RepoPagoDetalleEnc> _lista;
        private _Domain.Models.Moneda _monedaLocal;
        //
        public RepoPagoDetalleImpl()
        {
        }
        public void setMonedaLocal(_Domain.Models.Moneda moneda)
        {
            _monedaLocal = moneda;
        }
        public void setDataCargar(List<Domain.Models.RepoPagoDetalleEnc> data)
        {
            _lista = data;
        }
        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"\Src\CuadreCierre\repo\PagoDetalle.rdlc";
            var ds = new repo.DS();
            var xid = 0;
            var montoTotal = 0.0m;
            var cambioDarTotal = 0.0m;
            //
            foreach (var rg in _lista.OrderBy(o=>o.docNumero).ToList())
            {
                xid += 1;
                if (!rg.isAnulado && rg.isDocVenta)
                {
                    if (!rg.isCredito)
                    {
                        montoTotal += rg.docMonto;
                        cambioDarTotal += rg.docCambioDar;
                    }
                }
                foreach (var pg in rg.pagos.ToList())
                {
                    DataRow p = ds.Tables["Pago"].NewRow();
                    p["id1"] = xid.ToString().Trim().PadLeft(4, '0');
                    p["documento"] = rg.docNumero + Environment.NewLine+rg.docSiglas;
                    p["fechaHora"] = rg.docHora + Environment.NewLine + rg.docFecha.ToShortDateString();
                    p["nombreRazonSocial"] = rg.cliCiRif + Environment.NewLine + rg.cliNombre;
                    p["dirFiscal"] = rg.cliDir;
                    p["telefono"] = rg.cliTelf;
                    p["cambioDar"] = rg.docCambioDar;
                    //
                    var _monto = rg.docMonto;
                    var _medioPago = pg.codigoMP + "/ " + pg.descMP;
                    var _montoRecibido = pg.montoRecibido.ToString("n2")+pg.simboloMoneda;
                    var _importe = pg.montoRecibioMonLocal;
                    var _tasa = "";
                    //
                    if (_monedaLocal != null) 
                    {
                        if (_monedaLocal.codigo !=  pg.codigoMoneda)
                        {
                            _tasa = "/" + pg.tasaMoneda.ToString("n2") + "*" + rg.tasaReferencia.ToString("n2");
                        }
                    }
                    if (!rg.isAnulado)
                    {
                        p["estatus"] = "Activo";
                        p["monto"] = rg.docMonto;
                        p["montoRecibido"] = _montoRecibido;
                        if (rg.isCredito)
                        {
                            p["codigoMedioPago"] = "CREDITO";
                            p["esCredito"] = "1";
                        }
                        else 
                        {
                            p["codigoMedioPago"] = pg.descMP;
                            p["esCredito"] = "0";
                        }
                        p["tasa"] = _tasa;
                        p["importe"] = _importe;
                    }
                    else
                    {
                        p["estatus"] = "ANULADO";
                        p["monto"] = 0.0m;
                        p["montoRecibido"] = 0.0m;
                        p["codigoMedioPago"] = "";
                        p["tasa"] = "";
                        p["importe"] = 0.0m;
                    }
                    ds.Tables["Pago"].Rows.Add(p);
                    if (rg.isAnulado)
                    {
                        break;
                    }
                }
            }
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("montoTotal", montoTotal.ToString("n2")));
            pmt.Add(new ReportParameter("cambioDarTotal", cambioDarTotal.ToString("n2")));
            Rds.Add(new ReportDataSource("Pago", ds.Tables["Pago"]));
            //
            var frp = new __.Reporte.Frm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}