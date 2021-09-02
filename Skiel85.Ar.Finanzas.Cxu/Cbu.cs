using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class Cbu
    {
        private readonly string _valor;

        public Cbu(string valor)
        {
            _valor = valor;
        }

        public Cbu(string bloque1, string bloque2)
            : this(bloque1.PadLeft(8, '0') + bloque2.PadLeft(14, '0'))
        { }

        public Cbu(string nroEntidad, string nroSucursal, string dvBloque1, string nroCuenta, string dvBloque2)
            : this(
                nroEntidad.PadLeft(3, '0') + nroSucursal.PadLeft(4, '0') + dvBloque1,
                nroCuenta.PadLeft(13, '0') + dvBloque2)
        { }

        public Cbu(uint nroEntidad, uint nroSucursal, uint dvBloque1, ulong nroCuenta, uint dvBloque2)
            : this(nroEntidad.ToString(), nroSucursal.ToString(), dvBloque1.ToString(), nroCuenta.ToString(), dvBloque2.ToString())
        { }

        public override string ToString()
        {
            return _valor;
        }
    }
}
