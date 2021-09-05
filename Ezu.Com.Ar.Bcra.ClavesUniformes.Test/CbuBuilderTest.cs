using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ezu.Com.Ar.Bcra.ClavesUniformes.Test
{
    public class CbuBuilderTest
    {
        [Fact]
        public void CreacionDesdeString()
        {
            var cbu = new Cbu(CbusDePrueba.UnCbuValidoStr);
            Assert.Equal(CbusDePrueba.UnCbuValidoStr, cbu.ToString());
        }

        [Fact]
        public void CreacionDesdeBloques()
        {
            var cbu = new Cbu(CbusDePrueba.UnCbuValidoBloque1Str, CbusDePrueba.UnCbuValidoBloque2Str);
            Assert.Equal(CbusDePrueba.UnCbuValidoStr, cbu.ToString());
        }

        [Fact]
        public void CreacionDesdeComponentes()
        {
            var cbu = new Cbu(CbusDePrueba.UnCbuValidoNroEntidadStr, CbusDePrueba.UnCbuValidoNroSucursalStr, CbusDePrueba.UnCbuValidoNroDvBloque1Str, CbusDePrueba.UnCbuValidoNroCuentaStr, CbusDePrueba.UnCbuValidoNroDvBloque2Str);
            Assert.Equal(CbusDePrueba.UnCbuValidoStr, cbu.ToString());
        }

        [Fact]
        public void CreacionDesdeComponentesCompletandoCeros()
        {
            var cbu = new Cbu("11", "22", "3", "44", "5");
            Assert.Equal("0110022300000000000445", cbu.ToString());
        }

        [Fact]
        public void CreacionDesdeComponentesSinDvs()
        {
            var cbu = new Cbu(CbusDePrueba.UnCbuValidoNroEntidadStr, CbusDePrueba.UnCbuValidoNroSucursalStr, "0", CbusDePrueba.UnCbuValidoNroCuentaStr, "0");
            cbu = cbu.CorregirDvs();
            Assert.Equal(CbusDePrueba.UnCbuValidoStr, cbu.ToString());
        }
    }
}
