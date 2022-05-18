using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface ICliente
    {

        OOB.Resultado.Lista<OOB.Cliente.Lista.Ficha> 
            Cliente_GetLista(OOB.Cliente.Lista.Filtro filtro);
        OOB.Resultado.FichaEntidad<OOB.Cliente.Entidad.Ficha> 
            Cliente_GetFicha(string id);
        OOB.Resultado.FichaEntidad<string> 
            Cliente_GetFichaByCiRif(string ciRif);
        OOB.Resultado.FichaAuto 
            Cliente_AgregarFicha(OOB.Cliente.Agregar.Ficha ficha);
        OOB.Resultado.Ficha
            Cliente_EditarFicha(OOB.Cliente.Editar.Ficha ficha);

    }

}