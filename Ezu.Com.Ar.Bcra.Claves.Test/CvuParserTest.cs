using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ezu.Com.Ar.Bcra.Claves.Test
{
    public class CvuParserTest
    {
        [Fact]
        public void ParseCvuEnBloques()
        {
            var cvu = new Cvu(CvusDePrueba.UnCvuValidoStr);
            Assert.Equal(CvusDePrueba.UnCvuValidoBloque1Str, cvu.Bloque1);
            Assert.Equal(CvusDePrueba.UnCvuValidoBloque2Str, cvu.Bloque2);
        }

        [Fact]
        public void ParseCvuEnComponentes()
        {
            var cvu = new Cvu(CvusDePrueba.UnCvuValidoStr);
            Assert.Equal("000", cvu.IndicacionCvu);
            Assert.Equal(CvusDePrueba.UnCvuValidoPspStr, cvu.NroPsp);
            Assert.Equal(CvusDePrueba.UnCvuValidoNroDvBloque1Str, cvu.DvBloque1);
            Assert.Equal("0", cvu.Reservado);
            Assert.Equal(CvusDePrueba.UnCvuValidoIdClienteStr, cvu.IdCliente);
            Assert.Equal(CvusDePrueba.UnCvuValidoNroDvBloque2Str, cvu.DvBloque2);
        }
    }
}
