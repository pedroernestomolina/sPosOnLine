using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierreRepo.vm
{
    abstract public class BaseRepo: IRepo
    {
        private  int _idResumen;
        private bool _esHistorico;
        private  string _cierreNro;
        //
        public int IdResumen { get { return _idResumen; } }
        public bool EsHistorico { get { return _esHistorico; } }
        public string CierreNro { get { return _cierreNro; } }
        //
        public BaseRepo()
        {
            _idResumen = -1;
            _esHistorico = false;
        }
        public void setIdResumen(int id)
        {
            _idResumen=id;
        }
        public void setIdResumenHistorico(int idResumen, string cierreNro)
        {
            _idResumen = idResumen;
            _cierreNro = cierreNro;
            _esHistorico = true;
        }
        //
        abstract public void Generar();
    }
}