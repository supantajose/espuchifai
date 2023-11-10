using System.IO.Pipes;

namespace Espuchi.Core;

public interface IAdo
{
    void altaBanda (Banda banda);
    List<Banda> ObtenerBandas();
    void altaNombre(nombre nombre);
    List<Nombre> ObtenerNombre();
    void altaAnio (Anio anio);
    List<Banda> ObtenerAnio();
    void altaBanda(Banda banda, string pass);
    Banda? ObtenerBanda(string nombre, ushort anio);

}
