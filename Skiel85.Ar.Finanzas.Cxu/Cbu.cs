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

        public override string ToString()
        {
            return _valor;
        }
    }
}
