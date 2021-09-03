using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class CbuValidator
    {
        private readonly CalculadoraDvs _calculadoraDvs = new CalculadoraDvs();

        private bool LargoValido(Cbu cbu)
        {
            return cbu.ToString().Length == 22;
        }

        private bool EsNumerico(Cbu cbu)
        {
            return Regex.IsMatch(cbu.ToString(), @"^\d+$");
        }

        private bool DvsSonValidos(Cbu cbu)
        {
            return _calculadoraDvs.DvsSonValidos(cbu);
        }

        public bool EsValido(Cbu cbu)
        {
            return LargoValido(cbu) && EsNumerico(cbu) && DvsSonValidos(cbu);
        }
    }
}
