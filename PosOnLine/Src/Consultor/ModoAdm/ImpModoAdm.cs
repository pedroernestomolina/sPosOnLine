using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor.ModoAdm
{
    public class ImpModoAdm: IModoAdm
    {
        private decimal _factorCambio;
        private string _tarifaPrecio;
        private bool _busquedaIsOk; 
        private Producto.Buscar.Gestion _gestionBuscar;
        private string _cadenaBus;
        private IPrdConsultar _prd;


        public bool BusquedaIsOk { get { return _busquedaIsOk; } }
        public IPrdConsultar Prd { get { return _prd; } }
        

        public ImpModoAdm()
        {
            _factorCambio = 0.0m;
            _tarifaPrecio = "";
            _busquedaIsOk = false;
            _cadenaBus = "";
            _prd = new imp_prdConsultar();
        }


        public void Inicializa()
        {
            _cadenaBus = "";
            _prd.Inicializar();
        }
        Frm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setGestionBuscar(Producto.Buscar.Gestion ctr)
        {
            _gestionBuscar = ctr;
        }
        public void setTarifaPrecio(string tarifa) 
        {
            _tarifaPrecio = tarifa;
        }
        public void setFactorCambio(decimal factor)
        {
            _factorCambio = factor;
        }
        public void setCadenaBuscar(string cad)
        {
            _cadenaBus = cad;
        }


        public void Buscar()
        {
            BuscarProducto(_cadenaBus);
        }


        private bool CargarData()
        {
            return true;
        }
        private void BuscarProducto(string buscar)
        {
            _busquedaIsOk = false;
            _gestionBuscar.setHabilitarVentaMayor(false);
            _gestionBuscar.ActivarBusqueda(buscar);
            if (_gestionBuscar.BusquedaIsOk)
            {
                try
                {
                    var r01 = Sistema.MyData.Producto_ModoAdm_GetFicha_By(_gestionBuscar.AutoProducto);
                    var exOOB = new OOB.Producto.Existencia.Buscar.Ficha()
                    {
                        autoDeposito = _gestionBuscar.AutoDeposito,
                        autoPrd = _gestionBuscar.AutoProducto,
                    };
                    var r02 = Sistema.MyData.Producto_Existencia_GetByPrdDeposito(exOOB);
                    if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        throw new Exception(r02.Mensaje);
                    }
                    var precioOOB = new OOB.Producto_ModoAdm.Precio.Filtro()
                    {
                        autoPrd = _gestionBuscar.AutoProducto,
                        tipoPrecioHnd = "1",
                    };
                    var r03 = Sistema.MyData.Producto_ModoAdm_GetPrecio_By (precioOOB);
                    var r04 = Sistema.MyData.FechaServidor();

                    var p= r01.Entidad;
                    sData mdat = new sData()
                    {
                        nombrePrd = p.descPrd,
                        codigoBarra = "",
                        codigoPlu = p.codigoPLU,
                        codigoPrd = p.codigoPrd,
                        departamento = p.descDepart,
                        grupo = p.descGrupo,
                        marca = p.descMarca,
                        modelo = p.modelo,
                        pasillo = p.pasillo,
                        referencia = p.referencia,
                        tasaIva = p.tasaIva,
                        tasaIvaDesc = p.descTasaIva,
                        existencia = new Existencia()
                        {
                            cnt = r02.Entidad.exDisponible,
                            decimales = r01.Entidad.decimalesEmpCompra,
                        },
                    };
                    foreach (var rg in r03.Entidad.precios)
                    {
                        switch (rg.tipoEmp.Trim().ToUpper() )
                        { 
                            case "1":
                                mdat.vta1 = new Vta()
                                {
                                    cont=rg.contEmp,
                                    desc=rg.descEmp,
                                    pNetoMonLocal=rg.pnEmp,
                                    pFullDivisa=rg.pfdEmp,
                                    tasaIva=p.tasaIva,
                                    ofertaEstatus=rg.ofertaEstatus,
                                    ofertaDesde=rg.ofertaDesde,
                                    ofertaHasta=rg.ofertaHasta,
                                    ofertaPorct=rg.ofertaPorct,
                                    fecha= r04.Entidad.Date,
                                };
                                break;
                            case "2":
                                mdat.vta2 = new Vta()
                                {
                                    cont = rg.contEmp,
                                    desc = rg.descEmp,
                                    pNetoMonLocal = rg.pnEmp,
                                    pFullDivisa = rg.pfdEmp,
                                    tasaIva = p.tasaIva,
                                    ofertaEstatus = rg.ofertaEstatus,
                                    ofertaDesde = rg.ofertaDesde,
                                    ofertaHasta = rg.ofertaHasta,
                                    ofertaPorct = rg.ofertaPorct,
                                    fecha = r04.Entidad.Date,
                                };
                                break;
                            case "3":
                                mdat.vta3 = new Vta()
                                {
                                    cont = rg.contEmp,
                                    desc = rg.descEmp,
                                    pNetoMonLocal = rg.pnEmp,
                                    pFullDivisa = rg.pfdEmp,
                                    tasaIva = p.tasaIva,
                                    ofertaEstatus = rg.ofertaEstatus,
                                    ofertaDesde = rg.ofertaDesde,
                                    ofertaHasta = rg.ofertaHasta,
                                    ofertaPorct = rg.ofertaPorct,
                                    fecha = r04.Entidad.Date,
                                };
                                break;
                        }
                    }
                    _prd.setData(mdat);
                    _busquedaIsOk = true;
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
    }
}