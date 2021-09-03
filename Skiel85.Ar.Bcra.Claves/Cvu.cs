using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Bcra.Claves
{
    public class Cvu : Cxu
    {
        public Cvu(string valor) : base(valor)
        {
        }

        public Cvu(string bloque1, string bloque2) : base(bloque1, bloque2)
        {
        }

        public Cvu(string nroPsp, string dvBloque1, string idCliente, string dvBloque2)
        : base(
            "000" +
            CerosAIzq(nroPsp, 4) +
            CerosAIzq(dvBloque1, 1) +
            "0" +
            CerosAIzq(idCliente, 12) +
            CerosAIzq(dvBloque2, 1))
        {
        }

        public override string ToString()
        {
            return Valor;
        }

        public string IndicacionCvu => Valor.Substring(0, 3);
        public string NroPsp => Valor.Substring(3, 4);
        public string Reservado => Valor.Substring(8, 1);
        public string IdCliente => Valor.Substring(9, 12);

        public bool EsValido()
        {
            return EsValido(CvuValidator.Default);
        }

        public bool EsValido(CvuValidator validador)
        {
            return validador.EsValido(this);
        }

        public Cvu CorregirDvs()
        {
            var calculadora = new CalculadoraDvs();
            return calculadora.CorregirDvs(this);
        }


    }
}
