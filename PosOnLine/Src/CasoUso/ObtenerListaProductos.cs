using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CasoUso
{
    public class ObtenerListaProductos
    {
        public OOB.Resultado.Lista<OOB.Producto.Lista.Ficha> Execute( OOB.Producto.Lista.Filtro filtro)
        {
            var rt = Sistema.MyData.Producto_GetLista(filtro);
            if (rt.Result != OOB.Resultado.Enumerados.EnumResult.isError)
            {
                var rt2 = Sistema.MyData.Configuracion_PorcentajeAumentarEnPreciosDeProductosNoAdministradoPorDivisa();
                if (rt2.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    rt.ListaD = null;
                    rt.Mensaje = rt2.Mensaje;
                    rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                    return rt;
                }
                var _porcAumentoPrdNoAdmDivisa = rt2.Entidad;
                if (rt.ListaD != null)
                {
                    if (rt.ListaD.Count > 0)
                    {
                        foreach (var it in rt.ListaD)
                        {
                            if (it != null)
                            {
                                if (!it.EsAdmDivisa)
                                {
                                    it.pfullDivEmp_1u = calcularAumento(it.pfullDivEmp_1, _porcAumentoPrdNoAdmDivisa);
                                    it.pfullDivEmp_2u = calcularAumento(it.pfullDivEmp_2, _porcAumentoPrdNoAdmDivisa);
                                    it.pfullDivEmp_3u = calcularAumento(it.pfullDivEmp_3, _porcAumentoPrdNoAdmDivisa);
                                }
                            }
                        }
                    }
                }
            }
            return rt;
        }

        private decimal calcularAumento(decimal precio, decimal porcAumento)
        {
            var rt = 0m;
            if (precio > 0m) 
            {
                rt=precio;
                if (porcAumento > 0m)
                {
                    var _rt = rt * (porcAumento / 100m);
                    rt += _rt;
                }
            }
            rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            return rt;
        }
    }
}
