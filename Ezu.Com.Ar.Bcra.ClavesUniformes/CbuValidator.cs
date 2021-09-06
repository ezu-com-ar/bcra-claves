using System;
using System.Collections.Generic;
using System.Text;

namespace Ezu.Com.Ar.Bcra.ClavesUniformes
{
    /// <summary>
    /// Valida un objeto CBU.
    /// </summary>
    public class CbuValidator : CxuValidator
    {
        /// <summary>
        /// Validador predeterminado. Realiza validación de largo, numérico y dígitos verificadores.
        /// </summary>
        public static CbuValidator Default { get; set; } = new CbuValidator();
    }
}
