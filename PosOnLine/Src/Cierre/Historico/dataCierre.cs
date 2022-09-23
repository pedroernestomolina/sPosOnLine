using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cierre.Historico
{
    
    public class dataCierre
    {

        private OOB.Cierre.Entidad.Ficha _ficha;


        public int cntFac { get { return _ficha.cntDocFac; } }
        public int cntNCR { get { return _ficha.cntDocNCr; } }
        public decimal montoFAC { get { return _ficha.montoFac; } }
        public decimal montoNCR { get { return _ficha.montoNCr; } }
        public decimal montoVenta { get { return _ficha.montoFac - _ficha.montoNCr; } }
        public decimal montoVentaContado { get { return _ficha.mContado - _ficha.montoContadoAnulado; } }
        public decimal montoVentaCredito { get { return _ficha.mCredito - _ficha.montoCreditoAnulado; } }
        public decimal devoluciones_s { get { return _ficha.montoNCr; } }
        public decimal credito_s { get { return _ficha.firma; } }
        public decimal cambio_s { get { return (_ficha.m_cambio - _ficha.montoVueltoPorEfectivo - _ficha.montoVueltoPorDivisa); } }

        public string Usuario { get { return _ficha.nombreUsuario; } }
        public int cntDocContado { get { return _ficha.cntDocContado; } }
        public int cntDocCredito { get { return _ficha.cntDocCredito; } }
        public string nroCierre { get { return _ficha.cierreNro.ToString().Trim().PadLeft(8, '0'); } }

        //desgloze segun sistema
        public decimal efectivo_s { get { return (_ficha.mEfectivo_s - _ficha.montoVueltoPorEfectivo); } }
        public decimal divisa_s { get { return _ficha.cheque; } }
        public decimal electronico_s { get { return _ficha.debito; } }
        public decimal otros_s { get { return _ficha.otros; } }
        public int cnt_divisa_s { get { return _ficha.cntDivisia; } }
        public int cnt_efectivo_s { get { return _ficha.cntEfectivo_s; } }
        public int cnt_electronico_s { get { return _ficha.cntElectronico_s; } }
        public int cnt_otros_s { get { return _ficha.cntOtros_s; } }
        public decimal cuadre_s { get { return _ficha.SegunSistema - cambio_s; } }

        //desgloze segun usuario
        public decimal efectivo_u { get { return (_ficha.mefectivo); } }
        public decimal divisa_u { get { return (_ficha.mcheque); } }
        public decimal electronico_u { get { return (_ficha.mtarjeta); } }
        public decimal otros_u { get { return (_ficha.motros); } }
        public int cnt_divisa_u { get { return _ficha.cntDivisaUsuario; } }
        public decimal cuadre_u { get { return _ficha.SegunUsuario - _ficha.montoVueltoPorPagoMovil; } }
        public decimal vueltoPorPagoMovil { get { return _ficha.montoVueltoPorPagoMovil; } }


        public dataCierre(OOB.Cierre.Entidad.Ficha ficha)
        {
            _ficha = ficha;
        }

    }

}