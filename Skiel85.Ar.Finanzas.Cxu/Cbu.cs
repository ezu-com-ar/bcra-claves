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
            : this(bloque1 + bloque2)
        { }

        public Cbu(string nroEntidad, string nroSucursal, string dvBloque1, string nroCuenta, string dvBloque2)
            : this(nroEntidad + nroSucursal + dvBloque1 + nroCuenta + dvBloque2)
        { }

        public override string ToString()
        {
            return _valor;
        }
    }
}
