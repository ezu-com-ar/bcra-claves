using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class CxuUtils
    {
        public static string CerosAIzq(string str, int totalWidth)
        {
            return str.PadLeft(totalWidth, '0');
        }
    }
}
