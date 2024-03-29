﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdministradorDoc.Visualizar
{
    
    public class data
    {
        
        private OOB.Documento.Entidad.FichaItem it;


        public string CodigoPrd { get { return it.Codigo; } }
        public string NombrePrd { get { return it.Nombre; } }
        public decimal Precio { get { return it.PrecioItem; } }
        public decimal Importe { get { return it.Total; } }
        public string EmpaqueCont { get { return it.Empaque.Trim()+"/"+it.ContenidoEmpaque.ToString().Trim(); } }
        public string Cantidad { get { return it.EstatusPesado == "1" ? it.Cantidad.ToString("n3") : it.Cantidad.ToString("n0"); } }


        public data(OOB.Documento.Entidad.FichaItem it)
        {
            this.it = it;
        }

    }

}