using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Item.ModoAdm
{
    class ImpModoAdm : IModoAdm
    {
        public event EventHandler Hnd_Item_Cambio;


        private string _autoDeposito;
        private string _tarifaPrecio;
        private bool _validarExistencia;
        private bool _anularVentaIsOk;
        private decimal _tasaCambio;
        private OOB.Venta.Item.Entidad.Ficha _itemActual;
        private List<data> _litems;
        private BindingList<data> _blitems;
        private BindingSource _bsitems;
        private string _productoInf;
        private string _prdTasaIvaInf;
        private decimal _prdPrecioNetoInf;
        private decimal _prdIvaInf;
        private int _prdContenidoInf;
        private Multiplicar.Gestion _gestionMultiplicar;
        private Devolucion.Gestion _gestionDevolucion;
        private Pendiente.Gestion _gestionPendiente;
        private bool _dejarPendienteIsOk;


        public int CantItem { get { return _blitems.Sum(s => s.cantItem); } }
        public decimal TotalPeso { get { return _blitems.Sum(s => s.totalPeso); } }
        public int CantRenglones { get { return _blitems.Sum(s => s.cantRenglones); } }
        public decimal Importe { get { return _blitems.Sum(s => s.MontoTotal()); } }
        public decimal ImporteDivisa { get { return _blitems.Sum(s => s.TotalItemDivisa); } }
        public BindingSource ItemSource { get { return _bsitems; } }
        public bool AnularVentaIsOk { get { return _anularVentaIsOk; } }
        public bool DejarCtaPendienteIsOk { get { return _dejarPendienteIsOk; } }
        public OOB.Venta.Item.Entidad.Ficha ItemActual { get { return _itemActual; } }
        public string Producto { get { return _productoInf; } }
        public string PrdTasaIva { get { return _prdTasaIvaInf; } }
        public decimal PrdPrecioNeto { get { return _prdPrecioNetoInf; } }
        public decimal PrdIva { get { return _prdIvaInf; } }
        public decimal PrdContenido { get { return _prdContenidoInf; } }
        public BindingList<data> Items { get { return _blitems; } }
        public data DataItemActual { get { return (data)_bsitems.Current; } }


        public ImpModoAdm()
        {
            _autoDeposito = "";
            _tarifaPrecio = "";
            _anularVentaIsOk = false;
            _dejarPendienteIsOk = false;
            _validarExistencia = true;
            _itemActual = null;
            _litems = new List<data>();
            _blitems = new BindingList<data>(_litems);
            _bsitems = new BindingSource();
            _bsitems.DataSource = _blitems;
            _bsitems.CurrentChanged += _bsitems_CurrentChanged;
            _gestionDevolucion = new Devolucion.Gestion();
            _gestionDevolucion.EliminarItemHnd += _gestionDevolucion_EliminarItemHnd;
            _gestionDevolucion.DevolverItemHnd += _gestionDevolucion_DevolverItemHnd;
            _gestionDevolucion.CntDevItemHnd += _gestionDevolucion_CntDevItemHnd;
        }

        private void _gestionDevolucion_CntDevItemHnd(object sender, Devolucion.dataDev e)
        {
            if (DevolverItem(e.idItem, e.cnt))
            {
                _gestionDevolucion.DevolverItem(e.idItem);
                if (1 == 1)
                {
                    var _it = _blitems.FirstOrDefault(f => f.Id == e.idItem);
                    if (_it != null)
                    {
                        if (_it.Cantidad == 0m)
                        {
                            _blitems.Remove(_it);
                        }
                    }
                }
            }
        }

        private void _gestionDevolucion_DevolverItemHnd(object sender, int e)
        {
            if (DevolverItem(e))
            {
                _gestionDevolucion.DevolverItem(e);
            }
        }

        private bool DevolverItem(int id, int cnt = 1)
        {
            var rt = false;

            var it = _blitems.FirstOrDefault(f => f.Id == id);
            if (it != null)
            {
                if (it.EsPesado)
                {
                    Helpers.Msg.Error("PRODUCTO PESADO DEBE SER ELIMINADO POR COMPLETO");
                    return false;
                }

                if (it.Cantidad == 1)
                {
                    if (EliminarItem(it.Id))
                    {
                        it.setDisminuyeCantidad(1);
                        return true;
                    }
                }
                else
                {
                    var pneto = it.Ficha.pneto;
                    var tarifa = it.Ficha.tarifaPrecio;
                    var pdivisa = it.Ficha.pfullDivisa;

                    if (_modoFactura)
                    {
                        var ficha = new OOB.Venta.Item.ActualizarCantidad.Disminuir.Ficha()
                        {
                            idOperador = it.Ficha.idOperador,
                            idItem = it.Ficha.id,
                            autoProducto = it.Ficha.autoProducto,
                            autoDeposito = it.Ficha.autoDeposito,
                            cantUndBloq = it.ContenidoEmp * cnt,
                            cantidad = cnt,
                            precioNeto = pneto,
                            precioDivisa = pdivisa,
                            tarifaVenta = tarifa,
                        };
                        var r01 = Sistema.MyData.Venta_Item_ActualizarCantidad_Disminuir(ficha);
                        if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r01.Mensaje);
                            return false;
                        }
                    }
                    it.setDisminuyeCantidad(cnt);
                    it.setPrecioTarifa(pneto, tarifa, pdivisa);
                    Helpers.Sonido.SonidoOk();
                    _bsitems.CurrencyManager.Refresh();
                    return true;
                }
            }

            return rt;
        }

        private void _gestionDevolucion_EliminarItemHnd(object sender, int e)
        {
            if (EliminarItem(e))
            {
                _gestionDevolucion.Eliminar(e);
            }
        }

        private bool EliminarItem(int id)
        {
            var rt = false;

            var it = _blitems.FirstOrDefault(f => f.Id == id);
            if (it != null)
            {
                if (_modoFactura)
                {
                    var ficha = new OOB.Venta.Item.Eliminar.Ficha()
                    {
                        idOperador = it.Ficha.idOperador,
                        idItem = it.Ficha.id,
                        autoProducto = it.Ficha.autoProducto,
                        autoDeposito = it.Ficha.autoDeposito,
                        cantUndBloq = it.TotalUnd,
                    };
                    var r01 = Sistema.MyData.Venta_Item_Eliminar(ficha);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return false;
                    }
                }
                _blitems.Remove(it);
                Helpers.Sonido.SonidoOk();
                return true;
            }

            return rt;
        }

        private void _bsitems_CurrentChanged(object sender, EventArgs e)
        {
            _productoInf = "";
            _prdContenidoInf = 0;
            _prdIvaInf = 0.0m;
            _prdPrecioNetoInf = 0.0m;
            _prdTasaIvaInf = "";
            if (_bsitems.Current != null)
            {
                var it = (data)_bsitems.Current;
                _productoInf = it.Ficha.nombre;
                _prdContenidoInf = it.Ficha.empaqueContenido;
                _prdIvaInf = it.Iva();
                _prdPrecioNetoInf = it.Ficha.pneto;
                _prdTasaIvaInf = it.TasaIvaDescripcion;
            }
            var hnd = Hnd_Item_Cambio;
            if (hnd != null)
            {
                hnd(this, null);
            }
        }

        public void setDepositoAsignado(OOB.Deposito.Entidad.Ficha _depositoAsignado)
        {
            _autoDeposito = _depositoAsignado.id;
        }

        public void RegistraItem(string idPrd, string tarifa)
        {
            try
            {
                var r01 = Sistema.MyData.Producto_ModoAdm_GetFicha_By(idPrd);
                //r01.Entidad.setFactorCambio(_tasaCambio);
                if (!r01.Entidad.IsPesado)
                {
                    Registrar(r01.Entidad, 1, tarifa);
                }
                else
                {
                    var r1 = Sistema.MyBalanza.LeerPeso();
                    if (!r1.IsOk)
                    {
                        throw new Exception(r1.Mensaje);
                    }
                    if (r1.Peso > 0)
                    {
                        Registrar(r01.Entidad, r1.Peso, tarifa);
                    }
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return;
            }
        }

        private bool _habilitarPos_precio_5_para_venta_mayor = false;
        private void Registrar(OOB.Producto_ModoAdm.Entidad.Ficha prd, decimal cant, string tarifa)
        {
            try
            {
                var cnt = 0.0m;
                var precioNeto = 0.0m;
                var precioFullDivisa = 0.0m;
                var empaqueCont = 0;
                var empaqueDesc = "";
                var decimales = "";

                var precioOOB = new OOB.Producto_ModoAdm.Precio.Filtro()
                {
                    autoPrd = prd.idPrd,
                    tipoPrecioHnd = "1",
                };
                var r0p = Sistema.MyData.Producto_ModoAdm_GetPrecio_By(precioOOB);
                var r1p = Sistema.MyData.FechaServidor();
                var r2p = Sistema.MyData.Producto_GetCosto_By(prd.idPrd);
                var _fechaSist = r1p.Entidad.Date;
                foreach (var rg in r0p.Entidad.precios)
                {
                    if (rg.tipoEmp == tarifa)
                    {
                        var _ofertaIsOk = false;
                        if (rg.ofertaEstatus.Trim().ToUpper() == "1")
                        {
                            if (_fechaSist >= rg.ofertaDesde && _fechaSist <= rg.ofertaHasta)
                            {
                                _ofertaIsOk = true;
                            }
                        }

                        precioNeto = rg.pnEmp;
                        precioFullDivisa = rg.pfdEmp;
                        if (_ofertaIsOk)
                        {
                            var dsct = (precioNeto * rg.ofertaPorct) / 100m;
                            precioNeto -= dsct;
                            precioNeto = Math.Round(precioNeto, 2, MidpointRounding.AwayFromZero);

                            dsct = (precioFullDivisa * rg.ofertaPorct) / 100m;
                            precioFullDivisa -= dsct;
                            precioFullDivisa = Math.Round(precioFullDivisa, 2, MidpointRounding.AwayFromZero);
                        }
                        cnt = rg.contEmp;
                        empaqueCont = rg.contEmp;
                        empaqueDesc = rg.descEmp;
                        decimales = rg.decimales;
                        break;
                    }
                }
                precioNeto = Math.Round(precioNeto, 2, MidpointRounding.AwayFromZero);
                if (cnt == 0.0m)
                {
                    throw new Exception("CONTENIDO DEL PRODUCTO NO DEFINIDO");
                }
                if (precioNeto == 0.0m)
                {
                    throw new Exception("PRECIO DEL PRODUCTO NO DEFINIDO");
                }
                var _costoNeto = (r2p.Entidad.costoUndCompraMonLocal * empaqueCont);
                _costoNeto = Math.Round(_costoNeto, 2, MidpointRounding.AwayFromZero);
                if (_costoNeto > precioNeto)
                {
                    throw new Exception("PRECIO DEL PRODUCTO POR DEBAJO DEL COSTO");
                }

                cnt *= cant;
                var _fPeso = 0m;
                var _fVolumen = 0m;
                if (empaqueCont == prd.contEmpCompra)
                {
                    _fPeso = prd.fPeso;
                    _fVolumen = prd.fVolumen;
                }
                var ficha = new OOB.Venta.Item.Registrar.Ficha()
                {
                    validarExistencia = _validarExistencia,
                    deposito = new OOB.Venta.Item.Registrar.FichaDeposito()
                    {
                        autoDeposito = _autoDeposito,
                        autoPrd = prd.idPrd,
                        cantBloq = cnt
                    },
                    item = new OOB.Venta.Item.Registrar.FichaItem()
                    {
                        autoDepartamento = prd.idDepart,
                        autoGrupo = prd.idGrupo,
                        autoProducto = prd.idPrd,
                        autoSubGrupo = prd.idSubGrupo,
                        autoTasa = prd.idTasaIva,
                        cantidad = cant,
                        categoria = prd.categoria,
                        codigo = prd.codigoPrd,
                        costoCompra = prd.costo,
                        costoPromedio = prd.CostoPromedio,
                        costoPromedioUnd = prd.CostoPromUnd,
                        costoUnd = prd.CostoUnd,
                        decimales = decimales,
                        empaqueContenido = empaqueCont,
                        empaqueDescripcion = empaqueDesc,
                        estatusPesado = prd.estatusPesado,
                        idOperador = Sistema.PosEnUso.id,
                        nombre = prd.descPrd,
                        pfullDivisa = precioFullDivisa,
                        pneto = precioNeto,
                        tarifaPrecio = tarifa,
                        tasaIva = prd.tasaIva,
                        tipoIva = "",
                        autoDeposito = _autoDeposito,
                        fPeso = _fPeso,
                        fVolumen = _fVolumen,
                    },
                };
                var r01 = Sistema.MyData.Venta_Item_Registrar(ficha);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                var r02 = Sistema.MyData.Venta_Item_GetById(r01.Id);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
                _itemActual = r02.Entidad;
                _blitems.Insert(0, new data(r02.Entidad, _tasaCambio));
                _bsitems.Position = 0;
                Helpers.Sonido.SonidoOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return;
            }
        }

        public void setTarifaPrecio(string tarifa)
        {
            _tarifaPrecio = tarifa;
        }

        public void setValidarExistencia(bool validar)
        {
            _validarExistencia = validar;
        }

        public void setData(List<OOB.Venta.Item.Entidad.Ficha> list, decimal _tasaCambioActual)
        {
            setTasaCambio(_tasaCambioActual);
            _blitems.Clear();
            foreach (var it in list)
            {
                _blitems.Add(new data(it, _tasaCambioActual));
            }
        }

        public void AnularVenta(bool modoFactura = true)
        {
            _anularVentaIsOk = false;

            var litems = new List<OOB.Venta.Anular.FichaItem>();
            var litemsDeposito = new List<OOB.Venta.Anular.FichaDeposito>();
            foreach (var it in _litems)
            {
                var nit = new OOB.Venta.Anular.FichaItem()
                {
                    idOperador = it.Ficha.idOperador,
                    idItem = it.Ficha.id,
                };
                litems.Add(nit);

                var nitDep = new OOB.Venta.Anular.FichaDeposito()
                {
                    autoProducto = it.Ficha.autoProducto,
                    autoDeposito = it.Ficha.autoDeposito,
                    cantUndBloq = it.TotalUnd,
                };
                litemsDeposito.Add(nitDep);
            }

            if (modoFactura)
            {
                var ficha = new OOB.Venta.Anular.Ficha()
                {
                    items = litems,
                    itemDeposito = litemsDeposito,
                };
                var r01 = Sistema.MyData.Venta_Anular(ficha);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
            }
            _blitems.Clear();
            _bsitems.CurrencyManager.Refresh();
            _anularVentaIsOk = true;
        }

        public void Inicializar()
        {
            _anularVentaIsOk = false;
            _dejarPendienteIsOk = false;
            _itemActual = null;
            _productoInf = "";
            _prdContenidoInf = 0;
            _prdIvaInf = 0.0m;
            _prdPrecioNetoInf = 0.0m;
            _prdTasaIvaInf = "";
        }


        public void setTasaCambio(decimal _tasaCambioActual)
        {
            _tasaCambio = _tasaCambioActual;
        }

        public void Incrementar()
        {
            if (_habilitarPos_precio_5_para_venta_mayor)
            {
                if (ItemActual != null)
                {
                    if (_bsitems.Current != null)
                    {
                        var it = (data)_bsitems.Current;
                        IncrementarItem(it, 1);
                    }
                }
            }
            else
                IncrementarItem(1);
        }

        private void IncrementarItem(data it, decimal cnt)
        {
            if (it != null)
            {
                var autoPrd = it.Ficha.autoProducto;
                var t01 = Sistema.MyData.Producto_GetFichaById(autoPrd);
                if (t01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(t01.Mensaje);
                    return;
                }
                t01.Entidad.setFactorCambio(_tasaCambio);

                var pneto = it.PrecioItem;
                var tarifa = it.Ficha.tarifaPrecio;
                var pdivisa = it.Ficha.pfullDivisa;
                var ficha = new OOB.Venta.Item.ActualizarCantidad.Aumentar.Ficha()
                {
                    idOperador = it.Ficha.idOperador,
                    idItem = it.Ficha.id,
                    autoProducto = it.Ficha.autoProducto,
                    autoDeposito = it.Ficha.autoDeposito,
                    cantUndBloq = it.ContenidoEmp * cnt,
                    cantidad = cnt,
                    validarExistencia = Sistema.ConfiguracionActual.ValidarExistencia_Activa,
                    precioNeto = pneto,
                    tarifaVenta = tarifa,
                    precioDivisa = pdivisa,
                };
                var r01 = Sistema.MyData.Venta_Item_ActualizarCantidad_Aumentar(ficha);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var r02 = Sistema.MyData.Venta_Item_GetById(ficha.idItem);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }

                it.setAumentaCantiad(cnt);
                it.setPrecioTarifa(pneto, tarifa, pdivisa);
                if (_bsitems.IndexOf(it) > 0)
                {
                    _blitems.Remove(it);
                    _blitems.Insert(0, it);
                    _bsitems.MoveFirst();
                }

                _itemActual = r02.Entidad;
                Helpers.Sonido.SonidoOk();
            }
        }

        private void IncrementarItem(decimal cnt)
        {
            if (ItemActual != null)
            {
                if (_bsitems.Current != null)
                {
                    var it = (data)_bsitems.Current;
                    if (it.Ficha.id == ItemActual.id)
                    {
                        if (!it.EsPesado)
                        {

                            var pneto = it.PrecioItem;
                            var tarifa = it.Ficha.tarifaPrecio;
                            var pdivisa = it.Ficha.pfullDivisa;
                            var ficha = new OOB.Venta.Item.ActualizarCantidad.Aumentar.Ficha()
                            {
                                idOperador = it.Ficha.idOperador,
                                idItem = it.Ficha.id,
                                autoProducto = it.Ficha.autoProducto,
                                autoDeposito = it.Ficha.autoDeposito,
                                cantUndBloq = it.ContenidoEmp * cnt,
                                cantidad = cnt,
                                validarExistencia = Sistema.ConfiguracionActual.ValidarExistencia_Activa,
                                precioNeto = pneto,
                                tarifaVenta = tarifa,
                                precioDivisa = pdivisa,
                            };
                            var r01 = Sistema.MyData.Venta_Item_ActualizarCantidad_Aumentar(ficha);
                            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                            {
                                Helpers.Msg.Error(r01.Mensaje);
                                return;
                            }
                            it.setAumentaCantiad(cnt);
                            Helpers.Sonido.SonidoOk();
                        }
                    }
                }
            }
        }

        private void ActualizarLista(List<OOB.Venta.Item.Entidad.Ficha> list)
        {
            _blitems.Clear();
            foreach (var it in list.OrderByDescending(o => o.id).ToList())
            {
                _blitems.Add(new data(it, _tasaCambio));
            }
        }

        public void Decrementar()
        {
            if (ItemActual != null) { }
            if (1 == 1)
            {
                if (_bsitems.Current != null)
                {
                    var it = (data)_bsitems.Current;
                    if (1 == 1)
                    {
                        if (it.EsPesado)
                        {
                            return;
                        }
                        if (it.Cantidad == 1)
                        {
                            var ficha = new OOB.Venta.Item.Eliminar.Ficha()
                            {
                                idOperador = it.Ficha.idOperador,
                                idItem = it.Ficha.id,
                                autoProducto = it.Ficha.autoProducto,
                                autoDeposito = it.Ficha.autoDeposito,
                                cantUndBloq = it.ContenidoEmp,
                            };
                            var r01 = Sistema.MyData.Venta_Item_Eliminar(ficha);
                            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                            {
                                Helpers.Msg.Error(r01.Mensaje);
                                return;
                            }
                            _blitems.Remove(it);
                            Helpers.Sonido.SonidoOk();
                        }
                        else
                        {
                            var pneto = it.Ficha.pneto;
                            var tarifa = it.Ficha.tarifaPrecio;
                            var pdivisa = it.Ficha.pfullDivisa;

                            var ficha = new OOB.Venta.Item.ActualizarCantidad.Disminuir.Ficha()
                            {
                                idOperador = it.Ficha.idOperador,
                                idItem = it.Ficha.id,
                                autoProducto = it.Ficha.autoProducto,
                                autoDeposito = it.Ficha.autoDeposito,
                                cantUndBloq = it.ContenidoEmp,
                                cantidad = 1,
                                precioNeto = pneto,
                                precioDivisa = pdivisa,
                                tarifaVenta = tarifa,
                            };
                            var r01 = Sistema.MyData.Venta_Item_ActualizarCantidad_Disminuir(ficha);
                            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                            {
                                Helpers.Msg.Error(r01.Mensaje);
                                return;
                            }
                            it.setDisminuyeCantidad(1);
                            it.setPrecioTarifa(pneto, tarifa, pdivisa);
                            Helpers.Sonido.SonidoOk();
                        }
                    }
                }
            }
        }

        public void setItemActualInicializar()
        {
            _itemActual = null;
        }

        public void setGestionMultiplicar(Src.Multiplicar.Gestion gestion)
        {
            _gestionMultiplicar = gestion;
        }

        bool _modoFactura = false;
        public void DevolucionItem(bool modoFactura = true)
        {
            _modoFactura = modoFactura;
            if (_blitems.Count > 0)
            {
                _gestionDevolucion.Inicializa();
                _gestionDevolucion.setData(Items);
                _gestionDevolucion.Inicia();
                setItemActualInicializar();
            }
        }

        public void Multiplicar()
        {
            if (ItemActual != null)
            {
                if (_bsitems.Current != null)
                {
                    var it = (data)_bsitems.Current;
                    if (it.Ficha.id == ItemActual.id)
                    {
                        if (it.EsPesado)
                        {
                            return;
                        }
                        _gestionMultiplicar.Inicializa();
                        _gestionMultiplicar.Inicia();
                        if (_gestionMultiplicar.ProcesarIsOk)
                        {
                            if (_habilitarPos_precio_5_para_venta_mayor)
                                IncrementarItem(it, _gestionMultiplicar.Cantidad);
                            else
                                IncrementarItem(_gestionMultiplicar.Cantidad);
                        }
                    }
                }
            }
        }

        private AsignarVededor.IModo _asignarVendedor;
        public void DejarCtaPendiente(OOB.Cliente.Entidad.Ficha cliente, string _idSucursal, string _idDeposito, string _idVendedor)
        {
            _dejarPendienteIsOk = false;
            if (_gestionPendiente.DejarPendiente())
            {
                if (_asignarVendedor == null) 
                {
                    _asignarVendedor = new AsignarVededor.ModoAdm.ImpModoAdm();
                }
                _asignarVendedor.Inicializa();
                _asignarVendedor.Inicia();
                if (_asignarVendedor.AsignarVendedorIsOk)
                {
                    var agregar = new OOB.Pendiente.DejarCta.Ficha()
                    {
                        cirifCliente = cliente.CiRif,
                        idCliente = cliente.Id,
                        idOperador = Sistema.PosEnUso.id,
                        monto = Importe,
                        montoDivisa = ImporteDivisa,
                        nombreCliente = cliente.Nombre,
                        renglones = CantRenglones,
                        idSucursal = _idSucursal,
                        idDeposito = _idDeposito,
                        idVendedor = _asignarVendedor.IdVendedorSeleccionado,
                    };
                    agregar.items = _blitems.Select(s =>
                    {
                        var nr = new OOB.Pendiente.DejarCta.FichaItem()
                        {
                            idItem = s.Ficha.id,
                        };
                        return nr;
                    }).ToList();
                    var r01 = Sistema.MyData.Pendiente_DejarCta(agregar);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Sonido.Error();
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _blitems.Clear();
                    _bsitems.CurrencyManager.Refresh();
                    _dejarPendienteIsOk = true;
                    Helpers.Msg.OK("PROCESO REALIZADO CON EXITO !!!");
                }
                else
                {
                    Helpers.Sonido.Error();
                    Helpers.Msg.Error("VENDEDOR NO ASIGNADO");
                    return;
                }
            }
        }

        public void setGestionPendiente(Pendiente.Gestion gestion)
        {
            _gestionPendiente = gestion;
        }

        public void setDescuentoFinal(decimal p)
        {
            foreach (var it in _litems)
            {
                it.setDescuentoFinal(p);
            }
        }

        public void Limpiar()
        {
            Inicializar();
            _blitems.Clear();
            _bsitems.CurrencyManager.Refresh();
        }

        public void setData(List<OOB.Documento.Entidad.FichaItem> list, decimal _tasaCambioActual)
        {
            setTasaCambio(_tasaCambioActual);
            _blitems.Clear();
            var id = 0;
            foreach (var it in list)
            {
                id += 1;
                var rg = new data(it, _tasaCambioActual);
                rg.setId(id);
                _blitems.Add(rg);
            }
        }

        public void setHabilitarPrecio5VentaMayor(bool p)
        {
            _habilitarPos_precio_5_para_venta_mayor = p;
        }


        //
        public data Item { get { return (data)_bsitems.Current; } }
        public void SetCantIncrementar(data it, int cnt)
        {
            IncrementarItem(it, cnt);
        }
    }
}