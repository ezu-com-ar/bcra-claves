using System;
using System.Collections.Generic;
using System.Text;

namespace Ezu.Com.Ar.Bcra.ClavesUniformes
{
    /// <summary>
    /// Valida un objeto CVU.
    /// </summary>
    public class CvuValidator : CxuValidator
    {
        /// <summary>
        /// Validador predeterminado. Realiza validación de largo, numérico, dígitos verificadores y campos fijos.
        /// </summary>
        public static CvuValidator Default { get; } = new CvuValidator();

        private bool IndicacionCvuValida(Cvu cvu)
        {
            return cvu.IndicacionCvu == "000";
        }

        private bool ReservadoValido(Cvu cvu)
        {
            return cvu.Reservado == "0";
        }

        /// <summary>
        /// Realiza la validación.
        /// </summary>
        /// <param name="cxu">Objeto a validar.</param>
        /// <returns>True si es válido.</returns>
        public override bool EsValido(Cxu cxu)
        {
            var cvu = (Cvu) cxu;
            return IndicacionCvuValida(cvu) && ReservadoValido(cvu) && base.EsValido(cxu);
        }
    }
}
