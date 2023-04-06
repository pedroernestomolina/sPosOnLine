using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Tools.Vendedor
{
    public class ImpVendedor: IVendedor
    {
        private Helpers.Opcion.IOpcion _ficha;


        public BindingSource GetSource { get { return _ficha.Source; } }
        public string GetId { get { return _ficha.GetId; } }
        public Helpers.ficha GetItem { get { return _ficha.Item; } }


        public ImpVendedor()
        {
            _ficha = new Helpers.Opcion.Gestion();
        }


        public void setId(string id)        
        {
            _ficha.setFicha(id);
        }


        public void Inicializa()
        {
            _ficha.Inicializa();
        }
        public void CargarData()
        {
            var r01 = Sistema.MyData.Vendedor_GetLista();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                throw new Exception(r01.Mensaje);
            }
            var _lst = new List<Helpers.ficha>();
            foreach (var rg in r01.ListaD)
            {
                var nr = new Helpers.ficha()
                {
                    id = rg.id,
                    codigo = rg.codigo,
                    desc = rg.nombre,
                };
                _lst.Add(nr);
            }
            _ficha.setData(_lst);
        }
    }
}