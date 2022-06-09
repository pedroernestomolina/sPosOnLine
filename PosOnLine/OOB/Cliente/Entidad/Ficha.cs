using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Cliente.Entidad
{
    
    public class Ficha 
    {

        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string CiRif { get; set; }
        public string DireccionFiscal { get; set; }
        public string Telefono { get; set; }
        public string Estatus { get; set; }
        public string EstatusCredito { get; set; }
        public string Tarifa { get; set; }
        public bool IsActivo { get { return Estatus.Trim().ToUpper() == "ACTIVO" ? true : false; } }
        public bool IsClienteCredito { get { return EstatusCredito.Trim().ToUpper() == "1" ? true : false; } }
        public string Data { get { return CiRif.Trim() + Environment.NewLine + Nombre.Trim(); } }
        public string TarifaPrecio 
        { 
            get 
            { 
                var xr="1";
                if (Tarifa !="0")
                    xr=Tarifa;
                return xr;
            } 
        }


        public Ficha()
        {
            Id = "";
            Codigo = "";
            Nombre = "";
            CiRif = "";
            DireccionFiscal = "";
            Telefono = "";
            Estatus = "";
            EstatusCredito = "";
            Tarifa = "";
        }

    }

}