using PosOnLine.Data.Infra;
using ServicePos.Interfaces;
using ServicePos.MyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Prov
{
    
    public partial class DataPrv: IData
    {
        
        public static  IService MyData;


        public DataPrv(string instancia, string bd)
        {
            MyData = new  Service(instancia,bd);
        }


        public OOB.Resultado.FichaEntidad<DateTime> FechaServidor()
        {
            var result = new OOB.Resultado.FichaEntidad<DateTime>();

            var r01 = MyData.FechaServidor();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Entidad = r01.Entidad;

            return result;
        }

        public OOB.Resultado.Ficha Test()
        {
            var result = new OOB.Resultado.Ficha();

            var r01 = MyData.Test();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

    }

}