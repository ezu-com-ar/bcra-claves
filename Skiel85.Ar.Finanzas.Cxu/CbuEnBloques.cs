using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class CbuEnBloques : Cbu
    {
        public CbuEnBloques(string bloque1, string bloque2)
        : base(bloque1.PadLeft(8, '0') + bloque2.PadLeft(14, '0'))
        {
            Bloque1 = bloque1;
            Bloque2 = bloque2;
        }

        public string Bloque1 { get; }
        public string Bloque2 { get; }
    }
}
