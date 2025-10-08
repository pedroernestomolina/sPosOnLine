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
            CargarItem(int idItem);
        void 
            ProcesarCambioPrecio(OOB.PosCambioPrecio.ProcesarCambiar.Ficha ficha);
    }
}