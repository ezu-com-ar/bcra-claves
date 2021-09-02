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
    }
}
