using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.TasaCambioPos.Domain.USeCase
{
    public class UseCaseImpl: IUseCase
    {
        public decimal 
            ObtenerTasaActualPos()
        {
            try
            {
                var rst = Sistema.MyData.Configuracion_FactorDivisa();
                if (rst .Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst .Mensaje);
                }
                return rst.Entidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Models.ModeloRetornar 
            ActualizarTasaPos(Models.ModeloActualizarTasa ficha)
        {
            try
            {
                var filtro = new OOB.Venta.Item.Lista.Filtro()
                {
                    idOperador = ficha.IdOperador, 
                };
                var rst_1 = Sistema.MyData.Venta_Item_GetLista(filtro);
                if (rst_1.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst_1.Mensaje);
                }
                //
                var rst_2= Sistema.MyData.Configuracion_TasaCambioSistema();
                if (rst_2.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst_2.Mensaje);
                }
                var _tasaCambioSistema = rst_2.Entidad;
                //
                var _dsctoBonoPagoDivisa = 0m;
                if (_tasaCambioSistema > 0m)
                {
                    _dsctoBonoPagoDivisa = (1 - (ficha.TasaPos / _tasaCambioSistema)) * 100;
                }
                //
                var _lst = new List<OOB.PosItem.ActualizarPrecioPorCambioTasa.Item>();
                foreach (var rg in rst_1.ListaD)
                {
                    if (rg.isDivisa)
                    {
                        var neto = rg.pNetMonDivisa * _tasaCambioSistema;
                        neto = Math.Round(neto, 2, MidpointRounding.AwayFromZero);
                        rg.pneto = neto;
                    }
                    else
                    {
                        var neto = rg.pNetMonDivisa * ficha.TasaPos;
                        neto = Math.Round(neto, 2, MidpointRounding.AwayFromZero);
                        rg.pneto = neto;
                    }
                    _lst.Add(new OOB.PosItem.ActualizarPrecioPorCambioTasa.Item()
                    {
                        idItem = rg.id,
                        precioNeto = rg.pneto,
                    });
                }
                var fichaOOB = new OOB.PosItem.ActualizarPrecioPorCambioTasa.Ficha()
                {
                    items = _lst,
                    IdOperador = ficha.IdOperador,
                    TasaPos = ficha.TasaPos,
                };
                var rstItem = Sistema.MyData.PosItem_ActualizarPrecioPorCambioTasa(fichaOOB);
                if (rstItem.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rstItem.Mensaje);
                }
                //
                return new Models.ModeloRetornar()
                {
                    TasaSistemaActualizada = _tasaCambioSistema,
                    DsctoBonoPagoDivisaActualizado = _dsctoBonoPagoDivisa,
                    Items = rst_1.ListaD,
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void ActualizarTasaPos()
        {
            /*
            _tasaCambioActual = tasap;

            var filtro = new OOB.Venta.Item.Lista.Filtro()
            {
                idOperador = Sistema.PosEnUso.id,
            };
            var r03 = Sistema.MyData.Venta_Item_GetLista(filtro);
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return ;
            }

            var r066 = Sistema.MyData.Configuracion_TasaCambioSistema();
            if (r066.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r066.Mensaje);
                return;
            }
            if (r066.Entidad > 0)
            {
                //CALCULO BONO PORCT = (1-(TASA_BCV/TASA_PARALELA))*100
                _dsctoBonoPagoDivisa = (1 - (_tasaCambioActual / r066.Entidad)) * 100;
            }
            _tasaCambioSistema = r066.Entidad;


            _dsctoBonoPagoDivisa = (1 - (_tasaCambioActual / r066.Entidad)) * 100;

            if (!IsNotaCredito)
            {

                var _lst = new List<OOB.PosItem.ActualizarPrecioPorCambioTasa.Item>();
                foreach (var rg in r03.ListaD)
                {
                    if (rg.isDivisa)
                    {
                        var neto = rg.pNetMonDivisa * _tasaCambioSistema;
                        neto = Math.Round(neto, 2, MidpointRounding.AwayFromZero);
                        rg.pneto = neto;
                    }
                    else
                    {
                        var neto = rg.pNetMonDivisa * _tasaCambioActual;
                        neto = Math.Round(neto, 2, MidpointRounding.AwayFromZero);
                        rg.pneto = neto;
                    }
                    _lst.Add(new OOB.PosItem.ActualizarPrecioPorCambioTasa.Item()
                    {
                        idItem = rg.id,
                        precioNeto = rg.pneto,
                    });
                }
                var fichaOOB = new OOB.PosItem.ActualizarPrecioPorCambioTasa.Ficha()
                {
                    items = _lst,
                };
                var rstItem = Sistema.MyData.PosItem_ActualizarPrecioPorCambioTasa(fichaOOB);
                if (rstItem.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rstItem.Mensaje);
                }
                //

                _gestionItem.setData(r03.ListaD, _tasaCambioActual);
            }
             */
        }
    }
}