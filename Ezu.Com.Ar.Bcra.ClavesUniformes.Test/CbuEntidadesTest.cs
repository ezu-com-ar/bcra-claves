using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Ezu.Com.Ar.Bcra.ClavesUniformes.Test
{
    public class CbuEntidadesTest
    {
        [Fact]
        public void ObtenerNombreEntidadDesdeCbu()
        {
            var cbu = new Cbu(CbusDePrueba.UnCbuValidoStr);
            Assert.Equal("Banco de la Nación Argentina", cbu.GetNombreEntidad());
        }

        [Fact]
        public void ObtenerNombreEntidadDesdeCbus()
        {
            var cbus = CbusDePrueba.VariosCbusValidos.Select(x => new Cbu(x));
            var nombresEntidades = cbus.Select(x => x.GetNombreEntidad());
            Assert.Equal(new[]
            {
                "Banco de la Nación Argentina",
                "Banco de Galicia y Buenos Aires S.A.",
                "Banco de la Nación Argentina",
                "Banco de Galicia y Buenos Aires S.A.",
                "Banco de la Provincia de Buenos Aires",
            }, nombresEntidades.ToArray());
        }

        [Fact]
        public void ObtenerNombreEntidadInexistente()
        {
            var cbu = new Cbu("9999999999999999999999");
            Assert.Null(cbu.GetNombreEntidad());
        }

        [Fact]
        public void ObtenerNombrePorDefectoParaEntidadInexistente()
        {
            var cbu1 = new Cbu("0119999999999999999999");
            var cbu2 = new Cbu("9999999999999999999999");
            var entidades = new CbuEntidades();
            entidades.NombrePorDefecto = "Nombre de entidad no disponible.";
            Assert.Equal("Banco de la Nación Argentina", cbu1.GetNombreEntidad(entidades));
            Assert.Equal("Nombre de entidad no disponible.", cbu2.GetNombreEntidad(entidades));
        }

        [Fact]
        public void ObtenerNombreEntidadAgregado()
        {
            var cbu = new Cbu("9999999999999999999999");
            var entidades = new CbuEntidades();
            entidades.Agregar("999", "Banco Nuevo S.A.");
            Assert.Equal("Banco Nuevo S.A.", cbu.GetNombreEntidad(entidades));
        }

        [Fact]
        public void ObtenerNombreEntidadEliminado()
        {
            var cbu = new Cbu(CbusDePrueba.UnCbuValidoStr);
            var entidades = new CbuEntidades();
            entidades.Eliminar("011");
            Assert.Null(cbu.GetNombreEntidad(entidades));
        }

        [Fact]
        public void ObtenerNombreEntidadConDiccionarioPersonalizado()
        {
            var entidades = new CbuEntidades(new Dictionary<string, string>
            {
                ["011"] = "Banco Alfa",
                ["007"] = "Banco Beta",
                ["014"] = "Banco Gamma",
            });
            var cbus = CbusDePrueba.VariosCbusValidos.Select(x => new Cbu(x));
            var nombresEntidades = cbus.Select(x => x.GetNombreEntidad(entidades));
            Assert.Equal(new[]
            {
                "Banco Alfa",
                "Banco Beta",  
                "Banco Alfa",
                "Banco Beta",
                "Banco Gamma",
            }, nombresEntidades.ToArray());
        }
    }
}
