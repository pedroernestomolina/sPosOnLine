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
            try
            {
                _lst.Clear();
                var filtroOOb = new OOB.Cierre.Lista.Filtro();
                var r01 = Sistema.MyData.Cierre_Lista_GetByFiltro(filtroOOb);
                _lst = r01.ListaD.OrderByDescending(o => o.cierreNro).Select(s =>
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
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        public bool ImprimirIsOk { get { return _imprimirIsOk; } }
        public BindingSource GetDataSource { get { return _bs; } }
        public void ImprimirCierre()
        {
            _imprimirIsOk = false;
            if (_bs.Current != null) 
            {
                var _it = (data)_bs.Current;
                CargarPrepararCierre(_it.id);
            }
        }

        public void Imprimir(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Sistema.ImprimirCuadreCaja.setGrafico(e);
            Sistema.ImprimirCuadreCaja.ImprimirDoc();
        }


        private void CargarPrepararCierre(int id)
        {
            try
            {
                var r01 = Sistema.MyData.Cierre_GetById(id);
                var _dat = new dataCierre(r01.Entidad);

                _imprimirIsOk = true;
                var dat = new Helpers.Imprimir.dataCuadre();
                dat.cntFAC = _dat.cntFac;
                dat.cntNCR = _dat.cntNCR;
                dat.montoFAC = _dat.montoFAC;
                dat.montoNCR = _dat.montoNCR;
                dat.montoVenta = _dat.montoVenta;
                dat.montoVentaContado = _dat.montoVentaContado;
                dat.montoVentaCredito = _dat.montoVentaCredito;
                dat.devoluciones_s = _dat.devoluciones_s;
                dat.credito_s = _dat.credito_s;
                dat.cambio_s = _dat.cambio_s;

                //desgloze segun sistema
                dat.efectivo_s = _dat.efectivo_s;
                dat.divisa_s = _dat.divisa_s;
                dat.electronico_s = _dat.electronico_s;
                dat.otros_s = _dat.otros_s;
                dat.cnt_divisa_s = _dat.cnt_divisa_s;
                dat.cnt_efectivo_s = _dat.cnt_efectivo_s;
                dat.cnt_electronico_s = _dat.cnt_electronico_s;
                dat.cnt_otros_s = _dat.cnt_otros_s;
                dat.cuadre_s = _dat.cuadre_s;

                //desgloze segun usuario
                dat.efectivo_u = _dat.efectivo_u;
                dat.divisa_u = _dat.divisa_u;
                dat.electronico_u = _dat.electronico_u;
                dat.otros_u = _dat.otros_u;
                dat.cnt_divisa_u = _dat.cnt_divisa_u;
                dat.cuadre_u = _dat.cuadre_u;
                dat.vueltoPorPagoMovil = _dat.vueltoPorPagoMovil;

                //
                dat.Usuario = _dat.Usuario;
                dat.cntDocContado = _dat.cntDocContado;
                dat.cntDocCredito = _dat.cntDocCredito;
                dat.nroCierre = _dat.nroCierre;

                Sistema.ImprimirCuadreCaja.setData(dat);
                if (Sistema.ImprimirCuadreCaja.GetType() == typeof(Helpers.Imprimir.Grafico.CuadreDoc))
                    Sistema.ImprimirCuadreCaja.ImprimirDoc();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

    }

}