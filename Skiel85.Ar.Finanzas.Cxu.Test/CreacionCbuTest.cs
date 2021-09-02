using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Skiel85.Ar.Finanzas.Cxu.Test
{
    public class CreacionCbuTest
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
        public void CreacionDesdeString()
        {
            var cbu = new Cbu(UnCbuValidoStr);
            Assert.Equal(UnCbuValidoStr, cbu.ToString());
        }

        [Fact]
        public void CreacionDesdeBloques()
        {
            var cbu = new Cbu(UnCbuValidoBloque1Str, UnCbuValidoBloque2Str);
            Assert.Equal(UnCbuValidoStr, cbu.ToString());
        }

        [Fact]
        public void CreacionDesdeComponentes()
        {
            var cbu = new Cbu(UnCbuValidoNroEntidadStr, UnCbuValidoNroSucursalStr, UnCbuValidoNroDvBloque1Str, UnCbuValidoNroCuentaStr, UnCbuValidoNroDvBloque2Str);
            Assert.Equal(UnCbuValidoStr, cbu.ToString());
        }

        [Fact]
        public void CreacionDesdeComponentesCompletandoCeros()
        {
            var cbu = new Cbu("11", "22", "3", "44", "5");
            Assert.Equal("0110022300000000000445", cbu.ToString());
        }

        [Fact]
        public void CreacionDesdeComponentesNumericos()
        {
            var cbu = new Cbu(11, 22, 3, 44, 5);
            Assert.Equal("0110022300000000000445", cbu.ToString());
        }
    }
}
