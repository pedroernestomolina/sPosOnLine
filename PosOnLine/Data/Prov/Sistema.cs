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

        public OOB.Resultado.FichaEntidad<OOB.Sistema.TipoDocumento.Entidad.Ficha> Sistema_TipoDocumento_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Sistema.TipoDocumento.Entidad.Ficha>();

            var r01 = MyData.Sistema_TipoDocumento_GetFichaById (id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            result.Entidad = new OOB.Sistema.TipoDocumento.Entidad.Ficha()
            {
                autoId = ent.autoId,
                codigo = ent.codigo,
                nombre = ent.nombre,
                siglas = ent.siglas,
                signo = ent.signo,
                tipo = ent.tipo,
            };

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Sistema.SerieFiscal.Entidad.Ficha> Sistema_Serie_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Sistema.SerieFiscal.Entidad.Ficha>();

            var r01 = MyData.Sistema_Serie_GetFichaById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            result.Entidad = new OOB.Sistema.SerieFiscal.Entidad.Ficha()
            {
                Auto = ent.Auto,
                Control = ent.Control,
                Serie = ent.Serie
            };

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Sistema.Transporte.Entidad.Ficha> Sistema_Transporte_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Sistema.Transporte.Entidad.Ficha>();

            var r01 = MyData.Transporte_GetFichaById (id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            result.Entidad = new OOB.Sistema.Transporte.Entidad.Ficha()
            {
                id = ent.id,
                codigo = ent.codigo,
                nombre = ent.nombre,
            };

            return result;
        }

        public OOB.Resultado.Lista<OOB.Sistema.TasaFiscal.Entidad.Ficha> Sistema_Fiscal_GetTasas(OOB.Sistema.TasaFiscal.Listar.Filtro filtro)
        {
            var result = new OOB.Resultado.Lista<OOB.Sistema.TasaFiscal.Entidad.Ficha>();

            var filtroDTO = new DtoLibPos.Fiscal.Lista.Filtro();
            var r01 = MyData.Fiscal_GetTasas (filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst= new List<OOB.Sistema.TasaFiscal.Entidad.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Sistema.TasaFiscal.Entidad.Ficha()
                        {
                            codTasa = s.codTasa,
                            descripcion = s.descripcion,
                            id = s.id,
                            tasa = s.tasa,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Sistema.Cobrador.Entidad.Ficha> Sistema_Cobrador_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Sistema.Cobrador.Entidad.Ficha>();

            var r01 = MyData.Cobrador_GetFichaById (id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            result.Entidad = new OOB.Sistema.Cobrador.Entidad.Ficha()
            {
                id = ent.id,
                codigo = ent.codigo,
                nombre = ent.nombre,
            };

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Sistema.MedioPago.Entidad.Ficha> Sistema_MedioPago_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Sistema.MedioPago.Entidad.Ficha>();

            var r01 = MyData.MedioPago_GetFichaById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            result.Entidad = new OOB.Sistema.MedioPago.Entidad.Ficha()
            {
                id = ent.id,
                codigo = ent.codigo,
                nombre = ent.nombre,
            };

            return result;
        }

        public OOB.Resultado.FichaEntidad<string> Sistema_ClaveAcceso_GetByIdNivel(int id)
        {
            var result = new OOB.Resultado.FichaEntidad<string>();

            var r01 = MyData.Sistema_ClaveAcceso_GetByIdNivel(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Entidad = r01.Entidad;

            return result;
        }

        public OOB.Resultado.Lista<OOB.Sistema.MedioPago.Entidad.Ficha> Sistema_MedioPago_GetLista(OOB.Sistema.MedioPago.Lista.Filtro filtro)
        {
            var result = new OOB.Resultado.Lista<OOB.Sistema.MedioPago.Entidad.Ficha>();

            var filtroDTO = new DtoLibPos.MedioPago.Lista.Filtro() { };
            var r01 = MyData.MedioPago_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst=new List<OOB.Sistema.MedioPago.Entidad.Ficha>();
            if (r01.Lista !=null)
            {
                if (r01.Lista.Count>0)
                {
                    lst= r01.Lista.Select(s=>
                    {
                        var nr = new OOB.Sistema.MedioPago.Entidad.Ficha()
                        {
                            id = s.id,
                            codigo = s.codigo,
                            nombre = s.nombre,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD=lst;

            return result;
        }

        public OOB.Resultado.Lista<OOB.Sistema.TipoDocumento.Entidad.Ficha> Sistema_TipoDocumento_GetLista()
        {
            var result = new OOB.Resultado.Lista<OOB.Sistema.TipoDocumento.Entidad.Ficha>();

            var r01 = MyData.Sistema_TipoDocumento_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Sistema.TipoDocumento.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Sistema.TipoDocumento.Entidad.Ficha()
                        {
                            autoId = s.autoId,
                            codigo = s.codigo,
                            nombre = s.nombre,
                            siglas = s.siglas,
                            signo = s.signo,
                            tipo = s.tipo,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

        public OOB.Resultado.Lista<OOB.Sistema.SerieFiscal.Entidad.Ficha> Sistema_Serie_GetLista()
        {
            var result = new OOB.Resultado.Lista<OOB.Sistema.SerieFiscal.Entidad.Ficha>();

            var r01 = MyData.Sistema_Serie_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Sistema.SerieFiscal.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Sistema.SerieFiscal.Entidad.Ficha()
                        {
                            Auto = s.Auto,
                            Control = s.Control,
                            Serie = s.Serie,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

        public OOB.Resultado.Lista<OOB.Sistema.Transporte.Entidad.Ficha> Sistema_Transporte_GetLista()
        {
            var result = new OOB.Resultado.Lista<OOB.Sistema.Transporte.Entidad.Ficha>();

            var filtroDTO = new DtoLibPos.Transporte.Lista.Filtro();
            var r01 = MyData.Transporte_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Sistema.Transporte.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Sistema.Transporte.Entidad.Ficha()
                        {
                            id = s.id,
                            codigo = s.codigo,
                            nombre = s.nombre,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

        public OOB.Resultado.Lista<OOB.Sistema.Cobrador.Entidad.Ficha> Sistema_Cobrador_GetLista()
        {
            var result = new OOB.Resultado.Lista<OOB.Sistema.Cobrador.Entidad.Ficha>();

            var filtroDTO = new DtoLibPos.Cobrador.Lista.Filtro();
            var r01 = MyData.Cobrador_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Sistema.Cobrador.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Sistema.Cobrador.Entidad.Ficha()
                        {
                            id = s.id,
                            codigo = s.codigo,
                            nombre = s.nombre,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Sistema.Empresa.Ficha> Sistema_Empresa_GetFicha()
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Sistema.Empresa.Ficha>();

            var r01 = MyData.Sistema_Empresa_GetFicha();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            var s=r01.Entidad;
            result.Entidad = new OOB.Sistema.Empresa.Ficha()
            {
                CiRif = s.CiRif,
                Direccion = s.Direccion,
                Nombre = s.Nombre,
                Telefono = s.Telefono,
            };

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Sistema.SerieFiscal.Entidad.Ficha> Sistema_Serie_GetFichaBySerie(string serie)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Sistema.SerieFiscal.Entidad.Ficha>();

            var r01 = MyData.Sistema_Serie_GetFichaByNombre(serie);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            result.Entidad = new OOB.Sistema.SerieFiscal.Entidad.Ficha()
            {
                Auto = ent.Auto,
                Control = ent.Control,
                Serie = ent.Serie
            };

            return result;
        }

    }

}