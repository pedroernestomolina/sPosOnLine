using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pedido.SolicitarNumeroPedido
{
    public enum ModoSolicitud
    {
        SinDefinir = -1,
        Abrir = 1,
        Guardar = 2,
    }
    public interface ISolicitud : IGestion, Helpers.IAbandonar, Helpers.IProcesar
    {
        int GetNumeroPedidoTarjeta { get; }
        ModoSolicitud GetModoSolicitud { get; }
        void setNumeroPedidoTarjeta(int numPedTarj);
        void setModoSolicitud(ModoSolicitud modo);
        bool VerificarMaximoNumeroPermitidoIsOk(int num);
    }
}