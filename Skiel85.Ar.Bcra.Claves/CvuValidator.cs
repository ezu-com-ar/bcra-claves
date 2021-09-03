using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Bcra.Claves
{
    public class CvuValidator : CxuValidator
    {
        public static CvuValidator Default { get; } = new CvuValidator();

        private bool IndicacionCvuValida(Cvu cvu)
        {
            return cvu.IndicacionCvu == "000";
        }

        private bool ReservadoValido(Cvu cvu)
        {
            return cvu.Reservado == "0";
        }

        public override bool EsValido(ICxu cxu)
        {
            var cvu = (Cvu) cxu;
            return IndicacionCvuValida(cvu) && ReservadoValido(cvu) && base.EsValido(cxu);
        }
    }
}
