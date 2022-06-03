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

        public OOB.Resultado.Lista<OOB.Cliente.Lista.Ficha> 
            Cliente_GetLista(OOB.Cliente.Lista.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Cliente.Lista.Ficha>();

            var filtroDTO = new DtoLibPos.Cliente.Lista.Filtro()
            {
                cadena = filtro.cadena,
                preferenciaBusqueda = (DtoLibPos.Cliente.Lista.Enumerados.enumPreferenciaBusqueda)filtro.preferenciaBusqueda,
            };
            var r01 = MyData.Cliente_GetLista(filtroDTO);
            if (r01.Result ==  DtoLib.Enumerados.EnumResult.isError )
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.Cliente.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.Cliente.Lista.Ficha()
                        {
                            auto = s.auto,
                            codigo = s.codigo,
                            nombre = s.nombre,
                            ciRif = s.ciRif,
                            estatus = s.estatus,
                        };
                    }).ToList();
                }
            }
            rt.ListaD = list;

            return rt;
        }
        public OOB.Resultado.FichaEntidad<OOB.Cliente.Entidad.Ficha> 
            Cliente_GetFicha(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Cliente.Entidad.Ficha>();

            var r01 = MyData.Cliente_GetFichaById(id);
            if (r01.Result ==  DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            result.Entidad = new OOB.Cliente.Entidad.Ficha()
            {
                CiRif = ent.ciRif,
                Codigo = ent.codigo,
                Id = ent.id,
                Nombre = ent.razonSocial,
                Estatus = ent.estatus,
                DireccionFiscal = ent.dirFiscal,
                Telefono = ent.telefono1,
                Tarifa = ent.tarifa,
            };

            return result;
        }
        public OOB.Resultado.FichaEntidad<string> 
            Cliente_GetFichaByCiRif(string ciRif)
        {
            var result = new OOB.Resultado.FichaEntidad<string>();

            var r01 = MyData.Cliente_GetFichaByCiRif(ciRif);
            if (r01.Result ==  DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Entidad = r01.Entidad;

            return result;
        }


        public OOB.Resultado.FichaAuto 
            Cliente_AgregarFicha(OOB.Cliente.Agregar.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaAuto();

            var fichaDTO = new DtoLibPos.Cliente.Agregar.Ficha()
            {
                codigo = "",
                nombre = "",
                ciRif = ficha.ciRif,
                razonSocial = ficha.razonSocial,
                autoGrupo = ficha.autoGrupo,
                dirFiscal = ficha.dirFiscal,
                dirDespacho = ficha.dirDespacho,
                contacto = ficha.contacto,
                telefono = ficha.telefono,
                email = ficha.email,
                webSite = ficha.webSite,
                pais = ficha.pais,
                denominacionFiscal = ficha.denominacionFiscal,
                autoEstado = ficha.autoEstado,
                autoZona = ficha.autoZona,
                codigoPostal = ficha.codigoPostal,
                retencionIva = ficha.retencionIva,
                retencionIslr = ficha.retencionIslr,
                autoVendedor = ficha.autoVendedor,

                tarifa = ficha.tarifa,
                descuento = ficha.descuento,
                recargo = ficha.recargo,
                estatusCredito = ficha.estatusCredito,
                diasCredito = ficha.diasCredito,
                limiteCredito = ficha.limiteCredito,
                docPendientes = ficha.docPendientes,
                estatusMorosidad = ficha.estatusMorosidad,
                estatusLunes = ficha.estatusLunes,
                estatusMartes = ficha.estatusMartes,
                estatusMiercoles = ficha.estatusMiercoles,
                estatusJueves = ficha.estatusJueves,
                estatusViernes = ficha.estatusViernes,
                estatusSabado = ficha.estatusSabado,
                estatusDomingo = ficha.estatusDomingo,
                autoCobrador = ficha.autoCobrador,
                anticipos = ficha.anticipos,
                debitos = ficha.debitos,
                creditos = ficha.creditos,
                saldo = ficha.saldo,
                disponible = ficha.disponible,

                memo = ficha.memo,
                aviso = ficha.aviso,
                estatus = ficha.estatus,
                cuenta = ficha.cuenta,
                iban = ficha.iban,
                swit = ficha.swit,
                autoAgencia = ficha.autoAgencia,
                dirBanco = ficha.dirBanco,
                autoCodigoCobrar = ficha.autoCodigoCobrar,
                autoCodigoIngreso = ficha.autoCodigoIngreso,
                autoCodigoAnticipos = ficha.autoCodigoAnticipos,
                categoria = ficha.categoria,
                descuentoProntoPago = ficha.descuentoProntoPago,
                importeUltPago = ficha.importeUltPago,
                importeUltVenta = ficha.importeUltVenta,
                telefono2 = ficha.telefono2,
                fax = ficha.fax,
                celular = ficha.celular,

                abc = ficha.abc,
                montoClasificacion = ficha.montoClasificacion,
            };
            var r01 = MyData.Cliente_Agregar (fichaDTO);
            if (r01.Result ==  DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            result.Auto = r01.Auto;
            return result;
        }
        public OOB.Resultado.Ficha 
            Cliente_EditarFicha(OOB.Cliente.Editar.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.Cliente.Editar.Actualizar.Ficha()
           {
               autoId = ficha.auto,
               ciRif = ficha.ciRif,
               razonSocial = ficha.razonSocial,
               dirFiscal = ficha.dirFiscal,
               telefono1 = ficha.telefono,
           };
            var r01 = MyData.Cliente_Editar(fichaDTO);
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