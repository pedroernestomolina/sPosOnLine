﻿using PosOnLine.Data.Prov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine
{

    public class Gestion
    {

        private Src.Identificacion.ILogin _gLogin ;
        private Src.Principal.Gestion _gestionPrincipal;
        

        public Gestion()
        {
            _gLogin = new Src.Identificacion.ImpLogin();
        }


        public void Inicia()
        {
            Sistema.SimboloDivisa_AlImprimirTicket = "$";
            Sistema.ImpresoraFiscal = new Sistema.HndFiscal();
            if (CargarDataXML()) 
            {
                Sistema.MyData = new DataPrv(Sistema.Instancia, Sistema.BaseDatos);
                Sistema.MyBalanza = new Lib.Controles.BalanzaSoloPeso.BalanzaManual.Balanza();
                Sistema.EquipoEstacion = Environment.MachineName;
                if (Sistema.ImpresoraFiscal.Activar)
                {
                    Sistema.FiscalTfhka = new LibFoxFiscal.LibFoxFiscal.Fiscal();
                    Sistema.FiscalTfhka.SetPuerto(Sistema.ImpresoraFiscal.Puerto);
                    if (Sistema.ImprimirFactura.IsModoFiscal) 
                    {
                        Sistema.ImprimirFactura.setHndFiscal(Sistema.FiscalTfhka);
                        Sistema.ImprimirNotaCredito.setHndFiscal(Sistema.FiscalTfhka);
                    }
                }

                var r01 = Sistema.MyData.Configuracion_ModoPos();
                switch (r01.Entidad)
                {
                    case Data.Infra.modoPos.Basico:
                        throw new Exception("MODO FABRICA NO IMPLEMNTADO");
                    case Data.Infra.modoPos.Sucursal:
                        Sistema.MiFabrica = new Src.FabModSuc();
                        break;
                    case Data.Infra.modoPos.Administrativo:
                        Sistema.MiFabrica = new Src.FabModAdm();
                        break;
                    default:
                        throw new Exception("NO SE HA DEFINIDO UN MODO DE CONFIGURACION PARA EL POS");
                }

                _gLogin.Inicializa();
                _gLogin.Inicia();
                if (_gLogin.LoginIsOk)
                {
                    _gestionPrincipal = new Src.Principal.Gestion();
                    _gestionPrincipal.Inicializa();
                    _gestionPrincipal.Inicia();
                }
            }
        }

        private bool CargarDataXML()
        {
            var  r01= Helpers.Utilitis.CargarXml();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            return true;
        }
    }
}