using System.IO.Pipes;

namespace Espuchi.Core;

public interface IAdo
{
    void altaBandas (Banda banda);
    List<Banda> ObtenerBandas();
    Banda? ObtenerBanda(int id_banda);


    void altaAlbumes (Albumes albumes);
    List<Albumes> ObtenerAlbumes();
    Albumes? ObtenerAlbumes(int id_album);


    void altaCanciones (Canciones canciones);
    List<Canciones> ObtenerCanciones();
    Canciones? ObtenerCanciones(int idcancion); 
}
