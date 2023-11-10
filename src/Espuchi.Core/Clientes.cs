namespace Espuchi.Core;

public class Clientes
{
    public int id_cliente {get; set;}
    public required string Nombre {get; set;}
    public required string Apellido {get; set;}
    public required string email {get; set;}
    public required string contrasena {get;set;}
    public required List<Reproducciones> Reproducciones {get; set;}
}
