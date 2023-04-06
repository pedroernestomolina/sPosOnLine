using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor.ModoAdm
{
    public class imp_vta: IVta
    {
        private Vta _vta;


        public decimal GetPNetoMonLocal { get { return _vta.NetoMonLocal; } }
        public decimal GetPFullMonLocal { get { return _vta.FullMonLocal; } }
        public string GetEmpCont { get { return _vta.EmpDesplegar; } }
        public decimal GetPFullDivisa { get { return _vta.FullDivisa; } }
        public string GetOferta { get { return _vta.OfertaDesplegar; } }


        public imp_vta()
        {
        }


        public void Inicializar()
        {
        }


        public void setData(Vta vta)
        {
            _vta = vta;
        }
    }
}