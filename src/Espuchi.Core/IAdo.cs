namespace Espuchi.Core;

public interface IAdo
{
    void AltaBanda(Banda banda);
    List<Banda> ObtenerBandas();
    Banda? ObtenerBanda(int id_banda);


    void AltaAlbum(Albumes albumes);
    List<Albumes> ObtenerAlbumes();
    Albumes? ObtenerAlbumes(int id_album);


    void AltaCancion(Canciones canciones);
    List<Canciones> ObtenerCanciones();
    Canciones? ObtenerCanciones(int idcancion);
}
