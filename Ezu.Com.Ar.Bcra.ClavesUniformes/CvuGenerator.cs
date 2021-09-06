using System;
using System.Collections.Generic;
using System.Text;

namespace Ezu.Com.Ar.Bcra.ClavesUniformes
{
    /// <summary>
    /// Genera CVUs válidos pseudo-aleatorios.
    /// </summary>
    public class CvuGenerator
    {
        private readonly Random _random;

        /// <summary>
        /// Crea un generador de CVUs.
        /// </summary>
        /// <param name="seed">Semilla aleatoria.</param>
        public CvuGenerator(int seed)
        {
            _random = new Random(seed);
        }

        /// <summary>
        /// Obtiene el siguiente objeto CVU pseudo-aleatorio.
        /// </summary>
        /// <returns>Un CVU válido.</returns>
        public Cvu Next()
        {
            var nroPsp = _random.Next(1, 9999).ToString();
            var idCliente = _random.Next(1, 999999999).ToString();
            return new Cvu(nroPsp, "0", idCliente, "0").CorregirDvs();
        }
    }
}
