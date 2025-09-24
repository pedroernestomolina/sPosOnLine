using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreProceso.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public void CerrarPos(Models.CierreFicha ficha)
        {
            try
            {
                var fichaOOB = new OOB.CuadreCierre.CierrePos.Ficha()
                {
                    metPago = ficha.cierrePorMetPago.Select(s =>
                    {
                        return new OOB.CuadreCierre.CierrePos.MetodoPago()
                        {
                            codigoMon = s.codigoMon,
                            codigoMP = s.codigoMP,
                            descMon = "",
                            descMP = s.descMP,
                            importeMonLocal = s.importeMonLocal,
                            montoSegunSistema = s.montoSegunSistema,
                            montoSegunUsuario = s.montoSegunUsuario,
                            simboloMon = s.simboloMon,
                            tasaFactorPonderadoMon = s.tasaFactorPonderadoMon,
                        };
                    }).ToList(),
                };
                var result = Sistema.MyData.CuadreCierre_CerrarePos(fichaOOB);
                if (result.Result== OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(result.Mensaje);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}