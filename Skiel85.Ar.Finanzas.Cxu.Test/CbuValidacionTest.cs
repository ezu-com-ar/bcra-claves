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
            var cbuBuilder = new CbuBuilder();
            var cbu = cbuBuilder.CrearCbu(UnCbuValidoStr);
            Assert.True(cbu.EsValido());
        }

        [Fact]
        public void CbuDemasiadoLargoNoValida()
        {
            var cbuBuilder = new CbuBuilder();
            var cbu = cbuBuilder.CrearCbu(UnCbuDemasiadoLargoStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CbuDemasiadoCortoNoValida()
        {
            var cbuBuilder = new CbuBuilder();
            var cbu = cbuBuilder.CrearCbu(UnCbuDemasiadoCortoStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CbuConLetrasNoValida()
        {
            var cbuBuilder = new CbuBuilder();
            var cbu = cbuBuilder.CrearCbu(UnCbuConLetrasStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CbuConDvBloque1IncorrectoNoValida()
        {
            var cbuBuilder = new CbuBuilder();
            var cbu = cbuBuilder.CrearCbu(UnCbuConDvBloque1IncorrectoStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CbuConDvBloque2IncorrectoNoValida()
        {
            var cbuBuilder = new CbuBuilder();
            var cbu = cbuBuilder.CrearCbu(UnCbuConDvBloque2IncorrectoStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CorreccionDv()
        {
            var cbuBuilder = new CbuBuilder();
            var cbu = cbuBuilder.CrearCbu(UnCbuConDvsIncorrectosStr);
            var cbuCorregido = cbu.CorregirDvs();
            Assert.Equal(UnCbuValidoStr, cbuCorregido.ToString());
        }
    }
}
