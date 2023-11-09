namespace Espuchi.Core;
public class Banda
{
    public int id_banda {get; set; }
    public string Nombre {get; set;} 
    public ushort anio {get; set;}
    public List<Albumes> Albumes {get; set;}
}

