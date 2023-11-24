namespace Espuchi.Core;

public interface IAdo
{
    public void AltaBanda(Banda banda);
    public List<Banda> ObtenerBandas();



    public void AltaAlbum(Albumes albumes);
    public List<Albumes> ObtenerAlbumes();
    


    public void AltaCancion(Canciones canciones);
    public List<Canciones> ObtenerCanciones();
    

    public void AltaCliente(Clientes cliente);
    public List<Clientes> ObtenerClientes();
}