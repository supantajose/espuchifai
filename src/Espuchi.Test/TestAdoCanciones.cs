using Espuchi.Core;

namespace Espuchi.Test;


public class TestAdoCanciones : TestAdo
{
    [Fact]
    public void altaCanciones()
    {
        var bad  = Ado.ObtenerAlbumes().FirstOrDefault(p=>p.Nombre == "bad");
        Assert.NotNull(bad);

        var newCancion = new Canciones()
        {
            Nombre = "Te bote",
            numero= 1,
            Albumes = bad,
            Reproducciones = new List<Reproducciones>()
        };

        Ado.AltaCancion(newCancion);

        Assert.NotEqual(0, newCancion.idcancion);
    }
}

