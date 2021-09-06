using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Ezu.Com.Ar.Bcra.ClavesUniformes
{
    /// <summary>
    /// Representa una Clave Uniforme (CBU o CVU).
    /// </summary>
    public abstract class Cxu
    {
        /// <summary>
        /// Número de CBU o CVU.
        /// </summary>
        public string Numero { get; }

        /// <summary>
        /// Primer bloque del CBU o CVU.
        /// </summary>
        public string Bloque1 => Numero.Substring(0, 8);

        /// <summary>
        /// Segundo bloque del CBU o CVU.
        /// </summary>
        public string Bloque2 => Numero.Substring(8, 14);

        /// <summary>
        /// Dígito verificador del primer bloque.
        /// </summary>
        public string DvBloque1 => Numero.Substring(7, 1);

        /// <summary>
        /// Dígito verificador del segundo bloque.
        /// </summary>
        public string DvBloque2 => Numero.Substring(21, 1);

        protected Cxu(string numero)
        {
            Numero = numero;
        }

        protected Cxu(string bloque1, string bloque2)
        {
            Numero = CerosAIzq(bloque1, 8) + CerosAIzq(bloque2, 14);
        }

        protected static string CerosAIzq(string str, int totalWidth)
        {
            return str.PadLeft(totalWidth, '0');
        }
    }
}
