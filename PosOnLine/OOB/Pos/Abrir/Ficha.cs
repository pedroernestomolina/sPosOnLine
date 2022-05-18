using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PosOnLine.OOB.Pos.Abrir
{
    
    public class Ficha
    {

        public string idEquipo { get; set; }
        public string codSucursal { get; set; }
        public Operador operadorAbrir { get; set; }
        public Arqueo arqueoAbrir { get; set; }
        public Resumen resumenAbrir { get; set; }


        public Ficha()
        {
            idEquipo = "";
            codSucursal = "";
            operadorAbrir = new Operador();
            arqueoAbrir = new Arqueo();
            resumenAbrir = new Resumen();
        }

        public Ficha(OOB.Sucursal.Entidad.Ficha _sucursal, string _idEquipo, OOB.Usuario.Entidad.Ficha _usuario) 
            :this()
        {
            idEquipo = _idEquipo;
            codSucursal = _sucursal.codigo;
            operadorAbrir.setData(_usuario.id, _idEquipo, "A");
            arqueoAbrir.setData(_usuario);
        }

    }

}