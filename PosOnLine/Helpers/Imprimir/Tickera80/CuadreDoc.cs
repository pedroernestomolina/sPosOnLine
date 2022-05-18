using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir.Tickera80
{


    public class CuadreDoc : ICuadreCaja
    {

        private dataCuadre _ds;
        private List<string> _lista;
        private Ticket _tick;


        public CuadreDoc()
        {
            _tick = new Ticket();
            _lista = new List<string>();
        }


        public void setData(dataCuadre ds)
        {
            _ds = ds;
        }

        public void ImprimirDoc()
        {
            Imprimir();
        }

        private void Imprimir()
        {
            _lista.Add("REPORTE CAJA");
            _lista.Add("");
            _lista.Add("EQUIPO: " + Sistema.EquipoEstacion);
            _lista.Add("OPERAD: " + _ds.Usuario);
            _lista.Add("FECHA : " + DateTime.Now.ToShortDateString());
            _lista.Add("HORA  : " + DateTime.Now.ToShortTimeString());
            _lista.Add("");
            _lista.Add("");
            _lista.Add("EN FACTURA");
            _lista.Add("Cant      : " + _ds.cntFAC.ToString("n0"));
            _lista.Add("Monto     : " + _ds.montoFAC.ToString("n2").PadLeft(18, ' '));
            _lista.Add("");
            _lista.Add("EN NT/CREDITO");
            _lista.Add("Cant      : " + _ds.cntNCR.ToString("n0"));
            _lista.Add("Monto     : " + _ds.montoNCR.ToString("n2").PadLeft(18, ' '));
            _lista.Add("");
            _lista.Add("EN NT/ENTREGA");
            _lista.Add("Cant      : " + _ds.cntNEN.ToString("n0"));
            _lista.Add("Monto     : " + _ds.montoNEN.ToString("n2").PadLeft(18, ' '));
            _lista.Add("");
            _lista.Add("TOTAL VENTA");
            _lista.Add("MONTO     : " + _ds.montoVenta.ToString("n0").PadLeft(18, ' '));
            _lista.Add("");
            _lista.Add("CONTADO   :");
            _lista.Add("Cant      : " + _ds.cntDocContado.ToString("n0"));
            _lista.Add("Monto     : " + _ds.montoVentaContado.ToString("n0").PadLeft(18, ' '));
            _lista.Add("");
            _lista.Add("CREDITO   :");
            _lista.Add("Cant      : " + _ds.cntDocCredito.ToString("n0"));
            _lista.Add("Monto     : " + _ds.montoVentaCredito.ToString("n2").PadLeft(18, ' '));
            _lista.Add("");
            _lista.Add("");
            _lista.Add("DESGLOZE");
            _lista.Add("Efectivo  : " + _ds.cnt_efectivo_s.ToString("n0"));
            _lista.Add("Monto     : " + _ds.efectivo_s.ToString("n2").PadLeft(18, ' '));
            _lista.Add("Divisa    : " + _ds.cnt_divisa_s.ToString("n2"));
            _lista.Add("Monto     : " + _ds.divisa_s.ToString("n2").PadLeft(18, ' '));
            _lista.Add("Tarjetas  : " + _ds.cnt_electronico_s.ToString("n0"));
            _lista.Add("Monto     : " + _ds.electronico_s.ToString("n2").PadLeft(18, ' '));
            _lista.Add("Otros     : " + _ds.cnt_otros_s.ToString("n0"));
            _lista.Add("Monto     : " + _ds.otros_s.ToString("n2").PadLeft(18, ' '));
            _lista.Add("Devoluc   : " + _ds.cntNCR.ToString("n0"));
            _lista.Add("Monto     : " + _ds.montoNCR.ToString("n2").PadLeft(18, ' '));
            _lista.Add("A Credito : " + _ds.cntDocCredito.ToString("n0"));
            _lista.Add("Monto     : " + _ds.credito_s.ToString("n2").PadLeft(18, ' '));
            _lista.Add("TOTAL     :");
            _lista.Add("Monto     : " + _ds.cuadre_s.ToString("n2").PadLeft(18, ' '));

            _lista.Add("");
            _lista.Add("");
            _lista.Add("USUARIO");
            _lista.Add("Efectivo   ");
            _lista.Add("Monto     : " + _ds.efectivo_u.ToString("n2").PadLeft(18, ' '));
            _lista.Add("Divisa     ");
            _lista.Add("Cantidad  : " + _ds.cnt_divisa_u.ToString("n2"));
            _lista.Add("Monto     : " + _ds.divisa_u.ToString("n2").PadLeft(18, ' '));
            _lista.Add("Tarjetas   ");
            _lista.Add("Monto     : " + _ds.electronico_u.ToString("n2").PadLeft(18, ' '));
            _lista.Add("Otros      ");
            _lista.Add("Monto     : " + _ds.otros_u.ToString("n2").PadLeft(18, ' '));
            _lista.Add("A Credito  ");
            _lista.Add("Monto     : " + _ds.credito_s.ToString("n2").PadLeft(18, ' '));
            _lista.Add("TOTAL     ");
            _lista.Add("Monto     : " + _ds.cuadre_u.ToString("n2").PadLeft(18, ' '));
            _tick.Reporte(_lista);
        }

        public void setGrafico(System.Drawing.Printing.PrintPageEventArgs e)
        {
            _tick.setControlador(e);
        }

    }

}