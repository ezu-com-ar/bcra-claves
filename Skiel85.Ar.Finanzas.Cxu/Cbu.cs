﻿using System;
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

        public override string ToString()
        {
            return _valor;
        }

        public bool EsValido()
        {
            return _valor.Length == 22 && Regex.IsMatch(_valor, @"^\d+$") && DvEsValido();
        }

        private bool DvEsValido()
        {
            var calculadora = new CalculadoraDv();
            return calculadora.DvEsValido(this);
        }

        public Cbu CorregirDvs()
        {
            var calculadora = new CalculadoraDv();
            return calculadora.CorregirDvs(this);
        }
    }
}
