using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmAnularDoc.Domain.ReglaNegocio
{
    public class RuleImpl: IRule
    {
        public bool Permiso()
        {
            return Helpers.PassWord.PassWIsOk(Sistema.FuncionAdmAnularDocumento);
        }
        public void ParaAnularDoc(Models.DataAnular data)
        {
            if (data.doc.isDocFiscal)
            {
                throw new Exception("DOCUMENTO FISCAL NO PUEDE SER ANULADO");
            }
            if (data.doc.isAnulado)
            {
                throw new Exception("Documento Se Encuentra Ya Anulado");
            }
        }
    }
}
