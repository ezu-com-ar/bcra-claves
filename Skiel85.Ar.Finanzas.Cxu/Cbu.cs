using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class Cbu
    {
        private readonly string _valor;

        public Cbu(string valor)
        {
            _valor = valor;
        }

        public Cbu(string bloque1, string bloque2)
        {
            _valor = 
                CerosAIzq(bloque1, 8) + 
                CerosAIzq(bloque2, 14);
        }

        public Cbu(string nroEntidad, string nroSucursal, string dvBloque1, string nroCuenta, string dvBloque2)
        {
            _valor =
                CerosAIzq(nroEntidad, 3) +
                CerosAIzq(nroSucursal, 4) +
                CerosAIzq(dvBloque1, 1) +
                CerosAIzq(nroCuenta, 13) +
                CerosAIzq(dvBloque2, 1);
        }

        public Cbu(string nroEntidad, string nroSucursal, string nroCuenta)
        {
            _valor = new Cbu(nroEntidad, nroSucursal, "0", nroCuenta, "0").CorregirDvs().ToString();
        }

        public override string ToString()
        {
            return _valor;
        }

        private static string CerosAIzq(string str, int totalWidth)
        {
            return str.PadLeft(totalWidth, '0');
        }

        public string Bloque1 => _valor.Substring(0, 8);
        public string Bloque2 => _valor.Substring(8, 14);
        public string NroEntidad => _valor.Substring(0, 3);
        public string NroSucursal => _valor.Substring(3, 4);
        public string DvBloque1 => _valor.Substring(7, 1);
        public string NroCuenta => _valor.Substring(8, 13);
        public string DvBloque2 => _valor.Substring(21, 1);

        public bool EsValido()
        {
            var validador = new CbuValidator();
            return validador.EsValido(this);
        }

        public Cbu CorregirDvs()
        {
            var calculadora = new CalculadoraDvs();
            return calculadora.CorregirDvs(this);
        }
    }
}
