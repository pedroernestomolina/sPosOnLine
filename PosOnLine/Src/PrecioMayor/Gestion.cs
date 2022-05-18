using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.PrecioMayor
{

    public class Gestion
    {


        private string _autoPrd;
        private string _tarifa;
        private string _producto;
        private bool _precioSeleccionadoIsOk;
        private string _tarifaSeleccionada;
        private OOB.Producto.Entidad.Ficha _ficha;
        private List<data> _precios;
        private BindingSource _source;
        private decimal _factorCambio;


        public string Producto { get { return _producto; } }
        public OOB.Producto.Entidad.Ficha Ficha { get { return _ficha; } }
        public bool PrecioSeleccionadoIsOk { get { return _precioSeleccionadoIsOk; } }
        public string TarifaSeleccionada { get { return _tarifaSeleccionada; } }
        public BindingSource Source { get { return _source; } }
        public string AutoProducto { get { return _autoPrd; } }


        public Gestion()
        {
            _autoPrd = "";
            _tarifa = "";
            _precios = new List<data>();
            _source = new BindingSource();
            _source.DataSource = _precios;
            _factorCambio = 0m;
        }


        public void Inicializa()
        {
            _producto = "";
            _tarifaSeleccionada = "";
            _precioSeleccionadoIsOk = false;
            _precios.Clear();
            _factorCambio = 0m;
        }

        PrecioMayorFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (_ficha.PreciosMayorHabilitado)
                {
                    switch (_tarifa)
                    {
                        case "1":
                            var p1 = new precio("1", _ficha.empaque_1, _ficha.contenido_1, _ficha.pneto_1, _ficha.decimales_1);
                            p1.setFactorCambio(_factorCambio);
                            var nd1 = new data("1", "", p1);
                            if (p1.Habilitado)
                            {
                                _precios.Add(nd1);
                            }

                            var pM1 = new precio("6", _ficha.empaqueMay_1, _ficha.contenidoMay_1, _ficha.pnetoMay_1, _ficha.decimalesMay_1);
                            pM1.setFactorCambio(_factorCambio);
                            if (pM1.Habilitado)
                            {
                                _precios.Add(new data("6", "", pM1));
                            }

                            var pD1 = new precio("10", _ficha.empaqueDsp_1, _ficha.contenidoDsp_1, _ficha.pnetoDsp_1, _ficha.decimalesDsp_1);
                            pD1.setFactorCambio(_factorCambio);
                            if (pD1.Habilitado)
                            {
                                _precios.Add(new data("A", "", pD1));
                            }
                            break;
                        case "2":
                            var p2 = new precio("2", _ficha.empaque_2, _ficha.contenido_2, _ficha.pneto_2, _ficha.decimales_2);
                            p2.setFactorCambio(_factorCambio);
                            var nd2 = new data("2", "", p2);
                            if (p2.Habilitado)
                            {
                                _precios.Add(nd2);
                            }

                            var pM2 = new precio("7", _ficha.empaqueMay_2, _ficha.contenidoMay_2, _ficha.pnetoMay_2, _ficha.decimalesMay_2);
                            pM2.setFactorCambio(_factorCambio);
                            if (pM2.Habilitado)
                            {
                                _precios.Add(new data("7", "", pM2));
                            }
                            
                            var pD2 = new precio("B", _ficha.empaqueDsp_2, _ficha.contenidoDsp_2, _ficha.pnetoDsp_2, _ficha.decimalesDsp_2);
                            pD2.setFactorCambio(_factorCambio);
                            if (pD2.Habilitado)
                            {
                                _precios.Add(new data("B", "", pD2));
                            }

                            break;
                        case "3":
                            var p3 = new precio("3", _ficha.empaque_3, _ficha.contenido_3, _ficha.pneto_3, _ficha.decimales_3);
                            p3.setFactorCambio(_factorCambio);
                            var nd3 = new data("3", "DETAL", p3);
                            if (p3.Habilitado)
                            {
                                _precios.Add(nd3);
                            }

                            var pM3 = new precio("8", _ficha.empaqueMay_3, _ficha.contenidoMay_3, _ficha.pnetoMay_3, _ficha.decimalesMay_3);
                            pM3.setFactorCambio(_factorCambio);
                            if (pM3.Habilitado)
                            {
                                _precios.Add(new data("8", "", pM3));
                            }
                            
                            var pD3 = new precio("C", _ficha.empaqueDsp_3, _ficha.contenidoDsp_3, _ficha.pnetoDsp_3, _ficha.decimalesDsp_3);
                            pD3.setFactorCambio(_factorCambio);
                            if (pD3.Habilitado)
                            {
                                _precios.Add(new data("C", "", pD3));
                            }

                            break;
                        case "4":
                            var p4 = new precio("4", _ficha.empaque_4, _ficha.contenido_4, _ficha.pneto_4, _ficha.decimales_4);
                            p4.setFactorCambio(_factorCambio);
                            var nd4 = new data("4", "", p4);
                            if (p4.Habilitado)
                            {
                                _precios.Add(nd4);
                            }

                            var pM4 = new precio("9", _ficha.empaqueMay_4, _ficha.contenidoMay_4, _ficha.pnetoMay_4, _ficha.decimalesMay_4);
                            pM4.setFactorCambio(_factorCambio);
                            if (pM4.Habilitado)
                            {
                                _precios.Add(new data("9", "", pM4));
                            }

                            var pD4 = new precio("D", _ficha.empaqueDsp_4, _ficha.contenidoDsp_4, _ficha.pnetoDsp_4, _ficha.decimalesDsp_4);
                            pD4.setFactorCambio(_factorCambio);
                            if (pD4.Habilitado)
                            {
                                _precios.Add(new data("D", "", pD4));
                            }
                            break;
                        case "5":
                            var p5 = new precio("5", _ficha.empaque_5, _ficha.contenido_5, _ficha.pneto_5, _ficha.decimales_5);
                            _precios.Add(new data("5", "", p5));
                            break;
                        default:
                            var p11 = new precio("1", _ficha.empaque_1, _ficha.contenido_1, _ficha.pneto_1, _ficha.decimales_1);
                            _precios.Add(new data("1", "", p11));
                            break;
                    }
                    _source.CurrencyManager.Refresh();

                    if (frm == null)
                    {
                        frm = new PrecioMayorFrm();
                        frm.setControlador(this);
                    }
                    frm.ShowDialog();
                }
                else
                {
                    _tarifaSeleccionada = _tarifa;
                    _precioSeleccionadoIsOk = true;
                }
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Producto_GetFichaById(_autoPrd);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _producto = r01.Entidad.NombrePrd;
            _ficha = r01.Entidad;

            var r02 = Sistema.MyData.Configuracion_FactorDivisa();
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _factorCambio = r02.Entidad;

            return rt;
        }

        public void setAutoProducto(string autoPrd)
        {
            _autoPrd = autoPrd;
        }

        public void setTarifaPrecio(string tarifa)
        {
            _tarifa = tarifa;
        }

        public void ItemSeleccionado()
        {
            if (_source.Current != null)
            {
                var _item = (data)_source.Current;
                _tarifaSeleccionada = _item.ID;
                _precioSeleccionadoIsOk = true;
            }
        }

    }

}