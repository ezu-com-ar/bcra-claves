using System;
using System.Collections.Generic;
using System.Text;

namespace Ezu.Com.Ar.Bcra.ClavesUniformes
{
    /// <summary>
    /// Genera CBUs válidos pseudo-aleatorios.
    /// </summary>
    public class CbuGenerator
    {
        private readonly Random _random;

        /// <summary>
        /// Crea un generador de CBUs.
        /// </summary>
        /// <param name="seed">Semilla aleatoria.</param>
        public CbuGenerator(int seed)
        {
            _random = new Random(seed);
        }

        /// <summary>
        /// Obtiene el siguiente objeto CBU pseudo-aleatorio.
        /// </summary>
        /// <returns>Un CBU válido.</returns>
        public Cbu Next()
        {
            var nroEntidad = _random.Next(1, 999).ToString();
            var nroSucursal = _random.Next(1, 9999).ToString();
            var nroCuenta = _random.Next(1, 999999999).ToString();
            return new Cbu(nroEntidad, nroSucursal, "0", nroCuenta, "0").CorregirDvs();
        }
    }
}
