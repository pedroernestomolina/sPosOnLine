using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Item
{
    
    public class data
    {

        private OOB.Venta.Item.Entidad.Ficha _it;
        private decimal _tasaCambio;
        private decimal _dsctoFinal;


        public OOB.Venta.Item.Entidad.Ficha Ficha { get { return _it; } }
        public int Id { get { return _it.id; } }
        public string NombrePrd { get { return _it.nombre; } }
        public decimal Cantidad { get { return _it.cantidad; } }
        public int ContenidoEmp { get { return _it.empaqueContenido; } }
        public bool EsPesado { get { return _it.IsPesado; } }
        public decimal Importe { get { return Precio(); } }
        public decimal ImporteDivisa { get { return (Importe/_tasaCambio); } }
        public decimal TotalUnd { get { return Cantidad * ContenidoEmp; } }
        public decimal TotalItem { get { return MontoTotal(); } }
        public decimal TotalItemDivisa { get { return TotalItem /_tasaCambio ; } }
        public string IdTasaFiscal { get { return _it.autoTasa; } }
        public int cantRenglones { get { return 1; } }
        public string EmpaqueCont { get { return _it.empaqueDescripcion.Trim() + "/" + _it.empaqueContenido.ToString().Trim(); } }
        public string TasaIvaDescripcion  
        { 
            get 
            {
                var rt = " Ex ";
                if (_it.tasaIva >0)
                {
                    rt = _it.tasaIva.ToString("n2") + "%";
                }
                return rt;
            }
        }
        public int cantItem 
        { 
            get 
            {
                var x = (int)_it.cantidad;
                if (_it.IsPesado) { x = 1; }
                return x;
            }
        }
        public decimal totalPeso 
        { 
            get 
            {
                var x = 0.0m;
                if (_it.IsPesado) { x = _it.cantidad; }                
                return x; 
            }
        }


        public data()
        {
        }

        public data(OOB.Venta.Item.Entidad.Ficha it, decimal tasaCamb)
        {
            this._it = it;
            this._tasaCambio = tasaCamb;
        }

        public data(OOB.Documento.Entidad.FichaItem it, decimal _tasaCambioActual)
        {
            this._it = new OOB.Venta.Item.Entidad.Ficha(it);
            this._tasaCambio = _tasaCambioActual;
        }


        private decimal MontoNeto()
        {
            var rt = 0.0m;
            rt = _it.cantidad * _it.pneto;
            return rt;
        }

        private decimal MontoIva()
        {
            var rt = 0.0m;
            rt = MontoNeto() * (_it.tasaIva / 100);
            return rt;
        }

        public decimal MontoTotal()
        {
            var rt = 0.0m;
            rt = MontoNeto()+MontoIva();
            rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            return rt;
        }

        private decimal Precio()
        {
            var rt = 0.0m;
            rt = _it.pneto + Iva();
            return rt;
        }

        public decimal Iva()
        {
            var rt = 0.0m;
            rt = _it.pneto * (_it.tasaIva /100);
            rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            return rt;
        }

        public void setAumentaCantiad(decimal p)
        {
            _it.cantidad += p;
        }

        public void setDisminuyeCantidad(int p)
        {
            _it.cantidad -= p;
        }

        public void setDescuentoFinal(decimal dscto)
        {
            _dsctoFinal = dscto;
        }


        //
        public decimal TotalNeto { get { return Cantidad * _it.pneto; } }
        public decimal CostoVenta { get { return _it.costoUnd * TotalUnd; } }
        public decimal Impuesto { get { return TotalNeto * _it.tasaIva / 100; } }
        public decimal Total { get { return TotalNeto + Impuesto; } }
        public decimal PrecioFinal { get { return _it.pneto - (_it.pneto * _dsctoFinal / 100); } }
        public decimal PrecioUnd { get { return PrecioFinal; } }
        public decimal Utilidad { get { return (PrecioUnd - _it.costoUnd) * TotalUnd; } }
        public decimal UtilidadP { get { return 100 - ((_it.costoUnd / PrecioUnd) * 100); } }
        public decimal PrecioItem { get { return _it.pneto; } }
        public decimal VentaNeta { get { return (PrecioFinal * Cantidad); } }
        //
        public decimal BaseExenta 
        { 
            get 
            {
                var rt = 0.0m;
                if (_it.tasaIva == 0.0m) 
                {
                    rt = Cantidad * PrecioFinal;
                }
                return rt;
            } 
        }

        public decimal MontoBase 
        {
            get
            {
                var rt = 0.0m;
                if (_it.tasaIva > 0.0m)
                {
                    rt = Cantidad * PrecioFinal;
                }
                return rt;
            } 
        }

        public decimal MontoImpuesto
        {
            get
            {
                var rt = 0.0m;
                if (_it.tasaIva > 0.0m) 
                {
                    rt = (MontoBase * _it.tasaIva / 100);
                }
                return rt;
            }
        }

        public void setId(int id)
        {
            _it.id = id;
        }

        public void setPrecioTarifa(decimal pneto, string tarifa, decimal pdivisa)
        {
            _it.pneto = pneto;
            _it.tarifaPrecio = tarifa;
            _it.pfullDivisa = pdivisa;
        }
        public void setPrecio(decimal  pneto)
        {
            _it.pneto = pneto;
        }


        public decimal TasaCambio { get { return _tasaCambio; } }
        public decimal CostoItem 
        { 
            get 
            {
                var rt = 0m;
                rt = _it.costoUnd * _it.empaqueContenido;
                return rt;
            } 
        }

    }

}