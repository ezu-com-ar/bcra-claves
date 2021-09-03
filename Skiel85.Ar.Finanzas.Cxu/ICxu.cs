using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public interface ICxu
    {
        public string Bloque1 { get; }
        public string Bloque2 { get; }
        public string DvBloque1 { get; }
        public string DvBloque2 { get; }
    }
}
