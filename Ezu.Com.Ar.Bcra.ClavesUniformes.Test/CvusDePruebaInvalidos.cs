namespace Ezu.Com.Ar.Bcra.ClavesUniformes.Test
{
    public static class CvusDePruebaInvalidos
    {
        public const string UnCvuDemasiadoLargoStr = "0000003100062244154712222";
        public const string UnCvuDemasiadoCortoStr = "0000003100062244";
        public const string UnCvuConLetrasStr = "000000310006ABCD154712";
        public const string UnCvuConDvBloque1IncorrectoStr = "0000003000062244154712";
        public const string UnCvuConDvBloque2IncorrectoStr = "0000003100062244154710";
        public const string UnCvuConDvsIncorrectosStr = "0000003000062244154710";
        public const string UnCvuConIndicacionCvuIncorrectaStr = "1110003100062244154712";
        public const string UnCvuConReservadoUtilizadoStr = "0000003180062244154712";

    }
}