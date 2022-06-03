using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers
{
    
    public class ficha
    {


        public string id { get; set; }
        public string codigo { get; set; }
        public string desc { get; set; }


        public ficha() 
        {
            id = "";
            codigo = "";
            desc = "";
        }

        public ficha(string id, string cod, string des)
            :this()
        {
            this.id = id;
            this.codigo = cod;
            this.desc = des;
        }

        public ficha(fichaSeleccion fic)
            :this(fic.id, fic.codigo, fic.desc)
        {
        }

        public override string ToString()
        {
            return desc.Trim() + "(" + codigo.Trim() + ")";
        }

    }

}