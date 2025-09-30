using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdmAnularDoc.Domain.UseCase
{
    public class UseCaseImpl : IUseCase
    {
        public Models.DataAnular
            RecopilarDataDocumentoAnular(string idDoc)
        {
            var rt = new Models.DataAnular();
            //
            try
            {
                var rst = Sistema.MyData.Documento_RecopilarData_Anular(idDoc);
                if (rst.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
                var s = rst.Entidad.doc;
                rt.doc = new Models.Documento()
                {
                    codigoDoc = s.codigoDoc,
                    isAnulado = s.estatusAnulado,
                    isCredito = s.estatusCredito,
                    isDocFiscal = s.estatusDocFiscal,
                    idCliente = s.idCliente,
                    idDoc = s.idDoc,
                    idDocCxc = s.idDocCxc,
                    idReciboCxc = s.idReciboCxc,
                    montoPendCxc = s.montoPendCxc,

                };
                rt.kardex = rst.Entidad.kardex.Select(k =>
                {
                    var xr = new Models.Kardex()
                    {
                        cntUndMov = k.cntUndMov,
                        idDeposito = k.idDeposito,
                        idProducto = k.idProducto,
                        signoMov = k.signoMov,
                    };
                    return xr;
                }).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rt;
        }
        public void
            AnularFactura(Models.DataAnular dataAnular, string motivo)
        {
            try
            {
                var doc = dataAnular.doc;
                var ficha = new OOB.Documento.Anular.Factura.Ficha()
                {
                    idOperador = Sistema.PosEnUso.id,
                    autoDocumento = doc.idDoc,
                    autoDocCxC = doc.idDocCxc,
                    autoReciboCxC = doc.idReciboCxc,
                    CodigoDocumento = doc.codigoDoc,
                    clienteSaldo = new OOB.Documento.Anular.Factura.FichaClienteSaldo()
                    {
                        autoCliente = doc.idCliente,
                        monto = doc.montoPendCxc,
                    },
                    auditoria = new OOB.Documento.Anular.Factura.FichaAuditoria
                    {
                        autoSistemaDocumento = Sistema.ConfiguracionActual.idTipoDocumentoVenta,
                        autoUsuario = Sistema.Usuario.id,
                        codigo = Sistema.Usuario.codigo,
                        estacion = Sistema.EquipoEstacion,
                        motivo = motivo,
                        usuario = Sistema.Usuario.nombre,
                    },
                    deposito = dataAnular.kardex.Select(s =>
                    {
                        var nr = new OOB.Documento.Anular.Factura.FichaDeposito()
                        {
                            AutoDeposito = s.idDeposito,
                            AutoProducto = s.idProducto,
                            CantUnd = s.cntUndMov,
                            nombrePrd = "",
                        };
                        return nr;
                    }).ToList(),
                    resumen = new OOB.Documento.Anular.Factura.FichaResumen()
                    {
                        idResumen = Sistema.PosEnUso.idResumen,
                    }
                };
                var rst = Sistema.MyData.Documento_Anular_Factura(ficha);
                if (rst.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void
            AnularNotaCredito(Models.DataAnular dataAnular, string motivo)
        {
            try
            {
                var doc = dataAnular.doc;
                var ficha = new OOB.Documento.Anular.NotaCredito.Ficha()
                {
                    idOperador = Sistema.PosEnUso.id,
                    autoDocumento = doc.idDoc,
                    autoDocCxC = doc.idDocCxc,
                    autoReciboCxC = doc.idReciboCxc,
                    CodigoDocumento = doc.codigoDoc,
                    clienteSaldo = new OOB.Documento.Anular.NotaCredito.FichaClienteSaldo()
                    {
                        autoCliente = doc.idCliente,
                        monto = doc.montoPendCxc,
                    },
                    auditoria = new OOB.Documento.Anular.NotaCredito.FichaAuditoria
                    {
                        autoSistemaDocumento = Sistema.ConfiguracionActual.idTipoDocumentoDevVenta,
                        autoUsuario = Sistema.Usuario.id,
                        codigo = Sistema.Usuario.codigo,
                        estacion = Sistema.EquipoEstacion,
                        motivo = motivo,
                        usuario = Sistema.Usuario.nombre,
                    },
                    deposito = dataAnular.kardex.Select(s =>
                    {
                        var nr = new OOB.Documento.Anular.NotaCredito.FichaDeposito()
                        {
                            AutoDeposito = s.idDeposito,
                            AutoProducto = s.idProducto,
                            CantUnd = s.cntUndMov,
                            nombrePrd = "",
                        };
                        return nr;
                    }).ToList(),
                    resumen = new OOB.Documento.Anular.NotaCredito.FichaResumen()
                    {
                        idResumen = Sistema.PosEnUso.idResumen,
                    },
                };
                var rst = Sistema.MyData.Documento_Anular_NotaCredito(ficha);
                if (rst.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void 
            AnularNotaEntrega(Models.DataAnular dataAnular, string motivo)
        {
            try
            {
                var doc = dataAnular.doc;
                var ficha = new OOB.Documento.Anular.Factura.Ficha()
                {
                    idOperador = Sistema.PosEnUso.id,
                    autoDocumento = doc.idDoc,
                    autoDocCxC = doc.idDocCxc,
                    autoReciboCxC = doc.idReciboCxc,
                    CodigoDocumento = doc.codigoDoc,
                    clienteSaldo = new OOB.Documento.Anular.Factura.FichaClienteSaldo()
                    {
                        autoCliente = doc.idCliente,
                        monto = doc.montoPendCxc,
                    },
                    auditoria = new OOB.Documento.Anular.Factura.FichaAuditoria
                    {
                        autoSistemaDocumento = Sistema.ConfiguracionActual.idTipoDocumentoVenta,
                        autoUsuario = Sistema.Usuario.id,
                        codigo = Sistema.Usuario.codigo,
                        estacion = Sistema.EquipoEstacion,
                        motivo = motivo,
                        usuario = Sistema.Usuario.nombre,
                    },
                    deposito = dataAnular.kardex.Select(s =>
                    {
                        var nr = new OOB.Documento.Anular.Factura.FichaDeposito()
                        {
                            AutoDeposito = s.idDeposito,
                            AutoProducto = s.idProducto,
                            CantUnd = s.cntUndMov,
                            nombrePrd = "",
                        };
                        return nr;
                    }).ToList(),
                    resumen = new OOB.Documento.Anular.Factura.FichaResumen()
                    {
                        idResumen = Sistema.PosEnUso.idResumen,
                    }
                };
                var rst = Sistema.MyData.Documento_Anular_Factura(ficha);
                if (rst.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}