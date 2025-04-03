using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    abstract public class baseTicket : ITicket
    {
        protected System.Drawing.Printing.PrintPageEventArgs eg;
        protected int caracterPorLinea;
        protected float anchoPapel ;
        //
        public DatosNegocio Negocio { get; set; }
        public DatosCliente Cliente { get; set; }
        public DatosDocumento Documento { get; set; }
        //
        public baseTicket()
        {
            Negocio = new DatosNegocio();
            Cliente = new DatosCliente();
            Documento = new DatosDocumento();
        }
        public void setControlador(object ctr)
        {
            eg = (System.Drawing.Printing.PrintPageEventArgs)ctr;
        }
        abstract public void Imprimir();
        abstract public void Reporte(IEnumerable<string> lineas);
        //
        protected float centrar(string t)
        {
            float r = 0.0f;
            float tl = (anchoPapel / caracterPorLinea);
            r = ((caracterPorLinea - t.Trim().Length) / 2.0f) * tl;
            return r;
        }
        protected float dder2(string texto, Font fuente)
        {
            float r = 0.0f;
            var t = eg.Graphics.MeasureString(texto, fuente).Width;
            return (anchoPapel - t);
        }
    }
}