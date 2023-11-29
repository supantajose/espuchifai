namespace Espuchi.Core;
public class Banda
{
    public int id_banda {get; set; }
    public required string Nombre {get; set;} 
    public DateTime anio {get; set;}
    public List<Albumes> Albumes {get; set;}
        = new List<Albumes>();
    
}