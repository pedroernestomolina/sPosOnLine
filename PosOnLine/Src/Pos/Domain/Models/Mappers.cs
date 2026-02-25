using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosOnLine.Src.Pos.Domain.Models
{
    public class Mappers
    {
        public static List<PosProducto> 
            ToListaProducto(List<OOB.Producto.Lista.Ficha> lst)
        {
            var _lst = lst.Select(s =>
            {
                return new PosProducto()
                {
                    Info = new PosPrdInfo()
                    {
                        CntDecimalesManejar = s.Decimales,
                        CodigoPLUPrd = s.PLU,
                        CodigoPrd = s.Codigo,
                        DescTasaIvaFiscal = "",
                        IdPrd = s.Auto,
                        IsActivo = s.Estatus.Trim().ToUpper() == "ACTIVO",
                        IsPesado = s.EstatusPesado.Trim().ToUpper() == "1",
                        IsPorDivisa = s.EstatusDivisa.Trim().ToUpper() == "1",
                        NombrePrd = s.Nombre,
                        TasaIvaFiscal = s.TasaIva,
                        ImagenPrd = s.imagen == null ? new byte[0] : s.imagen,
                        IsPrecioActualizado = (s.histPrecio == null ? false : true),
                    },
                    EmpqCompra = new PosPrdEmpaque()
                    {
                        contEmp = s.contEmpCompra,
                        descEmp = s.descEmpCompra,
                    },
                    Existencia = new PosPrdExistencia()
                    {
                        Disponible = s.ExDisponible,
                        Fisica = s.ExFisica,
                    },
                    EmpqVta_1 = new PosPrdEmpaque()
                    {
                        contEmp = s.contEmp_1,
                        descEmp = s.descEmp_1
                    },
                    EmpqVta_2 = new PosPrdEmpaque()
                    {
                        contEmp = s.contEmp_2,
                        descEmp = s.descEmp_2
                    },
                    EmpqVta_3 = new PosPrdEmpaque()
                    {
                        contEmp = s.contEmp_3,
                        descEmp = s.descEmp_3
                    },
                    PrecioVta_1 = new PosPrdPrecio()
                    {
                        pnetoEmp = s.pnetoEmp_1,
                        pfullDiv = s.pfullDivEmp_1,
                    },
                    PrecioVta_2 = new PosPrdPrecio()
                    {
                        pnetoEmp = s.pnetoEmp_2,
                        pfullDiv = s.pfullDivEmp_2,
                    },
                    PrecioVta_3 = new PosPrdPrecio()
                    {
                        pnetoEmp = s.pnetoEmp_3,
                        pfullDiv = s.pfullDivEmp_3,
                    },
                };
            }).ToList();
            return _lst;
        }
    }
}