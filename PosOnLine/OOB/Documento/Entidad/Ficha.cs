using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Documento.Entidad
{
    public class Ficha
    {
        public FichaCuerpo cuerpo;
        public List<FichaItem> items;
        public List<FichaMedida> medidas;
        public List<FichaPrecio> precios;
        public List<FichaMetodoPago> metPago;
        public Ficha()
        {
            cuerpo = new FichaCuerpo();
            items = new List<FichaItem>();
            medidas = new List<FichaMedida>();
            precios = new List<FichaPrecio>();
            metPago = new List<FichaMetodoPago>();
        }
    }
}