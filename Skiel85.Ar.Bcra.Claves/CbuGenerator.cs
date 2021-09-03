using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Bcra.Claves
{
    public class CbuGenerator
    {
        private readonly Random _random;

        public CbuGenerator(int seed)
        {
            _random = new Random(seed);
        }

        public Cbu Next()
        {
            var nroEntidad = _random.Next(1, 999).ToString();
            var nroSucursal = _random.Next(1, 9999).ToString();
            var nroCuenta = _random.Next(1, 999999999).ToString();
            return new Cbu(nroEntidad, nroSucursal, "0", nroCuenta, "0").CorregirDvs();
        }
    }
}
