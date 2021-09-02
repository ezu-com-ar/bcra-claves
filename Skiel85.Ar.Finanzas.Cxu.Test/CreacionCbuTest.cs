using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Skiel85.Ar.Finanzas.Cxu.Test
{
    public class CreacionCbuTest
    {
        private const string UnCbuValidoStr = "0110012920000091344977";

        [Fact]
        public void CreacionDesdeString()
        {
            var cbu = new Cbu(UnCbuValidoStr);
            Assert.Equal(UnCbuValidoStr, cbu.ToString());
        }
    }
}
