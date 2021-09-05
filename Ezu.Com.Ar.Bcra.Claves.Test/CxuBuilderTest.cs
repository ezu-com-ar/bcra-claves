using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ezu.Com.Ar.Bcra.Claves.Test
{
    public class CxuBuilderTest
    {
        [Fact]
        public void CreacionDesdeString()
        {
            var builder = new CxuBuilder();
            var cbu = builder.Crear(CbusDePrueba.UnCbuValidoStr);
            var cvu = builder.Crear(CvusDePrueba.UnCvuValidoStr);
            Assert.IsType<Cbu>(cbu);
            Assert.IsType<Cvu>(cvu);
            Assert.Equal(CbusDePrueba.UnCbuValidoStr, cbu.ToString());
            Assert.Equal(CvusDePrueba.UnCvuValidoStr, cvu.ToString());
        }

        [Fact]
        public void CreacionDesdeBloques()
        {
            var builder = new CxuBuilder();
            var cbu = builder.Crear(CbusDePrueba.UnCbuValidoBloque1Str, CbusDePrueba.UnCbuValidoBloque2Str);
            var cvu = builder.Crear(CvusDePrueba.UnCvuValidoBloque1Str, CvusDePrueba.UnCvuValidoBloque2Str);
            Assert.IsType<Cbu>(cbu);
            Assert.IsType<Cvu>(cvu);
            Assert.Equal(CbusDePrueba.UnCbuValidoStr, cbu.ToString());
            Assert.Equal(CvusDePrueba.UnCvuValidoStr, cvu.ToString());
        }
    }
}
