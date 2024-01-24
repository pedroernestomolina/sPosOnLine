using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pos
{
    public interface ICliente
    {
        bool IsClienteOk { get; }
        OOB.Cliente.Entidad.Ficha Cliente { get; }
        string ClienteData { get; }


        void Inicializa();
        void Inicia();
        void CargarCliente(string id);
        void Limpiar();


        void setHabilitarBusqueda(bool _habilitar);

        string GetVendedorId { get; }
        string GetSucursalId { get; }
        string GetDepositoId { get; }

        void setVendedor(string id);
        void setSucursal(string id);
        void setDeposito(string id);

        //
        void CargarFicha(object ficha);
    }
}