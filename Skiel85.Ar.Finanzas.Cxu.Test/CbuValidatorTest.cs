using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Skiel85.Ar.Finanzas.Cxu.Test
{
    public class CbuValidatorTest
    {
        [Fact]
        public void ValidacionOk()
        {
            var cbu = new Cbu(CbusDePrueba.UnCbuValidoStr);
            Assert.True(cbu.EsValido());
        }

        [Fact]
        public void MasValidacionesOk()
        {
            foreach (var cbuStr in CbusDePrueba.VariosCbusValidos)
            {
                var cbu = new Cbu(cbuStr);
                Assert.True(cbu.EsValido());
            }
        }

        [Fact]
        public void CbuDemasiadoLargoNoValida()
        {
            var cbu = new Cbu(CbusDePruebaInvalidos.UnCbuDemasiadoLargoStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CbuDemasiadoCortoNoValida()
        {
            var cbu = new Cbu(CbusDePruebaInvalidos.UnCbuDemasiadoCortoStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CbuConLetrasNoValida()
        {
            var cbu = new Cbu(CbusDePruebaInvalidos.UnCbuConLetrasStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CbuConDvBloque1IncorrectoNoValida()
        {
            var cbu = new Cbu(CbusDePruebaInvalidos.UnCbuConDvBloque1IncorrectoStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CbuConDvBloque2IncorrectoNoValida()
        {
            var cbu = new Cbu(CbusDePruebaInvalidos.UnCbuConDvBloque2IncorrectoStr);
            Assert.False(cbu.EsValido());
        }

        [Fact]
        public void CorreccionDvs()
        {
            var cbu = new Cbu(CbusDePruebaInvalidos.UnCbuConDvsIncorrectosStr);
            var cbuCorregido = cbu.CorregirDvs();
            Assert.Equal(CbusDePrueba.UnCbuValidoStr, cbuCorregido.ToString());
        }
    }
}
