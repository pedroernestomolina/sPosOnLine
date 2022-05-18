using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Buscar
{
    
    public class Gestion
    {

        private string _autoPrd;
        private string _autoDepositoAsignado;
        private string _tarifaPrecio;
        private bool _habilitarVentaMayor; 
        private Producto.Lista.Gestion _gestionListar;
        private PrecioMayor.Gestion _gestionMayor;


        public bool BusquedaIsOk { get { return _autoPrd != ""; } }
        public string AutoProducto { get { return _autoPrd; } }
        public string AutoDeposito { get { return _autoDepositoAsignado; } }
        public Producto.Lista.Gestion GestionListar { get { return _gestionListar; } }
        public string TarifaPrecioSeleccionada { get { return _tarifaPrecio; } }


        public Gestion()
        {
            _autoPrd = "";
            _autoDepositoAsignado = "";
            _tarifaPrecio = "";
            _habilitarVentaMayor = false;
        }


        public void ActivarBusqueda(string buscar, bool activarBusquedaPorDescripcion = true)
        {
            _autoPrd = "";
            var codBuscar = buscar.Trim().ToUpper();
            if (codBuscar == "")
            {
                return;
            }

            //var vr = VerificaPreEmpaque(buscar);
            //if (vr.IsPreEmpaque)
            //{
            //    codBuscar = vr.ItemCodigo;
            //    Peso = vr.Peso;
            //}

            var r01 = Sistema.MyData.Producto_BusquedaByCodigoBarra(codBuscar);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return ;
            }
            if (r01.Auto == "")
            {
                var r02 = Sistema.MyData.Producto_BusquedaByPlu(codBuscar);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }
                if (r02.Auto == "")
                {
                    var r03 = Sistema.MyData.Producto_BusquedaByCodigo(codBuscar);
                    if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r03.Mensaje);
                        return;
                    }
                    if (r03.Auto == "")
                    {
                        if (activarBusquedaPorDescripcion)
                        {
                            var filtro = new OOB.Producto.Lista.Filtro()
                            {
                                autoDeposito = _autoDepositoAsignado,
                                cadena = codBuscar,
                                idPrecioManejar = _tarifaPrecio,
                            };
                            var r04 = Sistema.MyData.Producto_GetLista(filtro);
                            if (r04.Result == OOB.Resultado.Enumerados.EnumResult.isError )
                            {
                                Helpers.Msg.Error(r04.Mensaje);
                                return ;
                            }
                            _gestionListar.Inicializa();
                            _gestionListar.setData(r04.ListaD);
                            _gestionListar.Inicia();
                            if (_gestionListar.ItemSeleccionIsOk) 
                            {
                                if (_habilitarVentaMayor)
                                {
                                    _gestionMayor.Inicializa();
                                    _gestionMayor.setAutoProducto(_gestionListar.ItemSeleccionado.Auto);
                                    _gestionMayor.setTarifaPrecio(_tarifaPrecio);
                                    _gestionMayor.Inicia();
                                    if (_gestionMayor.PrecioSeleccionadoIsOk)
                                    {
                                        _autoPrd = _gestionMayor.AutoProducto;
                                        _tarifaPrecio = _gestionMayor.TarifaSeleccionada;
                                    }
                                }
                                else 
                                {
                                    _autoPrd = _gestionListar.ItemSeleccionado.Auto;
                                }
                            }
                        }
                    }
                    else
                        _autoPrd = r03.Auto;
                }
                else
                    _autoPrd = r02.Auto;
            }
            else
                _autoPrd = r01.Auto;
        }

        public void setDepositoAsignado(OOB.Deposito.Entidad.Ficha _depositoAsignado)
        {
            _autoDepositoAsignado = _depositoAsignado.id;
        }

        public void setGestionLista(Lista.Gestion _ctrListar)
        {
            _gestionListar = _ctrListar;
        }

        public void setTarifaPrecio(string tarifa)
        {
            _tarifaPrecio = tarifa;
        }

        public void setHabilitarVentaMayor(bool p)
        {
            _habilitarVentaMayor = p;
        }

        public void setGestionPrecioMayor(PrecioMayor.Gestion ctrlPrecMay)
        {
            _gestionMayor = ctrlPrecMay;
        }

    }

}