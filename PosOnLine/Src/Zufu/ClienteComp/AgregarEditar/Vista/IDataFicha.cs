using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Zufu.ClienteComp.AgregarEditar.Vista
{
    public interface IDataFicha
    {
        string Get_Id { get; }
        string Get_CiRif { get; }
        string Get_NombreRazonSocial { get; }
        string Get_DirFiscal { get; }
        string Get_Telefono { get; }
        void setCiRif(string dato);
        void setNombre(string dato);
        void setDirFiscal(string dato);
        void setTelefono(string dato);
        void setCliente(OOB.Cliente.Entidad.Ficha ficha);
        void Inicializa();
        bool VerificarDataIsOk();
    }
}
