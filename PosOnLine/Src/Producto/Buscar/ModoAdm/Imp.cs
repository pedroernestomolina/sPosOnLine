using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Producto.Buscar.ModoAdm
{
    public class Imp: baseBuscarModo
    {
        private Src.CasoUso.ObtenerListaProductos _obtenerListaProductosUseCase;
        //
        public Imp()
            :base()
        {
            _obtenerListaProductosUseCase = new CasoUso.ObtenerListaProductos();
        }
        public override void buscaPorDescripcion(string codBuscar)
        {
            var filtro = new OOB.Producto.Lista.Filtro()
            {
                autoDeposito = _autoDepositoAsignado,
                cadena = codBuscar,
                idPrecioManejar = _tarifaPrecio,
            };
            //var r01 = Sistema.MyData.Producto_GetLista(filtro);
            var r01 = _obtenerListaProductosUseCase.Execute(filtro);
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
            GestionListar.Inicializa();
            if (Sistema.ConfiguracionActual.ValidarExistencia_Activa)
            {
                _lst = _lst.Where(w => w.ExDisponible > 0).ToList();
            }
            GestionListar.setFiltroPrdListar(filtro);
            GestionListar.Inicia();
            if (GestionListar.ItemSeleccionIsOk)
            {
                _autoPrd = GestionListar.IdItemSeleccionado;
            }
        }
    }
}