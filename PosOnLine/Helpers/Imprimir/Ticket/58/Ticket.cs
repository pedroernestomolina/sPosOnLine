using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir.Ticket._58
{
    public class Ticket: baseTicket
    {
        public Ticket()
            :base()
        {
            caracterPorLinea = 32;
            anchoPapel = 184;
        }
        public override void Imprimir()
        {
            var fr = new Font("Arial", 6, FontStyle.Regular);
            var fb = new Font("Arial", 7, FontStyle.Bold);
            //
            var dn = this.Negocio;
            var df = this.Documento;
            var st = new List<String>();
            st.Add(dn.cirif);
            st.Add(dn.razonsocial_1);
            st.Add(dn.razonsocial_2);
            st.Add(dn.direcionFiscal_1);
            st.Add(dn.direcionFiscal_2);
            st.Add(dn.direcionFiscal_3);
            st.Add(dn.direcionFiscal_4);
            st.Add(dn.telefono_1);
            st.Add(dn.telefono_2);

            var dc = this.Cliente;
            var sc = new List<String>();

            if (df.aplicaA != "")
            {
                sc.Add("APLICA: " + df.aplicaA);
            }

            sc.Add("Datos Del Cliente:");
            sc.Add(dc.cirif);
            sc.Add(dc.nombre_1);
            sc.Add(dc.nombre_2);
            sc.Add(dc.dirFiscal_1);
            sc.Add(dc.dirFiscal_2);
            sc.Add(dc.telefono_1);
            sc.Add("CONDICION PAGO: " + dc.condicionpago);
            sc.Add("ESTACION: " + dc.estacion);
            sc.Add("USUARIO: " + dc.usuario);

            float l = 0.0f;
            foreach (var s in st)
            {
                if (s.Trim() != "")
                {
                    var t = eg.Graphics.MeasureString(s, fr).Width;
                    var c = (anchoPapel - t) / 2;
                    eg.Graphics.DrawString(s, fr, Brushes.Black, c, l);
                    l += 10f;
                }
            }
            l += 10f;

            foreach (var s in sc)
            {
                if (s.Trim() != "")
                {
                    eg.Graphics.DrawString(s, fr, Brushes.Black, 0, l);
                    l += 10f;
                }
            }

            l += 10f;
            eg.Graphics.DrawString(df.nombre, fb, Brushes.Black, centrar(df.nombre), l);
            l += 10;
            eg.Graphics.DrawString(df.nombre+":", fr, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.numero, fr, Brushes.Black, dder2(df.numero,fr), l);
            l += 10;
            eg.Graphics.DrawString("FECHA: " + df.fecha, fr, Brushes.Black, 0, l);
            eg.Graphics.DrawString("HORA: " + df.hora, fr, Brushes.Black, dder2("HORA: " + df.hora,fr), l);
            l += 10;
            eg.Graphics.DrawString("-".PadRight(58, '-'), fb, Brushes.Black, 0, l);
            l += 10;

            foreach (var r in df.Items)
            {
                if (r.isPesado)
                {
                }
                else
                {
                    var xdes = r.descripcion.Trim();
                    if (xdes.Length > 15)
                        xdes = xdes.Substring(0, 15);

                    if (r.cantidad != 1.0m)
                    {
                        eg.Graphics.DrawString(r.scantidadPrecio, fr, Brushes.Black, 0, l);
                        l += 10;
                    }
                    if (r.empCont > 1) 
                    {
                        var empCont = r.empDesc.Trim() + "/" + r.empCont.ToString().Trim();
                        eg.Graphics.DrawString(empCont, fr, Brushes.Black, 0, l);
                        l += 10;
                    }
                    eg.Graphics.DrawString(xdes, fr, Brushes.Black, 0, l);
                    eg.Graphics.DrawString(r.simporte, fr, Brushes.Black, dder2(r.simporte, fr), l);
                    l += 10;
                }
            }

            eg.Graphics.DrawString("-".PadRight(58, '-'), fb, Brushes.Black, 0, l);
            l += 10;
            eg.Graphics.DrawString("SUBTOTAL", fr, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.subtotal, fr, Brushes.Black, dder2(df.subtotal,fr), l);
            l += 10;
            eg.Graphics.DrawString("-".PadRight(58, '-'), fb, Brushes.Black, 0, l);
            l += 10;

            if (df.HayCargo || df.HayDescuento) 
            {
                if (df.HayDescuento)
                {
                    eg.Graphics.DrawString(df.descuento, fr, Brushes.Black, 0, l);
                    eg.Graphics.DrawString(df.descuentoMonto, fr, Brushes.Black, dder2(df.descuentoMonto,fr), l);
                    l += 10;
                    eg.Graphics.DrawString("-".PadRight(50, '-'), fr, Brushes.Black, 0, l);
                    l += 10;
                }
                if (df.HayCargo)
                {
                    eg.Graphics.DrawString(df.cargo, fr, Brushes.Black, 0, l);
                    eg.Graphics.DrawString(df.cargoMonto, fr, Brushes.Black, dder2(df.cargoMonto,fr), l);
                    l += 10;
                    eg.Graphics.DrawString("-".PadRight(50, '-'), fr, Brushes.Black, 0, l);
                    l += 10;
                }
            }

            eg.Graphics.DrawString("TOTAL", fb, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.total, fr, Brushes.Black, dder2(df.total,fr), l);
            l += 10;
            eg.Graphics.DrawString("TOTAL US$", fb, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.totalDivisa, fb, Brushes.Black, dder2(df.totalDivisa, fb), l);
            l += 15;

            foreach (var mp in df.MediosPago)
            {
                eg.Graphics.DrawString(mp.descripcion, fr, Brushes.Black, 0, l);
                eg.Graphics.DrawString(mp.monto, fr, Brushes.Black, dder2(mp.monto,fr), l);
                l += 10;
            }
            eg.Graphics.DrawString("CAMBIO", fr, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.cambio, fr, Brushes.Black, dder2(df.cambio,fr), l);

            if (df.vueltoEfectivo != "")
            {
                l += 10;
                eg.Graphics.DrawString("Vuelto en Efectivo:", fr, Brushes.Black, 0, l);
                eg.Graphics.DrawString(df.vueltoEfectivo, fr, Brushes.Black, dder2(df.vueltoEfectivo, fr), l);
            }
            if (df.vueltoDivisa != "")
            {
                l += 10;
                eg.Graphics.DrawString("Vuelto en Divisa($):", fr, Brushes.Black, 0, l);
                eg.Graphics.DrawString(df.vueltoDivisa, fr, Brushes.Black, dder2(df.vueltoDivisa, fr), l);
            }
            if (df.vueltoPagoMovil != "")
            {
                l += 10;
                eg.Graphics.DrawString("Vuelto en PagoMovil:", fr, Brushes.Black, 0, l);
                eg.Graphics.DrawString(df.vueltoPagoMovil, fr, Brushes.Black, dder2(df.vueltoPagoMovil, fr), l);
            }
            l += 10;
        }
        public override void Reporte(IEnumerable<string> lineas)
        {
            var l = 0;
            var fr = new Font(FontFamily.GenericMonospace, 5, FontStyle.Bold);
            foreach (var lin in lineas)
            {
                eg.Graphics.DrawString(lin, fr, Brushes.Black, 0, l);
                l += 10;
            }
        }
    }
}