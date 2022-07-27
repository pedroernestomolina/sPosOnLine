using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir.Tickera80
{

    public class Ticket
    {

        public class DatosNegocio
        {
            public string cirif { get; set; }
            public string razonsocial_1 { get; set; }
            public string razonsocial_2 { get; set; }
            public string razonsocial_3 { get; set; }
            public string direcionFiscal_1 { get; set; }
            public string direcionFiscal_2 { get; set; }
            public string direcionFiscal_3 { get; set; }
            public string direcionFiscal_4 { get; set; }
            public string telefono_1 { get; set; }
            public string telefono_2 { get; set; }


            public DatosNegocio()
            {
                Limpiar();
            }


            public void Limpiar() 
            {
                cirif = "";
                razonsocial_1 = "";
                razonsocial_2 = "";
                razonsocial_3 = "";
                direcionFiscal_1 = "";
                direcionFiscal_2 = "";
                direcionFiscal_3 = "";
                direcionFiscal_4 = "";
                telefono_1 = "";
                telefono_2 = "";
            }

            public void setEmpresa(OOB.Sistema.Empresa.Ficha ficha)
            {
                Limpiar();

                cirif = ficha.CiRif;
                if (Sistema.DatosNegociTicket_Rif.Trim() != "")
                    cirif = Sistema.DatosNegociTicket_Rif.Trim();

                var n = ficha.Nombre.Trim();
                if (Sistema.DatosNegociTicket_Nombre.Trim() != "")
                    n= Sistema.DatosNegociTicket_Nombre.Trim();

                var l = n.Length;
                var ml = 50;

                if (n.Length > ml*3)
                {
                    razonsocial_1 = n.Substring(0, ml);
                    razonsocial_2 = n.Substring(ml, ml);
                    razonsocial_3 = n.Substring(ml*2, ml);
                }
                if (n.Length > (ml*2) && n.Length<=(ml*3)) 
                {
                    razonsocial_1 = n.Substring(0,ml);
                    razonsocial_2 = n.Substring(ml,ml);
                    razonsocial_3 = n.Substring(ml*2);
                }
                if (n.Length>ml && n.Length<=(ml*2)) 
                {
                    razonsocial_1 = n.Substring(0, ml);
                    razonsocial_2 = n.Substring(ml);
                }
                if (n.Length > 0 && n.Length <=ml)
                {
                    razonsocial_1 = n.Substring(0);
                }

                var nd = ficha.Direccion.Trim();
                if (Sistema.DatosNegociTicket_Direccion.Trim() != "")
                    nd= Sistema.DatosNegociTicket_Direccion.Trim();

                var ld = nd.Length;
                if (nd.Length > (ml*4))
                {
                    direcionFiscal_1 = nd.Substring(0, ml);
                    direcionFiscal_2 = nd.Substring(ml, ml);
                    direcionFiscal_3 = nd.Substring((ml*2), ml);
                    direcionFiscal_4 = nd.Substring((ml*3), ml);
                }
                if (nd.Length > (ml*3)&& nd.Length <=(ml*4))
                {
                    direcionFiscal_1 = nd.Substring(0, ml);
                    direcionFiscal_2 = nd.Substring(ml, ml);
                    direcionFiscal_3 = nd.Substring((ml*2), ml);
                    direcionFiscal_4 = nd.Substring((ml*3));
                }
                if (nd.Length > (ml*2) && nd.Length <= (ml*3))
                {
                    direcionFiscal_1 = nd.Substring(0, ml);
                    direcionFiscal_2 = nd.Substring(ml, ml);
                    direcionFiscal_3 = nd.Substring(ml*2);
                }
                if (nd.Length > ml && nd.Length <=(ml*2))
                {
                    direcionFiscal_1 = nd.Substring(0, ml);
                    direcionFiscal_2 = nd.Substring(ml);
                }
                if (nd.Length > 0 && nd.Length <= ml)
                {
                    direcionFiscal_1 = nd.Substring(0);
                }

                var tlf = ficha.Telefono.Trim();
                var ltlf = tlf.Length;
                if (ltlf > (ml*2))
                {
                    telefono_1 = tlf.Substring(0, ml);
                    telefono_2 = tlf.Substring(ml, ml);
                }
                if (ltlf> ml && ltlf<=(ml*2))
                {
                    telefono_1 = tlf.Substring(0, ml);
                    telefono_2 = tlf.Substring(ml);
                }
                if (ltlf > 0 && ltlf <= ml)
                {
                    telefono_1 = tlf.Substring(0);
                }
            }
        }

        public class DatosCliente
        {
            public string cirif { get; set; }
            public string nombre_1 { get; set; }
            public string nombre_2 { get; set; }
            public string dirFiscal_1 { get; set; }
            public string dirFiscal_2 { get; set; }
            public string telefono_1 { get; set; }
            public string condicionpago { get; set; }
            public string estacion { get; set; }
            public string usuario { get; set; }


            public DatosCliente()
            {
                Limpiar();
            }

            public void Limpiar() 
            {
                cirif = "";
                nombre_1 = "";
                nombre_2 = "";
                dirFiscal_1 = "";
                dirFiscal_2 = "";
                telefono_1 = "";
                condicionpago = "";
                usuario = "";
                estacion = "";
            }
        }

        public class DatosDocumento
        {

            public class Item
            {
                public decimal cantidad { get; set; }
                public decimal precio { get; set; }
                public bool isExento { get; set; }
                public bool isPesado { get; set; }
                public decimal importe { get; set; }
                public string descripcion { get; set; }
                public int empCont { get; set; }
                public string empDesc { get; set; }
                public decimal factorCambio { get; set; }
                public decimal precioDivisa
                {
                    get
                    {
                        var rt = 0m;
                        if (factorCambio > 0)
                        {
                            rt = precio / factorCambio;
                        }
                        return rt;
                    }
                }


                public Item()
                {
                    cantidad = 1.0m;
                    precio = 0.0m;
                    isExento = false;
                    isPesado = false;
                    importe = 0.0m;
                    descripcion = "";
                    empCont = 0;
                    empDesc = "";
                }


                public string simporte { get { return "Bs " + importe.ToString("n2"); } }
                public List<string> sdescripcion
                {
                    get
                    {
                        //var t = descripcion.Trim();
                        //if (t.Length >= 30)
                        //{
                        //    t = t.Substring(0, 30);
                        //}
                        //if (isExento) { t = t + " (E)"; }

                        var lst = new List<string>();
                        var t = descripcion.Trim();
                        var l = (int)t.Length / 30;
                        var sw = 0;
                        for (var x = 0; x < l; x++) 
                        {
                            var xt = t.Substring(30*x, 30*(x+1));
                            if (isExento && sw==0)
                            {
                                sw = 1;
                                xt = xt + " (E)";
                            }
                            lst.Add(xt);
                        }
                        if (t.Length > (30 * l)) 
                        {
                            var xt = t.Substring(30*l);
                            lst.Add(xt);
                        }

                        return lst;
                    }
                }
                public string scantidadPrecio
                {
                    get
                    {
                        var c = (int)cantidad;
                        var cx = cantidad.ToString("n3");
                        if ((cantidad - c) == 0)
                        {
                            cx = cantidad.ToString("n0");
                        }
                        var t = "";
                        t += cx + " ";
                        t += empDesc.Trim() + "/" + empCont.ToString().Trim();
                        t += " X " + precio.ToString("n2");
                        t += " X $" + precioDivisa.ToString("n2");
                        return t;
                    }
                }
            }

            public class MedioPago
            {
                public string descripcion { get; set; }
                public string monto { get; set; }
            }

            public class MedidaEmp 
            {
                public string nombre { get; set; }
            }

            public string nombre { get; set; }
            public string aplicaA { get; set; }
            public string numero { get; set; }
            public string fecha { get; set; }
            public string hora { get; set; }
            public string subtotalNeto { get; set; }
            public string subtotal { get; set; }
            public string descuentoMonto { get; set; }
            public string descuentoPorct { get; set; }
            public string cargoMonto { get; set; }
            public string cargoPorct { get; set; }
            public bool HayDescuento { get; set; }
            public bool HayCargo { get; set; }
            public string total { get; set; }
            public string cambio { get; set; }
            public decimal factorCambio { get; set; }
            public string totalDivisa { get; set; }
            public List<Item> Items { get; set; }
            public List<MedioPago> MediosPago { get; set; }
            public List<MedidaEmp > MedidasEmp { get; set; }


            public string descuento
            {
                get
                {
                    return "DESCUENTO " + descuentoPorct;
                }
            }

            public string cargo
            {
                get
                {
                    return "CARGO " + cargoPorct;
                }
            }


            public DatosDocumento()
            {
                Limpiar();
            }

            public void Limpiar() 
            {
                aplicaA = "";
                nombre = "";
                numero = "";
                fecha = "";
                hora = "";
                subtotal = "";
                total = "";
                cambio = "";
                descuentoMonto = "";
                descuentoPorct = "";
                cargoMonto = "";
                cargoPorct = "";
                HayDescuento = false;
                factorCambio = 0m;
                totalDivisa = "";
                HayCargo = false;
                Items = new List<Item>();
                MediosPago = new List<MedioPago>();
                MedidasEmp = new List<MedidaEmp>();
                ImageQR = null;
            }

            public Bitmap ImageQR { get; set; }
        }

        public enum EnumModoTicket { Modo80mm = 1, Modo58mm };
        public int caracterPorLinea;
        public float anchoPapel ;


        public DatosNegocio Negocio;
        public DatosCliente Cliente;
        public DatosDocumento Documento;
        private System.Drawing.Printing.PrintPageEventArgs eg;
        private EnumModoTicket _modoTicket;


        public Ticket()
        {
            setModo(EnumModoTicket.Modo80mm);
            Negocio = new DatosNegocio();
            Cliente = new DatosCliente();
            Documento = new DatosDocumento();
        }


        public void setControlador(System.Drawing.Printing.PrintPageEventArgs e) 
        {
            eg = e;
        }

        public void setModo(EnumModoTicket modo)
        {
            _modoTicket = modo;
            switch (modo) 
            {
                case EnumModoTicket.Modo58mm:
                    caracterPorLinea = 32;
                    anchoPapel = 184;
                    break;
                case EnumModoTicket.Modo80mm:
                    caracterPorLinea = 50;
                    anchoPapel = 285;
                    break;
            }
        }


        public void Imrpimir() 
        {

            var fr = new Font("Arial", 7, FontStyle.Regular);
            var fb = new Font("Arial", 8, FontStyle.Bold);
            var fc = new Font("Arial", 9, FontStyle.Bold);


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
                    eg.Graphics.DrawString(xl, fb, Brushes.Black, 0, l);
                    if (sw == 0)
                    {
                        eg.Graphics.DrawString(r.simporte, fb, Brushes.Black, dder2(r.simporte, fb), l);
                        sw = 1;
                    }
                    l += 10;
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
            eg.Graphics.DrawString("TOTAL($)", fb, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.totalDivisa, fr, Brushes.Black, dder2(df.totalDivisa, fr), l);
            l += 15;

            foreach (var mp in df.MediosPago)
            {
                eg.Graphics.DrawString(mp.descripcion, fr, Brushes.Black, 0, l);
                eg.Graphics.DrawString(mp.monto, fr, Brushes.Black, dder2(mp.monto,fr), l);
                l += 10;
            }
            eg.Graphics.DrawString("CAMBIO", fr, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.cambio, fr, Brushes.Black, dder2(df.cambio,fr), l);
            l += 15;

            eg.Graphics.DrawString("EMPAQUE              CANT      PESO     VOLUMEN", fr, Brushes.Black, 0, l);
            l += 10;
            foreach (var mp in df.MedidasEmp)
            {
                eg.Graphics.DrawString(mp.nombre, fr, Brushes.Black, 0, l);
                l += 10;
            }

            if (df.ImageQR != null) 
            {
                l += 10;
                PointF loc = new PointF(100, l);
                eg.Graphics.DrawImage(df.ImageQR, loc);
            }
        }

        private float centrar(string t)
        {
            float r = 0.0f;
            float tl = (anchoPapel/ caracterPorLinea);
            r = (( caracterPorLinea- t.Trim().Length) / 2.0f) * tl;
            return r;
        }

        private float dder2(string texto, Font fuente)
        {
            float r = 0.0f;
            var t = eg.Graphics.MeasureString(texto, fuente).Width;
            return (anchoPapel - t);
        }

        public void Reporte(List<string> lineas) 
        {
            var l = 0;
            var fr = new Font(FontFamily.GenericMonospace, 7, FontStyle.Regular);
            foreach (var lin in lineas)
            {
                eg.Graphics.DrawString(lin, fr, Brushes.Black, 0, l);
                l += 10;
            }
        }

    }

}