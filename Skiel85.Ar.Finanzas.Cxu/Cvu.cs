using System;
using System.Collections.Generic;
using System.Text;

namespace Skiel85.Ar.Finanzas.Cxu
{
    public class Cvu
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
    }
}
