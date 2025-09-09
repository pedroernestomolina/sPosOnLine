using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.FormaPagoSolicitudPagoMovil.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public List<Models.Agencia> 
            CargarAgenciasUseCase()
        {
            var rt = new List<Models.Agencia>();
            //
            var filtro = new OOB.Agencia.Lista.Filtro();
            var result = Sistema.MyData.Agencia_GetLista(filtro);
            if (result.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                throw new Exception(result.Mensaje);
            }
            rt = result.ListaD
                .OrderBy(o=> o.nombre)
                .Select(s =>
                {
                    var nr = new Models.Agencia()
                    {
                        codigo = "",
                        desc = s.nombre,
                        id = s.auto,
                    };
                    return nr;
                })
                .ToList();
            //
            return rt;
        }
    }
}