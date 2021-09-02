using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class CbuParser
    {
        public CbuEnBloques ParseCbuEnBloques(string valor)
        {
            var bloque1 = valor.Substring(0, 8);
            var bloque2 = valor.Substring(8, 14);
            return new CbuEnBloques(bloque1, bloque2);
        }

        public CbuEnComponentes ParseCbuEnComponentes(string valor)
        {
            var nroEntidad = valor.Substring(0, 3);
            var nroSucursal = valor.Substring(3, 4);
            var dvBloque1 = valor.Substring(7, 1);
            var nroCuenta = valor.Substring(8, 13);
            var dvBloque2 = valor.Substring(21, 1);
            return new CbuEnComponentes(nroEntidad, nroSucursal, dvBloque1, nroCuenta, dvBloque2);
        }
    }
}
