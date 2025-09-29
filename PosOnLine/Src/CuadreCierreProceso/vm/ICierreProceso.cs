using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreProceso.vm
{
    public interface ICierreProceso
    {
        void setIdResumen(int id);
        void setTotalesCierre(Domain.Models.CierreTotales totales);
        void setMetodosPagoImplementados(List<CuadreCierre.Domain.Models.MetodoPagoUso> list);
        void setDocumentos(List<CuadreCierre.Domain.Models.TipoDocUso> list);
        //
        void Inicializa();
        bool ProcesarCierre();
    }
}