using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
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
            if (ficha != null)
            {
                cirif = ficha.CiRif;
                if (Sistema.DatosNegociTicket_Rif.Trim() != "")
                    cirif = Sistema.DatosNegociTicket_Rif.Trim();

                var n = ficha.Nombre.Trim();
                if (Sistema.DatosNegociTicket_Nombre.Trim() != "")
                    n = Sistema.DatosNegociTicket_Nombre.Trim();

                var l = n.Length;
                var ml = 48;

                if (n.Length > ml * 3)
                {
                    razonsocial_1 = n.Substring(0, ml);
                    razonsocial_2 = n.Substring(ml, ml);
                    razonsocial_3 = n.Substring(ml * 2, ml);
                }
                if (n.Length > (ml * 2) && n.Length <= (ml * 3))
                {
                    razonsocial_1 = n.Substring(0, ml);
                    razonsocial_2 = n.Substring(ml, ml);
                    razonsocial_3 = n.Substring(ml * 2);
                }
                if (n.Length > ml && n.Length <= (ml * 2))
                {
                    razonsocial_1 = n.Substring(0, ml);
                    razonsocial_2 = n.Substring(ml);
                }
                if (n.Length > 0 && n.Length <= ml)
                {
                    razonsocial_1 = n.Substring(0);
                }

                var nd = ficha.Direccion.Trim();
                if (Sistema.DatosNegociTicket_Direccion.Trim() != "")
                    nd = Sistema.DatosNegociTicket_Direccion.Trim();

                var ld = nd.Length;
                if (nd.Length > (ml * 4))
                {
                    direcionFiscal_1 = nd.Substring(0, ml);
                    direcionFiscal_2 = nd.Substring(ml, ml);
                    direcionFiscal_3 = nd.Substring((ml * 2), ml);
                    direcionFiscal_4 = nd.Substring((ml * 3), ml);
                }
                if (nd.Length > (ml * 3) && nd.Length <= (ml * 4))
                {
                    direcionFiscal_1 = nd.Substring(0, ml);
                    direcionFiscal_2 = nd.Substring(ml, ml);
                    direcionFiscal_3 = nd.Substring((ml * 2), ml);
                    direcionFiscal_4 = nd.Substring((ml * 3));
                }
                if (nd.Length > (ml * 2) && nd.Length <= (ml * 3))
                {
                    direcionFiscal_1 = nd.Substring(0, ml);
                    direcionFiscal_2 = nd.Substring(ml, ml);
                    direcionFiscal_3 = nd.Substring(ml * 2);
                }
                if (nd.Length > ml && nd.Length <= (ml * 2))
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
                if (ltlf > (ml * 2))
                {
                    telefono_1 = tlf.Substring(0, ml);
                    telefono_2 = tlf.Substring(ml, ml);
                }
                if (ltlf > ml && ltlf <= (ml * 2))
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
    }
}