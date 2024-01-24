using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.Listar.Handler
{
    public class dataList: Vista.IdataList
    {
        private OOB.Cliente.Lista.Ficha it;

        public string ciRif {get;set;}
        public string nombreRazonSocial {get;set;}
        public OOB.Cliente.Lista.Ficha Ficha { get { return it; } }

        public dataList(OOB.Cliente.Lista.Ficha it)
        {
            this.it = it;
            ciRif = it.ciRif;
            nombreRazonSocial = it.nombre;
        }
    }
}