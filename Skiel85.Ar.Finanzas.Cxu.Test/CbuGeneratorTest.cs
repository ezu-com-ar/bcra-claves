using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Skiel85.Ar.Finanzas.Cxu.Test
{
    public class CbuGeneratorTest
    {
        [Fact]
        public void GeneracionDeCbus()
        {
            const int seed = 123;
            var cbuGenerator = new CbuGenerator(seed);
            var cbu1 = cbuGenerator.Next();
            var cbu2 = cbuGenerator.Next();
            Assert.Equal("9839077100007435455173", cbu1.ToString());
            Assert.Equal("8117387700000483150175", cbu2.ToString());
        }
    }
}
