using System.IO.Pipes;

namespace Espuchi.Core;

public interface IAdo
{
    void altaBanda (Banda banda);
    List<Banda> ObtenerBandas();
    Banda? ObtenerBanda(string nombre, ushort anio);

}
