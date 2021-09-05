using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ezu.Com.Ar.Bcra.Claves.Test
{
    public class CbuParserTest
    {
        [Fact]
        public void ParseCbuEnBloques()
        {
            var cbu = new Cbu(CbusDePrueba.UnCbuValidoStr);
            Assert.Equal(CbusDePrueba.UnCbuValidoBloque1Str, cbu.Bloque1);
            Assert.Equal(CbusDePrueba.UnCbuValidoBloque2Str, cbu.Bloque2);
        }

        [Fact]
        public void ParseCbuEnComponentes()
        {
            var cbu = new Cbu(CbusDePrueba.UnCbuValidoStr);
            Assert.Equal(CbusDePrueba.UnCbuValidoNroEntidadStr, cbu.NroEntidad);
            Assert.Equal(CbusDePrueba.UnCbuValidoNroSucursalStr, cbu.NroSucursal);
            Assert.Equal(CbusDePrueba.UnCbuValidoNroDvBloque1Str, cbu.DvBloque1);
            Assert.Equal(CbusDePrueba.UnCbuValidoNroCuentaStr, cbu.NroCuenta);
            Assert.Equal(CbusDePrueba.UnCbuValidoNroDvBloque2Str, cbu.DvBloque2);
        }
    }
}
