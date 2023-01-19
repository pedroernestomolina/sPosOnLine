﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    public interface IReportePos
    {
        OOB.Resultado.Lista<OOB.Reportes.Pos.PagoDetalle.Ficha> 
            ReportePos_PagoDetalle(OOB.Reportes.Pos.Filtro filtro);
        OOB.Resultado.Lista<OOB.Reportes.Pos.PagoResumen.Ficha> 
            ReportePos_PagoResumen(OOB.Reportes.Pos.Filtro filtro);
        OOB.Resultado.Lista<OOB.Reportes.Pos.PagoMovil.Ficha>
            ReportePos_PagoMovil(OOB.Reportes.Pos.Filtro filtro);
        OOB.Resultado.Lista<OOB.Reportes.Pos.VueltosEntregados.Ficha>
            ReportePos_VueltosEntregados(OOB.Reportes.Pos.Filtro filtro);
        //
        OOB.Resultado.FichaEntidad<OOB.Reportes.Pos.MovCaja.Ficha>
            ReportePos_MovCaja(OOB.Reportes.Pos.MovCaja.Filtro filtro);
    }
}