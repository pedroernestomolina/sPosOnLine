using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor
{
    public class Gestion: IModo
    {
        private decimal _factorCambio;
        private string _tarifaPrecio;
        private data _dataPrd;
        private bool _busquedaIsOk; 
        private Producto.Buscar.Gestion _gestionBuscar;


        public decimal FactorCambio { get { return _factorCambio; } }
        public bool BusquedaIsOk { get { return _busquedaIsOk; } }
        public string NombrePrd { get { return _dataPrd.NombrePrd; } }
        public string Departamento { get { return _dataPrd.Departamento; } }
        public string Grupo { get { return _dataPrd.Grupo; } }
        public string Marca { get { return _dataPrd.Marca; } }
        public string Modelo { get { return _dataPrd.Modelo; } }
        public string Referencia { get { return _dataPrd.Referencia; } }
        public string Pasillo { get { return _dataPrd.Pasillo; } }
        public string CodigoPrd { get { return _dataPrd.CodigoPrd; } }
        public string CodigoPlu { get { return _dataPrd.CodigoPlu; } }
        public string CodigoBarra { get { return _dataPrd.CodigoBarra; } }
        public string TasaIvaDescripcion { get { return _dataPrd.TasaIvaDescripcion;} }
        public Existencia Existencia { get { return _dataPrd.Existencia; } }

        public decimal PrecioNeto_1 { get { return _dataPrd.Precio_1.Neto; } }
        public decimal PrecioFull_1 { get { return _dataPrd.Precio_1.Full; } }
        public string EmpaqueContenido_1 { get { return _dataPrd.Precio_1.EmpaqueContenidoDescripcion; } }
        public decimal PrecioDivisa_1 { get { return _dataPrd.Precio_1.FullDivisa; } }

        public decimal PrecioNeto_2 { get { return _dataPrd.Precio_2.Neto; } }
        public decimal PrecioFull_2 { get { return _dataPrd.Precio_2.Full; } }
        public string EmpaqueContenido_2 { get { return _dataPrd.Precio_2.EmpaqueContenidoDescripcion; } }
        public decimal PrecioDivisa_2 { get { return _dataPrd.Precio_2.FullDivisa; } }

        public decimal PrecioNeto_3 { get { return _dataPrd.Precio_3.Neto; } }
        public decimal PrecioFull_3 { get { return _dataPrd.Precio_3.Full; } }
        public string EmpaqueContenido_3 { get { return _dataPrd.Precio_3.EmpaqueContenidoDescripcion; } }
        public decimal PrecioDivisa_3 { get { return _dataPrd.Precio_3.FullDivisa; } }
        

        public Gestion()
        {
            _factorCambio = 0.0m;
            _tarifaPrecio = "";
            _busquedaIsOk = false;
            _dataPrd = new data();
        }


        public void BuscarProducto(string buscar)
        {
            _busquedaIsOk = false;
            _gestionBuscar.setHabilitarVentaMayor(false);
            _gestionBuscar.GestionListar.setCantidadVisible(false);
            _gestionBuscar.GestionListar.setPrecioVisible(false);
            _gestionBuscar.ActivarBusqueda(buscar);
            if (_gestionBuscar.BusquedaIsOk) 
            {
                var r01 = Sistema.MyData.Producto_GetFichaById(_gestionBuscar.AutoProducto);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                r01.Entidad.setFactorCambio(_factorCambio);
                var ficha = new OOB.Producto.Existencia.Buscar.Ficha()
                {
                    autoDeposito = _gestionBuscar.AutoDeposito,
                    autoPrd = _gestionBuscar.AutoProducto,
                };
                var r02 = Sistema.MyData.Producto_Existencia_GetByPrdDeposito(ficha);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }

                _busquedaIsOk = true;
                _dataPrd.setData(r01.Entidad,_tarifaPrecio, r02.Entidad, FactorCambio);
            }
        }

        public void setTarifaPrecio(string tarifa) 
        {
            _tarifaPrecio = tarifa;
        }

        public void setFactorCambio(decimal factor)
        {
            _factorCambio = factor;
        }

        public void Inicializa()
        {
            _gestionBuscar.GestionListar.setCantidadVisible(false);
            _gestionBuscar.GestionListar.setPrecioVisible(false);
        }

        ConsultorFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new ConsultorFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setGestionBuscar(Producto.Buscar.Gestion _ctrBuscar)
        {
            _gestionBuscar = _ctrBuscar;
        }
    }
}