using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PosBuscarProducto.vm
{
    public class BuscarPrdImpl : IBuscarPrd
    {
        private string _idDepositoManejar;
        private string _tarifaPrecioManejar;
        private Domain.UseCase.IUseCase _uc;
        //
        public BuscarPrdImpl()
        {
            _idDepositoManejar = "";
            _tarifaPrecioManejar = "";
            _uc = new Domain.UseCase.UseCaseImpl();
        }
        public void setIdDepositoManejar(string id)
        {
            _idDepositoManejar = id;
        }
        public void setTarifaPrecio(string tarifa)
        {
            _tarifaPrecioManejar = tarifa;
        }
        public Domain.Models.BusquedaResult
            Execute(string cadenaBuscar)
        {
            var _cadena = cadenaBuscar.Trim();
            if (_cadena == "") { return null; }
            try
            {
                var _idPrd= _uc.BuscarPor_CodigoBarra_Plu_CodigoAdm(_cadena);
                var _lstPrd = new List<Pos.Domain.Models.PosProducto>();
                if (_idPrd == "") 
                {
                    var _filtrarPor = new Pos.Domain.Models.PosPrdFiltrarLista()
                    {
                        CadenaBuscar = _cadena,
                        PorIdDeposito = _idDepositoManejar,
                        PorIdPrecioManejar = _tarifaPrecioManejar,
                    };
                    _lstPrd = _uc.BuscarPor_Descripcion(_filtrarPor);
                }
                return new Domain.Models.BusquedaResult()
                {
                    IdPrdEncontrado = _idPrd,
                    LstPrdEncontrado = _lstPrd,
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
