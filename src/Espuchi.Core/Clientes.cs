namespace Espuchi.Core;

public class Clientes
{
    public int id_cliente {get; set;}
    public required string Nombre {get; set;}
    public required string Apellido {get; set;}
    public string email {get; set;}
    public string contrasena {get;set;}
    public List<Reproducciones> Reproducciones {get; set;}
}
