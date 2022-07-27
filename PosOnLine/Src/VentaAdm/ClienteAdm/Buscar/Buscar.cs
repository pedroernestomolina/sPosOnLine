using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.VentaAdm.ClienteAdm.Buscar
{

    public class Buscar: IBuscar
    {

        private string _cadBusq;
        private data _itemSeleccionado;
        private bool _itemSeleccionadoIsOk;
        private Lista _gLista;
        private Helpers.Opcion.IOpcion _gOpcBusq;


        public bool ClienteSeleccionadoIsOk { get { return _itemSeleccionadoIsOk; } }
        public string GetClienteSeleccionadoId { get { return _itemSeleccionado.Id; } }



        public Buscar()
        {
            _cadBusq = "";
            _itemSeleccionado = null;
            _itemSeleccionadoIsOk = false;
            _gOpcBusq = new Helpers.Opcion.Gestion();
            _gLista = new Lista();
        }


        public void Inicializa() 
        {
            _itemSeleccionado = null;
            _itemSeleccionadoIsOk = false;
            _gOpcBusq.Inicializa();
            _gLista.Inicializa();
        }

        BuscarFrm _frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (_frm == null) 
                {
                    _frm = new BuscarFrm();
                    _frm.setControlador(this);
                }
                _frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt=true;

            var r01 = Sistema.MyData.Configuracion_BusquedaCliente();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var _lst= new List<Helpers.ficha>();
            _lst.Add(new Helpers.ficha() { id = "01", codigo = "", desc = "Codigo" });
            _lst.Add(new Helpers.ficha() { id = "02", codigo = "", desc = "Nombre/Razón Social" });
            _lst.Add(new Helpers.ficha() { id = "03", codigo = "", desc = "CI/Rif" });
            _gOpcBusq.setData(_lst);
            switch (r01.Entidad.PrefBusqueda)
            { 
                case OOB.Configuracion.Enumerados.EnumPreferenciaBusquedaCliente.CiRif:
                    _gOpcBusq.setFicha("03");
                    break;
                case OOB.Configuracion.Enumerados.EnumPreferenciaBusquedaCliente.Codigo:
                    _gOpcBusq.setFicha("01");
                    break;
                case OOB.Configuracion.Enumerados.EnumPreferenciaBusquedaCliente.Nombre:
                    _gOpcBusq.setFicha("02");
                    break;
            }
            return rt;
        }

        public void setCadena(string cad)
        {
            _cadBusq = cad;
        }
        public void ActivarBusqueda()
        {
            if (_cadBusq.Trim() == "")
                return;
            if (_gOpcBusq.GetId == "")
                return;

            var _prf = OOB.Cliente.Lista.Enumerados.enumPreferenciaBusqueda.SinDefinir;
            switch (_gOpcBusq.GetId) 
            {
                case "01":
                    _prf = OOB.Cliente.Lista.Enumerados.enumPreferenciaBusqueda.Codigo;
                    break;
                case "02":
                    _prf = OOB.Cliente.Lista.Enumerados.enumPreferenciaBusqueda.Nombre;
                    break;
                case "03":
                    _prf = OOB.Cliente.Lista.Enumerados.enumPreferenciaBusqueda.CiRif;
                    break;
            }
            var filtroOOB = new OOB.Cliente.Lista.Filtro()
            {
                cadena = _cadBusq,
                preferenciaBusqueda = _prf,
            };
            var r01 = Sistema.MyData.Cliente_GetLista(filtroOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var _lst = r01.ListaD.OrderBy(o=>o.nombre).Select(s =>
            {
                var nr = new data()
                {
                    CiRif = s.ciRif,
                    Codigo = s.codigo,
                    Estatus = s.estatus,
                    Id = s.auto,
                    NombreRazonSocial = s.nombre,
                };
                return nr;
            }).ToList();
            _gLista.setLista(_lst);
        }


        public void SeleccionarCliente()
        {
            if (_gLista.ItemActual != null)
            {
                var _item= (data)_gLista.ItemActual;
                if (!_item.IsActivo)
                {
                    Helpers.Msg.Error("CLIENTE SELECCIONADO EN ESTADO INACTIVO");
                    return;
                }
                _itemSeleccionado = _item;
                _itemSeleccionadoIsOk = true;
            }
        }


        public int GetCntItem { get { return _gLista.GetCntItem; } }
        public BindingSource GetItemsSource { get { return _gLista.GetSource; } }


        public BindingSource GetOpcBusqSource { get { return _gOpcBusq.Source; } }
        public string GetOpcBusqId { get { return _gOpcBusq.GetId; } }
        public void SetOpcBusq(string id)
        {
            _gOpcBusq.setFicha(id);
        }

    }

}