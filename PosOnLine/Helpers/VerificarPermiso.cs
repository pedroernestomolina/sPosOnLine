using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers
{

    public class VerificarPermiso
    {

        static public bool Verificar(string usu, string psw) 
        {
            var usuarioOOB = new OOB.Usuario.Identificar.Ficha();
            usuarioOOB.codigo = usu;
            usuarioOOB.clave = psw;
            var r01 = Sistema.MyData.Usuario_Identificar(usuarioOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var permisoOOB = new OOB.Permiso.Buscar.Ficha();
            permisoOOB.IdGrupoUsuario = r01.Entidad.idGrupo;
            permisoOOB.CodigoFuncion = Sistema.FuncionPosCambiarPrecioVenta;
            var r02 = Sistema.MyData.Permiso_Pos(permisoOOB);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            if (!r02.Entidad.permisoHabilitado) 
            {
                Helpers.Msg.Alerta("PERMISO NO HABILITADO PARA CAMBIAR PRECIO");
                return false;
            }
            return true;
        }

    }

}
