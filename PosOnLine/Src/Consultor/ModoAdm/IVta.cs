using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor.ModoAdm
{
    public interface IVta
    {
        decimal GetPNetoMonLocal { get; }
        decimal GetPFullMonLocal { get; }
        string GetEmpCont { get; }
        decimal GetPFullDivisa { get; }
        string GetOferta { get; }

        void Inicializar();
        void setData(Vta vta);
    }
}