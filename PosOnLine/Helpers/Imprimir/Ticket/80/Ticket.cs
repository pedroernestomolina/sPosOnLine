using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir.Ticket._80
{
    public class Ticket: baseTicket
    {
        public Ticket()
            :base()
        {
            caracterPorLinea = 50;
            anchoPapel = 285;
        }
        public override void Imprimir()
        {
            var fp = new Font("Arial", 6, FontStyle.Regular);
            var fr = new Font("Arial", 7, FontStyle.Regular);
            var fb = new Font("Arial", 8, FontStyle.Bold);
            var fc = new Font("Arial", 9, FontStyle.Bold);
            var fd = new Font("Arial", 11, FontStyle.Bold); 
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

            if (df.IsAnulado)
            {
                l += 10f;
                eg.Graphics.DrawString("ANULADO", fd, Brushes.Black, centrar("ANULADO"), l);
                l += 5f;
            }

            l += 10f;
            eg.Graphics.DrawString(df.nombre, fc, Brushes.Black, centrar(df.nombre), l);
            l += 10;
            eg.Graphics.DrawString(df.nombre+":", fr, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.numero, fr, Brushes.Black, dder2(df.numero,fr), l);
            l += 10;
            eg.Graphics.DrawString("FECHA: " + df.fecha, fr, Brushes.Black, 0, l);
            eg.Graphics.DrawString("HORA: " + df.hora, fr, Brushes.Black, dder2("HORA: " + df.hora,fr), l);
            l += 10;
            eg.Graphics.DrawString("-".PadRight(85, '-'), fb, Brushes.Black, 0, l);
            l += 10;

            foreach (var r in df.Items)
            {
                var sw = 0;
                var xdes2 = r.sdescripcion;
                eg.Graphics.DrawString(r.scantidadPrecio, fb, Brushes.Black, 0, l);
                l += 10;
                foreach (var xl in xdes2)
                {
                    if (xl.Length > 0)
                    {
                        eg.Graphics.DrawString(xl, fb, Brushes.Black, 0, l);
                        if (sw == 0)
                        {
                            eg.Graphics.DrawString(r.simporte, fb, Brushes.Black, dder2(r.simporte, fb), l);
                            sw = 1;
                        }
                        l += 10;
                    }
                }
                l += 5;
            }

            eg.Graphics.DrawString("-".PadRight(85, '-'), fb, Brushes.Black, 0, l);
            l += 10;
            eg.Graphics.DrawString("SUBTOTAL", fr, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.subtotal, fr, Brushes.Black, dder2(df.subtotal,fr), l);
            l += 10;
            eg.Graphics.DrawString("-".PadRight(85, '-'), fb, Brushes.Black, 0, l);
            l += 10;

            if (df.HayCargo || df.HayDescuento) 
            {
                if (df.HayDescuento)
                {
                    eg.Graphics.DrawString(df.descuento, fr, Brushes.Black, 0, l);
                    eg.Graphics.DrawString(df.descuentoMonto, fr, Brushes.Black, dder2(df.descuentoMonto,fr), l);
                    l += 10;
                    eg.Graphics.DrawString("-".PadRight(90, '-'), fr, Brushes.Black, 0, l);
                    l += 10;
                }
                if (df.HayCargo)
                {
                    eg.Graphics.DrawString(df.cargo, fr, Brushes.Black, 0, l);
                    eg.Graphics.DrawString(df.cargoMonto, fr, Brushes.Black, dder2(df.cargoMonto,fr), l);
                    l += 10;
                    eg.Graphics.DrawString("-".PadRight(90, '-'), fr, Brushes.Black, 0, l);
                    l += 10;
                }
            }

            eg.Graphics.DrawString("TOTAL", fb, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.total, fr, Brushes.Black, dder2(df.total,fr), l);
            l += 10;
            eg.Graphics.DrawString("TOTAL(" + Sistema.SimboloDivisa_AlImprimirTicket + ")", fb, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.totalDivisa, fr, Brushes.Black, dder2(df.totalDivisa, fr), l);
            l += 10;
            eg.Graphics.DrawString(df.bonoDivisa, fb, Brushes.Black, 0, l);
            l += 10;
            eg.Graphics.DrawString(df.bonoDscto, fb, Brushes.Black, 0, l);
            if (df.saldoPendiente.Trim() != "")
            {
                l += 10;
                eg.Graphics.DrawString(df.saldoPendiente, fb, Brushes.Black, 0, l);
            }
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
                eg.Graphics.DrawString("Vuelto en Divisa(" + Sistema.SimboloDivisa_AlImprimirTicket + "):", fr, Brushes.Black, 0, l);
                eg.Graphics.DrawString(df.vueltoDivisa, fr, Brushes.Black, dder2(df.vueltoDivisa, fr), l);
            }
            if (df.vueltoPagoMovil != "") 
            {
                l += 10;
                eg.Graphics.DrawString("Vuelto en PagoMovil:", fr, Brushes.Black, 0, l);
                eg.Graphics.DrawString(df.vueltoPagoMovil, fr, Brushes.Black, dder2(df.vueltoPagoMovil, fr), l);
            }

            l += 15;
            eg.Graphics.DrawString("EMPAQUE              CANT      PESO     VOLUMEN", fb, Brushes.Black, 0, l);
            l += 10;
            foreach (var mp in df.MedidasEmp)
            {
                eg.Graphics.DrawString(mp.nombre, fb, Brushes.Black, 0, l);
                l += 10;
            }

            //
            if (df.Precios.Count > 0)
            {
                l += 15;
                eg.Graphics.DrawString("Ref", fb, Brushes.Black, 0, l);
                l += 10;
                foreach (var p in df.Precios)
                {
                    eg.Graphics.DrawString(p, fp, Brushes.Black, 0, l);
                    l += 10;
                }
            }
            //

            if (df.ImageQR != null) 
            {
                l += 10;
                PointF loc = new PointF(10, l);
                eg.Graphics.DrawImage(df.ImageQR, loc);
            }
        }
        public override void Reporte(IEnumerable<string> lineas)
        {
            var l = 0;
            var fr = new Font(FontFamily.GenericMonospace, 7, FontStyle.Bold);
            foreach (var lin in lineas)
            {
                eg.Graphics.DrawString(lin, fr, Brushes.Black, 0, l);
                l += 10;
            }
        }
    }
}