using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public abstract class CxuValidator
    {
        private readonly CalculadoraDvs _calculadoraDvs = new CalculadoraDvs();

        public bool ValidarDvs { get; set; } = true;

        private bool LargoValido(ICxu cxu)
        {
            return cxu.ToString().Length == 22;
        }

        private bool EsNumerico(ICxu cxu)
        {
            return Regex.IsMatch(cxu.ToString(), @"^\d+$");
        }

        private bool DvsSonValidos(ICxu cxu)
        {
            return !ValidarDvs || _calculadoraDvs.DvsSonValidos(cxu);
        }

        public bool EsValido(ICxu cxu)
        {
            return LargoValido(cxu) && EsNumerico(cxu) && DvsSonValidos(cxu);
        }
    }
}
