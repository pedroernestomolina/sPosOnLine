using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cliente.Listar
{

    public class data
    {

        private OOB.Cliente.Lista.Ficha it;


        public OOB.Cliente.Lista.Ficha Ficha { get { return it; } }
        public string CiRif { get { return it.ciRif; } }
        public string NombreRazonSocial { get { return it.nombre; } }


        public data()
        {
            Limpiar();
        }

        public data(OOB.Cliente.Lista.Ficha it)
        {
            this.it = it;
        }

        public void Limpiar() 
        {
        }

    }

}