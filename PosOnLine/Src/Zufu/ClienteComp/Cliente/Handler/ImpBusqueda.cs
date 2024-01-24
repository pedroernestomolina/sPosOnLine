using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.Cliente.Handler
{
    public class ImpBusqueda: Vista.IBusqueda
    {
        private Vista.ITipoBusq _tipoBusq;
        private string _aBuscar;

        public string Get_TextoBuscar { get { return _aBuscar; } }
        public Vista.ITipoBusq TipoBusqueda { get { return _tipoBusq; } }

        public ImpBusqueda()
        {
            _tipoBusq = new ImpTipoBusq();
        }
        public void Inicializa()
        {
            _tipoBusq.Inicializa();
            _aBuscar = "";
        }
        public void CargarData()
        {
            _tipoBusq.ObtenerData();
        }
        public void setBuscar(string dato)
        {
            _aBuscar = dato;
        }
    }
}