using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
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

            //public string simporte { get { return "Bs " + importe.ToString("n2"); } }
            public string simporte { get { return "" + importe.ToString("n2"); } }

            public List<string> sdescripcion
            {
                get
                {
                    var lst = new List<string>();
                    var t = descripcion.Trim();
                    var l = (int)t.Length / 30;
                    var sw = 0;
                    for (var x = 0; x < l; x++)
                    {
                        var xt = t.Substring(30 * x, 30);
                        if (isExento && sw == 0)
                        {
                            sw = 1;
                            xt = xt + " (E)";
                        }
                        lst.Add(xt);
                    }
                    if (t.Length > (30 * l))
                    {
                        var xt = t.Substring(30 * l);
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
                    t += " X " + Sistema.SimboloDivisa_AlImprimirTicket + precioDivisa.ToString("n2");
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
        public string bonoDivisa { get; set; }
        public string saldoPendiente { get; set; }
        public List<Item> Items { get; set; }
        public List<MedioPago> MediosPago { get; set; }
        public List<MedidaEmp> MedidasEmp { get; set; }
        public List<String> Precios { get; set; }


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
            bonoDivisa = "";
            HayCargo = false;
            Items = new List<Item>();
            MediosPago = new List<MedioPago>();
            MedidasEmp = new List<MedidaEmp>();
            Precios = new List<string>();
            ImageQR = null;
            vueltoEfectivo = "";
            vueltoDivisa = "";
            vueltoPagoMovil = "";
            IsAnulado = false;
            //
            bonoDscto = "";
            //
            saldoPendiente = "";
        }
        public Bitmap ImageQR { get; set; }
        public string vueltoEfectivo { get; set; }
        public string vueltoDivisa { get; set; }
        public string vueltoPagoMovil { get; set; }
        public bool IsAnulado { get; set; }
        public string bonoDscto { get; set; }
    }
}
