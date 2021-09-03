using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class CalculadoraDvs
    {
        public (int, int) CalcularDvs(Cbu cbu)
        {
            return (CalcularDvBloque1(cbu), CalcularDvBloque2(cbu));
        }

        public int CalcularDvBloque1(Cbu cbu)
        {
            var b1 = Convert.ToInt32(cbu.NroEntidad[0].ToString());
            var b2 = Convert.ToInt32(cbu.NroEntidad[1].ToString());
            var b3 = Convert.ToInt32(cbu.NroEntidad[2].ToString());
            var s1 = Convert.ToInt32(cbu.NroSucursal[0].ToString());
            var s2 = Convert.ToInt32(cbu.NroSucursal[1].ToString());
            var s3 = Convert.ToInt32(cbu.NroSucursal[2].ToString());
            var s4 = Convert.ToInt32(cbu.NroSucursal[3].ToString());

            decimal suma = b1 * 7 + b2 * 1 + b3 * 3 + s1 * 9 + s2 * 7 + s3 * 1 + s4 * 3;
            decimal auxSuma = suma / 10;
            auxSuma = Math.Floor(auxSuma) * 10;
            decimal result;

            if (auxSuma < suma) { result = 10 - (suma - auxSuma); }
            else { result = auxSuma - suma; }

            return (int)result;
        }

        public int CalcularDvBloque2(Cbu cbu)
        {
            var c1 = Convert.ToInt32(cbu.NroCuenta[0].ToString());
            var c2 = Convert.ToInt32(cbu.NroCuenta[1].ToString());
            var c3 = Convert.ToInt32(cbu.NroCuenta[2].ToString());
            var c4 = Convert.ToInt32(cbu.NroCuenta[3].ToString());
            var c5 = Convert.ToInt32(cbu.NroCuenta[4].ToString());
            var c6 = Convert.ToInt32(cbu.NroCuenta[5].ToString());
            var c7 = Convert.ToInt32(cbu.NroCuenta[6].ToString());
            var c8 = Convert.ToInt32(cbu.NroCuenta[7].ToString());
            var c9 = Convert.ToInt32(cbu.NroCuenta[8].ToString());
            var c10 = Convert.ToInt32(cbu.NroCuenta[9].ToString());
            var c11 = Convert.ToInt32(cbu.NroCuenta[10].ToString());
            var c12 = Convert.ToInt32(cbu.NroCuenta[11].ToString());
            var c13 = Convert.ToInt32(cbu.NroCuenta[12].ToString());

            decimal suma = c1 * 3 + c2 * 9 + c3 * 7 + c4 * 1 + c5 * 3 + c6 * 9 + c7 * 7 + c8 * 1 + c9 * 3 + c10 * 9 + c11 * 7 + c12 * 1 + c13 * 3;
            decimal auxSuma = suma / 10;
            auxSuma = Math.Floor(auxSuma) * 10;
            decimal result;

            if (auxSuma < suma) { result = 10 - (suma - auxSuma); }
            else { result = auxSuma - suma; }

            return (int)result;
        }

        public bool DvsSonValidos(Cbu cbu)
        {
            var (dv1, dv2) = CalcularDvs(cbu);
            return cbu.DvBloque1 == dv1.ToString() && cbu.DvBloque2 == dv2.ToString();
        }

        public Cbu CorregirDvs(Cbu cbu)
        {
            var (dv1, dv2) = this.CalcularDvs(cbu);
            return new Cbu(cbu.NroEntidad, cbu.NroSucursal, dv1.ToString(), cbu.NroCuenta, dv2.ToString());
        }
    }
}
