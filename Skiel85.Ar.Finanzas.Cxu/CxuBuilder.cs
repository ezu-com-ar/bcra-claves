using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class CxuBuilder
    {
        public ICxu Crear(string cxuStr)
        {
            return cxuStr.StartsWith("000") ? (ICxu) new Cvu(cxuStr) : new Cbu(cxuStr);
        }

        public object Crear(string bloque1, string bloque2)
        {
            return bloque1.StartsWith("000") ? (ICxu) new Cvu(bloque1, bloque2) : new Cbu(bloque1, bloque2);
        }
    }
}
