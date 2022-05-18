using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Helpers.Imprimir.Grafico
{

    public class Documento: IDocumento
    {

        private data _ds;


        public Documento()
        {
        }


        public void ImprimirDoc()
        {
            Imprimir();
        }

        public void ImprimirCopiaDoc()
        {
            Imprimir();
        }

        private void Imprimir()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Helpers\Imprimir\Grafico\Documento.rdlc";
            var ds = new ds();
            var factor = _ds.encabezado.FactorCambio;

            //NEGOCIO
            DataRow N = ds.Tables["DatosNegocio"].NewRow();
            N["Nombre"] = _ds.negocio.Nombre;
            N["CiRif"] = _ds.negocio.CiRif;
            N["Direccion"] = _ds.negocio.Direccion;
            ds.Tables["DatosNegocio"].Rows.Add(N);

            //ENCABEZADO
            DataRow E = ds.Tables["Encabezado"].NewRow();
            E["NombreCli"] = _ds.encabezado.NombreCli;
            E["DireccionCli"] = _ds.encabezado.DireccionCli;
            E["CiRifCli"] = _ds.encabezado.CiRifCli;
            E["CodigoCli"] = _ds.encabezado.CodigoCli;
            E["DocNombre"] = _ds.encabezado.DocumentoNombre;
            E["DocNro"] = _ds.encabezado.DocumentoNro;
            E["DocFecha"] = _ds.encabezado.DocumentoFecha;
            E["SubTotal"] = _ds.encabezado.SubTotalItemFull;
            E["Descuento"] = _ds.encabezado.Descuento;
            E["Total"] = _ds.encabezado.Total;
            E["TotalDivisa"] = _ds.encabezado.TotalDivisa;
            ds.Tables["Encabezado"].Rows.Add(E);

            //ITEMS
            foreach (var rg in _ds.item)
            {
                DataRow p = ds.Tables["Item"].NewRow();
                p["NombrePrd"] = rg.NombrePrd;
                p["CodigoPrd"] = rg.CodigoPrd;
                p["Cantidad"] = rg.Cantidad;
                p["Empaque"] = rg.Empaque+Environment.NewLine+"( "+rg.Contenido.ToString().Trim()+" )";
                p["Deposito"] = rg.DepositoDesc;
                p["Precio"] = rg.PrecioFull;
                p["PrecioDivisa"] = rg.PrecioFull/factor;
                p["Importe"] = rg.ImporteFull;
                p["ImporteDivisa"] = rg.ImporteDivisa/factor;
                p["TotalUnd"] = rg.TotalUnd ;
                ds.Tables["Item"].Rows.Add(p);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("DatosNegocio", ds.Tables["DatosNegocio"]));
            Rds.Add(new ReportDataSource("Encabezado", ds.Tables["Encabezado"]));
            Rds.Add(new ReportDataSource("Item", ds.Tables["Item"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }


        public void setData(data ds)
        {
            _ds = ds;
        }

    }

}