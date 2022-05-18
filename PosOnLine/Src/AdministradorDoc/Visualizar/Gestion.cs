using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.AdministradorDoc.Visualizar
{
    
    public class Gestion
    {


        private string _autoDoc;
        private List<data> _detalles;
        private BindingSource _bs;
        private OOB.Documento.Entidad.Ficha _documento;


        public BindingSource Source { get { return _bs; } }
        public string Fecha
        {
            get
            {
                var xr = "";
                if (_documento != null)
                    xr = _documento.Fecha.ToShortDateString();
                return xr;
            }
        }

        public string DocumentoTipo 
        {
            get 
            {
                var xr = "";
                if (_documento != null)
                    xr = _documento.DocumentoNombre;
                return xr;
            }
        }

        public string DocumentoNro
        {
            get
            {
                var xr = "";
                if (_documento != null)
                    xr = _documento.DocumentoNro;
                return xr;
            }
        }
        public string DatosCliente
        {
            get
            {
                var xr = "";
                if (_documento != null)
                {
                    xr += _documento.CiRif + Environment.NewLine + _documento.RazonSocial + Environment.NewLine + _documento.DirFiscal;
                }
                return xr;
            }
        }
        public decimal TotalDocumento
        {
            get
            {
                var xr = 0.0m;
                if (_documento != null)
                {
                    xr = _documento.Total* _documento.Signo;
                }
                return xr;
            }
        }


        public Gestion()
        {
            _autoDoc = "";
            _detalles = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _detalles;
            _documento = null;
        }


        private VerFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new VerFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void setDocumento(Lista.data item)
        {
            _autoDoc = item.idDocumento;
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Documento_GetById(_autoDoc);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Sonido.Error();
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _documento = r01.Entidad;
            _detalles.Clear();
            foreach (var it in r01.Entidad.items)
            {
                var nr = new data(it);
                _detalles.Add(nr);
            }
            _bs.CurrencyManager.Refresh();

            return rt;
        }

        public void Inicializa()
        {
            _autoDoc = "";
            _detalles.Clear();
            _documento = null;
        }

    }

}