using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClientePorDefecto
{
    public class Imp: Pos.IClientePorDefecto
    {
        public Imp()
        {
        }
        public object GetClientePorDefecto()
        {
            var _ficha = Sistema.FichaClientexDefecto;
            var r01 = Sistema.MyData.Cliente_GetFicha(_ficha.IdCli);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            r01.Entidad.Codigo = _ficha.CodigoCli;
            r01.Entidad.Nombre = _ficha.NombreCli.Trim() == "" ? "CONTADO" : _ficha.NombreCli;
            r01.Entidad.DireccionFiscal = _ficha.DirFiscalCli.Trim() == "" ? "VALENCIA, CARABOBO" : _ficha.DirFiscalCli;
            r01.Entidad.CiRif = _ficha.CiRifCli.Trim() == "" ? "V00000000" : _ficha.CiRifCli;
            r01.Entidad.Telefono = _ficha.TelefonoCli;
            r01.Entidad.Estatus = "ACTIVO";
            r01.Entidad.EstatusCredito = "0";
            return r01.Entidad;
        }
    }
}
