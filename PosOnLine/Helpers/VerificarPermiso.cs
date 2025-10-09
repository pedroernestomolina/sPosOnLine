using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers
{

    public class VerificarPermiso
    {
        static public OOB.Usuario.Entidad.Ficha 
            Verificar(string usu, string psw) 
        {
            try
            {
                var usuarioOOB = new OOB.Usuario.Identificar.Ficha();
                usuarioOOB.codigo = usu;
                usuarioOOB.clave = psw;
                var r01 = Sistema.MyData.Usuario_Identificar(usuarioOOB);
                //
                var permisoOOB = new OOB.Permiso.Buscar.Ficha();
                permisoOOB.IdGrupoUsuario = r01.Entidad.idGrupo;
                permisoOOB.CodigoFuncion = Sistema.FuncionPosCambiarPrecioVenta;
                var r02 = Sistema.MyData.Permiso_Pos(permisoOOB);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
                if (!r02.Entidad.permisoHabilitado)
                {
                    throw new Exception("PERMISO NO HABILITADO PARA CAMBIAR PRECIO");
                }
                //
                return r01.Entidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}