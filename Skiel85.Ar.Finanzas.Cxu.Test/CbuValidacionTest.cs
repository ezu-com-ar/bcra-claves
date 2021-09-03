using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Skiel85.Ar.Finanzas.Cxu.Test
{
    public class CbuValidacionTest
    {
        private const string UnCbuValidoStr = "0110012920000091344977";
        private const string UnCbuDemasiadoLargoStr = "0110012920000091344977777";
        private const string UnCbuDemasiadoCortoStr = "0110012920000091";
        private const string UnCbuConLetrasStr = "011ABCD920000091344977";
        private const string UnCbuConDvBloque1IncorrectoStr = "0110012020000091344977";
        private const string UnCbuConDvBloque2IncorrectoStr = "0110012920000091344970";
        private const string UnCbuConDvsIncorrectosStr = "0110012020000091344970";

        [Fact]
        public void ValidacionOk()
        {
            var cbu = new Cbu(UnCbuValidoStr);
            Assert.True(cbu.EsValido());
        }

        [Fact]
        public void CbuDemasiadoLargoNoValida()
        {
            var cbu = new Cbu(UnCbuDemasiadoLargoStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CbuDemasiadoCortoNoValida()
        {
            var cbu = new Cbu(UnCbuDemasiadoCortoStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CbuConLetrasNoValida()
        {
            var cbu = new Cbu(UnCbuConLetrasStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CbuConDvBloque1IncorrectoNoValida()
        {
            var cbu = new Cbu(UnCbuConDvBloque1IncorrectoStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CbuConDvBloque2IncorrectoNoValida()
        {
            var cbu = new Cbu(UnCbuConDvBloque2IncorrectoStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CorreccionDvs()
        {
            var cbu = new Cbu(UnCbuConDvsIncorrectosStr);
            var cbuCorregido = cbu.CorregirDvs();
            Assert.Equal(UnCbuValidoStr, cbuCorregido.ToString());
        }
    }
}
