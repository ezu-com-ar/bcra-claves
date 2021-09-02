using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Skiel85.Ar.Finanzas.Cxu.Test
{
    public class CbuBuilderTest
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
            var cbuBuilder = new CbuBuilder();
            var cbu = cbuBuilder.CrearCbu(UnCbuValidoStr);
            Assert.Equal(UnCbuValidoStr, cbu.ToString());
        }

        [Fact]
        public void CreacionDesdeBloques()
        {
            var cbuBuilder = new CbuBuilder();
            var cbu = cbuBuilder.CrearCbu(UnCbuValidoBloque1Str, UnCbuValidoBloque2Str);
            Assert.Equal(UnCbuValidoStr, cbu.ToString());
        }

        [Fact]
        public void CreacionDesdeComponentes()
        {
            var cbuBuilder = new CbuBuilder();
            var cbu = cbuBuilder.CrearCbu(UnCbuValidoNroEntidadStr, UnCbuValidoNroSucursalStr, UnCbuValidoNroDvBloque1Str, UnCbuValidoNroCuentaStr, UnCbuValidoNroDvBloque2Str);
            Assert.Equal(UnCbuValidoStr, cbu.ToString());
        }

        [Fact]
        public void CreacionDesdeComponentesCompletandoCeros()
        {
            var cbuBuilder = new CbuBuilder();
            var cbu = cbuBuilder.CrearCbu("11", "22", "3", "44", "5");
            Assert.Equal("0110022300000000000445", cbu.ToString());
        }

        [Fact]
        public void CreacionDesdeComponentesNumericos()
        {
            var cbuBuilder = new CbuBuilder();
            var cbu = cbuBuilder.CrearCbu(11, 22, 3, 44, 5);
            Assert.Equal("0110022300000000000445", cbu.ToString());
        }
    }
}
