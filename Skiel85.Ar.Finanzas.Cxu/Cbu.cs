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
            _valor = CxuUtils.CerosAIzq(bloque1, 8) + CxuUtils.CerosAIzq(bloque2, 14);
        }

        public Cbu(string nroEntidad, string nroSucursal, string dvBloque1, string nroCuenta, string dvBloque2)
        {
            _valor = CxuUtils.CerosAIzq(nroEntidad, 3) + CxuUtils.CerosAIzq(nroSucursal, 4) + CxuUtils.CerosAIzq(dvBloque1, 1) + CxuUtils.CerosAIzq(nroCuenta, 13) + CxuUtils.CerosAIzq(dvBloque2, 1);
        }

        public Cbu(string nroEntidad, string nroSucursal, string nroCuenta)
        {
            _valor = new Cbu(nroEntidad, nroSucursal, "0", nroCuenta, "0").CorregirDvs().ToString();
        }

        public override string ToString()
        {
            return _valor;
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
