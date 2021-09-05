using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ezu.Com.Ar.Bcra.Claves.Test
{
    public class CvuGeneratorTest
    {
        [Fact]
        public void GeneracionDeCvus()
        {
            const int seed = 123;
            var cvuGenerator = new CvuGenerator(seed);
            var cvu1 = cvuGenerator.Next();
            var cvu2 = cvuGenerator.Next();
            Assert.Equal("0009844700009078153229", cvu1.ToString());
            Assert.Equal("0007434400008116416520", cvu2.ToString());
        }
    }
}
