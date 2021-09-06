using System;
using System.Collections.Generic;
using System.Text;

namespace Ezu.Com.Ar.Bcra.ClavesUniformes
{
    /// <summary>
    /// Calcula dígitos verificadores para los dos bloques de CBU o CVU.
    /// </summary>
    public class CalculadoraDvs
    {
        /// <summary>
        /// Obtiene los dígitos verificadores de los dos bloques de CBU o CVU.
        /// </summary>
        /// <param name="cxu">Objeto CXU para el cuál se calcularán sus dígitos verificadores.</param>
        /// <returns>Tupla con los dígitos verificadores correspondientes a cada bloque.</returns>
        public (int, int) CalcularDvs(Cxu cxu)
        {
            return (CalcularDvBloque1(cxu), CalcularDvBloque2(cxu));
        }

        /// <summary>
        /// Obtiene los dígitos verificadores del primer bloque de CBU o CVU.
        /// </summary>
        /// <param name="cxu">Objeto CXU para el cuál se calculará el dígito verificador.</param>
        /// <returns>Dígitos verificadores correspondientes al primer bloque.</returns>
        public int CalcularDvBloque1(Cxu cxu)
        {
            var c1 = Convert.ToInt32(cxu.Bloque1[0].ToString());
            var c2 = Convert.ToInt32(cxu.Bloque1[1].ToString());
            var c3 = Convert.ToInt32(cxu.Bloque1[2].ToString());
            var c4 = Convert.ToInt32(cxu.Bloque1[3].ToString());
            var c5 = Convert.ToInt32(cxu.Bloque1[4].ToString());
            var c6 = Convert.ToInt32(cxu.Bloque1[5].ToString());
            var c7 = Convert.ToInt32(cxu.Bloque1[6].ToString());

            decimal suma = c1 * 7 + c2 * 1 + c3 * 3 + c4 * 9 + c5 * 7 + c6 * 1 + c7 * 3;
            decimal auxSuma = suma / 10;
            auxSuma = Math.Floor(auxSuma) * 10;
            decimal result;

            if (auxSuma < suma) { result = 10 - (suma - auxSuma); }
            else { result = auxSuma - suma; }

            return (int)result;
        }

        /// <summary>
        /// Obtiene los dígitos verificadores del segundo bloque de CBU o CVU.
        /// </summary>
        /// <param name="cxu">Objeto CXU para el cuál se calculará el dígito verificador.</param>
        /// <returns>Dígitos verificadores correspondientes al segundo bloque.</returns>
        public int CalcularDvBloque2(Cxu cxu)
        {
            var c1 = Convert.ToInt32(cxu.Bloque2[0].ToString());
            var c2 = Convert.ToInt32(cxu.Bloque2[1].ToString());
            var c3 = Convert.ToInt32(cxu.Bloque2[2].ToString());
            var c4 = Convert.ToInt32(cxu.Bloque2[3].ToString());
            var c5 = Convert.ToInt32(cxu.Bloque2[4].ToString());
            var c6 = Convert.ToInt32(cxu.Bloque2[5].ToString());
            var c7 = Convert.ToInt32(cxu.Bloque2[6].ToString());
            var c8 = Convert.ToInt32(cxu.Bloque2[7].ToString());
            var c9 = Convert.ToInt32(cxu.Bloque2[8].ToString());
            var c10 = Convert.ToInt32(cxu.Bloque2[9].ToString());
            var c11 = Convert.ToInt32(cxu.Bloque2[10].ToString());
            var c12 = Convert.ToInt32(cxu.Bloque2[11].ToString());
            var c13 = Convert.ToInt32(cxu.Bloque2[12].ToString());

            decimal suma = c1 * 3 + c2 * 9 + c3 * 7 + c4 * 1 + c5 * 3 + c6 * 9 + c7 * 7 + c8 * 1 + c9 * 3 + c10 * 9 + c11 * 7 + c12 * 1 + c13 * 3;
            decimal auxSuma = suma / 10;
            auxSuma = Math.Floor(auxSuma) * 10;
            decimal result;

            if (auxSuma < suma) { result = 10 - (suma - auxSuma); }
            else { result = auxSuma - suma; }

            return (int)result;
        }

        /// <summary>
        /// Verifica la validez de los dígitos verificadores de un CBU o CVU.
        /// </summary>
        /// <param name="cxu">Objeto CXU del cual se evaluarán sus dígitos verificadores.</param>
        /// <returns>True si los dígitos verificadores son válidos.</returns>
        public bool DvsSonValidos(Cxu cxu)
        {
            var (dv1, dv2) = CalcularDvs(cxu);
            return cxu.DvBloque1 == dv1.ToString() && cxu.DvBloque2 == dv2.ToString();
        }

        /// <summary>
        /// Produce un nuevo objeto CBU con los dígitos verificadores corregidos de modo tal de que sea válido.
        /// </summary>
        /// <param name="cbu">Objeto CBU a partir del cual se producirá un nuevo objeto CBU con dígitos verificadores válidos.</param>
        /// <returns>Nuevo objeto CBU con dígitos verificadores válidos.</returns>
        public Cbu CorregirDvs(Cbu cbu)
        {
            var (dv1, dv2) = this.CalcularDvs(cbu);
            return new Cbu(cbu.NroEntidad, cbu.NroSucursal, dv1.ToString(), cbu.NroCuenta, dv2.ToString());
        }

        /// <summary>
        /// Produce un nuevo objeto CVU con los dígitos verificadores corregidos de modo tal de que sea válido.
        /// </summary>
        /// <param name="cvu">Objeto CVU a partir del cual se producirá un nuevo objeto CVU con dígitos verificadores válidos.</param>
        /// <returns>Nuevo objeto CVU con dígitos verificadores válidos.</returns>
        public Cvu CorregirDvs(Cvu cvu)
        {
            var (dv1, dv2) = this.CalcularDvs(cvu);
            return new Cvu(cvu.NroPsp, dv1.ToString(), cvu.IdCliente, dv2.ToString());
        }
    }
}
