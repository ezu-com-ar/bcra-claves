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
            return _valor.Length == 22 && Regex.IsMatch(_valor, @"^\d+$") && DvsSonValidos();
        }

        private bool DvsSonValidos()
        {
            var calculadora = new CalculadoraDvs();
            return calculadora.DvsSonValidos(this);
        }

        public Cbu CorregirDvs()
        {
            var calculadora = new CalculadoraDvs();
            return calculadora.CorregirDvs(this);
        }
    }
}
