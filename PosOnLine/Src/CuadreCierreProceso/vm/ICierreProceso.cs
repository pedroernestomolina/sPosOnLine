using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreProceso.vm
{
    public interface ICierreProceso
    {
        void setMetodosPagoImplementados(List<CuadreCierre.Domain.Models.MetodoPagoUso> list);
        void Inicializa();
        bool ProcesarCierre();
    }
}