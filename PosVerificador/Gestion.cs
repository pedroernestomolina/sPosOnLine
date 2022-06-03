using PosVerificador.Data.Prov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador
{

    public class Gestion
    {

        private Src.Principal.IPrincipal _gPrincipal;
        //private Src.Identificacion.Gestion _gestionIdentifica;
        //private Src.Principal.Gestion _gestionPrincipal;
        

        public Gestion()
        {
            _gPrincipal = new Src.Principal.Principal();
            //_gestionIdentifica = new Src.Identificacion.Gestion();
            //_gestionPrincipal = new Src.Principal.Gestion();
        }


        public void Inicia()
        {
            if (CargarDataXML()) 
            {
                Sistema.MyData = new DataPrv(Sistema.Instancia, Sistema.BaseDatos);
                _gPrincipal.Inicializa();
                _gPrincipal.Inicia();
                //Sistema.MyData = new DataPrv(Sistema.Instancia, Sistema.BaseDatos);
                //Sistema.EquipoEstacion = Environment.MachineName;

                //_gestionIdentifica.Inicializa();
                //_gestionIdentifica.Inicia();
                //if (_gestionIdentifica.IsOk)
                //{
                //    _gestionPrincipal.Inicializa();
                //    _gestionPrincipal.Inicia();
                //}

            }
        }

        private bool CargarDataXML()
        {
            var r01 = Helpers.Utilitis.CargarXml();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            return true;
        }

    }

}