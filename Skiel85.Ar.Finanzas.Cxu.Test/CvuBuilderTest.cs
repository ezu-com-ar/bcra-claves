using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Skiel85.Ar.Finanzas.Cxu.Test
{
    public class CvuBuilderTest
    {
        [Fact]
        public void CreacionDesdeString()
        {
            var cvu = new Cvu(CvusDePrueba.UnCvuValidoStr);
            Assert.Equal(CvusDePrueba.UnCvuValidoStr, cvu.ToString());
        }

        [Fact]
        public void CreacionDesdeBloques()
        {
            var cbu = new Cvu(CvusDePrueba.UnCvuValidoBloque1Str, CvusDePrueba.UnCvuValidoBloque2Str);
            Assert.Equal(CvusDePrueba.UnCvuValidoStr, cbu.ToString());
        }

        [Fact]
        public void CreacionDesdeComponentes()
        {
            var cvu = new Cvu(CvusDePrueba.UnCvuValidoPspStr, CvusDePrueba.UnCvuValidoNroDvBloque1Str, CvusDePrueba.UnCvuValidoIdClienteStr, CvusDePrueba.UnCvuValidoNroDvBloque2Str);
            Assert.Equal(CvusDePrueba.UnCvuValidoStr, cvu.ToString());
        }
    }
}
