using PosVerificador.Data.Infra;
using ServicePos.Interfaces;
using ServicePos.MyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosVerificador.Data.Prov
{
    
    public partial class DataPrv: IData
    {

        public static IService MyData;


        public DataPrv(string instancia, string bd)
        {
            MyData = new  Service(instancia,bd);
        }

    }

}