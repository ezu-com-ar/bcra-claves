using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class CbuEnComponentesNumericos : CbuEnComponentes
    {
        public CbuEnComponentesNumericos(uint nroEntidad, uint nroSucursal, uint dvBloque1, ulong nroCuenta,
            uint dvBloque2)
            : base(nroEntidad.ToString(), nroSucursal.ToString(), dvBloque1.ToString(), nroCuenta.ToString(), dvBloque2.ToString())
        {
            NroEntidadAsNum = nroEntidad;
            NroSucursalAsNum = nroSucursal;
            DvBloque1AsNum = dvBloque1;
            NroCuentaAsNum = nroCuenta;
            DvBloque2AsNum = dvBloque2;
        }

        public uint NroEntidadAsNum { get; }
        public uint NroSucursalAsNum { get; }
        public uint DvBloque1AsNum { get; }
        public ulong NroCuentaAsNum { get; }
        public uint DvBloque2AsNum { get; }
    }
}
