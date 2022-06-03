using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Data.Infra
{

    public interface IData: IVerificador, IDocumento, IUsuario, IReportes
    {
    }

}