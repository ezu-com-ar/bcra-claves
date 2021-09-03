using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class Cvu
    {
        private readonly string _valor;

        public Cvu(string valor)
        {
            _valor = valor;
        }

        public override string ToString()
        {
            return _valor;
        }
    }
}
