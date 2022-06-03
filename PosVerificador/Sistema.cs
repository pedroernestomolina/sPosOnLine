using PosVerificador.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador
{
    
    public class Sistema
    {

        static public IData MyData;
        static public string Instancia;
        static public string BaseDatos;
        public static string IdEquipo;
        public static string EquipoEstacion;
        public static OOB.Usuario.Entidad.Ficha Usuario;

    }

}