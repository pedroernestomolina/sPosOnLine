using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PosItemCambiarPrecio.Domain.UseCase
{
    public interface IUseCase
    {
        Models.ItemCambio 
            CargarItemCambio(int idItem);
    }
}