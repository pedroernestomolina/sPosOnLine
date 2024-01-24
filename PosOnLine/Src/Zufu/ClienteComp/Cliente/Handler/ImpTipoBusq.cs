using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.Cliente.Handler
{
    public class ImpTipoBusq: LibUtilitis.CtrlCB.ImpCB, Vista.ITipoBusq
    {
        public ImpTipoBusq()
            :base()
        {
        }
        public void ObtenerData()
        {
            var _lst = new List<LibUtilitis.Opcion.IData>();
            _lst.Add(new data() { id = "1", codigo = "", desc = "CI/RIF" });
            _lst.Add(new data() { id = "2", codigo = "", desc = "NOMBRE/RAZON SOCIAL" });
            this.CargarData(_lst);
        }
    }
}
