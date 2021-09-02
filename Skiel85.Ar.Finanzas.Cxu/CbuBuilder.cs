using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class CbuBuilder
    {
        public Cbu CrearCbu(string valor)
        {
            return new Cbu(valor);
        }

        public CbuEnBloques CrearCbu(string bloque1, string bloque2)
        {
            return new CbuEnBloques(bloque1, bloque2);
        }

        public CbuEnComponentes CrearCbu(string nroEntidad, string nroSucursal, string dvBloque1, string nroCuenta, string dvBloque2)
        {
            return new CbuEnComponentes(nroEntidad, nroSucursal, dvBloque1, nroCuenta, dvBloque2);
        }

        public CbuEnComponentesNumericos CrearCbu(uint nroEntidad, uint nroSucursal, uint dvBloque1, ulong nroCuenta, uint dvBloque2)
        {
            return new CbuEnComponentesNumericos(nroEntidad, nroSucursal, dvBloque1, nroCuenta, dvBloque2);
        }
    }
}
