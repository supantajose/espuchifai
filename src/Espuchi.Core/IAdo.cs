namespace Espuchi.Core;

public interface IAdo
{
<<<<<<< HEAD
    public void AltaBanda(Banda banda);
    public List<Banda> ObtenerBandas();



    public void AltaAlbum(Albumes albumes);
    public List<Albumes> ObtenerAlbumes();
    


    public void AltaCancion(Canciones canciones);
    public List<Canciones> ObtenerCanciones();
    

    public void AltaCliente(Clientes cliente);
    public List<Clientes> ObtenerClientes();
}
=======
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
>>>>>>> cb9f4e842ea928d8e63d0f1654b712303df07738
