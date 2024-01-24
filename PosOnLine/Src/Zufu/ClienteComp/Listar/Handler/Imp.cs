using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.Listar.Handler
{
    public class Imp: Vista.IVista
    {
        private IEnumerable<object> _lst;
        private Vista.IListaCliente _lista;


        public Vista.IListaCliente Lista { get { return _lista; } }


        public Imp()
        {
            _lista = new ImpLista();
        }
        public void Inicializa()
        {
            _lista.Inicializa();
        }
        Vista.Frm frm;
        public void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null) 
                {
                    frm = new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setListaCargar(IEnumerable<object> lst)
        {
            _lst = lst;
        }


        private bool cargarData()
        {
            _lista.setLista(_lst.ToList());
            return true;
        }
    }
}