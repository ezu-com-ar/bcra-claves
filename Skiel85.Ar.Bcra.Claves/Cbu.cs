using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Skiel85.Ar.Bcra.Claves
{
    public class Cbu : Cxu
    {
        public Cbu(string valor) : base(valor)
        {
        }

        public Cbu(string bloque1, string bloque2) : base(bloque1, bloque2)
        {
        }

        public Cbu(string nroEntidad, string nroSucursal, string dvBloque1, string nroCuenta, string dvBloque2)
        : base(
            CerosAIzq(nroEntidad, 3) +
               CerosAIzq(nroSucursal, 4) +
               CerosAIzq(dvBloque1, 1) +
               CerosAIzq(nroCuenta, 13) +
               CerosAIzq(dvBloque2, 1))
        {
        }

        public override string ToString()
        {
            return Valor;
        }

        public string NroEntidad => Valor.Substring(0, 3);
        public string NroSucursal => Valor.Substring(3, 4);
        public string NroCuenta => Valor.Substring(8, 13);

        public bool EsValido()
        {
            return EsValido(CbuValidator.Default);
        }

        public bool EsValido(CbuValidator validador)
        {
            return validador.EsValido(this);
        }

        public Cbu CorregirDvs()
        {
            var calculadora = new CalculadoraDvs();
            return calculadora.CorregirDvs(this);
        }
    }
}
