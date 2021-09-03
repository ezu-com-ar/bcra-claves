using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class Cvu : ICxu
    {
        private readonly string _valor;

        public Cvu(string valor)
        {
            _valor = valor;
        }

        public Cvu(string bloque1, string bloque2)
        {
            _valor =
                CxuUtils.CerosAIzq(bloque1, 8) +
                CxuUtils.CerosAIzq(bloque2, 14);
        }

        public Cvu(string nroPsp, string dvBloque1, string idCliente, string dvBloque2)
        {
            _valor =
                "000" +
                CxuUtils.CerosAIzq(nroPsp, 4) +
                CxuUtils.CerosAIzq(dvBloque1, 1) +
                "0" +
                CxuUtils.CerosAIzq(idCliente, 12) +
                CxuUtils.CerosAIzq(dvBloque2, 1);
        }

        public override string ToString()
        {
            return _valor;
        }

        public string Bloque1 => _valor.Substring(0, 8);
        public string Bloque2 => _valor.Substring(8, 14);
        public string IndicacionCvu => _valor.Substring(0, 3);
        public string NroPsp => _valor.Substring(3, 4);
        public string DvBloque1 => _valor.Substring(7, 1);
        public string Reservado => _valor.Substring(8, 1);
        public string IdCliente => _valor.Substring(9, 12);
        public string DvBloque2 => _valor.Substring(21, 1);

        public bool EsValido()
        {
            var validador = new CvuValidator();
            return validador.EsValido(this);
        }

        public Cvu CorregirDvs()
        {
            var calculadora = new CalculadoraDvs();
            return calculadora.CorregirDvs(this);
        }
    }
}
