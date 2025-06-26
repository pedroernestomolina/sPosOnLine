using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.CasoUso
{
    public class ObtenerFichaProduco
    {
        public OOB.Resultado.FichaEntidad<OOB.Producto.Entidad.Ficha>
            Execute(string idPrd)
        {
            var rt = Sistema.MyData.Producto_GetFichaById(idPrd);
            if (rt.Result != OOB.Resultado.Enumerados.EnumResult.isError)
            {
                var rt2 = Sistema.MyData.Configuracion_PorcentajeAumentarEnPreciosDeProductosNoAdministradoPorDivisa();
                if (rt2.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    rt.Entidad = null;
                    rt.Mensaje = rt2.Mensaje;
                    rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                    return rt;
                }

                var _porcAumentoPrdNoAdmDivisa=rt2.Entidad;
                if (rt.Entidad != null) 
                {
                    if (!rt.Entidad.IsDivisa) 
                    {
                        rt.Entidad.pdf_1 = calcularAumento(rt.Entidad.pdf_1, _porcAumentoPrdNoAdmDivisa);
                        rt.Entidad.pdf_2 = calcularAumento(rt.Entidad.pdf_2, _porcAumentoPrdNoAdmDivisa);
                        rt.Entidad.pdf_3 = calcularAumento(rt.Entidad.pdf_3, _porcAumentoPrdNoAdmDivisa);
                        rt.Entidad.pdf_4 = calcularAumento(rt.Entidad.pdf_4, _porcAumentoPrdNoAdmDivisa);
                        rt.Entidad.pdf_5 = calcularAumento(rt.Entidad.pdf_5, _porcAumentoPrdNoAdmDivisa);
                        rt.Entidad.pdfMay_1 = calcularAumento(rt.Entidad.pdfMay_1, _porcAumentoPrdNoAdmDivisa);
                        rt.Entidad.pdfMay_2 = calcularAumento(rt.Entidad.pdfMay_2, _porcAumentoPrdNoAdmDivisa);
                        rt.Entidad.pdfMay_3 = calcularAumento(rt.Entidad.pdfMay_3, _porcAumentoPrdNoAdmDivisa);
                        rt.Entidad.pdfMay_4 = calcularAumento(rt.Entidad.pdfMay_4, _porcAumentoPrdNoAdmDivisa);
                        rt.Entidad.pdfDsp_1= calcularAumento(rt.Entidad.pdfDsp_1, _porcAumentoPrdNoAdmDivisa);
                        rt.Entidad.pdfDsp_2 = calcularAumento(rt.Entidad.pdfDsp_2, _porcAumentoPrdNoAdmDivisa);
                        rt.Entidad.pdfDsp_3 = calcularAumento(rt.Entidad.pdfDsp_3, _porcAumentoPrdNoAdmDivisa);
                        rt.Entidad.pdfDsp_4 = calcularAumento(rt.Entidad.pdfDsp_4, _porcAumentoPrdNoAdmDivisa);
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