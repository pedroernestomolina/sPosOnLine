using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CuadreCierre.Domain.Models
{
    public class MyData
    {
        private DataResumenRecolectada _dataResumenRecolectada;
        //
        public DataResumenRecolectada DataResumenRecolectada { get { return _dataResumenRecolectada; } }
        public List<MetodoPagoUso> MetodosPagoUsado { get { return _dataResumenRecolectada.MetodosPagoUsados; } }
        //
        public MyData()
        {
            _dataResumenRecolectada = new DataResumenRecolectada();
        }
        //
        public void 
            setDataResumenRecolectada(DataResumenRecolectada data)
        {
            _dataResumenRecolectada = data;
        }
    }
}