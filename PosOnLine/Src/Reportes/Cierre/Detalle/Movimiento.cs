using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Reportes.Cierre.Detalle
{

    public class Movimiento
    {


        private List<OOB.Reportes.Pos.PagoDetalle.Ficha> _lista;
        private decimal _montoNtCredito;


        public Movimiento(List<OOB.Reportes.Pos.PagoDetalle.Ficha> list)
        {
            _montoNtCredito = 0.0m;
            _lista = list;
        }


        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Src\Reportes\PagoDetalle.rdlc";
            var ds = new DS();
            var xid = 0;
            var montoTotal = 0.0m;
            var cambioDarTotal = 0.0m;
            var ncreditoTotal = _montoNtCredito;

            foreach (var rg in _lista.OrderBy(o => o.idRecibo).ToList())
            {
                xid += 1;
                if (rg.isActivo && rg.isFactura)
                {
                    montoTotal += rg.docMonto;
                    cambioDarTotal += rg.docCambioDar;
                }

                foreach (var pg in rg.pagos.ToList())
                {
                    DataRow p = ds.Tables["Pago"].NewRow();
                    p["id1"] = xid.ToString().Trim().PadLeft(4, '0');
                    p["documento"] = rg.docNumero;
                    p["fechaHora"] = rg.docHora + Environment.NewLine + rg.docFecha.ToShortDateString();
                    p["nombreRazonSocial"] = rg.cliCiRif + Environment.NewLine + rg.cliNombre;
                    p["dirFiscal"] = rg.cliDir;
                    p["telefono"] = rg.cliTelf;
                    p["cambioDar"] = rg.docCambioDar;

                    var _monto = rg.docMonto;
                    var _medioPago = pg.medioPagCodigo + "/ " + pg.medioPagDesc;
                    var _montoRecibido = pg.montoRecibido;
                    var _importe = pg.montoRecibido;
                    var _tasa = "";

                    if (pg.tasaDivisa > 1)
                    {
                        _tasa = pg.tasaDivisa.ToString("n2");
                        _montoRecibido = pg.cntDivisa;
                        _importe = _montoRecibido * pg.tasaDivisa;
                    }

                    if (rg.isActivo)
                    {
                        p["estatus"] = "Activo";
                        p["monto"] = rg.docMonto;
                        p["montoRecibido"] = _montoRecibido;
                        p["codigoMedioPago"] = pg.medioPagCodigo + "/ " + pg.medioPagDesc;
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
                    if (!rg.isActivo)
                    {
                        break;
                    }
                }
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("montoTotal", montoTotal.ToString("n2")));
            pmt.Add(new ReportParameter("cambioDarTotal", cambioDarTotal.ToString("n2")));
            pmt.Add(new ReportParameter("ncreditoTotal", ncreditoTotal.ToString("n2")));
            Rds.Add(new ReportDataSource("Pago", ds.Tables["Pago"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

        public void setMontoNtCredito(decimal p)
        {
            _montoNtCredito = p;
        }

    }

}