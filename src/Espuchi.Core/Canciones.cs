namespace Espuchi.Core;

public class Canciones
{
    public int idcancion {get; set;}
    public string Nombre {get; set;}
    public int numero {get; set;}
    public int id_album {get; set;}
    public int Reproduccion {get;set;}
    public List<Reproducciones> Reproducciones {get; set;}
}
