using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Ezu.Com.Ar.Bcra.ClavesUniformes
{
    public abstract class Cxu
    {
        public string Valor { get; }
        public string Bloque1 => Valor.Substring(0, 8);
        public string Bloque2 => Valor.Substring(8, 14);
        public string DvBloque1 => Valor.Substring(7, 1);
        public string DvBloque2 => Valor.Substring(21, 1);

        protected Cxu(string valor)
        {
            Valor = valor;
        }

        protected Cxu(string bloque1, string bloque2)
        {
            Valor = CerosAIzq(bloque1, 8) + CerosAIzq(bloque2, 14);
        }

        protected static string CerosAIzq(string str, int totalWidth)
        {
            return str.PadLeft(totalWidth, '0');
        }
    }
}
