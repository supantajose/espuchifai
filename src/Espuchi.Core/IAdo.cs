using System.IO.Pipes;

namespace Espuchi.Core;

public interface IAdo
{
    void altaBandas (Banda banda);
    List<Banda> ObtenerBandas();
    Banda? ObtenerBanda(int id_banda, string nombre, ushort anio);


    void altaAlbumes (Albumes albumes);
    List<Albumes> ObtenerAlbumes();
    Albumes? ObtenerAlbumes(int id_album, string nombre, DateTime lanzamiento, int id_banda,int Reproduccion);


    void altaCanciones (Canciones canciones);
    List<Canciones> ObtenerCanciones();
    Canciones? ObtenerCanciones(int idcancion, string nombre, int numero, int id_album, int Reproduccion); 
}
