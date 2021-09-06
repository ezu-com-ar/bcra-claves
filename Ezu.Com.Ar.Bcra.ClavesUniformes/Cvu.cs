using System;
using System.Collections.Generic;
using System.Text;

namespace Ezu.Com.Ar.Bcra.ClavesUniformes
{
    /// <summary>
    /// Representa una Clave Virtual Uniforme (CVU). Los objetos de esta clase son inmutables.
    /// </summary>
    public class Cvu : Cxu
    {
        /// <summary>
        /// Construye una Clave Bancaria Uniforme (CVU) a partir de su número.
        /// </summary>
        /// <param name="numero">Número de CVU</param>
        public Cvu(string numero) : base(numero)
        {
        }

        /// <summary>
        /// Construye una Clave Virtual Uniforme (CVU) a partir de su número.
        /// </summary>
        /// <param name="bloque1">Primer bloque de CVU de 8 dígitos.</param>
        /// <param name="bloque2">Segundo bloque de CVU de 14 dígitos.</param>
        public Cvu(string bloque1, string bloque2) : base(bloque1, bloque2)
        {
        }

        /// <summary>
        /// Construye una Clave Virtual Uniforme (CVU) a partir de sus componentes.
        /// </summary>
        /// <param name="nroPsp">Número de proveedor de servicios de pago. Máximo 4 dígitos.</param>
        /// <param name="dvBloque1">Dígito verificador del primer bloque.</param>
        /// <param name="idCliente">Identificador del cliente del PSP. Máximo 12 dígitos.</param>
        /// <param name="dvBloque2">Dígito verificador del segundo bloque.</param>
        public Cvu(string nroPsp, string dvBloque1, string idCliente, string dvBloque2)
        : base(
            "000" +
            CerosAIzq(nroPsp, 4) +
            CerosAIzq(dvBloque1, 1) +
            "0" +
            CerosAIzq(idCliente, 12) +
            CerosAIzq(dvBloque2, 1))
        {
        }

        /// <summary>
        /// Produce una representación de la Clave Virtual Uniforme (CVU).
        /// </summary>
        /// <returns>Número de CBU como string.</returns>
        public override string ToString()
        {
            return Numero;
        }

        /// <summary>
        /// Código que indica que es un CVU. En las CVU válidas este código es "000".
        /// </summary>
        public string IndicacionCvu => Numero.Substring(0, 3);

        /// <summary>
        /// Número de proveedor de servicios de pago.
        /// </summary>
        public string NroPsp => Numero.Substring(3, 4);

        /// <summary>
        /// Campo reservado. En las CVU válidas este campo vale "0".
        /// </summary>
        public string Reservado => Numero.Substring(8, 1);

        /// <summary>
        /// Identificador del cliente del PSP.
        /// </summary>
        public string IdCliente => Numero.Substring(9, 12);

        /// <summary>
        /// Determina si el objeto CVU es válido.
        /// </summary>
        /// <returns>True si es válido.</returns>
        public bool EsValido()
        {
            return EsValido(CvuValidator.Default);
        }

        /// <summary>
        /// Determina si el objeto CVU es válido, permitiendo personalizar que validaciones se realizarán.
        /// </summary>
        /// <param name="validador">Validador personalizado.</param>
        /// <returns>True si es válido.</returns>
        public bool EsValido(CvuValidator validador)
        {
            return validador.EsValido(this);
        }

        /// <summary>
        /// Produce un nuevo objeto CVU con los dígitos verificadores corregidos de modo tal de que sea válido.
        /// </summary>
        /// <returns>Nuevo objeto CVU con dígitos verificadores válidos.</returns>
        public Cvu CorregirDvs()
        {
            var calculadora = new CalculadoraDvs();
            return calculadora.CorregirDvs(this);
        }
    }
}
