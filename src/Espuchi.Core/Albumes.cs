using Microsoft.VisualBasic;

namespace Espuchi.Core;

public class Albumes
{
    public int id_album {get; set;}
    public required string Nombre {get;set;}
    public DateTime Lanzamiento {get; set;}
    public required Banda Banda{get; set;}
    public int Reproduccion {get; set;}
    public required List<Canciones> Canciones {get; set;}
}
