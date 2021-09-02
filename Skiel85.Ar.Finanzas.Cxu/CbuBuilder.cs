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

        public Cbu CrearCbu(string bloque1, string bloque2)
        {
            return CrearCbu(bloque1.PadLeft(8, '0') + bloque2.PadLeft(14, '0'));
        }

        public Cbu CrearCbu(string nroEntidad, string nroSucursal, string dvBloque1, string nroCuenta, string dvBloque2)
        {
            return CrearCbu(
                nroEntidad.PadLeft(3, '0') + nroSucursal.PadLeft(4, '0') + dvBloque1,
                nroCuenta.PadLeft(13, '0') + dvBloque2);
        }

        public Cbu CrearCbu(uint nroEntidad, uint nroSucursal, uint dvBloque1, ulong nroCuenta, uint dvBloque2)
        {
            return CrearCbu(nroEntidad.ToString(), nroSucursal.ToString(), dvBloque1.ToString(), nroCuenta.ToString(), dvBloque2.ToString());
        }
    }
}
