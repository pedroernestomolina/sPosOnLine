using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Src.Reportes.DocVerificados
{

    public interface IDocVerificados: IReporte
    {

        void setData(List<data> dat);

    }

}