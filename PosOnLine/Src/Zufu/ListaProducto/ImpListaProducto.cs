using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ListaProducto
{
    public class ImpListaProducto: IListaProducto
    {
        private ILista _lista;
        private bool _salirLista;
        //
        public bool SalirListaIsOk { get { return _salirLista; } }
        public object ItemSeleccionado { get { return _lista.ItemSeleccionado; } }
        public bool ItemSeleccionadoIsOk { get { return _lista.ItemSeleccionadoIsOk; } }
        public object ItemActual { get { return _lista.ItemActual; } }
        public object GetSource { get { return _lista.GetSource; } }
        //
        public string GetTituloPrecioBono { get { return _lista.GetTituloPrecioBono; } }
        public string GetDetalleProducto { get { return _lista.GetDetalleProducto;  } }
        //
        public bool GetIsOkEmp1 { get { return _lista.GetIsOkEmp1; } }
        public string GetEmp1 { get { return _lista.GetEmp1;  } }
        public string GetPrecio1 { get { return _lista.GetPrecio1; } }
        public string GetPrecio1ConBono { get { return _lista.GetPrecio1ConBono; } }
        public bool GetIsOkEmp2 { get { return _lista.GetIsOkEmp2; } }
        public string GetEmp2 { get { return _lista.GetEmp2; } }
        public string GetPrecio2 { get { return _lista.GetPrecio2; } }
        public string GetPrecio2ConBono { get { return _lista.GetPrecio2ConBono; } }
        public bool GetIsOkEmp3 { get { return _lista.GetIsOkEmp3; } }
        public string GetEmp3 { get { return _lista.GetEmp3; } }
        public string GetPrecio3 { get { return _lista.GetPrecio3; } }
        public string GetPrecio3ConBono { get { return _lista.GetPrecio3ConBono; } }
        //
        public decimal GetInvEmpCompra { get { return _lista.GetInvEmpCompra; } }
        public string GetDescEmpCompra { get { return _lista.GetDescEmpCompra; } }
        public decimal GetInvEmpInv { get { return _lista.GetInvEmpInv; } }
        public string GetDescEmpInv { get { return _lista.GetDescEmpInv; } }
        public decimal GetInvEmpUnd { get { return _lista.GetInvEmpUnd; } }
        public string GetDescEmpUnd { get { return _lista.GetDescEmpUnd; } }
        public object GetPrdImagen { get { return _lista.GetPrdImagen; } }
        //
        public ImpListaProducto()
        {
            _lista = new ImpLista();
        }
        public void Inicializa()
        {
            _salirLista = false;
            _lista.Inicializa();
        }
        vistas.Frm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new vistas.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void SeleccionarItem()
        {
            _lista.SeleccionarItem();
        }
        public void FlechaArriba()
        {
            _lista.FlechaArriba();
        }
        public void FlechaAbajo()
        {
            _lista.FlechaAbajo();
        }
        public void setData(IEnumerable<object> lst, decimal factorCambio, decimal porctBonoDivisa, bool habilitarBonoDivisa)
        {
            _lista.setData(lst, factorCambio, porctBonoDivisa, habilitarBonoDivisa);
        }
        //
        private bool cargarData()
        {
            return true;
        }
        public void SalirLista()
        {
            _salirLista = true;
        }
    }
}