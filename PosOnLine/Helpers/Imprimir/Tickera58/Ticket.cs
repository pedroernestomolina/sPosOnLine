using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir.Tickera58
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
                var ml = 32;
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
                    nd = Sistema.DatosNegociTicket_Direccion.Trim();
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
                public string sdescripcion
                {
                    get
                    {
                        var t = descripcion.Trim();
                        if (t.Length >= 40)
                        {
                            t = t.Substring(0, 40);
                        }
                        if (isExento) { t = t + " (E)"; }
                        return t;
                    }
                }
                public string scantidadPrecio
                {
                    get
                    {
                        var t = "";
                        t = cantidad.ToString("n2") + " X " + precio.ToString("n2");
                        return t;
                    }
                }
            }

            public class MedioPago
            {
                public string descripcion { get; set; }
                public string monto { get; set; }
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
            public string totalDivisa { get; set; }
            public List<Item> Items { get; set; }
            public List<MedioPago> MediosPago { get; set; }


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
                totalDivisa = "";
                cambio = "";
                descuentoMonto = "";
                descuentoPorct = "";
                cargoMonto = "";
                cargoPorct = "";
                HayDescuento = false;
                HayCargo = false;
                Items = new List<Item>();
                MediosPago = new List<MedioPago>();
            }
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
            setModo(EnumModoTicket.Modo58mm);
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
                    caracterPorLinea = 51;
                    anchoPapel = 285;
                    break;
            }
        }


        public void Imrpimir() 
        {

            var fr = new Font("Arial", 6, FontStyle.Regular);
            var fb = new Font("Arial", 7, FontStyle.Bold);


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
                    //eg.Graphics.DrawString(s, fr, Brushes.Black, centrar(s), l);
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
            eg.Graphics.DrawString("-".PadRight(85, '-'), fb, Brushes.Black, 0, l);
            l += 10;

            foreach (var r in df.Items)
            {
                if (r.isPesado)
                {
                }
                else
                {
                    var xdes = r.descripcion.Trim();
                    if (_modoTicket == EnumModoTicket.Modo58mm)
                    {
                        if (xdes.Length > 15)
                            xdes = xdes.Substring(0, 15);
                    }

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
                //eg.Graphics.DrawString("SUBTOTAL", fr, Brushes.Black, 0, l);
                //eg.Graphics.DrawString(df.subtotal, fr, Brushes.Black, dder2(df.subtotal,fr), l);
                //l += 10;
                //eg.Graphics.DrawString("-".PadRight(90, '-'), fr, Brushes.Black, 0, l);
                //l += 10;
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
            l += 10;
        }

        private float centrar(string t)
        {
            float r = 0.0f;
            ////r=(275 /51 - ((70 / 49) * t.Trim().Length))/2;
            //float tl = (275.0f / 51.0f);
            //r = ((50.0f - t.Trim().Length) / 2.0f) * tl;
            //return r;

            float tl = (anchoPapel/ caracterPorLinea);
            r = (( caracterPorLinea- t.Trim().Length) / 2.0f) * tl;
            return r;
        }

        //private float dder(string t)
        //{
        //    float r = 0.0f;
        //    ////r=(275 /51 - ((70 / 49) * t.Trim().Length))/2;
        //    //float tl = (285.0f / 51.0f);
        //    //r = ((51.0f - t.Length)) * tl;
        //    //return r;

        //    float tl = ((anchoPapel+0) / caracterPorLinea);
        //    r = (((caracterPorLinea+1) - t.Length)) * tl;
        //    return r;
        //}

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