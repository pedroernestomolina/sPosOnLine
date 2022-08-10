using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Cierre.Historico
{
    
    public class Historia: IHistoria
    {


        private List<data> _lst;
        private BindingSource _bs;
        private bool _imprimirIsOk; 


        public Historia() 
        {
            _imprimirIsOk = false;
            _lst = new List<data>();
            _bs=new BindingSource();
            _bs.DataSource= _lst;
        }


        public void Inicializa()
        {
            _imprimirIsOk = false;
            _lst.Clear();
            _bs.DataSource=_lst;
            _bs.CurrencyManager.Refresh();
        }
        HistoriaFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new HistoriaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            _lst.Clear();
            var filtroOOb= new OOB.Cierre.Lista.Filtro();
            var r01 = Sistema.MyData.Cierre_Lista_GetByFiltro(filtroOOb);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _lst = r01.ListaD.OrderByDescending(o=>o.cierreNro).Select(s=>
            {
                var nr = new data()
                {
                    id = s.id,
                    fechaHora = s.fecha.ToShortDateString() + ", " + s.hora,
                    idEquipo = s.idEquipo,
                    cierreNro = s.cierreNro.ToString().Trim().PadLeft(6, '0'),
                };
                return nr;
            }).ToList();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();

            return true;
        }


        public bool ImprimirIsOk { get { return _imprimirIsOk; } }
        public BindingSource GetDataSource { get { return _bs; } }
        public void ImprimirCierre()
        {
            _imprimirIsOk = false;
            if (_bs.Current != null) 
            {
                var _it = (data)_bs.Current;
                var r01 = Sistema.MyData.Cierre_GetById(_it.id);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _imprimirIsOk = true;
                var s = r01.Entidad;
                var dat = new Helpers.Imprimir.dataCuadre();
                dat.cntFAC = s.cntDocFac;
                dat.cntNCR = s.cntDocNCr;
                //dat.cntNEN = cntNEntrega;
                //dat.cntFACAnu = cntFacturaAnulada;
                //dat.cntNCRAnu = cntNCreditoAnulada;
                //dat.cntNENAnu = cntNEntregaAnulada;
                dat.montoFAC = s.montoFac;
                //dat.montoFACAnu = montoFacturaAnulada;
                dat.montoNCR = s.montoNCr;
                //dat.montoNCRAnu = montoNCreditoAnulada;
                //dat.montoNEN = montoNEntrega;
                //dat.montoNENAnu = montoNEntregaAnulada;
                dat.montoVenta = s.total;
                dat.montoVentaContado = s.mContado;
                dat.montoVentaCredito = s.mCredito;
                dat.devoluciones_s = s.montoNCr;
                dat.credito_s = s.firma;
                dat.cambio_s = s.m_cambio;

                //desgloze segun sistema
                dat.efectivo_s = s.mEfectivo_s;
                dat.divisa_s = s.cheque;
                dat.electronico_s = s.debito;
                dat.otros_s = s.otros;
                dat.cnt_divisa_s = s.cntDivisia;
                dat.cnt_efectivo_s = s.cntEfectivo_s;
                dat.cnt_electronico_s = s.cntElectronico_s;
                dat.cnt_otros_s = s.cntOtros_s;
                dat.cuadre_s = s.SegunSistema;

                //desgloze segun usuario
                dat.efectivo_u = s.mefectivo;
                dat.divisa_u = s.mcheque;
                dat.electronico_u = s.mtarjeta;
                dat.otros_u = s.motros;
                dat.cnt_divisa_u = s.cntDivisaUsuario;
                dat.cuadre_u = s.SegunUsuario;

                dat.Usuario = s.nombreUsuario;
                dat.cntDocContado = s.cntDocContado;
                dat.cntDocCredito = s.cntDocCredito;
                dat.nroCierre = s.cierreNro.ToString().Trim().PadLeft(8, '0');

                Sistema.ImprimirCuadreCaja.setData(dat);
                if (Sistema.ImprimirCuadreCaja.GetType() == typeof(Helpers.Imprimir.Tickera58.CuadreDoc))
                {
                    //_isTicket = true;
                }
                else if (Sistema.ImprimirCuadreCaja.GetType() == typeof(Helpers.Imprimir.Tickera80.CuadreDoc))
                {
                   // _isTicket = true;
                }
                else if (Sistema.ImprimirCuadreCaja.GetType() == typeof(Helpers.Imprimir.Grafico.CuadreDoc))
                {
                    Sistema.ImprimirCuadreCaja.ImprimirDoc();
                }

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

    }

}
