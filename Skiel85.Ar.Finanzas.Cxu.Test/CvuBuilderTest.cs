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
    }
}
