using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Bcra.Claves
{
    public class CvuGenerator
    {
        private readonly Random _random;

        public CvuGenerator(int seed)
        {
            _random = new Random(seed);
        }

        public Cvu Next()
        {
            var nroPsp = _random.Next(1, 9999).ToString();
            var idCliente = _random.Next(1, 999999999).ToString();
            return new Cvu(nroPsp, "0", idCliente, "0").CorregirDvs();
        }
    }
}
