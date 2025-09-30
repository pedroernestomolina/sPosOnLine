using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmVisualizarDoc.vm
{
    public interface IVisualizar: IGestion
    {
        object Get_ItemSource { get; }
        string Get_Doc_Tipo { get; }
        string Get_Doc_Numero { get; }
        string Get_Doc_FechaEmision { get; }
        string Get_Doc_ClienteInfo { get; }
        string Get_Doc_Importe { get; }
        bool Get_doc_IsCredito { get; }
        bool Get_doc_IsAnulado { get; }
        //
        void setIdDocumentoVisualizar(string id);
        //
        void Visualizar();
    }
}