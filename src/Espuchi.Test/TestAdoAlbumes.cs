using Espuchi.Core;

namespace Espuchi.Test;

public class TestAdoAlbumes : TestAdo
{

    [Fact]
    public void AltaAlbumes()
    {
        var Drako = Ado.ObtenerBandas().FirstOrDefault(p=>p.Nombre == "Drako");
        Assert.NotNull(Drako);

        
        var newAlbumes = new Albumes()
        {
            Nombre=  "Bad",
            Lanzamiento= new DateTime(2022),
            Banda= Drako,
            Reproduccion = 1,
            Canciones = new List<Canciones>()
        };
        Ado.AltaAlbum(newAlbumes);
        Assert.NotEqual(0, newAlbumes.id_album);
    }
}  
