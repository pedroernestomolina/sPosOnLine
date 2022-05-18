using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Cierre
{
    
    public class Gestion
    {

        private bool _cierreOk; 
        private bool _abandonarOk;
        private OOB.Pos.Resumen.Ficha _resumen;
        private decimal _entradaEfectivo;
        private decimal _entradaTarjeta ;
        private decimal _entradaDivisa;
        private decimal _entradaOtro;
        private int _entradaCntDivisa;
        private decimal _factorCambio;
        private bool _isTicket;


        public int cntDoc { get { return _resumen.cntDoc-_resumen.cnt_anu; } }
        public int cntFactura { get { return _resumen.cntFac-_resumen.cnt_anu_fac; } }
        public int cntNCredito { get { return _resumen.cntNCr-_resumen.cnt_anu_ncr; } }
        public int cntNEntrega { get { return _resumen.cntNtE-_resumen.cnt_anu_nte; } }
        public decimal montoFactura { get { return _resumen.mFac-_resumen.m_anu_fac; } }
        public decimal montoNCredito { get { return _resumen.mNCr-_resumen.m_anu_ncr ; } }
        public decimal montoNEntrega { get { return _resumen.mNtE-_resumen.m_anu_nte; } }
        public decimal montoVenta { get { return montoFactura-montoNCredito; } }
        public int cntDocContado { get { return _resumen.cntDocContado-_resumen.cntDocContado_anu; } }
        public int cntDocCredito { get { return _resumen.cntDocCredito-_resumen.cntDocCredito_anu; } }
        public decimal montoDocContado { get { return _resumen.mContado-_resumen.mContado_anu ; } }
        public decimal montoDocCredito { get { return _resumen.mCredito-_resumen.mCredito_anu; } }

        public int cntEfecitvo { get { return _resumen.cntEfectivo-_resumen.cntEfectivo_anu; } }
        public int cntDivisa { get { return _resumen.cntDivisa-_resumen.cntDivisa_anu; } }
        public int cntElectronico { get { return _resumen.cntElectronico-_resumen.cntElectronico_anu; } }
        public int cntOtros { get { return _resumen.cntotros-_resumen.cntotros_anu; } }

        public decimal montoEfectivo { get { return _resumen.mEfectivo-_resumen.mEfectivo_anu; } }
        public decimal montoDivisa { get { return _resumen.mDivisa-_resumen.mDivisa_anu; } }
        public decimal montoElectronico { get { return _resumen.mElectronico-_resumen.mElectronico_anu; } }
        public decimal montoOtros { get { return _resumen.mOtros-_resumen.mOtros_anu; } }

        public int cntCambio { get { return _resumen.cnt_cambio-_resumen.cntCambio_anu; } }
        public decimal montoCambio { get { return _resumen.m_cambio-_resumen.mCambio_anu; } }

        public decimal montoDesgloze { get { return ((montoEfectivo + montoDivisa + montoElectronico + montoOtros + montoDocCredito) - (montoNCredito + montoCambio)); } }
        public decimal montoEntrada { get { return ((_entradaEfectivo + _entradaTarjeta + _entradaDivisa + _entradaOtro + montoDocCredito) - (montoNCredito + montoCambio)); } }
        public decimal montoEntradaDivisa { get { return _entradaDivisa; } }
        public decimal Diferencia { get { return montoEntrada-montoDesgloze; } }

        public int cntFacturaAnulada { get { return _resumen.cnt_anu_fac; } }
        public decimal montoFacturaAnulada { get { return _resumen.m_anu_fac; } }
        public int cntNCreditoAnulada { get { return _resumen.cnt_anu_ncr; } }
        public decimal montoNCreditoAnulada { get { return _resumen.m_anu_ncr; } }
        public int cntNEntregaAnulada { get { return _resumen.cnt_anu_nte; } }
        public decimal montoNEntregaAnulada { get { return _resumen.m_anu_nte; } }

        public string Estacion { get { return Sistema.EquipoEstacion; } }
        public string Usuario { get { return Sistema.PosEnUso.nomUsuario; } }
        public string FechaHoraApertura { get { return Sistema.PosEnUso.fechaApertura.ToShortDateString() + ", " + Sistema.PosEnUso.horaApertura; } }
        public bool CierreIsOk { get { return _cierreOk; } }
        public bool AbandonarIsOk { get { return _abandonarOk; } }
        public bool IsTicket { get { return _isTicket; } }


        public void Inicializa()
        {
            _isTicket = false;
            _cierreOk = false;
            _abandonarOk = false;
            _entradaCntDivisa = 0;
            _entradaEfectivo = 0.0m;
            _entradaTarjeta = 0.0m;
            _entradaDivisa = 0.0m;
            _entradaOtro = 0.0m;
        }

        CierreFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new CierreFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var idResumen= Sistema.PosEnUso.idResumen;
            var xr1 = Sistema.MyData.Jornada_Resumen_GetByIdResumen(idResumen);
            if (xr1.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(xr1.Mensaje);
                return false;
            }
            _resumen = xr1.Entidad;

            if (_resumen.FactorCambio != 0.0m)
            {
                _factorCambio = _resumen.FactorCambio;
            }
            else 
            {
                var xr2 = Sistema.MyData.Configuracion_FactorDivisa();
                if (xr2.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(xr2.Mensaje);
                    return false;
                }
                _factorCambio = xr2.Entidad;
            }

            return rt;
        }

        public void setEfectivo(decimal mEfectivo)
        {
            _entradaEfectivo = mEfectivo;
        }

        public void setTarjeta(decimal mTarjeta)
        {
            _entradaTarjeta = mTarjeta;
        }

        public void setCntDivisa(int cntDivisa)
        {
            _entradaCntDivisa = cntDivisa;
            _entradaDivisa = _factorCambio * cntDivisa;
        }

        public void setOtro(decimal mOtro)
        {
            _entradaOtro= mOtro;
        }

        public void Procesar()
        {
            _cierreOk = false;
            var msg = MessageBox.Show("Estas Seguro De Realizar El Cierre ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                int idPosUso = -1;
                if (!Sistema.ModoAbrirDocPendOtrosUsuarios)
                    idPosUso = Sistema.PosEnUso.id;

                var r01 = Sistema.MyData.Pendiente_CtasPendientes(idPosUso);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError )
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                if (r01.Entidad > 0) 
                {
                    Helpers.Msg.Error("HAY CUENTAS PENDIENTES EN PROCESO");
                    return;
                }

                var ficha = new OOB.Pos.Cerrar.Ficha()
                {
                    idOperador = Sistema.PosEnUso.id,
                    estatus = "C",
                    arqueo = new OOB.Pos.Cerrar.FichaArqueo()
                    {
                         autoArqueo=Sistema.PosEnUso.idAutoArqueoCierre,
                         diferencia = Diferencia,
                         efectivo=  (montoEfectivo-montoCambio),
                         cheque = montoDivisa,
                         debito=montoElectronico,
                         credito= 0.0m,
                         ticket=0.0m,
                         firma = montoDocCredito,
                         retiro=0.0m,
                         otros=montoOtros,
                         devolucion=montoNCredito,
                         subTotal=montoDesgloze,
                         cobranza=0.0m,
                         total=montoDesgloze,
                         mefectivo=_entradaEfectivo,
                         mcheque=_entradaDivisa,
                         mbanco1=0.0m,
                         mbanco2 = 0.0m,
                         mbanco3 = 0.0m,
                         mbanco4 = 0.0m,
                         mtarjeta=_entradaTarjeta,
                         mticket=0.0m,
                         mtrans=0.0m,
                         mfirma = montoDocCredito,
                         motros= _entradaOtro,
                         mgastos=0.0m,
                         mretiro=0.0m,
                         mretenciones=0.0m,
                         msubtotal=montoEntrada,
                         mtotal=montoEntrada,
                         cierreFtp="",
                         cntDivisia=cntDivisa, 
                         cntDivisaUsuario=_entradaCntDivisa,
                         cntDoc=cntDoc,
                         cntDocFac=cntFactura ,
                         cntDocNCr=cntNCredito,
                         montoFac=montoFactura,
                         montoNCr=montoNCredito,
                    },
                };

                var dat = new Helpers.Imprimir.dataCuadre();
                dat.cntFAC = cntFactura;
                dat.cntNCR = cntNCredito;
                dat.cntNEN = cntNEntrega;
                dat.cntFACAnu = cntFacturaAnulada;
                dat.cntNCRAnu = cntNCreditoAnulada;
                dat.cntNENAnu = cntNEntregaAnulada;
                dat.montoFAC = montoFactura;
                dat.montoFACAnu = montoFacturaAnulada;
                dat.montoNCR = montoNCredito;
                dat.montoNCRAnu = montoNCreditoAnulada;
                dat.montoNEN = montoNEntrega;
                dat.montoNENAnu = montoNEntregaAnulada;
                dat.montoVenta = montoVenta;
                dat.montoVentaContado = montoDocContado;
                dat.montoVentaCredito = montoDocCredito;
                dat.efectivo_s = montoEfectivo;
                dat.divisa_s = montoDivisa;
                dat.electronico_s = montoElectronico;
                dat.otros_s = montoOtros;
                dat.devoluciones_s = montoNCredito;
                dat.credito_s = montoDocCredito;
                dat.cambio_s = montoCambio;
                dat.efectivo_u = _entradaEfectivo;
                dat.divisa_u = montoEntradaDivisa;
                dat.electronico_u = _entradaTarjeta;
                dat.otros_u = _entradaOtro;
                dat.cnt_efectivo_s = cntEfecitvo;
                dat.cnt_divisa_s = cntDivisa;
                dat.cnt_electronico_s = cntElectronico;
                dat.cnt_otros_s = cntOtros;
                dat.cnt_divisa_u = _entradaCntDivisa;
                dat.cuadre_s=montoDesgloze;
                dat.cuadre_u=montoEntrada;
                dat.Usuario=Sistema.PosEnUso.nomUsuario;
                dat.cntDocContado = cntDocContado;
                dat.cntDocCredito = cntDocCredito;

                var r02 = Sistema.MyData.Jornada_Cerrar(ficha);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }
                Sistema.ImprimirCuadreCaja.setData(dat);
                if (Sistema.ImprimirCuadreCaja.GetType() == typeof(Helpers.Imprimir.Tickera58.CuadreDoc))
                {
                    _isTicket = true;
                }
                else if (Sistema.ImprimirCuadreCaja.GetType() == typeof(Helpers.Imprimir.Tickera80.CuadreDoc)) 
                {
                    _isTicket = true;
                }
                else if (Sistema.ImprimirCuadreCaja.GetType() == typeof(Helpers.Imprimir.Grafico.CuadreDoc))
                {
                    Sistema.ImprimirCuadreCaja.ImprimirDoc();
                }
                _cierreOk = true;
                Sistema.PosEnUso.Cerrar();
            }
        }

        public void Salir()
        {
            _abandonarOk = false;
            var msg = MessageBox.Show("Estas Seguro De Abandonar El Cierre ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                _abandonarOk = true;
            }
        }

        public void Imprimir(System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (Sistema.ImprimirCuadreCaja.GetType() == typeof(Helpers.Imprimir.Tickera80.CuadreDoc))
            {
                var tick = (Helpers.Imprimir.Tickera80.CuadreDoc)Sistema.ImprimirCuadreCaja;
                tick.setGrafico(e);
            }
            else if (Sistema.ImprimirCuadreCaja.GetType() == typeof(Helpers.Imprimir.Tickera58.CuadreDoc))
            {
                var tick = (Helpers.Imprimir.Tickera58.CuadreDoc)Sistema.ImprimirCuadreCaja;
                tick.setGrafico(e);
            }
            Sistema.ImprimirCuadreCaja.ImprimirDoc();
        }

        public void ReporteDetalle()
        {
            var filtro = new OOB.Reportes.Pos.Filtro ()
            {
                 idCierre= Sistema.PosEnUso.idAutoArqueoCierre,
            };
            var r01 = Sistema.MyData.ReportePos_PagoDetalle(filtro);
            if (r01.Result ==  OOB.Resultado.Enumerados.EnumResult.isError )
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var rp1 = new Reportes.Cierre.Detalle.Movimiento(r01.ListaD);
            rp1.setMontoNtCredito(_resumen.mNCr - _resumen.m_anu_ncr);
            rp1.Generar();
        }

        public void PagoResumen()
        {
            var filtro = new OOB.Reportes.Pos.Filtro()
            {
                idCierre = Sistema.PosEnUso.idAutoArqueoCierre,
            };
            var r01 = Sistema.MyData.ReportePos_PagoResumen(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var rp1 = new Reportes.Cierre.Resumen.Movimiento(r01.ListaD);
            rp1.setMontoNtCredito(_resumen.mNCr - _resumen.m_anu_ncr);
            rp1.setMontoCambioDar(_resumen.m_cambio - _resumen.mCambio_anu);
            rp1.Generar();
        }

    }

}