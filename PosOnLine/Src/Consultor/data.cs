using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor
{

    public class data
    {

        private OOB.Producto.Entidad.Ficha _ficha;
        private Precio _precio_1;
        private Precio _precio_2;
        private Precio _precio_3;
        private Existencia _existencia;


        public string CodigoPrd { get { return _ficha.CodigoPrd; } }
        public string CodigoPlu { get { return _ficha.CodigoPLU; } }
        public string CodigoBarra { get; set; }
        public string NombrePrd { get { return _ficha.NombrePrd; } }
        public string Departamento { get { return _ficha.NombreDepartamento; } }
        public string Grupo { get { return _ficha.NombreGrupo; } }
        public string Marca { get { return _ficha.Marca; } }
        public string Modelo { get { return _ficha.Modelo; } }
        public string Pasillo { get { return _ficha.Pasillo; } }
        public decimal Tasa { get { return _ficha.TasaImpuesto; } }
        public string Referencia { get { return _ficha.Referencia; } }
        public Precio Precio_1 { get { return _precio_1; } }
        public Precio Precio_2 { get { return _precio_2; } }
        public Precio Precio_3 { get { return _precio_3; } }
        public Existencia Existencia { get { return _existencia; } }
        public string TasaIvaDescripcion 
        {
            get 
            {
                var rt = "EXENTO";
                if (Tasa > 0) 
                {
                    rt = Tasa.ToString("n2") + "%";
                }
                return rt ;
            }
        }


        public data() 
        {
            _precio_1 = new Precio();
            _precio_2 = new Precio();
            _precio_3 = new Precio();
            _existencia = new Existencia();
        }

        public void setData(OOB.Producto.Entidad.Ficha fichaPrd, string _tarifaPrecio, OOB.Producto.Existencia.Entidad.Ficha fichaEx)
        {
            _ficha = fichaPrd;
            _precio_1.Limpiar();
            _precio_2.Limpiar();
            _precio_3.Limpiar();
            _existencia.Limpiar();

            switch (_tarifaPrecio)
            {
                case "1":
                    _precio_1.setData(_ficha.pneto_1, _ficha.TasaImpuesto, _ficha.contenido_1, _ficha.empaque_1, _ficha.pdf_1);
                    _precio_2.setData(_ficha.pnetoMay_1, _ficha.TasaImpuesto, _ficha.contenidoMay_1, _ficha.empaqueMay_1, _ficha.pdfMay_1);
                    _precio_3.setData(_ficha.pnetoDsp_1, _ficha.TasaImpuesto, _ficha.contenidoDsp_1, _ficha.empaqueDsp_1, _ficha.pdfDsp_1);
                    break;
                case "2":
                    _precio_1.setData(_ficha.pneto_2, _ficha.TasaImpuesto, _ficha.contenido_2, _ficha.empaque_2, _ficha.pdf_2);
                    _precio_2.setData(_ficha.pnetoMay_2, _ficha.TasaImpuesto, _ficha.contenidoMay_2, _ficha.empaqueMay_2, _ficha.pdfMay_2);
                    _precio_3.setData(_ficha.pnetoDsp_2, _ficha.TasaImpuesto, _ficha.contenidoDsp_2, _ficha.empaqueDsp_2, _ficha.pdfDsp_2);
                    break;
                case "3":
                    _precio_1.setData(_ficha.pneto_3, _ficha.TasaImpuesto, _ficha.contenido_3, _ficha.empaque_3, _ficha.pdf_3);
                    _precio_2.setData(_ficha.pnetoMay_3, _ficha.TasaImpuesto, _ficha.contenidoMay_3, _ficha.empaqueMay_3, _ficha.pdfMay_3);
                    _precio_3.setData(_ficha.pnetoDsp_3, _ficha.TasaImpuesto, _ficha.contenidoDsp_3, _ficha.empaqueDsp_3, _ficha.pdfDsp_3);
                    break;
                case "4":
                    _precio_1.setData(_ficha.pneto_4, _ficha.TasaImpuesto, _ficha.contenido_4, _ficha.empaque_4, _ficha.pdf_4);
                    _precio_2.setData(_ficha.pnetoMay_4, _ficha.TasaImpuesto, _ficha.contenidoMay_4, _ficha.empaqueMay_4, _ficha.pdfMay_4);
                    _precio_3.setData(_ficha.pnetoDsp_4, _ficha.TasaImpuesto, _ficha.contenidoDsp_4, _ficha.empaqueDsp_4, _ficha.pdfDsp_4);
                    break;
                case "5":
                    _precio_1.setData(_ficha.pneto_5, _ficha.TasaImpuesto, _ficha.contenido_5, _ficha.empaque_5, _ficha.pdf_5);
                    break;
            }
            _existencia.setData(fichaEx, 1);
        }

    }

}