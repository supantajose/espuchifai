namespace Espuchi.Core;

public class Canciones
{
    public int idcancion {get; set;}
    public required string Nombre {get; set;}
    public int numero {get; set;}
    public required Albumes Albumes {get; set;}
    public int Reproduccion {get;set;}
    public required List<Reproducciones> Reproducciones {get; set;}
}


