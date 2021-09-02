using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Skiel85.Ar.Finanzas.Cxu.Test
{
    public class CbuParserTest
    {
        private const string UnCbuValidoStr = "0110012920000091344977";
        private const string UnCbuValidoBloque1Str = "01100129";
        private const string UnCbuValidoBloque2Str = "20000091344977";
        private const string UnCbuValidoNroEntidadStr = "011";
        private const string UnCbuValidoNroSucursalStr = "0012";
        private const string UnCbuValidoNroDvBloque1Str = "9";
        private const string UnCbuValidoNroCuentaStr = "2000009134497";
        private const string UnCbuValidoNroDvBloque2Str = "7";

        [Fact]
        public void ParseCbuEnBloques()
        {
            var parser = new CbuParser();
            var cbu = parser.ParseCbuEnBloques(UnCbuValidoStr);
            Assert.Equal(UnCbuValidoBloque1Str, cbu.Bloque1);
            Assert.Equal(UnCbuValidoBloque2Str, cbu.Bloque2);
        }

        [Fact]
        public void ParseCbuEnComponentes()
        {
            var parser = new CbuParser();
            var cbu = parser.ParseCbuEnComponentes(UnCbuValidoStr);
            Assert.Equal(UnCbuValidoNroEntidadStr, cbu.NroEntidad);
            Assert.Equal(UnCbuValidoNroSucursalStr, cbu.NroSucursal);
            Assert.Equal(UnCbuValidoNroDvBloque1Str, cbu.DvBloque1);
            Assert.Equal(UnCbuValidoNroCuentaStr, cbu.NroCuenta);
            Assert.Equal(UnCbuValidoNroDvBloque2Str, cbu.DvBloque2);
        }
    }
}
