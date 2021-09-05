using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ezu.Com.Ar.Bcra.ClavesUniformes.Test
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
            var validador = new CbuValidator { ValidarDvs = false };
            var cbu = new Cbu(CbusDePruebaInvalidos.UnCbuDemasiadoLargoStr);
            Assert.False(cbu.EsValido(validador));
        }

        [Fact]
        public void CbuDemasiadoCortoNoValida()
        {
            var validador = new CbuValidator { ValidarDvs = false };
            var cbu = new Cbu(CbusDePruebaInvalidos.UnCbuDemasiadoCortoStr);
            Assert.False(cbu.EsValido(validador));
        }

        [Fact]
        public void CbuConLetrasNoValida()
        {
            var validador = new CbuValidator { ValidarDvs = false };
            var cbu = new Cbu(CbusDePruebaInvalidos.UnCbuConLetrasStr);
            Assert.False(cbu.EsValido(validador));
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

        [Fact]
        public void ValidacionDvDesactivable()
        {
            var validador = new CbuValidator { ValidarDvs = false };
            var cbu = new Cbu(CbusDePruebaInvalidos.UnCbuConDvsIncorrectosStr);
            Assert.True(cbu.EsValido(validador));
        }
    }
}
