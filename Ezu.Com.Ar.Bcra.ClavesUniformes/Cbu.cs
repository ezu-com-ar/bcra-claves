using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Ezu.Com.Ar.Bcra.ClavesUniformes
{
    /// <summary>
    /// Representa una Clave Bancaria Uniforme (CBU). Los objetos de esta clase son inmutables.
    /// </summary>
    public class Cbu : Cxu
    {
        /// <summary>
        /// Construye una Clave Bancaria Uniforme (CBU) a partir de su número.
        /// </summary>
        /// <param name="numero">Número de CBU</param>
        public Cbu(string numero) : base(numero)
        {
        }

        /// <summary>
        /// Construye una Clave Bancaria Uniforme (CBU) a partir de sus bloques.
        /// </summary>
        /// <param name="bloque1">Primer bloque de CBU de 8 dígitos.</param>
        /// <param name="bloque2">Segundo bloque de CBU de 14 dígitos.</param>
        public Cbu(string bloque1, string bloque2) : base(bloque1, bloque2)
        {
        }

        /// <summary>
        /// Construye una Clave Bancaria Uniforme (CBU) a partir de sus componentes.
        /// </summary>
        /// <param name="nroEntidad">Número de entidad. Máximo 3 dígitos.</param>
        /// <param name="nroSucursal">Número de sucursal. Máximo 4 dígitos.</param>
        /// <param name="dvBloque1">Dígito verificador del primer bloque.</param>
        /// <param name="nroCuenta">Número de cuenta. Máximo 13 dígitos.</param>
        /// <param name="dvBloque2">Dígito verificador del segundo bloque.</param>
        public Cbu(string nroEntidad, string nroSucursal, string dvBloque1, string nroCuenta, string dvBloque2)
        : base(
            CerosAIzq(nroEntidad, 3) +
               CerosAIzq(nroSucursal, 4) +
               CerosAIzq(dvBloque1, 1) +
               CerosAIzq(nroCuenta, 13) +
               CerosAIzq(dvBloque2, 1))
        {
        }

        /// <summary>
        /// Produce una representación de la Clave Bancaria Uniforme (CBU).
        /// </summary>
        /// <returns>Número de CBU como string.</returns>
        public override string ToString()
        {
            return Numero;
        }

        /// <summary>
        /// Número de entidad.
        /// </summary>
        public string NroEntidad => Numero.Substring(0, 3);

        /// <summary>
        /// Número de sucursal.
        /// </summary>
        public string NroSucursal => Numero.Substring(3, 4);

        /// <summary>
        /// Número de cuenta.
        /// </summary>
        public string NroCuenta => Numero.Substring(8, 13);

        /// <summary>
        /// Determina si el objeto CBU es válido.
        /// </summary>
        /// <returns>True si es válido.</returns>
        public bool EsValido()
        {
            return EsValido(CbuValidator.Default);
        }

        /// <summary>
        /// Determina si el objeto CBU es válido, permitiendo personalizar que validaciones se realizarán.
        /// </summary>
        /// <param name="validador">Validador personalizado.</param>
        /// <returns>True si es válido.</returns>
        public bool EsValido(CbuValidator validador)
        {
            return validador.EsValido(this);
        }

        /// <summary>
        /// Produce un nuevo objeto CBU con los dígitos verificadores corregidos de modo tal de que sea válido.
        /// </summary>
        /// <returns>Nuevo objeto CBU con dígitos verificadores válidos.</returns>
        public Cbu CorregirDvs()
        {
            var calculadora = new CalculadoraDvs();
            return calculadora.CorregirDvs(this);
        }

        /// <summary>
        /// Obtiene el nombre de la entidad bancaria correspondiente al CBU.
        /// </summary>
        /// <returns>El nombre de la entidad bancaria correspondiente al CBU.</returns>
        public string GetNombreEntidad()
        {
            return GetNombreEntidad(CbuEntidades.Default);
        }

        /// <summary>
        /// Obtiene el nombre de la entidad bancaria correspondiente al CBU.
        /// </summary>
        /// <param name="entidades">Diccionario de entidades.</param>
        /// <returns>El nombre de la entidad bancaria correspondiente al CBU.</returns>
        public string GetNombreEntidad(CbuEntidades entidades)
        {
            return entidades.GetNombreEntidad(this);
        }
    }
}
