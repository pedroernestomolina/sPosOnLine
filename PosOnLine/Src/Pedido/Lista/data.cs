using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pedido.Lista
{
    public class data: Idata
    {
        private OOB.Pedido.ListaResumen.Resumen it;
        //
        public int Id {get;set;}
        public string PedidoTarjetaNum {get;set;}
        public string Fecha { get; set; }
        public string MontoMonAct {get;set;}
        public string MontoMonDiv {get;set;}
        public string CntRenglones {get;set;}
        public OOB.Pedido.ListaResumen.Resumen Item { get { return it; } }
        //
        public data()
        {
        }
        public data(OOB.Pedido.ListaResumen.Resumen it)
        {
            this.it = it;
            Id = it.Id;
            Fecha = it.fechaHora.ToShortDateString();
            PedidoTarjetaNum = it.tarjetaNum.ToString().Trim().PadLeft(6, '0');
            MontoMonAct = it.montoMonAct.ToString("#,##0.00");
            MontoMonDiv = it.montoMonDiv.ToString("#,##0.00");
            CntRenglones = it.cntItems.ToString("###0");
        }
    }
}