using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Item
{

    public class Gestion
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
        public int PrdContenido { get { return _prdContenidoInf; } }
        public BindingList<data> Items { get { return _blitems; } }
        public data DataItemActual { get { return (data)_bsitems.Current; } }


        public Gestion()
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
            _gestionDevolucion.EliminarItemHnd+=_gestionDevolucion_EliminarItemHnd;
            _gestionDevolucion.DevolverItemHnd+=_gestionDevolucion_DevolverItemHnd;
            _gestionDevolucion.CntDevItemHnd += _gestionDevolucion_CntDevItemHnd;
        }

        private void _gestionDevolucion_CntDevItemHnd(object sender, Devolucion.dataDev e)
        {
            if (DevolverItem(e.idItem, e.cnt))
            {
                _gestionDevolucion.DevolverItem(e.idItem);
                if (1==1) 
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

        private bool DevolverItem(int id, int cnt=1)
        {
            var rt = false;

            var it = _blitems.FirstOrDefault(f=>f.Id==id);
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

                        //var autoPrd = it.Ficha.autoProducto;
                        //var t01 = Sistema.MyData.Producto_GetFichaById(autoPrd);
                        //if (t01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                        //{
                        //    Helpers.Msg.Error(t01.Mensaje);
                        //    return false;
                        //}

                        //switch (_tarifaPrecio)
                        //{
                        //    case "1":
                        //        pneto = t01.Entidad.pneto_1;
                        //        tarifa = "1";
                        //        pdivisa = t01.Entidad.pdf_1;
                        //        break;
                        //    case "2":
                        //        pneto = t01.Entidad.pneto_2;
                        //        tarifa = "2";
                        //        pdivisa = t01.Entidad.pdf_2;
                        //        break;
                        //    case "3":
                        //        pneto = t01.Entidad.pneto_3;
                        //        tarifa = "3";
                        //        pdivisa = t01.Entidad.pdf_3;
                        //        break;
                        //    case "4":
                        //        pneto = t01.Entidad.pneto_4;
                        //        tarifa = "4";
                        //        pdivisa = t01.Entidad.pdf_4;
                        //        break;
                        //    case "5":
                        //        pneto = t01.Entidad.pneto_5;
                        //        tarifa = "5";
                        //        pdivisa = t01.Entidad.pdf_5;
                        //        break;
                        //}

                        //if (_habilitarPos_precio_5_para_venta_mayor)
                        //{
                        //    var xcnt = Items.Where(f => f.Ficha.autoProducto == autoPrd).Sum(f => f.Cantidad);
                        //    if ((xcnt - 1) >= t01.Entidad.contenido_5)
                        //    {
                        //        pneto = t01.Entidad.pneto_5;
                        //        tarifa = "5";
                        //        pdivisa = t01.Entidad.pdf_5;
                        //    }
                        //}

                        var ficha = new OOB.Venta.Item.ActualizarCantidad.Disminuir.Ficha()
                        {
                            idOperador = it.Ficha.idOperador,
                            idItem = it.Ficha.id,
                            autoProducto = it.Ficha.autoProducto,
                            autoDeposito = it.Ficha.autoDeposito,
                            cantUndBloq = it.ContenidoEmp*cnt,
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

            var it = _blitems.FirstOrDefault(f=>f.Id==id);
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
            var r01 = Sistema.MyData.Producto_GetFichaById(idPrd);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            if (!r01.Entidad.IsPesado)
            {
                Registrar(r01.Entidad, 1, tarifa);
            }
            else
            {
                var r1 = Sistema.MyBalanza.LeerPeso();
                if (!r1.IsOk) 
                {
                    Helpers.Msg.Error(r1.Mensaje);
                    return;
                }
                if (r1.Peso > 0) 
                {
                    Registrar(r01.Entidad, r1.Peso, tarifa);
                }
            }
        }

        //private void Registrar(OOB.Producto.Entidad.Ficha prd, decimal cant)
        //{
        //    var cnt = 0.0m;
        //    var precioNeto = 0.0m;
        //    var precioFullDivisa = 0.0m;
        //    var empaqueCont = 0;
        //    var empaqueDesc = "";
        //    var decimales = "";

        //    switch (_tarifaPrecio)
        //    {
        //        case "1":
        //            cnt = prd.contenido_1;
        //            precioNeto = prd.pneto_1;
        //            precioFullDivisa = prd.pdf_1;
        //            empaqueCont = prd.contenido_1;
        //            empaqueDesc = prd.empaque_1;
        //            decimales = prd.decimales_1;
        //            break;
        //        case "2":
        //            cnt = prd.contenido_2;
        //            precioNeto = prd.pneto_2;
        //            precioFullDivisa = prd.pdf_2;
        //            empaqueCont = prd.contenido_2;
        //            empaqueDesc = prd.empaque_2;
        //            decimales = prd.decimales_2;
        //            break;
        //        case "3":
        //            cnt = prd.contenido_3;
        //            precioNeto = prd.pneto_3;
        //            precioFullDivisa = prd.pdf_3;
        //            empaqueCont = prd.contenido_3;
        //            empaqueDesc = prd.empaque_3;
        //            decimales = prd.decimales_3;
        //            break;
        //        case "4":
        //            cnt = prd.contenido_4;
        //            precioNeto = prd.pneto_4;
        //            precioFullDivisa = prd.pdf_4;
        //            empaqueCont = prd.contenido_4;
        //            empaqueDesc = prd.empaque_4;
        //            decimales = prd.decimales_4;
        //            break;
        //        case "5":
        //            cnt = prd.contenido_5;
        //            precioNeto = prd.pneto_5;
        //            precioFullDivisa = prd.pdf_5;
        //            empaqueCont = prd.contenido_5;
        //            empaqueDesc = prd.empaque_5;
        //            decimales = prd.decimales_5;
        //            break;
        //    }

        //    if (cnt == 0.0m)
        //    {
        //        Helpers.Msg.Error("CONTENIDO DEL PRODUCTO NO DEFINIDO");
        //        return;
        //    }
        //    if (precioNeto == 0.0m)
        //    {
        //        Helpers.Msg.Error("PRECIO DEL PRODUCTO NO DEFINIDO");
        //        return;
        //    }

        //    cnt *= cant;
        //    var ficha = new OOB.Venta.Item.Registrar.Ficha()
        //    {
        //        validarExistencia = _validarExistencia,
        //        deposito = new OOB.Venta.Item.Registrar.FichaDeposito()
        //        {
        //            autoDeposito = _autoDeposito,
        //            autoPrd = prd.Auto,
        //            cantBloq = cnt
        //        },
        //        item = new OOB.Venta.Item.Registrar.FichaItem()
        //        {
        //            autoDepartamento = prd.AutoDepartamento,
        //            autoGrupo = prd.AutoGrupo,
        //            autoProducto = prd.Auto,
        //            autoSubGrupo = prd.AutoSubGrupo,
        //            autoTasa = prd.AutoTasaIva,
        //            cantidad = cant,
        //            categoria = prd.Categoria,
        //            codigo = prd.CodigoPrd,
        //            costoCompra = prd.Costo,
        //            costoPromedio = prd.CostoPromedio,
        //            costoPromedioUnd = prd.CostoPromedioUnidad,
        //            costoUnd = prd.CostoUnidad,
        //            decimales = decimales,
        //            empaqueContenido = empaqueCont,
        //            empaqueDescripcion = empaqueDesc,
        //            estatusPesado = prd.EstatusPesado,
        //            idOperador = Sistema.PosEnUso.id,
        //            nombre = prd.NombrePrd,
        //            pfullDivisa = precioFullDivisa,
        //            pneto = precioNeto,
        //            tarifaPrecio = _tarifaPrecio,
        //            tasaIva = prd.TasaImpuesto,
        //            tipoIva = "",
        //            autoDeposito = _autoDeposito,
        //        },
        //    };
        //    var r01 = Sistema.MyData.Venta_Item_Registrar(ficha);
        //    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
        //    {
        //        Helpers.Msg.Error(r01.Mensaje);
        //        return;
        //    }
        //    var r02 = Sistema.MyData.Venta_Item_GetById(r01.Id);
        //    if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
        //    {
        //        Helpers.Msg.Error(r02.Mensaje);
        //        return;
        //    }

        //    _itemActual = r02.Entidad;
        //    _blitems.Insert(0, new data(r02.Entidad, _tasaCambio));
        //    _bsitems.Position = 0;
        //    Helpers.Sonido.SonidoOk();
        //}

        private bool _habilitarPos_precio_5_para_venta_mayor = false;
        private void Registrar(OOB.Producto.Entidad.Ficha prd, decimal cant, string tarifa)
        {
            var cnt = 0.0m;
            var precioNeto = 0.0m;
            var precioFullDivisa = 0.0m;
            var empaqueCont = 0;
            var empaqueDesc = "";
            var decimales = "";


            //if (_habilitarPos_precio_5_para_venta_mayor)
            //{
            //    var ent = (data)Items.FirstOrDefault(f => f.Ficha.autoProducto == prd.Auto);
            //    if (ent != null)
            //    {
            //        if (!ent.EsPesado)
            //        {
            //            IncrementarItem(ent,1);
            //            return;
            //        }
            //    }
            //}

            switch (tarifa)
            {
                case "1":
                    cnt = prd.contenido_1;
                    precioNeto = prd.pneto_1;
                    precioFullDivisa = prd.pdf_1;
                    empaqueCont = prd.contenido_1;
                    empaqueDesc = prd.empaque_1;
                    decimales = prd.decimales_1;
                    break;
                case "2":
                    cnt = prd.contenido_2;
                    precioNeto = prd.pneto_2;
                    precioFullDivisa = prd.pdf_2;
                    empaqueCont = prd.contenido_2;
                    empaqueDesc = prd.empaque_2;
                    decimales = prd.decimales_2;
                    break;
                case "3":
                    cnt = prd.contenido_3;
                    precioNeto = prd.pneto_3;
                    precioFullDivisa = prd.pdf_3;
                    empaqueCont = prd.contenido_3;
                    empaqueDesc = prd.empaque_3;
                    decimales = prd.decimales_3;
                    break;
                case "4":
                    cnt = prd.contenido_4;
                    precioNeto = prd.pneto_4;
                    precioFullDivisa = prd.pdf_4;
                    empaqueCont = prd.contenido_4;
                    empaqueDesc = prd.empaque_4;
                    decimales = prd.decimales_4;
                    break;
                case "5":
                    cnt = prd.contenido_5;
                    precioNeto = prd.pneto_5;
                    precioFullDivisa = prd.pdf_5;
                    empaqueCont = prd.contenido_5;
                    empaqueDesc = prd.empaque_5;
                    decimales = prd.decimales_5;
                    break;
                case "6":
                    cnt = prd.contenidoMay_1;
                    precioNeto = prd.pnetoMay_1;
                    precioFullDivisa = prd.pdfMay_1;
                    empaqueCont = prd.contenidoMay_1;
                    empaqueDesc = prd.empaqueMay_1;
                    decimales = prd.decimalesMay_1;
                    break;
                case "7":
                    cnt = prd.contenidoMay_2;
                    precioNeto = prd.pnetoMay_2;
                    precioFullDivisa = prd.pdfMay_2;
                    empaqueCont = prd.contenidoMay_2;
                    empaqueDesc = prd.empaqueMay_2;
                    decimales = prd.decimalesMay_2;
                    break;
                case "8":
                    cnt = prd.contenidoMay_3;
                    precioNeto = prd.pnetoMay_3;
                    precioFullDivisa = prd.pdfMay_3;
                    empaqueCont = prd.contenidoMay_3;
                    empaqueDesc = prd.empaqueMay_3;
                    decimales = prd.decimalesMay_3;
                    break;
                case "9":
                    cnt = prd.contenidoMay_4;
                    precioNeto = prd.pnetoMay_4;
                    precioFullDivisa = prd.pdfMay_4;
                    empaqueCont = prd.contenidoMay_4;
                    empaqueDesc = prd.empaqueMay_4;
                    decimales = prd.decimalesMay_4;
                    break;
                case "A":
                    cnt = prd.contenidoDsp_1;
                    precioNeto = prd.pnetoDsp_1;
                    precioFullDivisa = prd.pdfDsp_1;
                    empaqueCont = prd.contenidoDsp_1;
                    empaqueDesc = prd.empaqueDsp_1;
                    decimales = prd.decimalesDsp_1;
                    break;
                case "B":
                    cnt = prd.contenidoDsp_2;
                    precioNeto = prd.pnetoDsp_2;
                    precioFullDivisa = prd.pdfDsp_2;
                    empaqueCont = prd.contenidoDsp_2;
                    empaqueDesc = prd.empaqueDsp_2;
                    decimales = prd.decimalesDsp_2;
                    break;
                case "C":
                    cnt = prd.contenidoDsp_3;
                    precioNeto = prd.pnetoDsp_3;
                    precioFullDivisa = prd.pdfDsp_3;
                    empaqueCont = prd.contenidoDsp_3;
                    empaqueDesc = prd.empaqueDsp_3;
                    decimales = prd.decimalesDsp_3;
                    break;
                case "D":
                    cnt = prd.contenidoDsp_4;
                    precioNeto = prd.pnetoDsp_4;
                    precioFullDivisa = prd.pdfDsp_4;
                    empaqueCont = prd.contenidoDsp_4;
                    empaqueDesc = prd.empaqueDsp_4;
                    decimales = prd.decimalesDsp_4;
                    break;
            }

            //if (_habilitarPos_precio_5_para_venta_mayor)
            //{
            //    var xcnt = Items.Where(f => f.Ficha.autoProducto == prd.Auto).Sum(f => f.Cantidad);
            //    if (xcnt >= (prd.contenido_5 - 1))
            //    {
            //        precioNeto = prd.pneto_5;
            //        precioFullDivisa = prd.pdf_5;
            //        empaqueDesc = prd.empaque_5;
            //    }
            //}

            if (cnt == 0.0m)
            {
                Helpers.Msg.Error("CONTENIDO DEL PRODUCTO NO DEFINIDO");
                return;
            }
            if (precioNeto == 0.0m)
            {
                Helpers.Msg.Error("PRECIO DEL PRODUCTO NO DEFINIDO");
                return;
            }

            cnt *= cant;
            var ficha = new OOB.Venta.Item.Registrar.Ficha()
            {
                validarExistencia = _validarExistencia,
                deposito = new OOB.Venta.Item.Registrar.FichaDeposito()
                {
                    autoDeposito = _autoDeposito,
                    autoPrd = prd.Auto,
                    cantBloq = cnt
                },
                item = new OOB.Venta.Item.Registrar.FichaItem()
                {
                    autoDepartamento = prd.AutoDepartamento,
                    autoGrupo = prd.AutoGrupo,
                    autoProducto = prd.Auto,
                    autoSubGrupo = prd.AutoSubGrupo,
                    autoTasa = prd.AutoTasaIva,
                    cantidad = cant,
                    categoria = prd.Categoria,
                    codigo = prd.CodigoPrd,
                    costoCompra = prd.Costo,
                    costoPromedio = prd.CostoPromedio,
                    costoPromedioUnd = prd.CostoPromedioUnidad,
                    costoUnd = prd.CostoUnidad,
                    decimales = decimales,
                    empaqueContenido = empaqueCont,
                    empaqueDescripcion = empaqueDesc,
                    estatusPesado = prd.EstatusPesado,
                    idOperador = Sistema.PosEnUso.id,
                    nombre = prd.NombrePrd,
                    pfullDivisa = precioFullDivisa,
                    pneto = precioNeto,
                    tarifaPrecio = tarifa,
                    tasaIva = prd.TasaImpuesto,
                    tipoIva = "",
                    autoDeposito = _autoDeposito,
                },
            };
            var r01 = Sistema.MyData.Venta_Item_Registrar(ficha);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var r02 = Sistema.MyData.Venta_Item_GetById(r01.Id);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            _itemActual = r02.Entidad;
            _blitems.Insert(0, new data(r02.Entidad, _tasaCambio));
            _bsitems.Position = 0;
            Helpers.Sonido.SonidoOk();
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

        public void AnularVenta(bool modoFactura=true)
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
            if (it!= null)
            {
                var autoPrd = it.Ficha.autoProducto;
                var t01 = Sistema.MyData.Producto_GetFichaById(autoPrd);
                if (t01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(t01.Mensaje);
                    return;
                }

                var pneto = it.PrecioItem;
                var tarifa = it.Ficha.tarifaPrecio;
                var pdivisa = it.Ficha.pfullDivisa;
                //var xcnt = Items.Where(f => f.Ficha.autoProducto == autoPrd).Sum(f => f.Cantidad);
                //if ((xcnt+cnt) >= t01.Entidad.contenido_5) 
                //{
                //    pneto = t01.Entidad.pneto_5;
                //    tarifa = "5";
                //    pdivisa = t01.Entidad.pdf_5;
                //}

                var ficha = new OOB.Venta.Item.ActualizarCantidad.Aumentar.Ficha()
                {
                    idOperador = it.Ficha.idOperador,
                    idItem = it.Ficha.id,
                    autoProducto = it.Ficha.autoProducto,
                    autoDeposito = it.Ficha.autoDeposito,
                    cantUndBloq = it.ContenidoEmp * cnt,
                    cantidad = cnt,
                    validarExistencia = Sistema.ConfiguracionActual.ValidarExistencia_Activa,
                    precioNeto=pneto,
                    tarifaVenta=tarifa,
                    precioDivisa=pdivisa,
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
                if (_bsitems.IndexOf(it)>0)
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
            if (1==1)
            {
                if (_bsitems.Current != null)
                {
                    var it = (data)_bsitems.Current;
                    if (1==1)
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

                            //var autoPrd = it.Ficha.autoProducto;
                            //var t01 = Sistema.MyData.Producto_GetFichaById(autoPrd);
                            //if (t01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                            //{
                            //    Helpers.Msg.Error(t01.Mensaje);
                            //    return;
                            //}

                            //var pneto = 0.0m;
                            //var tarifa = "";
                            //var pdivisa = 0.0m;
                            //switch (_tarifaPrecio)
                            //{
                            //    case "1":
                            //        pneto = t01.Entidad.pneto_1;
                            //        tarifa = "1";
                            //        pdivisa = t01.Entidad.pdf_1;
                            //        break;
                            //    case "2":
                            //        pneto = t01.Entidad.pneto_2;
                            //        tarifa = "2";
                            //        pdivisa = t01.Entidad.pdf_2;
                            //        break;
                            //    case "3":
                            //        pneto = t01.Entidad.pneto_3;
                            //        tarifa = "3";
                            //        pdivisa = t01.Entidad.pdf_3;
                            //        break;
                            //    case "4":
                            //        pneto = t01.Entidad.pneto_4;
                            //        tarifa = "4";
                            //        pdivisa = t01.Entidad.pdf_4;
                            //        break;
                            //    case "5":
                            //        pneto = t01.Entidad.pneto_5;
                            //        tarifa = "5";
                            //        pdivisa = t01.Entidad.pdf_5;
                            //        break;
                            //}

                            //if (_habilitarPos_precio_5_para_venta_mayor) 
                            //{
                            //    var xcnt = Items.Where(f => f.Ficha.autoProducto == autoPrd).Sum(f => f.Cantidad);
                            //    if ((xcnt - 1) >= t01.Entidad.contenido_5)
                            //    {
                            //        pneto = t01.Entidad.pneto_5;
                            //        tarifa = "5";
                            //        pdivisa = t01.Entidad.pdf_5;
                            //    }
                            //}

                            var ficha = new OOB.Venta.Item.ActualizarCantidad.Disminuir.Ficha()
                            {
                                idOperador = it.Ficha.idOperador,
                                idItem = it.Ficha.id,
                                autoProducto = it.Ficha.autoProducto,
                                autoDeposito = it.Ficha.autoDeposito,
                                cantUndBloq = it.ContenidoEmp,
                                cantidad = 1,
                                precioNeto=pneto,
                                precioDivisa=pdivisa,
                                tarifaVenta=tarifa,
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
            if (_blitems.Count>0)
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

        public void DejarCtaPendiente(OOB.Cliente.Entidad.Ficha cliente)
        {
            _dejarPendienteIsOk = false;
            if (_gestionPendiente.DejarPendiente()) 
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
                if (r01.Result ==  OOB.Resultado.Enumerados.EnumResult.isError )
                {
                    Helpers.Sonido.Error();
                    Helpers.Msg.Error(r01.Mensaje);
                }
                _blitems.Clear();
                _bsitems.CurrencyManager.Refresh();
                _dejarPendienteIsOk = true;
                Helpers.Msg.OK("PROCESO REALIZADO CON EXITO !!!");
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