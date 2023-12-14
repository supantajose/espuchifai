using Espuchi.Core;

namespace Espuchi.Test;


public class TestAdoCanciones : TestAdo
{
    [Fact]
    public void altaCanciones()
    {
        Ado.ObtenerAlbumes();
        var Drako= Ado.ObtenerAlbumes().FirstOrDefault(a=>a.Nombre == "Drako");
        Assert.NotNull(Drako);

        var newCancion = new Canciones()
        {
            Nombre = "The Truth Untold",
            numero= 1,
            Albumes = Drako,
            Reproduccion=1,
            Reproducciones = new List<Reproducciones>()
        };

        Ado.AltaCancion(newCancion);

        Assert.NotEqual(0, newCancion.idcancion);
    }
}

