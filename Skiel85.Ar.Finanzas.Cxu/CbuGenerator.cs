using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class CbuGenerator
    {
        private readonly CbuBuilder _builder;
        private readonly Random _random;

        public CbuGenerator(int seed)
        {
            _random = new Random(seed);
            _builder = new CbuBuilder();
        }

        public Cbu Next()
        {
            var nroEntidad = _random.Next(1, 999);
            var nroSucursal = _random.Next(1, 9999);
            var nroCuenta = _random.Next(1, 999999999);
            return _builder.CrearCbu((uint)nroEntidad, (uint)nroSucursal, 0, (ulong)nroCuenta, 0).CorregirDvs();
        }
    }
}
