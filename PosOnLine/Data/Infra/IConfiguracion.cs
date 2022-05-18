using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IConfiguracion
    {

        OOB.Resultado.FichaEntidad<decimal> Configuracion_FactorDivisa();
        OOB.Resultado.FichaEntidad<OOB.Configuracion.Entidad.Ficha> Configuracion_Pos_GetFicha();
        OOB.Resultado.Ficha Configuracion_Pos_Actualizar(OOB.Configuracion.Actualizar.Ficha ficha);
        OOB.Resultado.Ficha Configuracion_Pos_CambioDepositoSucursalFrio();
        OOB.Resultado.Ficha Configuracion_Pos_CambioDepositoSucursalViveres();
        OOB.Resultado.Ficha Configuracion_Pos_CambioSucursalDeposito(OOB.Configuracion.CambioSucursalDeposito.Ficha ficha);
        OOB.Resultado.FichaEntidad<bool> Configuracion_Habilitar_Precio5_VentaMayor();

    }

}