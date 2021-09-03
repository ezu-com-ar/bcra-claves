namespace Skiel85.Ar.Bcra.Claves.Test
{
    public static class CbusDePruebaInvalidos
    {
        public const string UnCbuDemasiadoLargoStr = "0110012920000091344977777";
        public const string UnCbuDemasiadoCortoStr = "0110012920000091";
        public const string UnCbuConLetrasStr = "011ABCD920000091344977";
        public const string UnCbuConDvBloque1IncorrectoStr = "0110012020000091344977";
        public const string UnCbuConDvBloque2IncorrectoStr = "0110012920000091344970";
        public const string UnCbuConDvsIncorrectosStr = "0110012020000091344970";
    }
}