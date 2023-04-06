using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.Consultor.ModoAdm
{
    public struct Existencia
    {
        public string decimales;
        public decimal cnt;
    }
    public struct Vta
    {
        public int cont;
        public string desc;
        public decimal pNetoMonLocal;
        public decimal pFullDivisa;
        public decimal tasaIva;
        public string ofertaEstatus;
        public DateTime ofertaDesde;
        public DateTime ofertaHasta;
        public decimal ofertaPorct;
        public  DateTime fecha;


        public bool OfertaIsOk
        {
            get
            {
                var r = false;
                if (ofertaEstatus.Trim().ToUpper() == "1")
                {
                    if (fecha >= ofertaDesde && fecha <= ofertaHasta)
                    {
                        r = true;
                    }
                }
                return r;
            }
        }
        public decimal NetoMonLocal 
        { 
            get
            {
                var r=pNetoMonLocal;
                if (OfertaIsOk)
                {
                    var dsct = (r * ofertaPorct) / 100m;
                    r -= dsct;
                    r = Math.Round(r, 2, MidpointRounding.AwayFromZero);
                }
                return r;
            }
        }
        public decimal FullMonLocal 
        { 
            get
            {
                var r = NetoMonLocal;
                if (tasaIva>0m)
                {
                    var iva = (r * tasaIva ) / 100m;
                    r += iva;
                    r = Math.Round(r, 2, MidpointRounding.AwayFromZero);
                }
                return r;
            }
        }
        public decimal FullDivisa          
        {
            get
            {
                var r = pFullDivisa;
                if (OfertaIsOk)
                {
                    var dsct = (r * ofertaPorct) / 100m;
                    r -= dsct;
                    r = Math.Round(r, 2, MidpointRounding.AwayFromZero);
                }
                return r;
            }
        }
        public string EmpDesplegar 
        {
            get
            {
                var p="";
                p=desc+" ( "+cont.ToString().Trim()+" )";
                return p;
            } 
        }
        public string OfertaDesplegar 
        {
            get 
            {
                var r = "";
                if (OfertaIsOk) 
                {
                    r = ofertaPorct.ToString("n2") + "%";
                }
                return r;
            } 
        }
    }
    public struct sData
    {
        public string nombrePrd;
        public string departamento;
        public string grupo;
        public string marca;
        public string modelo;
        public string referencia;
        public string codigoPrd;
        public string pasillo;
        public string codigoPlu;
        public string tasaIvaDesc;
        public decimal tasaIva;
        public string codigoBarra;
        public Existencia existencia;
        public Vta vta1;
        public Vta vta2;
        public Vta vta3;

        public string tasaIvaDesplegar
        { 
            get 
            {
                var p = "EXENTO (0%)";
                if (tasaIva > 0m) 
                {
                    p = tasaIvaDesc + tasaIva.ToString("n2") + "%";
                }
                return p;
            }
        }
    }

    public interface IPrdConsultar
    {
        string GetNombrePrd { get; }
        string GetDepartamento { get; }
        string GetGrupo { get; }
        string GetMarca { get; }
        string GetModelo { get; }
        string GetReferencia { get; }
        string GetPasillo { get; }
        string GetCodigoPrd { get; }
        string GetCodigoPlu { get; }
        string GetCodigoBarra { get; }
        string GetTasaIvaDescripcion { get; }
        IExistencia Existencia { get; }
        IVta Vta1 { get; }
        IVta Vta2 { get; }
        IVta Vta3 { get; }

        void Inicializar();
        void setData(sData mdat);
    }
}