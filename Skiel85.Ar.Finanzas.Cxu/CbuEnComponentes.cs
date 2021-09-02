using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class CbuEnComponentes : CbuEnBloques
    {
        public CbuEnComponentes(string nroEntidad, string nroSucursal, string dvBloque1, string nroCuenta, string dvBloque2)
            : base(
                nroEntidad.PadLeft(3, '0') + nroSucursal.PadLeft(4, '0') + dvBloque1.PadLeft(1, '0'),
                nroCuenta.PadLeft(13, '0') + dvBloque2.PadLeft(1, '0'))
        {
            NroEntidad = nroEntidad;
            NroSucursal = nroSucursal;
            DvBloque1 = dvBloque1;
            NroCuenta = nroCuenta;
            DvBloque2 = dvBloque2;
        }

        public string NroEntidad { get; }
        public string NroSucursal { get; }
        public string DvBloque1 { get; }
        public string NroCuenta { get; }
        public string DvBloque2 { get; }
    }
}
