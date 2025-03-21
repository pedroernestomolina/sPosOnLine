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


        private bool _estatusModoBusquedaCodigoBarra;
        public void ActivarBusqueda(string buscar, bool activarBusquedaPorDescripcion = true)
        {
            _estatusModoBusquedaCodigoBarra = false; 
            _autoPrd = "";
            try
            {
                var codBuscar = buscar.Trim().ToUpper();
                if (codBuscar == "")
                {
                    return;
                }

                var r01 = Sistema.MyData.Producto_BusquedaByCodigoBarra(codBuscar);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Auto.Trim() != "") 
                {
                    _autoPrd = r01.Auto;
                    _estatusModoBusquedaCodigoBarra = true;
                    return;
                }

                var r02 = Sistema.MyData.Producto_BusquedaByPlu(codBuscar);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
                if (r02.Auto.Trim() != "") 
                {
                    _autoPrd = r02.Auto;
                    _estatusModoBusquedaCodigoBarra = true;
                    return;
                }

                var r03 = Sistema.MyData.Producto_BusquedaByCodigo(codBuscar);
                if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r03.Mensaje);
                }
                if (r03.Auto.Trim() != "") 
                {
                    _autoPrd = r03.Auto;
                    _estatusModoBusquedaCodigoBarra = true;
                    return;
                }

                if (activarBusquedaPorDescripcion)
                {
                    buscaPorDescripcion(codBuscar);
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private void buscaPorDescripcion(string codBuscar)
        {
            var filtro = new OOB.Producto.Lista.Filtro()
            {
                autoDeposito = _autoDepositoAsignado,
                cadena = codBuscar,
                idPrecioManejar = _tarifaPrecio,
            };
            var r01 = Sistema.MyData.Producto_GetLista(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var r02 = Sistema.MyData.Configuracion_FactorDivisa();
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(r02.Mensaje);
            }

            var _lst = r01.ListaD.ToList();
            if (codBuscar == "#")
            {
                _lst = _lst.Where(w => w.histPrecio != "").ToList();
            }
            _gestionListar.Inicializa();
            if (Sistema.ConfiguracionActual.ValidarExistencia_Activa)
            {
                _lst = _lst.Where(w => w.ExDisponible > 0).ToList();
            }
            _gestionListar.setData(_lst, r02.Entidad);
            _gestionListar.setFiltroPrdListar(filtro);
            _gestionListar.Inicia();
            if (_gestionListar.ItemSeleccionIsOk)
            {
                _autoPrd = _gestionListar.IdItemSeleccionado;
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

        public bool SeguirMismaLista { get { return _gestionListar.GetSalirMismaLista; } }
        public void InicializaSeguirMismaLista()
        {
        }

        public bool ProductoSeleccionadoIsPesado { get { return _gestionListar.ProductoSeleccionadoIsPesado; } }
        public bool EstatusModoBusquedaPorCodigoBarra { get { return _estatusModoBusquedaCodigoBarra; } } 
    }
}