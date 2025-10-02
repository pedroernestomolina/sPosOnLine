using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreRepo.vm
{
    public interface IRepo: _Domain.IRepo
    {
        void setIdResumen(int id);
        void setIdResumenHistorico(int idResumen, string cierreNro);
    }
}