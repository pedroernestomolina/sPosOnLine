using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Prov
{
    
    public partial class DataPrv: IData
    {

        public OOB.Resultado.Ficha Pendiente_DejarCta(OOB.Pendiente.DejarCta.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.Pendiente.Dejar.Ficha()
            {
                cirifCliente = ficha.cirifCliente,
                idCliente = ficha.idCliente,
                idOperador = ficha.idOperador,
                monto = ficha.monto,
                montoDivisa = ficha.montoDivisa,
                nombreCliente = ficha.nombreCliente,
                renglones = ficha.renglones,
                items = ficha.items.Select(s => 
                {
                    var nr= new DtoLibPos.Pendiente.Dejar.FichaItem()
                    {
                         idItem=s.idItem,
                    };
                    return nr;
                }).ToList(),
            };
            var r01 = MyData.Pendiente_DejarCta(fichaDTO);
            if (r01.Result ==  DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.Resultado.FichaEntidad<int> Pendiente_CtasPendientes(int idOperador)
        {
            var result = new OOB.Resultado.FichaEntidad<int>();

            var filtroDTO= new DtoLibPos.Pendiente.Cnt.Filtro();
            if (idOperador != -1)
                filtroDTO.idOperador = idOperador;
                
            var r01 = MyData.Pendiente_CtasPendientes(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Entidad = r01.Entidad;

            return result;
        }

        public OOB.Resultado.Lista<OOB.Pendiente.Lista.Ficha> Pendiente_Lista(OOB.Pendiente.Lista.Filtro filtro)
        {
            var result = new OOB.Resultado.Lista<OOB.Pendiente.Lista.Ficha>();

            var filtroDTO = new DtoLibPos.Pendiente.Lista.Filtro();
            if (filtro.idOperador !=-1)
            {
                filtroDTO.idOperador = filtro.idOperador;
            };
            var r01 = MyData.Pendiente_Lista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            var lst = new List<OOB.Pendiente.Lista.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Pendiente.Lista.Ficha()
                        {
                            cirifCliente = s.cirifCliente,
                            id = s.id,
                            idCliente = s.idCliente,
                            monto = s.monto,
                            montoDivisa = s.montoDivisa,
                            nombreCliente = s.nombreCliente,
                            renglones = s.renglones,
                            fecha=s.fecha,
                            hora=s.hora,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

        public OOB.Resultado.Ficha Pendiente_AbrirCta(int idCta, int idOperador)
        {
            var result = new OOB.Resultado.Ficha();

            var r01 = MyData.Pendiente_AbrirCta(idCta, idOperador);
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