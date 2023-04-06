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
        private Producto.Lista.IListaModo _gestionListar;
        private PrecioMayor.IModo _gestionMayor;


        public bool BusquedaIsOk { get { return _autoPrd != ""; } }
        public string AutoProducto { get { return _autoPrd; } }
        public string AutoDeposito { get { return _autoDepositoAsignado; } }
        public Producto.Lista.IListaModo GestionListar { get { return _gestionListar; } }
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
                            if (r04.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                            {
                                Helpers.Msg.Error(r04.Mensaje);
                                return;
                            }
                            var r05 = Sistema.MyData.Configuracion_FactorDivisa();
                            if (r05.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                            {
                                Helpers.Msg.Error(r05.Mensaje);
                                return;
                            }
                            var _lst = r04.ListaD.ToList();
                            _gestionListar.Inicializa();
                            if (Sistema.ConfiguracionActual.ValidarExistencia_Activa)
                            {
                                _lst = _lst.Where(w => w.ExDisponible > 0).ToList();
                            }
                            _gestionListar.setData(_lst, r05.Entidad);
                            _gestionListar.setFiltroPrdListar(filtro);
                            _gestionListar.Inicia();
                            if (_gestionListar.ItemSeleccionIsOk)
                            {
                                _autoPrd = _gestionListar.IdItemSeleccionado;
                            }
                        }
                    }
                    else
                    {
                        _autoPrd = r03.Auto;
                        if (!Sistema.HabilitarTiposEmpaqueAlBuscarPorCodigoDeBarra)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    _autoPrd = r02.Auto;
                    if (!Sistema.HabilitarTiposEmpaqueAlBuscarPorCodigoDeBarra)
                    {
                        return;
                    }
                }
            }
            else
            {
                _autoPrd = r01.Auto;
                if (!Sistema.HabilitarTiposEmpaqueAlBuscarPorCodigoDeBarra)
                {
                    return;
                }
            }

            if (!string.IsNullOrEmpty(_autoPrd))
            {
                if (_habilitarVentaMayor)
                {
                    _gestionMayor.Inicializa();
                    _gestionMayor.setAutoProducto(_autoPrd);
                    _gestionMayor.setTarifaPrecio(_tarifaPrecio);
                    _gestionMayor.Inicia();
                    if (_gestionMayor.PrecioSeleccionadoIsOk)
                    {
                        _autoPrd = _gestionMayor.AutoProducto;
                        _tarifaPrecio = _gestionMayor.TarifaSeleccionada;
                    }
                    else 
                    {
                        _autoPrd = "";
                    }
                }
            }
        }

        public void setGestionLista(Lista.IListaModo ctr)
        {
            _gestionListar = ctr;
        }
        public void setGestionPrecioMayor(PrecioMayor.IModo ctr)
        {
            _gestionMayor = ctr;
        }
        public void setDepositoAsignado(OOB.Deposito.Entidad.Ficha _depositoAsignado)
        {
            _autoDepositoAsignado = _depositoAsignado.id;
        }
        public void setTarifaPrecio(string tarifa)
        {
            _tarifaPrecio = tarifa;
        }
        public void setHabilitarVentaMayor(bool p)
        {
            _habilitarVentaMayor = p;
        }
    }
}