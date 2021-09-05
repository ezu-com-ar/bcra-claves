using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ezu.Com.Ar.Bcra.ClavesUniformes.Test
{
    public class CvuValidatorTest
    {
        [Fact]
        public void ValidacionOk()
        {
            var cvu = new Cvu(CvusDePrueba.UnCvuValidoStr);
            Assert.True(cvu.EsValido());
        }

        [Fact]
        public void MasValidacionesOk()
        {
            foreach (var cvuStr in CvusDePrueba.VariosCvusValidos)
            {
                var cvu = new Cvu(cvuStr);
                Assert.True(cvu.EsValido());
            }
        }

        [Fact]
        public void CvuDemasiadoLargoNoValida()
        {
            var validador = new CvuValidator { ValidarDvs = false };
            var cvu = new Cvu(CvusDePruebaInvalidos.UnCvuDemasiadoLargoStr);
            Assert.False(cvu.EsValido(validador));
        }

        [Fact]
        public void CvuDemasiadoCortoNoValida()
        {
            var validador = new CvuValidator { ValidarDvs = false };
            var cvu = new Cvu(CvusDePruebaInvalidos.UnCvuDemasiadoCortoStr);
            Assert.False(cvu.EsValido(validador));
        }

        [Fact]
        public void CvuConLetrasNoValida()
        {
            var validador = new CvuValidator { ValidarDvs = false };
            var cvu = new Cvu(CvusDePruebaInvalidos.UnCvuConLetrasStr);
            Assert.False(cvu.EsValido(validador));
        }

        [Fact]
        public void CvuConDvBloque1IncorrectoNoValida()
        {
            var cvu = new Cvu(CvusDePruebaInvalidos.UnCvuConDvBloque1IncorrectoStr);
            Assert.False(cvu.EsValido());
        }

        [Fact]
        public void CvuConDvBloque2IncorrectoNoValida()
        {
            var cvu = new Cvu(CvusDePruebaInvalidos.UnCvuConDvBloque2IncorrectoStr);
            Assert.False(cvu.EsValido());
        }

        [Fact]
        public void CorreccionDvs()
        {
            var cvu = new Cvu(CvusDePruebaInvalidos.UnCvuConDvsIncorrectosStr);
            var cvuCorregido = cvu.CorregirDvs();
            Assert.Equal(CvusDePrueba.UnCvuValidoStr, cvuCorregido.ToString());
        }

        [Fact]
        public void CvuConIndicacionCvuIncorrectaNoValida()
        {
            var validador = new CvuValidator { ValidarDvs = false };
            var cvu = new Cvu(CvusDePruebaInvalidos.UnCvuConIndicacionCvuIncorrectaStr);
            Assert.False(cvu.EsValido(validador));
        }

        [Fact]
        public void CvuConReservadoUtilizadoNoValida()
        {
            var validador = new CvuValidator { ValidarDvs = false };
            var cvu = new Cvu(CvusDePruebaInvalidos.UnCvuConReservadoUtilizadoStr);
            Assert.False(cvu.EsValido(validador));
        }

        [Fact]
        public void ValidacionDvDesactivable()
        {
            var validador = new CvuValidator { ValidarDvs = false };
            var cvu = new Cvu(CvusDePruebaInvalidos.UnCvuConDvsIncorrectosStr);
            Assert.True(cvu.EsValido(validador));
        }
    }
}
