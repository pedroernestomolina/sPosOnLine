using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Buscar
{
    public abstract class baseBuscarModo: IBuscarModo
    {
        protected string _autoPrd;
        protected string _autoDepositoAsignado;
        protected string _tarifaPrecio;
        private bool _estatusModoBusquedaCodigoBarra;
        private Producto.Lista.IListaModo _gestionListar;
        //
        public bool BusquedaIsOk { get { return _autoPrd != ""; } }
        public string AutoProducto { get { return _autoPrd; } }
        public string AutoDeposito { get { return _autoDepositoAsignado; } }
        public Producto.Lista.IListaModo GestionListar { get { return _gestionListar; } }
        //
        public baseBuscarModo()
        {
            _autoPrd = "";
            _autoDepositoAsignado = "";
            _tarifaPrecio = "";
            _estatusModoBusquedaCodigoBarra = false;
        }
        public void setGestionLista(Lista.IListaModo ctr)
        {
            _gestionListar = ctr;
        }
        public void setDepositoAsignado(OOB.Deposito.Entidad.Ficha _depositoAsignado)
        {
            _autoDepositoAsignado = _depositoAsignado.id;
        }
        public void setTarifaPrecio(string tarifa)
        {
            _tarifaPrecio = tarifa;
        }
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
                //POR CODIGO/BARRA
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
                //POR PLU
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
                //POR CODIGO/ADMINISTRATIVO
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
                //POR DESCRIPCION
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
        //
        public abstract void buscaPorDescripcion(string codBuscar);
        //
        public bool SeguirMismaLista { get { return _gestionListar.GetSalirMismaLista; } }
        public bool EstatusModoBusquedaPorCodigoBarra { get { return _estatusModoBusquedaCodigoBarra; } } 
    }
}