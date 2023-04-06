using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Producto.Lista.ModoAdm
{
    public class ImpModoAdm: IModoAdm
    {
        private IListar _listar;
        private decimal _tasaCambio;
        private OOB.Producto.Lista.Filtro _filtroPrdListar;
        private bool _itemSeleccionadoIsOk; 
        private string _idItemSeleccionado; 


        public IListar Listar { get { return _listar; } }
        public bool ItemSeleccionIsOk { get { return _itemSeleccionadoIsOk; } }
        public string IdItemSeleccionado { get { return _idItemSeleccionado; } }


        public ImpModoAdm()
        {
            _tasaCambio = 0m;
            _filtroPrdListar = null;
            _listar = new ImpListar();
            _itemSeleccionadoIsOk = false;
            _idItemSeleccionado = "";
        }


        public void Inicializa()
        {
            _itemSeleccionadoIsOk = false;
            _tasaCambio = 0m;
            _filtroPrdListar = null;
            _listar.Inicializa();
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


        public void setData(List<OOB.Producto.Lista.Ficha> lst, decimal tasaCambio)
        {
            _tasaCambio = tasaCambio;
        }
        public void setCantidadVisible(bool valor) 
        {
        }
        public void setPrecioVisible(bool valor)
        {
        }
        public void setFiltroPrdListar(OOB.Producto.Lista.Filtro filtro)
        {
            _filtroPrdListar = filtro;
        }


        public void SeleccionItem()
        {
            if (_listar.ItemActual != null)
            {
                var _item = (IDataPrd)_listar.ItemActual;
                _itemSeleccionadoIsOk = true;
                _idItemSeleccionado = _item.GetAutoPrd;
            }
        }


        private bool CargarData()
        {
            try
            {
                var _lst = new List<IDataPrd>();
                var r01 = Sistema.MyData.Producto_ModoAdm_GetLista(_filtroPrdListar);
                foreach (var rg in r01.ListaD.
                                        GroupBy(g => new
                                        {
                                            g.nombre,
                                            g.auto,
                                            g.codigo,
                                            g.tasaIva,
                                            g.plu,
                                            g.contEmpCompra,
                                            g.contEmpInv,
                                            g.descEmpCompra,
                                            g.descEmpInv,
                                            g.estatus,
                                            g.estatusDivisa,
                                            g.estatusPesado,
                                            g.exDisponible,
                                            g.exFisica
                                        }).
                                        Where(w => w.Key.exDisponible > 0).
                                        Select(s => new { key = s.Key, lst = s.ToList() }).
                                        OrderBy(o => o.key.nombre).ToList())
                {
                    var nr = new imp_dataPrd();
                    nr.setPrd(rg.key.auto, rg.key.codigo, rg.key.nombre, rg.key.exDisponible, rg.key.plu);

                    //
                    IEmp hnd_Compra = new imp_emp();
                    hnd_Compra.setContEmp(rg.key.contEmpCompra);
                    hnd_Compra.setDescEmp(rg.key.descEmpCompra);
                    IEmp hnd_Inv = new imp_emp();
                    hnd_Inv.setContEmp(rg.key.contEmpInv);
                    hnd_Inv.setDescEmp(rg.key.descEmpInv);
                    IEmp hnd_Und = new imp_emp();
                    hnd_Und.setContEmp(1);
                    hnd_Und.setDescEmp("UNIDAD");
                    nr.setInv(hnd_Compra, hnd_Inv, hnd_Und, rg.key.exDisponible);

                    //
                    IEmpVta vt1 = new imp_empVta();
                    IEmpVta vt2 = new imp_empVta();
                    IEmpVta vt3 = new imp_empVta();
                    foreach (var it in rg.lst)
                    {
                        switch (it.tipoEmpVta.Trim().ToUpper())
                        {
                            case "1":
                                vt1.setPNeto(it.pNeto);
                                vt1.setEmpCont(it.contEmpVta);
                                vt1.setEmpDesc(it.descEmpVta);
                                vt1.setPFullDivisa(it.pFullDivisa);
                                vt1.setOferta(it.estatusOferta, it.desdeOferta, it.hastaOferta, it.porctOferta);
                                break;
                            case "2":
                                vt2.setPNeto(it.pNeto);
                                vt2.setEmpCont(it.contEmpVta);
                                vt2.setEmpDesc(it.descEmpVta);
                                vt2.setPFullDivisa(it.pFullDivisa);
                                vt2.setOferta(it.estatusOferta, it.desdeOferta, it.hastaOferta, it.porctOferta);
                                break;
                            case "3":
                                vt3.setPNeto(it.pNeto);
                                vt3.setEmpCont(it.contEmpVta);
                                vt3.setEmpDesc(it.descEmpVta);
                                vt3.setPFullDivisa(it.pFullDivisa);
                                vt3.setOferta(it.estatusOferta, it.desdeOferta, it.hastaOferta, it.porctOferta);
                                break;
                        }
                    }
                    var _admDivisa = rg.key.estatusDivisa.Trim().ToUpper() == "1";
                    nr.setPVta(vt1, vt2, vt3, rg.key.tasaIva, _admDivisa, _tasaCambio);

                    //
                    _lst.Add(nr);
                }
                _listar.setDataListar(_lst);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}