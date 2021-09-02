using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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

        public bool EsValido()
        {
            return Regex.IsMatch(_valor, @"^\d+$") && _valor.Length == 22;
        }
    }
}
