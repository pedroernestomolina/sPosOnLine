using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src._Domain.UseCase
{
    public class CargarMonedaLocalImpl: ICargarMonedaLocal
    {
        public Models.Moneda 
            Invoke()
        {
            var rt = new Models.Moneda();
            //
            var result = Sistema.MyData.Configuracion_MonedaLocal();
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            if (result.Entidad == null)
            {
                throw new Exception("PROBLEMA AL CARGAR DATA");
            }
            var s = result.Entidad;
            rt = new Models.Moneda()
            {
                id = s.id,
                codigo = s.codigo,
                nombre = s.nombre,
                simbolo = s.simbolo,
                tasaRespectoMonReferencia = s.tasaRespectoMonReferencia,
            };
            //
            return rt;
        }
    }
}