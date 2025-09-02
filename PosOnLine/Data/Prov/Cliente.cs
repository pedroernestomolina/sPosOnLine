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
            //
            try
            {
                var filtroDTO = new DtoLibPos.Cliente.Lista.Filtro()
                {
                    cadena = filtro.cadena,
                    preferenciaBusqueda = (DtoLibPos.Cliente.Lista.Enumerados.enumPreferenciaBusqueda)filtro.preferenciaBusqueda,
                };
                var r01 = MyData.Cliente_GetLista(filtroDTO);
                if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Lista == null) 
                {
                    throw new Exception("LISTA NO CARGADA");
                }
                var list = new List<OOB.Cliente.Lista.Ficha>();
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
                rt.ListaD = list;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public OOB.Resultado.FichaEntidad<OOB.Cliente.Entidad.Ficha> 
            Cliente_GetFicha(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Cliente.Entidad.Ficha>();
            //
            try
            {
                var r01 = MyData.Cliente_GetFichaById(id);
                if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Entidad == null) 
                {
                    throw new Exception("DATA N CARGADA");
                }
                var ent = r01.Entidad;
                result.Entidad = new OOB.Cliente.Entidad.Ficha()
                {
                    CiRif = ent.ciRif,
                    Codigo = ent.codigo,
                    Id = ent.id,
                    Nombre = ent.razonSocial,
                    Estatus = ent.estatus,
                    EstatusCredito = ent.estatusCredito,
                    DireccionFiscal = ent.dirFiscal,
                    Telefono = ent.telefono1,
                    Tarifa = ent.tarifa,
                };
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
        public OOB.Resultado.FichaEntidad<string> 
            Cliente_GetFichaByCiRif(string ciRif)
        {
            var result = new OOB.Resultado.FichaEntidad<string>();
            //
            try
            {
                var r01 = MyData.Cliente_GetFichaByCiRif(ciRif);
                if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Entidad == null) 
                {
                    throw new Exception("DATA NO CARAGADA");
                }
                result.Entidad = r01.Entidad;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
        public OOB.Resultado.FichaEntidad<bool>
            Cliente_GetEstatusCredito(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<bool>();
            //
            try
            {
                var r01 = MyData.Cliente_GetEstatusCredito(id);
                if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                if (r01.Entidad == null) 
                {
                    throw new Exception("DATA NO CARGADA");
                }
                result.Entidad = r01.Entidad.Trim().ToUpper()=="1";
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
        //
        public OOB.Resultado.FichaAuto 
            Cliente_AgregarFicha(OOB.Cliente.Agregar.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaAuto();
            //
            try
            {
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
                    //
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
                    //
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
                    //
                    abc = ficha.abc,
                    montoClasificacion = ficha.montoClasificacion,
                    codigoSucursal = ficha.codigoSucursal,
                };
                var r01 = MyData.Cliente_Agregar(fichaDTO);
                if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                result.Auto = r01.Auto;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
        public OOB.Resultado.Ficha 
            Cliente_EditarFicha(OOB.Cliente.Editar.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();
            //
            try
            {
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
                    throw new Exception(r01.Mensaje);
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
    }
}