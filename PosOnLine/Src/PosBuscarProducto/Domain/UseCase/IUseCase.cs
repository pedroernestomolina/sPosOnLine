using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.PosBuscarProducto.Domain.UseCase
{
    public interface IUseCase
    {
        string 
            BuscarPor_CodigoBarra_Plu_CodigoAdm(string cadena);
        List<Pos.Domain.Models.PosProducto>
            BuscarPor_Descripcion(Pos.Domain.Models.PosPrdFiltrarLista filtrarPor);
    }
}