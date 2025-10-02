using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreHistorico.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public List<Models.Cierre> 
            CargarListaCierresHistorico()
        {
            var rt = new List<Models.Cierre>();
            //
            try
            {
                var rst = Sistema.MyData.CuadreCierre_Get_ListaCierre();
                if (rst.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rst.Mensaje);
                }
                var lst = rst.ListaD;
                rt = lst.Where(w=>w.isCerradoOperador).OrderByDescending(o=>o.nroCierre).Select(s =>
                {
                    return new Models.Cierre()
                    {
                        fechaHoraApertura = s.fechaApertura.ToShortDateString() + "/" + s.horaApertura,
                        fechaHoraCierre = s.fechaCierre.ToShortDateString() + "/" + s.horaCierre,
                        idArqueo = s.idArqueo,
                        idOperador = s.idOperador,
                        idResumen = s.idResumen,
                        nroCierre = s.nroCierre,
                        terminal = s.terminal,
                        Usuario = s.codigoUsuario + "/" + s.nombreUsuario,
                    };
                }).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            //
            return rt;
        }
    }
}