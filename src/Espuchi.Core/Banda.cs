namespace Espuchi.Core;
public class Banda
{
    public int id_banda {get; set; }
    public required string Nombre {get; set;} 
    public ushort anio {get; set;}
    public required List<Albumes> Albumes {get; set;}
    
}